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

namespace anonymous_chat
{
    public partial class JoinGroup : Form
    {
        public Main? main;
        private static FirestoreDb db = FireBase.dataBase;
        private GroupChat group;

        public JoinGroup()
        {
            InitializeComponent();

            if (!FireBase.setEnironmentVariables())
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Không thể kết nối đến cơ sở dữ liệu";
                return;
            }
        }

        private async void BT_find_Click(object sender, EventArgs e)
        {
            if (TB_UID.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập UID nhóm";
                BT_add.Enabled = false;
                BT_join.Enabled = false;
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Group").Document(TB_UID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "UID nhóm không tồn tại";
                BT_add.Enabled = false;
                BT_join.Enabled = false;
                return;
            }

            group = snapshot.ConvertTo<GroupChat>();
            BT_add.Enabled = true;
            BT_join.Enabled = true;

            rTB_info.Clear();
            rTB_info.Text += "UID nhóm: " + group.GroupUID + "\n";
            rTB_info.Text += "Tên nhóm: " + group.GroupName + "\n";
            rTB_info.Text += "Mô tả: " + group.Description + "\n";
            rTB_info.Text += "Cấm UID: " + string.Join(", ", group.BanUID) + "\n";

            string fileName = $"SETAVATAR~{group.GroupUID}.png";
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, main.UID.ToString());
            folderPath = Path.Combine(folderPath, group.GroupUID.ToString());
            string filePath = Path.Combine(folderPath, fileName);
            if (File.Exists(filePath))
            {
                using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                {
                    PB_avatar.Image = Image.FromStream(ms);
                }
            }
        }

        private async void BT_add_Click(object sender, EventArgs e)
        {
            if (TB_addUID.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập UID người muốn mời";
                return;
            }
            if (TB_addUID.Text == main.UID.ToString())
            {
                LB_log.Text = "Đây là UID của bạn";
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Users").Document(TB_addUID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                LB_log.Text = "UID không tồn tại";
                return;
            }

            // Check if the user is already in the group
            if (group.MemberUID != null && group.MemberUID.Contains(int.Parse(TB_addUID.Text)))
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "Người này đã là thành viên của nhóm";
                return;
            }

            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đã mời " + TB_addUID.Text;
            string groupRequestMessage = $"GROUPREQUEST={main.UID}>{TB_addUID.Text}#{group.GroupUID}&{group.GroupName}";
            main.Send(groupRequestMessage);
            TB_addUID.Clear();
        }

        private async void BT_join_Click(object sender, EventArgs e)
        {
            // Check if the main.UID is in the BanUID list
            if (group.BanUID != null && group.BanUID.Contains(main.UID))
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Bạn đã bị cấm tham gia nhóm này";
                return;
            }

            if (group.MemberUID.Contains(main.UID))
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "Bạn đã là thành viên của nhóm";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(group.GroupUID.ToString());
            await groupDocRef.UpdateAsync("MemberUID", FieldValue.ArrayUnion(main.UID));

            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đã tham gia nhóm";

            main.reLoadList();
        }

        private void BT_hide_Click(object sender, EventArgs e)
        {
            TB_password.PasswordChar = TB_password.PasswordChar == '\0' ? '*' : '\0';
        }
    }
}
