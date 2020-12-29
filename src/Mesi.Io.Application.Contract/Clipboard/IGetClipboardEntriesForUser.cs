using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mesi.Io.Application.Contract.Clipboard
{
    /// <summary>
    /// Returns the clipboard entries for a given user
    /// </summary>
    public interface IGetClipboardEntriesForUser
    {
        /// <summary>
        /// Returns the clipboard entries for a given user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetClipboardEntriesForUserResponse> GetEntries(GetClipboardEntriesForUserRequest request);
    }

    public record GetClipboardEntriesForUserRequest(string AccessToken);

    public record GetClipboardEntriesForUserResponse(IEnumerable<ClipboardEntry> Entries);
}