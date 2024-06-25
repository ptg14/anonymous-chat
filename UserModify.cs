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
    public partial class UserModify : Form
    {
        public Main? main;
        private static FirestoreDb db = FireBase.dataBase;

        public UserModify()
        {
            InitializeComponent();
        }

        private void BT_hide1_Click(object sender, EventArgs e)
        {
            TB_password.PasswordChar = TB_password.PasswordChar == '\0' ? '*' : '\0';
        }

        private void BT_hide2_Click(object sender, EventArgs e)
        {
            TB_repassword.PasswordChar = TB_repassword.PasswordChar == '\0' ? '*' : '\0';
        }

        private async void BT_change_Click(object sender, EventArgs e)
        {
            if (TB_username.Text == "" && TB_password.Text == "" && TB_repassword.Text == "")
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Nhập thông tin muốn thay đổi";
                return;
            }

            if (TB_password.Text != TB_repassword.Text)
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Mật khẩu không khớp!";
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Users").Document(main.UID.ToString()).GetSnapshotAsync();
            if (snapshot.Exists)
            {
                UserData user = snapshot.ConvertTo<UserData>();

                if (TB_username.Text != "")
                {
                    await db.Collection("Users").Document(main.UID.ToString()).UpdateAsync("Username", TB_username.Text);
                    main.LB_name.Text = TB_username.Text;
                }

                if (TB_password.Text != "" && TB_password.Text == TB_repassword.Text)
                {
                    await db.Collection("Users").Document(main.UID.ToString()).UpdateAsync("Password", TB_password.Text);
                }

                LB_noti.ForeColor = Color.Green;
                LB_noti.Text = "Thay đổi thành công!";
            }
        }
    }
}
