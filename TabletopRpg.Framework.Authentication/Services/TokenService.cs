using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TabletopRpg.Framework.DependencyInjection.Interfaces;

namespace TabletopRpg.Framework.Authentication.Services
{
    public class TokenService : ITokenService, ITransientDependency
    {
        private readonly byte[] _key;
        private readonly int _expirationInMinutes;
        
        public TokenService(IConfiguration configuration)
        {
            _key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]);
            _expirationInMinutes = int.Parse(configuration["Jwt:ExpirationInMinutes"]);
        }


        public string Generate(ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(_expirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}