using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopRpg.Framework.Authentication.Services;

namespace TabletopRpgApp.Controllers
{
    [Route("v1/authentication")]
    public class AuthenticationController
    {
        private ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate(string username, string password)
        {
            return _tokenService.Generate(new ClaimsIdentity(new Claim[]
            {
                new("username", username),
            }));
        }
    }
}