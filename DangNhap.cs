using anonymous_chat.Redis;
using StackExchange.Redis;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        public static bool ShowAndTryGetInput(IWin32Window? owner = null)
        {
            DangNhap dangNhap = new DangNhap();
            if (dangNhap.ShowDialog(owner) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void TB_signIn_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            if (TB_email.Text == "" || TB_password.Text == "")
            {
                LB_noti.Text = "Vui lòng nhập đủ thông tin";
                DialogResult = DialogResult.Cancel;
            }
            // Check if the email exists
            if (dataBase.GetDatabase().KeyExists(TB_email.Text))
            {
                // The email exists, now check the password
                string? correctPassword = dataBase.GetDatabase().StringGet(TB_email.Text); // Assuming the password is stored under the email key

                if (correctPassword != null && TB_password.Text == correctPassword)
                {
                    // Login successful
                    DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    // Login failed
                    LB_noti.Text = "Sai mật khẩu";
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
            else
            {
                // The email does not exist
                LB_noti.Text = "Email không tồn tại";
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void TB_signUp_Click(object sender, EventArgs e)
        {
            if (DangKy.ShowAndTryGetInput(this))
            {

            }
            else
            {

            }
        }
    }
}
