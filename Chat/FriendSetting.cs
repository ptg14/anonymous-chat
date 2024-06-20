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
            if (UID >= 10000)
            {
                BT_deleteFriend.Text = "Rời nhóm";
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

        private async void BT_deleteFriend_Click(object sender, EventArgs e)
        {
            if (friendUID < 10000)
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
            }
            else
            {
                DocumentReference groupDocRef = db.Collection("Group").Document(friendUID.ToString());
                DocumentSnapshot groupDocSnapshot = await groupDocRef.GetSnapshotAsync();
                if (groupDocSnapshot.Exists)
                {
                    GroupChat groupChat = groupDocSnapshot.ConvertTo<GroupChat>();
                    if (groupChat.MemberUID.Contains(main.UID))
                    {
                        groupChat.MemberUID.Remove(main.UID);
                        await groupDocRef.SetAsync(groupChat, SetOptions.MergeAll);
                    }
                }
            }

            main.reLoadList();
        }
    }
}
