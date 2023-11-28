using Application.Data.Entities.Identity;

namespace Application.Services.Abstracts
{
    public interface IAuthenticationServices
    {
        public Task<string> GetJWTToken(ApplicationUser applicationUser);
    }
}
