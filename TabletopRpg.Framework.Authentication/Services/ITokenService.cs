using System.Security.Claims;

namespace TabletopRpg.Framework.Authentication.Services
{
    public interface ITokenService
    {
        string Generate(ClaimsIdentity claimsIdentity);
    }
}