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
        public async Task<IEnumerable<ClipboardEntry>> FindByUser(string accessToken)
        {
            var entries = await _apiClient.GetEntriesWithAccessToken(accessToken);
            return entries.Select(entry => new ClipboardEntry(entry.Content, entry.CreatedAt));
        }
    }
}