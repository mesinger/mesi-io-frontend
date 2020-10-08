using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mesi.Io.App.Controllers
{
    [Route("")]
    [Authorize]
    public class AuthenticationController : Controller
    {
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
        
        [Route("logout")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}