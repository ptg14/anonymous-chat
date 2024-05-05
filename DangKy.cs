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
using anonymous_chat.Redis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System.Net.Http;

namespace anonymous_chat
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private static DataBase dataBase = new DataBase();
        private static IDatabase redis = dataBase.GetDatabase();

        public static bool ShowAndTryGetInput(out string email, out string password, IWin32Window? owner = null)
        {
            DangKy dangKy = new DangKy();
            if (dangKy.ShowDialog(owner) == DialogResult.OK)
            {
                email = dangKy.TB_email.Text;
                password = dangKy.TB_password.Text;
                return true;
            }
            else
            {
                email = "";
                password = "";
                return false;
            }
        }

        private void TB_signUP_Click(object sender, EventArgs e)
        {
            if (TB_email.Text == "" || TB_username.Text == "" || TB_password.Text == "" || TB_repassword.Text == "")
            {
                LB_noti.Text = "Vui lòng điền đầy đủ thông tin";
                return;
            }
            if (TB_password.Text != TB_repassword.Text)
            {
                LB_noti.Text = "Mật khẩu không khớp";
                return;
            }
            try
            {
                // Store the user data in the database
                bool result = dataBase.StoreUserData(redis, TB_email.Text, TB_username.Text, TB_password.Text, LB_noti.Text);

                if (result)
                {
                    LB_noti.Text = "Đăng ký thành công";
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    LB_noti.Text = "Đăng ký không thành công";
                    return;
                }
            }
            catch (ArgumentException ex)
            {
                // Show the error message in a message box
                MessageBox.Show(ex.Message);
            }
        }

        private void TB_signIn_Click(object sender, EventArgs e)
        {
            // Close the DangKy form
            DialogResult = DialogResult.Cancel;
        }
    }
}
