using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_chat.DataBase
{
    [FirestoreData]
    public class Group
    {
        [FirestoreProperty]
        public int GroupUID { get; set; }
        [FirestoreProperty]
        public Array MemberUID { get; set; }
    }
}
