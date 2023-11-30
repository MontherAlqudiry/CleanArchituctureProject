using Application.Data.Entities.Helpers;
using Application.Data.Entities.Identity;

namespace Application.Services.Abstracts
{
    public interface IAuthenticationServices
    {
        public JwtAuthResult GetJWTToken(ApplicationUser applicationUser);
    }
}
