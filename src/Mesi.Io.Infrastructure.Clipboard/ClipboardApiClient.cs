using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
        public async Task<IEnumerable<ClipboardEntryDto>> GetEntries(string accessToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await _httpClient.GetStringAsync("/clipboard/getAll");

                var entries = JsonSerializer.Deserialize<IEnumerable<ClipboardEntryDto>>(response);
                return entries;
            }
            catch (JsonException e)
            {
                _logger.LogWarning("Received invalid json data from clipboard api, while trying to get all clipboard entries for a user.", e);
                return Enumerable.Empty<ClipboardEntryDto>();
            }
            catch (HttpRequestException e)
            {
                _logger.LogWarning("A http request error occured, while trying to get all clipboard entries for a user.", e);
                return Enumerable.Empty<ClipboardEntryDto>();
            }
        }

        /// <inheritdoc />
        public async Task AddEntry(string content, string accessToken)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await _httpClient.PostAsync("/clipboard",
                    new StringContent(JsonSerializer.Serialize(new ClipboardAddEntryRequest(content)), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning($"Unable to add new clipboard entry for user. The clipboard api responded with a '{response.StatusCode}' status code.");
                }
            }
            catch (HttpRequestException e)
            {
                _logger.LogWarning("A http request error occured, while trying to add a new clipboard entry for a user.", e);
            }
        }
    }
}