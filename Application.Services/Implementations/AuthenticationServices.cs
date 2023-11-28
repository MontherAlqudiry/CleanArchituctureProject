using Application.Data.Entities.Helpers;
using Application.Data.Entities.Identity;
using Application.Services.Abstracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Implementations
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly JwtSettings _jwtSettings;
        public AuthenticationServices(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;

        }

        public Task<string> GetJWTToken(ApplicationUser applicationUser)
        {

            var _claims = new List<Claim>()
            {
                new Claim(nameof(ApplicationUserClaimModel.Username),applicationUser.UserName),
                 new Claim(nameof(ApplicationUserClaimModel.Email),applicationUser.Email),
                  new Claim(nameof(ApplicationUserClaimModel.PhoneNumber),applicationUser.PhoneNumber),
                   new Claim(nameof(ApplicationUserClaimModel.Address),applicationUser.Address)
            };

            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer

                , audience: _jwtSettings.Audience

                , claims: _claims

                , expires: DateTime.UtcNow.AddMinutes(2)

                , signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(_jwtSettings.Issuer))
                    , SecurityAlgorithms.HmacSha256Signature)

                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Task.FromResult(accessToken);
        }
    }
}
