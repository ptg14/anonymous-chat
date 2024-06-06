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
            isOnline();
            if (online || friendUID == 142)
            {
                LB_online.ForeColor = Color.Green;
                LB_online.Text = "Online";
            }
            else
            {
                LB_online.ForeColor = Color.Red;
                LB_online.Text = "Offline";
            }
        }

        private async void isOnline()
        {
            DocumentSnapshot snapshot = await db.Collection("Online").Document(LB_UID.Text).GetSnapshotAsync();
            online = snapshot.Exists;
        }

        private void mainFriend_Click(object sender, EventArgs e)
        {
            main.openChat(friendUID);
        }

        private void PB_avatar_Click(object sender, EventArgs e)
        {
            main.openChat(friendUID);
        }
    }
}
