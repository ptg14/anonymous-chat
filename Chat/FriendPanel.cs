using anonymous_chat.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anonymous_chat.Chat
{
    public partial class FriendPanel : UserControl
    {
        public Main main;
        public Dictionary<int, AFriend> friendList = new Dictionary<int, AFriend>();

        public FriendPanel()
        {
            InitializeComponent();
        }

        public void addFriend(int UID, string username)
        {
            AFriend newFriend = new AFriend(UID, username);
            newFriend.main = main;
            newFriend.Dock = DockStyle.Top;
            Controls.Add(newFriend);
            newFriend.BringToFront();
            if (UID == 142 || UID == 999)
            {
                ScrollControlIntoView(newFriend);
            }
            friendList.Add(UID, newFriend);
        }
    }

}
