using System.Collections.Generic;
using System.Threading.Tasks;
using Mesi.Io.Web.Clipboard.Models;

namespace Mesi.Io.Web.Clipboard.Clients
{
    public interface IClipboardApiClient
    {
        public Task<IEnumerable<ClipboardEntry>> FindAllByUser(string accessToken);
    }
}