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

namespace anonymous_chat.Chat
{
    public partial class GroupSetting : UserControl
    {
        private GroupChat group;
        private static FirestoreDb db = FireBase.dataBase;
        public Group groupPanel { get; set; }
        public Main? main;

        public GroupSetting()
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
            if (TB_groupUID.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập UID nhóm";
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                panel1.Enabled = false;
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Group").Document(TB_groupUID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                // The UID does not exist in the database
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "UID nhóm không tồn tại";
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                panel1.Enabled = false;
                return;
            }

            group = snapshot.ConvertTo<GroupChat>();

            if (group.AdminUID != main.UID)
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Bạn không phải là admin của nhóm này";
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                panel1.Enabled = false;
                return;
            }

            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            panel1.Enabled = true;

            LB_log.Text = "";
            TB_groupName.Text = group.GroupName;
            rTB_description.Text = group.Description;
            TB_password.Text = group.Password;
            TB_admin.Text = group.AdminUID.ToString();
            rTB_list.Text = "Members: " + string.Join(", ", group.MemberUID) + "\n";
            rTB_list.Text += "Ban: " + string.Join(", ", group.BanUID) + "\n";

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

        private async void BT_rename_Click(object sender, EventArgs e)
        {
            if (TB_groupName.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập tên nhóm";
                return;
            }

            if (group.GroupName == TB_groupName.Text)
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "Tên nhóm không thay đổi";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(group.GroupUID.ToString());
            await groupDocRef.UpdateAsync("GroupName", TB_groupName.Text);

            group.GroupName = TB_groupName.Text;
            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đổi tên nhóm thành công";
        }

        private async void BT_description_Click(object sender, EventArgs e)
        {
            if (group.Description == rTB_description.Text)
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "Mô tả không thay đổi";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(group.GroupUID.ToString());
            await groupDocRef.UpdateAsync("Description", rTB_description.Text);

            group.Description = rTB_description.Text;
            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đổi mô tả thành công";
        }

        private async void BT_kick_Click(object sender, EventArgs e)
        {
            if (TB_kickbanUID.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập UID người dùng cần đuổi khỏi nhóm";
                return;
            }

            if (!group.MemberUID.Contains(int.Parse(TB_kickbanUID.Text)))
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Người dùng không phải là thành viên của nhóm";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(group.GroupUID.ToString());
            await groupDocRef.UpdateAsync("MemberUID", FieldValue.ArrayRemove(int.Parse(TB_kickbanUID.Text)));

            group.MemberUID.Remove(int.Parse(TB_kickbanUID.Text));
            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đã đuổi " + TB_kickbanUID.Text + " khỏi nhóm";
        }

        private async void BT_ban_Click(object sender, EventArgs e)
        {
            if (TB_kickbanUID.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập UID người dùng cần cấm tham gia nhóm";
                return;
            }

            if (group.BanUID.Contains(int.Parse(TB_kickbanUID.Text)))
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "Người dùng đã bị cấm tham gia nhóm";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(group.GroupUID.ToString());
            await groupDocRef.UpdateAsync("BanUID", FieldValue.ArrayUnion(int.Parse(TB_kickbanUID.Text)));

            if (group.MemberUID.Contains(int.Parse(TB_kickbanUID.Text)))
            {
                await groupDocRef.UpdateAsync("MemberUID", FieldValue.ArrayRemove(int.Parse(TB_kickbanUID.Text)));
                group.MemberUID.Remove(int.Parse(TB_kickbanUID.Text));
            }

            group.BanUID.Add(int.Parse(TB_kickbanUID.Text));
            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đã cấm " + TB_kickbanUID.Text + " tham gia nhóm";
        }

        private void BT_hide_Click(object sender, EventArgs e)
        {
            TB_password.PasswordChar = TB_password.PasswordChar == '\0' ? '*' : '\0';
        }

        private async void BT_password_Click(object sender, EventArgs e)
        {
            if (TB_password.Text == group.Password)
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "Mật khẩu không thay đổi";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(group.GroupUID.ToString());
            await groupDocRef.UpdateAsync("Password", TB_password.Text);

            group.Password = TB_password.Text;
            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đổi mật khẩu thành công";
        }

        private async void BT_admin_Click(object sender, EventArgs e)
        {
            if (TB_admin.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập UID trưởng nhóm cần đổi";
                return;
            }

            if (group.AdminUID == int.Parse(TB_admin.Text))
            {
                LB_log.ForeColor = Color.Green;
                LB_log.Text = "UID trưởng nhóm không thay đổi";
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Users").Document(TB_admin.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "UID không tồn tại";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(group.GroupUID.ToString());
            await groupDocRef.UpdateAsync("AdminUID", int.Parse(TB_admin.Text));

            group.AdminUID = int.Parse(TB_admin.Text);
            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đổi trưởng nhóm thành công";
        }

        private void BT_avatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, main.UID.ToString());
                    folderPath = Path.Combine(folderPath, group.GroupUID.ToString());
                    string fileName = $"SETAVATAR~{group.GroupUID}.png";
                    string filePath = Path.Combine(folderPath, fileName);

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    main.ResizeImage(openFileDialog.FileName, filePath, 50, 50);

                    using (var ms = new MemoryStream(File.ReadAllBytes(filePath)))
                    {
                        PB_avatar.Image = Image.FromStream(ms);
                    }

                    main.SendFile(filePath);
                }
            }
        }

        private void BT_group_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            groupPanel.taoNhom.Visible = true;
        }
    }
}
