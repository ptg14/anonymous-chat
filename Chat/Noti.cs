using anonymous_chat.DataBase;
using Chat_Server.DataBase;
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
    public partial class Noti : UserControl
    {
        private static FirestoreDb db = FireBase.dataBase;
        public bool friendRequest;
        public bool friendAccepted;
        public bool friendRejected;
        public bool groupRequest;
        public bool Call;
        public int senderID;
        public int receiverID;
        public int groupID;
        public Main main;

        public Noti(int UID, string receivedMessage)
        {
            InitializeComponent();

            string[] parts = receivedMessage.Split('=');
            if (parts[0] == "FRIENDREQUEST")
            {
                string[] ids = parts[1].Split(">");
                senderID = int.Parse(ids[0]);
                receiverID = int.Parse(ids[1]);
                if (receiverID == UID)
                {
                    friendRequest = true;
                    LB_title.Text = senderID + " muốn kết bạn với bạn";
                }
            }
            else if (parts[0] == "FRIENDACCEPTED")
            {
                string[] ids = parts[1].Split(">");
                senderID = int.Parse(ids[0]);
                receiverID = int.Parse(ids[1]);
                if (receiverID == UID)
                {
                    friendAccepted = true;
                    LB_title.Text = senderID + " đã chấp nhận lời mời kết bạn của bạn";
                }
                BT_no.Visible = false;
            }
            else if (parts[0] == "FRIENDREJECTED")
            {
                string[] ids = parts[1].Split(">");
                senderID = int.Parse(ids[0]);
                receiverID = int.Parse(ids[1]);
                if (receiverID == UID)
                {
                    friendRejected = true;
                    LB_title.Text = senderID + " đã từ chối lời mời kết bạn của bạn";
                }
                BT_no.Visible = false;
            }
            else if (parts[0] == "GROUPREQUEST")
            {
                string[] nua = parts[1].Split("#");
                string[] dau = nua[0].Split(">");
                string[] cuoi = nua[1].Split("&");
                senderID = int.Parse(dau[0]);
                receiverID = int.Parse(dau[1]);
                groupID = int.Parse(cuoi[0]);
                string groupName = cuoi[1];
                if (receiverID == UID)
                {
                    groupRequest = true;
                    LB_title.Text = senderID + " mời bạn tham gia nhóm " + groupName;
                }
            }
        }

        private async void BT_yes_Click(object sender, EventArgs e)
        {
            if (friendRequest)
            {
                main.Send("FRIENDACCEPTED=" + receiverID + ">" + senderID);
                Dispose();
            }
            else if (friendAccepted)
            {
                main.reLoadList();
                Dispose();
            }
            else if (friendRejected)
            {
                Dispose();
            }
            else if (groupRequest)
            {
                DocumentSnapshot snapshot = await db.Collection("Group").Document(groupID.ToString()).GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    MessageBox.Show("Nhóm không tồn tại");
                    Dispose();
                }

                GroupChat group = snapshot.ConvertTo<GroupChat>();

                // Check if the main.UID is in the BanUID list
                if (group.BanUID != null && group.BanUID.Contains(main.UID))
                {
                    MessageBox.Show("Bạn đã bị cấm tham gia nhóm này", "BAN");
                    Dispose();
                }

                DocumentReference groupDocRef = db.Collection("Group").Document(groupID.ToString());
                await groupDocRef.UpdateAsync("MemberUID", FieldValue.ArrayUnion(receiverID));
                Dispose();
            }
            else if (Call)
            {
            }
            else
            {
                Dispose();
            }
        }

        private void BT_no_Click(object sender, EventArgs e)
        {
            if (friendRequest)
            {
                main.Send("FRIENDREJECTED=" + receiverID + ">" + senderID);
                Dispose();
            }
            else if (Call)
            {
            }
            else
            {
                Dispose();
            }
        }
    }
}
