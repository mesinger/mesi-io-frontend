using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mesi.Io.Application.Contract.Clipboard;

namespace Mesi.Io.Infrastructure.Clipboard
{
    /// <inheritdoc />
    public class ClipboardRepository : IClipboardRepository
    {
        private readonly IClipboardApiClient _apiClient;

        public ClipboardRepository(IClipboardApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<ClipboardEntry>> FindByUser(ClipboardUser user)
        {
            var entries = await _apiClient.GetEntries(user.AccessToken);
            return entries.Select(entry => new ClipboardEntry(new (entry.Content), entry.CreatedAt));
        }

        /// <inheritdoc />
        public Task Save(ClipboardContent content, ClipboardUser user)
        {
            return _apiClient.AddEntry(content.Content, user.AccessToken);
        }
    }
}