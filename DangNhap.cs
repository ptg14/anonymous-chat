using anonymous_chat.Redis;
using StackExchange.Redis;
using ServiceStack.Redis;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceStack;
using Newtonsoft.Json;

namespace anonymous_chat
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private static DataBase dataBase = new DataBase();
        private static IDatabase redis = dataBase.GetDatabase();
        private long UID;
        private string UserName;
        private string? email;
        private string? password;

        public static bool ShowAndTryGetInput(out long UID, out string userName, IWin32Window? owner = null)
        {
            DangNhap dangNhap = new DangNhap();
            if (dangNhap.ShowDialog(owner) == DialogResult.OK)
            {
                UID = dangNhap.UID;
                userName = dangNhap.UserName;
                return true;
            }
            else
            {
                UID = -1;
                userName = "";
                return false;
            }
        }

        private void TB_signIn_Click(object sender, EventArgs e)
        {
            if (TB_email.Text == "" || TB_password.Text == "")
            {
                LB_noti.Text = "Vui lòng nhập đủ thông tin";
                DialogResult = DialogResult.Cancel;
            }
            // Get user IDs
            string userID = redis.StringGet(TB_email.Text);

            if (userID.IsNullOrEmpty())
            {
                LB_noti.Text = "Email không tồn tại";
            }

            // Get the user data associated with the UID
            string jsonData = redis.StringGet(userID);
            UserData user = JsonConvert.DeserializeObject<UserData>(jsonData);

            // Check the password
            if (user.Password == TB_password.Text)
            {
                UID = long.Parse(userID);
                UserName = user.UserName;
                DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                LB_noti.Text = "Sai mật khẩu";
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void TB_signUp_Click(object sender, EventArgs e)
        {
            if (DangKy.ShowAndTryGetInput(out email, out password, this))
            {
                LB_noti.Text = "Đăng ký thành công";
                TB_email.Text = email;
                TB_password.Text = password;
            }
            else
            {
                // nothing
            }
        }
    }
}
