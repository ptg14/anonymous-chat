using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
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
    public partial class AFriend : UserControl
    {
        private static FirestoreDb db = FireBase.dataBase;
        public Main main;
        public int friendUID;
        public bool online;

        public AFriend(int UID, string username)
        {
            InitializeComponent();

            LB_name.Text = username;
            LB_UID.Text = UID.ToString();
            friendUID = UID;
            if (UID == 142)
            {
                PB_avatar.Image = Properties.Resources.Simsimi70x70;
            }
            else if (UID == 999)
            {
                PB_avatar.Image = Properties.Resources.random70x70;
            }
            else if (UID < 10000)
            {
                PB_avatar.Image = Properties.Resources.user70x70;
            }
            else
            {
                PB_avatar.Image = Properties.Resources.friend70x70;
            }
            isOnline();
        }

        private async void isOnline()
        {
            if (friendUID < 10000 && friendUID != 142)
            {
                DocumentSnapshot snapshot = await db.Collection("Online").Document(LB_UID.Text).GetSnapshotAsync();
                online = snapshot.Exists;
                UpdateOnlineStatusUI();
            }
            else if (friendUID == 999)
            {
                online = false;
                UpdateOnlineStatusUI();
            }
        }

        private void UpdateOnlineStatusUI()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { UpdateOnlineStatusUI(); });
            }
            else
            {
                if (online)
                {
                    LB_online.ForeColor = Color.Lime;
                    LB_online.Text = "Online";
                }
                else
                {
                    LB_online.ForeColor = Color.Red;
                    LB_online.Text = "Offline";
                }
            }
        }

        public void changeOnlineStatus(bool status)
        {
            online = status;
            UpdateOnlineStatusUI();
        }

        public void hasMessage()
        {
            PB_noti.Image = Properties.Resources.exclamation34x30;
        }

        private void mainFriend_Click(object sender, EventArgs e)
        {
            main.openChat(friendUID);
            PB_noti.Image = null;
        }

        private void PB_avatar_Click(object sender, EventArgs e)
        {
            main.openChat(friendUID);
            PB_noti.Image = null;
        }

        private void LB_name_Click(object sender, EventArgs e)
        {
            main.openChat(friendUID);
            PB_noti.Image = null;
        }

        private void PB_noti_Click(object sender, EventArgs e)
        {
            main.openChat(friendUID);
            PB_noti.Image = null;
        }
    }
}
