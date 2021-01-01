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
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IEnumerable<ClipboardEntry>> GetEntries(ClipboardUser user);
    }
}