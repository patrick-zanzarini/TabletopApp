using System.Security.Claims;
using TabletopRpg.Framework.DependencyInjection.Interfaces;

namespace TabletopRpg.Framework.Authentication.Services
{
    public interface ITokenService
    {
        string Generate(ClaimsIdentity claimsIdentity);
    }
}