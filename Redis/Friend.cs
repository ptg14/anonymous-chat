using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_chat.Redis
{
    public class Friend
    {
        public long UID { get; set; }
        public long FriendUID { get; set; }
        public bool isFriend { get; set; }
    }
}
