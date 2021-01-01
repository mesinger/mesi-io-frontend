using System.Threading.Tasks;

namespace Mesi.Io.Application.Contract.Clipboard
{
    /// <summary>
    /// Adds a new <see cref="ClipboardEntry"/> for a given <see cref="ClipboardUser"/>
    /// </summary>
    public interface IAddClipboardEntryForUser
    {
        /// <summary>
        /// Adds a new <see cref="ClipboardEntry"/> for a given <see cref="ClipboardUser"/>
        /// </summary>
        /// <param name="content"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddEntry(ClipboardContent content, ClipboardUser user);
    }
}