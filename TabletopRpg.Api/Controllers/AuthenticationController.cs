using System.Globalization;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using TabletopRpg.Core;
using TabletopRpg.DataAccess.Contexts;
using TabletopRpg.Framework.Authentication.Services;

namespace TabletopRpg.Api.Controllers
{
    [Route("v1/authentication")]
    [Authorize]
    public class AuthenticationController : Controller
    {
        private ITokenService _tokenService;
        private TabletopRpgDbContext _context;

        public AuthenticationController(ITokenService tokenService, TabletopRpgDbContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public ActionResult<string> Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user != null)
            {
                var token = _tokenService.Generate(new ClaimsIdentity(
                    new Claim[] {new("id", user.Id.ToString())})
                );

                return Ok(token);
            }

            return Unauthorized();
        }

        [HttpGet("check-auth")]
        public ActionResult<string> CheckAuth()
        {
            return $"{CultureInfo.CurrentCulture}";
        }
    }
}