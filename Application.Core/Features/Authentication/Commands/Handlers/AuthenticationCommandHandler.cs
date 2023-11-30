using Application.Core.Bases;
using Application.Core.Features.Authentication.Commands.Models;
using Application.Data.Entities.Helpers;
using Application.Data.Entities.Identity;
using Application.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler
                                               , IRequestHandler<SignInCommand, Response<JwtAuthResult>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationServices _authenticationService;

        public AuthenticationCommandHandler(UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager
            , IAuthenticationServices authenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;

        }

        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //check if gmail is exist
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest<JwtAuthResult>("Username or Password is invalid!");
            }

            //Try to signIn
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
            {
                return BadRequest<JwtAuthResult>("Username or Password is invalid!");
            }
            //Generate Token
            var result = _authenticationService.GetJWTToken(user);
            //Return Token
            return Success(result);

        }
    }
}
