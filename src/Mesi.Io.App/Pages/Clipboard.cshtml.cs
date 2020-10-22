using System;
using System.Collections.Generic;
using Mesi.Io.Web.Clipboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mesi.Io.App.Pages
{
    public class Clipboard : PageModel
    { 
        public List<ClipboardEntry> Entries { get; private set; }
        
        public void OnGet()
        {
           Entries = new List<ClipboardEntry>()
           {
               new ClipboardEntry("entry1", DateTime.Now),
               new ClipboardEntry("entry2", DateTime.Now),
               new ClipboardEntry("entry3", DateTime.Now),
           };
        }
        
        [BindProperty] public string NewEntry { get; set; }

        public void OnPost()
        {
            
        }
    }
}