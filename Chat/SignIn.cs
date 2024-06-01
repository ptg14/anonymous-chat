using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace anonymous_chat.Chat
{
    public partial class SignIn : UserControl
    {
        public SignUp SignUp { get; set; }

        public SignIn()
        {
            InitializeComponent();
        }

        private static FirestoreDb db = FireBase.dataBase;
        public SignIn_SignUp signIn_signUp;

        public int UID;
        public string UserName;

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return regex.IsMatch(email);
        }

        private async void BT_signIn_Click(object sender, EventArgs e)
        {

            if (TB_email.Text == "" || TB_password.Text == "")
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Vui lòng nhập đủ thông tin";
                return;
            }
            else if (!IsValidEmail(TB_email.Text))
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Email không hợp lệ";
                return;
            }

            if (!FireBase.setEnironmentVariables())
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Không thể kết nối đến cơ sở dữ liệu";
                return;
            }
            try
            {
                CollectionReference usersRef = db.Collection("Users");
                QuerySnapshot snapshot = await usersRef.WhereEqualTo("Email", TB_email.Text).GetSnapshotAsync();

                if (snapshot.Count == 0)
                {
                    // The email does not exist in the database
                    LB_noti.ForeColor = Color.Red;
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
                    if (CB_saveSignIn.Checked)
                    {
                        string json = JsonConvert.SerializeObject(user);
                        await File.WriteAllTextAsync("credentials.json", json);
                    }
                    signIn_signUp.DialogResult = DialogResult.OK;
                }
                else
                {
                    LB_noti.ForeColor = Color.Red;
                    LB_noti.Text = "Sai mật khẩu";
                }
            }
            catch (Exception ex)
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Lỗi: " + ex.Message;
            }
        }

        private void BT_signUp_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SignUp.Visible = true;
        }

        private void BT_reco_Click(object sender, EventArgs e)
        {

        }

        private void BT_hide_Click(object sender, EventArgs e)
        {
            TB_password.PasswordChar = TB_password.PasswordChar == '*' ? '\0' : '*';
        }
    }
}
