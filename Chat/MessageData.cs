using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_chat.Chat
{
    public class MessageData
    {
        public string? User { get; set; }
        public string? NamePlaceholder { get; set; }
        public string? PhonePlaceholder { get; set; }
        public string? StatusPlaceholder { get; set; }
        public string ChatPlaceholder = "Please enter a message...";
        public byte[]? Attachment { get; set; }
        public string? AttachmentName { get; set; }
        public string? AttachmentType { get; set; }
    }
}
