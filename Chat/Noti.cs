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
        }

        private static FirestoreDb db = FireBase.dataBase;
        public bool friendRequest;
        public bool friendAccepted;
        public bool friendRejected;
        public bool Call;
        public int senderID;
        public int receiverID;
        public Main main;

        private async void BT_yes_Click(object sender, EventArgs e)
        {
            if (friendRequest)
            {
                main.Send("FRIENDACCEPTED=" + receiverID + ">" + senderID);
                Dispose();
            }
            if (friendAccepted || friendRejected)
            {
                Dispose();
            }
            else if (Call)
            {
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
        }
    }
}
