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
    public partial class FriendListPanel : UserControl
    {
        public Main main;

        public FriendListPanel()
        {
            InitializeComponent();
        }

        public void addFriend(int UID, string username)
        {
            FriendSetting newFriend = new FriendSetting(UID, username);
            newFriend.main = main;
            newFriend.Dock = DockStyle.Top;
            Controls.Add(newFriend);
            newFriend.BringToFront();
        }
    }
}
