using Application.Core.Features.ApplicationUserCore.Commands.Models;
using Application.Core.Resources;
using Application.Data.Entities.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Application.Core.Features.ApplicationUserCore.Commands.Handlers
{
    public class ApplicationUserCommandHandler : IRequestHandler<AddApplicationUserCommand, string>
                                                , IRequestHandler<EditApplicationUserCommand, string>
                                                , IRequestHandler<DeleteApplicationUserCommand, string>
                                                , IRequestHandler<ChangePasswordApplicationUserCommand, string>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer
                                            , IMapper mapper
                                            , UserManager<ApplicationUser> userManager)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<string> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {

            var userEmailExist = await _userManager.FindByEmailAsync(request.Email);

            if (userEmailExist != null)
            {
                return "User is already exist! ";
            }


            //double check (optional)
            var userNameExist = await _userManager.FindByNameAsync(request.UserName);

            if (userNameExist != null)
            {
                return "User is already exist! ";
            }

            //mapping between requst and the applicationUser
            var userMapping = _mapper.Map<ApplicationUser>(request);

            //create the result user from mapping
            var userResult = await _userManager.CreateAsync(userMapping, request.Password);
            if (!userResult.Succeeded)
            {
                return userResult.Errors.FirstOrDefault().Description;
            }
            else
                return "Created Successfully!";
        }

        public async Task<string> Handle(EditApplicationUserCommand request, CancellationToken cancellationToken)
        {
            //check the id if exist
            var checkApplicationUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (checkApplicationUser == null)
            {
                return "No User with the given Id!";
            }
            //mapping
            var ApplicationUserMapping = _mapper.Map(request, checkApplicationUser);
            //update 
            var ApplicationUserResult = await _userManager.UpdateAsync(ApplicationUserMapping);
            if (ApplicationUserResult.Succeeded)
            {
                return "Application User updated successfully!";

            }
            else
            {
                return ApplicationUserResult.Errors.FirstOrDefault().Description;
            }
        }

        public async Task<string> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
        {
            //check the id if exist
            var ApplicationUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (ApplicationUser == null)
            {
                return "Bad Request!";
            }
            //no need to mapp take the result of checking the id and delete it
            var ApplicationUserResult = await _userManager.DeleteAsync(ApplicationUser);
            if (ApplicationUserResult.Succeeded)
            {
                return "Application User deleted successfuly!";
            }
            else
            {
                return ApplicationUserResult.Errors.FirstOrDefault().Description;

            }
        }

        public async Task<string> Handle(ChangePasswordApplicationUserCommand request, CancellationToken cancellationToken)
        {
            //Check the user if exist then find user by id
            var ApplicationUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (ApplicationUser == null) { return "Bad Request!"; }

            //cahnge Password using cahngePasswordAsync()
            var result = await _userManager.ChangePasswordAsync(ApplicationUser, request.CurrentPassword, request.NewPassword);
            //no need for mapping because the userById result is an applicationUser which is the type that must send
            if (!result.Succeeded)
            {
                return result.Errors.FirstOrDefault().Description;
            }
            else
            {
                return "Password Changed Successfully!";
            }
        }
    }
}
