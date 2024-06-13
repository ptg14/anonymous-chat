﻿using anonymous_chat.DataBase;
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
        GroupChat group;

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
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Group").Document(TB_UID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                // The UID does not exist in the database
                LB_log.Text = "UID nhóm không tồn tại";
                return;
            }

            group = snapshot.ConvertTo<GroupChat>();

            rTB_info.Text = "";
            rTB_info.Text += "GroupUID: " + group.GroupUID + "\n";
            rTB_info.Text += "GroupName: " + group.GroupName + "\n";
            rTB_info.Text += "BanUID: " + string.Join(", ", group.BanUID) + "\n";
        }

        private async void BT_add_Click(object sender, EventArgs e)
        {
            if (TB_UID.Text == "")
            {
                LB_addNoti.ForeColor = Color.Red;
                LB_addNoti.Text = "Nhập UID nhóm";
                return;
            }
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
            string groupRequestMessage = $"GROUPREQUEST={main.UID}>{TB_addUID.Text}#{group.GroupUID}&{group.GroupName}";
            main.Send(groupRequestMessage);
            TB_addUID.Clear();
        }

        private async void BT_join_Click(object sender, EventArgs e)
        {
            if (TB_UID.Text == "")
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Nhập UID nhóm";
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Group").Document(TB_UID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                // The UID does not exist in the database
                LB_log.Text = "UID nhóm không tồn tại";
                return;
            }

            group = snapshot.ConvertTo<GroupChat>();

            // Check if the main.UID is in the BanUID list
            if (group.BanUID != null && group.BanUID.Contains(main.UID))
            {
                LB_log.ForeColor = Color.Red;
                LB_log.Text = "Bạn đã bị cấm tham gia nhóm này";
                return;
            }

            DocumentReference groupDocRef = db.Collection("Group").Document(TB_UID.Text);
            await groupDocRef.UpdateAsync("MemberUID", FieldValue.ArrayUnion(main.UID));

            LB_log.ForeColor = Color.Green;
            LB_log.Text = "Đã tham gia nhóm";
            main.LoadList();
        }

        private void BT_hide_Click(object sender, EventArgs e)
        {
            TB_password.PasswordChar = TB_password.PasswordChar == '\0' ? '*' : '\0';
        }
    }
}
