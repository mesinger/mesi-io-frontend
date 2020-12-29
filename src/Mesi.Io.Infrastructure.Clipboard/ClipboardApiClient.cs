using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Mesi.Io.Infrastructure.Clipboard
{
    /// <inheritdoc />
    public class ClipboardApiClient : IClipboardApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClipboardApiClient> _logger;

        public ClipboardApiClient(HttpClient httpClient, ILogger<ClipboardApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<ClipboardEntryDto>> GetEntriesWithAccessToken(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetStringAsync("/clipboard/getAll");

            try
            {
                var entries = JsonSerializer.Deserialize<IEnumerable<ClipboardEntryDto>>(response);
                return entries;
            }
            catch (JsonException e)
            {
                _logger.LogWarning("Unable to parse response from clipboard api. Invalid json data.", e);
                return Enumerable.Empty<ClipboardEntryDto>();
            }
        }
    }
}