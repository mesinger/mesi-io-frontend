using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mesi.Io.Application.Contract.Clipboard
{
    /// <summary>
    /// Access to <see cref="ClipboardEntry"/>s
    /// </summary>
    public interface IClipboardRepository
    {
        /// <summary>
        /// Finds all <see cref="ClipboardEntry"/> for a given user
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ClipboardEntry>> FindByUser(string accessToken);
    }
}