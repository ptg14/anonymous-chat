using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using anonymous_chat.DataBase;
using Google.Cloud.Firestore;

namespace anonymous_chat
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private static FirestoreDb db = FireBase.dataBase;
        private int UID;
        private string UserName;
        private string? email;
        private string? password;

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return regex.IsMatch(email);
        }

        public static bool ShowAndTryGetInput(out int UID, out string userName, IWin32Window? owner = null)
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

        private async void TB_signIn_Click(object sender, EventArgs e)
        {
            if (TB_email.Text == "" || TB_password.Text == "")
            {
                LB_noti.Text = "Vui lòng nhập đủ thông tin";
                return;
            }
            else if (!IsValidEmail(TB_email.Text))
            {
                LB_noti.Text = "Email không hợp lệ";
                return;
            }

            if (!FireBase.setEnironmentVariables())
            {
                LB_noti.Text = "Không thể kết nối đến cơ sở dữ liệu";
                return;
            }
            CollectionReference usersRef = db.Collection("Users");
            QuerySnapshot snapshot = await usersRef.WhereEqualTo("Email", TB_email.Text).GetSnapshotAsync();

            if (snapshot.Count == 0)
            {
                // The email does not exist in the database
                LB_noti.Text = "Email không tồn tại";
                return;
            }

            // The email exists in the database
            // Get the user data
            DocumentSnapshot userDocument = snapshot.Documents[0];
            UserData user = userDocument.ConvertTo<UserData>();

            // Check the password
            if (user.Password == TB_password.Text)
            {
                UID = user.UID;
                UserName = user.UserName;
                DialogResult = DialogResult.OK;
            }
            else
            {
                LB_noti.Text = "Sai mật khẩu";
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
        }
    }
}
