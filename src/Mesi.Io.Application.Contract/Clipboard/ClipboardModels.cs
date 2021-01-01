using System;

namespace Mesi.Io.Application.Contract.Clipboard
{
    public record ClipboardEntry(ClipboardContent Content, DateTime TimeStamp);

    public record ClipboardContent(string Content);
    
    public record ClipboardUser(string AccessToken);
}