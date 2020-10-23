using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mesi.Io.Web.Clipboard.Models;

namespace Mesi.Io.Web.Clipboard.Clients
{
    public class ClipboardApiClient : IClipboardApiClient
    {
        private readonly HttpClient _httpClient;

        public ClipboardApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        /// <inheritdoc />
        public Task<IEnumerable<ClipboardEntry>> FindAllByUser(string accessToken)
        {
            throw new System.NotImplementedException();
        }
    }
}