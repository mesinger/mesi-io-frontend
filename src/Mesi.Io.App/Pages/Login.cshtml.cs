using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mesi.Io.App.Pages
{
    public class Login : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("https://identity.mesi.io");
        }
    }
}