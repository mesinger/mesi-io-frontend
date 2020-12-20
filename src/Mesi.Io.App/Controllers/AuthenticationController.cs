using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mesi.Io.App.Controllers
{
    [Route("")]
    public class AuthenticationController : Controller
    {
        [Route("login")]
        [HttpGet]
        [Authorize]
        public IActionResult Login()
        {
            return RedirectToPage("/Index");
        }
        
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [HttpGet]
        [Route("logout-redirect")]
        public IActionResult LogoutRedirect()
        {
            return RedirectToPage("/Index");
        }
    }
}