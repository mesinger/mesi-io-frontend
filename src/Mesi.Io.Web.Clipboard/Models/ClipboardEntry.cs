using System;

namespace Mesi.Io.Web.Clipboard.Models
{
    public class ClipboardEntry
    {
        public ClipboardEntry(string content, DateTime timeStamp)
        {
            Content = content;
            TimeStamp = timeStamp;
        }

        public string Content { get; }
        public DateTime TimeStamp { get; }
    }
}