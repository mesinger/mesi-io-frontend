using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mesi.Io.Infrastructure.Clipboard
{
    /// <summary>
    /// Access to the microservice clipboard api at api.mesi.io/clipboard
    /// </summary>
    public interface IClipboardApiClient
    {
        /// <summary>
        /// Returns clipboard entries 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ClipboardEntryDto>> GetEntries(string accessToken);

        /// <summary>
        /// Adds a new clipboard entry
        /// </summary>
        /// <param name="content"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task AddEntry(string content, string accessToken);
    }
    
    public record ClipboardEntryDto([property:JsonPropertyName("content")] string Content, [property:JsonPropertyName("createdAt")] DateTime CreatedAt);
    internal record ClipboardAddEntryRequest([property:JsonPropertyName("content")] string Content);
}