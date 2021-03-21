using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TabletopRpgApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly byte[] _key;
        private readonly int _expirationInMinutes;
        
        public TokenService(IConfiguration configuration)
        {
            _key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]);
            _expirationInMinutes = int.Parse(configuration["Jwt:ExpirationInMinutes"]);
        }


        public string Generate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_expirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}