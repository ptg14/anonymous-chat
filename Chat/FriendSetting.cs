using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace anonymous_chat.Chat
{
    public partial class FriendSetting : UserControl
    {
        private static FirestoreDb db = FireBase.dataBase;
        public Main main;
        public int friendUID;
        public bool online;

        public FriendSetting(int UID, string username)
        {
            InitializeComponent();

            LB_name.Text = username;
            LB_UID.Text = UID.ToString();
            friendUID = UID;
            isOnline();
            if (online)
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

        private async void BT_deleteFriend_Click(object sender, EventArgs e)
        {
            CollectionReference friendsRef = db.Collection("Friends");
            Query query = friendsRef.WhereEqualTo("UID", main.UID).WhereEqualTo("FriendUID", friendUID);
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                await documentSnapshot.Reference.DeleteAsync();
            }
            query = friendsRef.WhereEqualTo("UID", friendUID).WhereEqualTo("FriendUID", main.UID);
            querySnapshot = await query.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                await documentSnapshot.Reference.DeleteAsync();
            }
            main.LoadFriendList();
        }
    }
}
