﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace anonymous_chat.Chat
{
    public interface IChatModel
    {
        bool Inbound { get; set; }
        bool Read { get; set; }
        DateTime Time { get; set; }
        string? Author { get; set; }
        string Type { get; }
    }

    public class TextChatModel : IChatModel
    {
        public bool Inbound { get; set; }
        public bool Read { get; set; }
        public DateTime Time { get; set; }
        public string? Author { get; set; }
        public string Type { get; } = "text";

        public string? Body { get; set; }

    }

    public class ImageChatModel : IChatModel
    {
        public bool Inbound { get; set; }
        public bool Read { get; set; }
        public DateTime Time { get; set; }
        public string? Author { get; set; }
        public string Type { get; } = "image";
        public string? ImageName { get; set; }
        [JsonIgnore]
        public Image? Image { get; set; }
        public string? path { get; set; }
    }

    public class AttachmentChatModel : IChatModel
    {
        public bool Inbound { get; set; }
        public bool Read { get; set; }
        public DateTime Time { get; set; }
        public string? Author { get; set; }
        public string Type { get; } = "attachment";

        public byte[]? Attachment { get; set; }
        public string? path { get; set; }
        public string? Filename { get; set; }
    }

    public class SimsimiResponse
    {
        public string text { get; set; }
        public string message { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public string language { get; set; }
    }
}
