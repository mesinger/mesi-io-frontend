using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mesi.Io.App.Pages
{
    public class Clipboard : PageModel
    {
        public IEnumerable<(string, string)> Claims { get; set; }
        public void OnGet()
        {
            Claims = from claim in User.Claims select (claim.Type, claim.Value);
        }
    }
}