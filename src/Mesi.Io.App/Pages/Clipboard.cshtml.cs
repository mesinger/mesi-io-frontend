using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mesi.Io.Application.Contract.Clipboard;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.App.Pages
{
    public class ClipboardModel : PageModel
    {
        private readonly IGetClipboardEntriesForUser _getClipboardEntriesForUser;
        private readonly ILogger<ClipboardModel> _logger;

        public ClipboardModel(IGetClipboardEntriesForUser getClipboardEntriesForUser, ILogger<ClipboardModel> logger)
        {
            _getClipboardEntriesForUser = getClipboardEntriesForUser;
            _logger = logger;
        }
        
        public List<ClipboardEntry> Entries { get; private set; }
        
        public async Task<IActionResult> OnGet()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                _logger.LogError("Unable to obtain valid access token but execute secured endpoint 'Clipboard'.");
                return BadRequest();
            }
            
            Entries = (await _getClipboardEntriesForUser.GetEntries(new(accessToken))).Entries.ToList();

            return Page();
        }
        
        [BindProperty] public string NewEntry { get; set; }

        public void OnPost()
        {
            
        }
    }
}