using System.Threading.Tasks;
using Mesi.Io.Application.Contract.Clipboard;

namespace Mesi.Io.Application.Clipboard
{
    /// <summary>
    /// Implements application layer use cases for entities of type <see cref="ClipboardEntry"/>
    /// </summary>
    public class ClipboardApplicationService : IGetClipboardEntriesForUser
    {
        private readonly IClipboardRepository _clipboardRepository;

        public ClipboardApplicationService(IClipboardRepository clipboardRepository)
        {
            _clipboardRepository = clipboardRepository;
        }
        
        /// <inheritdoc />
        public async Task<GetClipboardEntriesForUserResponse> GetEntries(GetClipboardEntriesForUserRequest request)
        {
            return new(await _clipboardRepository.FindByUser(request.AccessToken));
        }
    }
}