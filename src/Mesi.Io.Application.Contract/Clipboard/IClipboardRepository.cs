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
        /// <param name="user"></param>
        /// <returns></returns>
        Task<IEnumerable<ClipboardEntry>> FindByUser(ClipboardUser user);

        /// <summary>
        /// Saves a given <see cref="ClipboardContent"/> for a given <see cref="ClipboardUser"/>
        /// </summary>
        /// <param name="content"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Save(ClipboardContent content, ClipboardUser user);
    }
}