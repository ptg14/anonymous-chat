using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_chat.Redis
{
    internal class Online
    {
        public long UID { get; set; }
        public string? IP { get; set; }
        public bool Searching { get; set; }
    }
}
