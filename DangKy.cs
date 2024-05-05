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

        public static bool ShowAndTryGetInput(IWin32Window? owner = null)
        {
            DangKy dangKy = new DangKy();
            if (dangKy.ShowDialog(owner) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetPublicIPAddressAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync("https://api.ipify.org");
            }
        }

        private void TB_signUP_Click(object sender, EventArgs e)
        {
            if (TB_password.Text != TB_repassword.Text)
            {
                LB_noti.Text = "Mật khẩu không khớp";
                DialogResult = DialogResult.Cancel;
                return;
            }
            try
            {
                DataBase dataBase = new DataBase();
                // Store the user data in the database
                bool result = dataBase.StoreUserData(dataBase.GetDatabase(), TB_email.Text, TB_username.Text, TB_password.Text);

                if (result)
                {
                    LB_noti.Text = "Đăng ký thành công";
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    LB_noti.Text = "Đăng ký không thành công";
                    DialogResult = DialogResult.Cancel;
                }
            }
            catch (ArgumentException ex)
            {
                // Show the error message in a message box
                MessageBox.Show(ex.Message);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void TB_signIn_Click(object sender, EventArgs e)
        {
            // Close the DangKy form
            this.Close();
        }
    }
}
