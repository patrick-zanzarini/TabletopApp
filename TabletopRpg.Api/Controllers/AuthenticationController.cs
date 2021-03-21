using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopRpgApp.Services;

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
            return _tokenService.Generate(new User
            {
                Name = username
            });
        }
    }
}