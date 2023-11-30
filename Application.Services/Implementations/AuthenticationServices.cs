using Application.Data.Entities.Helpers;
using Application.Data.Entities.Identity;
using Application.Services.Abstracts;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services.Implementations
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ConcurrentDictionary<string, RefreshToken> _userRefreshToken;
        public AuthenticationServices(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _userRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
        }

        public JwtAuthResult GetJWTToken(ApplicationUser applicationUser)
        {

            var _claims = new List<Claim>()
            {
                new Claim(nameof(ApplicationUserClaimModel.Username),applicationUser.UserName),
                 new Claim(nameof(ApplicationUserClaimModel.Email),applicationUser.Email),
                  new Claim(nameof(ApplicationUserClaimModel.PhoneNumber),applicationUser.PhoneNumber),
                   new Claim(nameof(ApplicationUserClaimModel.Address),applicationUser.Address),

            };

            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer

                , audience: _jwtSettings.Audience

                , claims: _claims

                , expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate)

                , signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(_jwtSettings.Secret))
                    , SecurityAlgorithms.HmacSha256Signature)


                );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var refreshToken = new RefreshToken()
            {
                UserName = applicationUser.UserName,
                ExpireAt = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                TokenString = GenerateRefreshToken()
            };

            _userRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);


            var result = new JwtAuthResult();
            result.AccessToken = accessToken;
            result.RefreshToken = refreshToken;
            return result;

        }

        //generate a random number to refresh the token
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }
    }
}
