using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopRpg.Framework.Authentication.Services;
using TabletopRpg.Framework.DependencyInjection.Interfaces;

namespace TabletopRpgApp.Controllers
{
    [Route("v1/authentication")]
    [Authorize]
    public class AuthenticationController
    {
        private ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate(string username, string password)
        {
            return _tokenService.Generate(new ClaimsIdentity(new Claim[]
            {
                new("username", username),
            }));
        }
        
        [HttpGet("check-auth")]
        public ActionResult<dynamic> CheckAuth()
        {
            return "Welcome";
        }
    }
}