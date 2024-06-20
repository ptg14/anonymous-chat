using anonymous_chat.Chat;
using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace anonymous_chat
{
    public partial class Group : Form
    {
        public Main? main;
        private GroupChat? groupChat;
        private static FirestoreDb db = FireBase.dataBase;
        private int groupUID;
        private List<int> groupInviteUID = new List<int>();
        private List<int> groupBanUID = new List<int>();

        public Group()
        {
            InitializeComponent();

            if (!FireBase.setEnironmentVariables())
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Không thể kết nối đến cơ sở dữ liệu";
                return;
            }
        }

        private async void BT_review_Click(object sender, EventArgs e)
        {
            if (TB_Name.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập tên nhóm";
                return;
            }
            try
            {
                Random random = new Random();
                CollectionReference groupsRef = db.Collection("Group");
                bool isUnique = false;
                do
                {
                    groupUID = random.Next(10000, 20000);

                    QuerySnapshot snapshot = await groupsRef.WhereEqualTo("GroupUID", groupUID).GetSnapshotAsync();
                    isUnique = snapshot.Count == 0;
                }
                while (!isUnique);

                groupChat = new GroupChat
                {
                    GroupUID = groupUID,
                    GroupName = TB_Name.Text,
                    Password = TB_password.Text,
                    AdminUID = main.UID,
                    BanUID = groupBanUID
                };

                rTB_info.Text = "";
                rTB_info.Text += "GroupUID: " + groupUID + "\n";
                rTB_info.Text += "GroupName: " + TB_Name.Text + "\n";
                rTB_info.Text += "Password: " + TB_password.Text + "\n";
                rTB_info.Text += "AdminUID: " + main.UID + "\n";
                rTB_info.Text += "InviteUID: " + string.Join(", ", groupInviteUID) + "\n";
                rTB_info.Text += "BanUID: " + string.Join(", ", groupBanUID) + "\n";

                BT_group.Enabled = true;
            }
            catch (Exception ex)
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Lỗi: " + ex.Message;
            }
        }

        private async void BT_add_Click(object sender, EventArgs e)
        {
            if (TB_addUID.Text == "")
            {
                LB_addNoti.ForeColor = Color.Red;
                LB_addNoti.Text = "Nhập UID mời";
                return;
            }
            if (TB_addUID.Text == main.UID.ToString())
            {
                LB_addNoti.Text = "Đây là UID của bạn";
                return;
            }
            // Query the database for the UID
            DocumentSnapshot snapshot = await db.Collection("Users").Document(TB_addUID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                // The UID does not exist in the database
                LB_addNoti.Text = "UID không tồn tại";
                return;
            }

            LB_addNoti.Text = "Đã mời " + TB_addUID.Text;
            groupInviteUID.Add(int.Parse(TB_addUID.Text));
            string groupRequestMessage = $"GROUPREQUEST={main.UID}>{TB_addUID.Text}#{groupUID}&{TB_Name.Text}";
            main.Send(groupRequestMessage);
            TB_addUID.Clear();
        }

        private async void BT_ban_Click(object sender, EventArgs e)
        {
            if (TB_banUID.Text == "")
            {
                LB_banNoti.ForeColor = Color.Red;
                LB_banNoti.Text = "Nhập UID cần ban";
                return;
            }
            if (TB_addUID.Text == main.UID.ToString())
            {
                LB_addNoti.Text = "Đây là UID của bạn";
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Users").Document(TB_banUID.Text).GetSnapshotAsync();
            if (!snapshot.Exists)
            {
                // The UID does not exist in the database
                LB_addNoti.Text = "UID không tồn tại";
                return;
            }
            LB_banNoti.Text = "Đã cấm " + TB_banUID.Text;
            groupBanUID.Add(int.Parse(TB_banUID.Text));
            TB_banUID.Clear();
        }

        private async void BT_group_Click(object sender, EventArgs e)
        {
            groupChat.MemberUID = new List<int> { main.UID };
            CollectionReference groupsRef = db.Collection("Group");
            DocumentReference docRef = groupsRef.Document(groupUID.ToString());
            await docRef.SetAsync(groupChat);

            if (!string.IsNullOrEmpty(docRef.Id))
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "Tạo nhóm thành công";
                BT_add.Enabled = true;

                main.reLoadList();
            }
            else
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Tạo nhóm không thành công";
            }
        }

        private void BT_hide_Click(object sender, EventArgs e)
        {
            TB_password.PasswordChar = TB_password.PasswordChar == '*' ? '\0' : '*';
        }

        private void BT_modify_Click(object sender, EventArgs e)
        {
            groupSetting.main = main;
            taoNhom.Visible = false;
            groupSetting.Visible = true;
        }
    }
}
