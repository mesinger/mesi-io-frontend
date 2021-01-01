using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Application.Contract.Clipboard;

namespace Mesi.Io.Application.Clipboard
{
    /// <summary>
    /// Implements application layer use cases for entities of type <see cref="ClipboardEntry"/>
    /// </summary>
    public class ClipboardApplicationService : IGetClipboardEntriesForUser, IAddClipboardEntryForUser
    {
        private readonly IClipboardRepository _clipboardRepository;

        public ClipboardApplicationService(IClipboardRepository clipboardRepository)
        {
            _clipboardRepository = clipboardRepository;
        }

        /// <inheritdoc />
        public Task<IEnumerable<ClipboardEntry>> GetEntries(ClipboardUser user)
        {
            return _clipboardRepository.FindByUser(user);
        }

        /// <inheritdoc />
        public Task AddEntry(ClipboardContent content, ClipboardUser user)
        {
            return _clipboardRepository.Save(content, user);
        }
    }
}