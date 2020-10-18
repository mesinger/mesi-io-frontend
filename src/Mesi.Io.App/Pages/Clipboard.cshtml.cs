using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mesi.Io.App.Pages
{
    public class Clipboard : PageModel
    {
        [BindProperty]
        public List<string> Entries { get; private set; }
        
        public void OnGet()
        {
           Entries = new List<string>()
           {
               "entry1",
               "entry2",
               "entry3",
           };
        }
        
        [BindProperty] public string NewEntry { get; set; }

        public void OnPost()
        {
            
        }
    }
}