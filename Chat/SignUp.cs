using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
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

namespace anonymous_chat.Chat
{
    public partial class SignUp : UserControl
    {
        public SignIn SignIn { get; set; }

        public SignUp()
        {
            InitializeComponent();
        }

        private static FirestoreDb db = FireBase.dataBase;
        public string Email;
        public string Password;

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return regex.IsMatch(email);
        }

        private async void TB_signUp_Click(object sender, EventArgs e)
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
            if (IsValidEmail(TB_email.Text) == false)
            {
                LB_noti.Text = "Email không hợp lệ";
                return;
            }
            if (!FireBase.setEnironmentVariables())
            {
                LB_noti.Text = "Không thể kết nối đến cơ sở dữ liệu";
                return;
            }
            try
            {
                // Generate a unique random 4-digit number
                Random random = new Random();
                int uid;
                bool isUnique;
                CollectionReference usersRef = db.Collection("Users");

                do
                {
                    uid = random.Next(1000, 10000);  // Generates a random number between 1000 and 9999

                    QuerySnapshot snapshot = await usersRef.WhereEqualTo("UID", uid).GetSnapshotAsync();
                    isUnique = snapshot.Count == 0;
                }
                while (!isUnique);

                // Store the user data in the database
                UserData userData = new UserData
                {
                    UID = uid,
                    Email = TB_email.Text,
                    UserName = TB_username.Text,
                    Password = TB_password.Text
                };

                // Create a DocumentReference with the UID as the document ID
                DocumentReference docRef = usersRef.Document(uid.ToString());

                // Set the userData in the document
                await docRef.SetAsync(userData);

                // If the document was set successfully, docRef.Id will not be null
                if (!string.IsNullOrEmpty(docRef.Id))
                {
                    LB_noti.Text = "Đăng ký thành công";
                    Email = TB_email.Text;
                    Password = TB_password.Text;
                    SignIn.TB_email.Text = Email;
                    SignIn.TB_password.Text = Password;
                }
                else
                {
                    LB_noti.Text = "Đăng ký không thành công";
                    return;
                }
            }
            catch (ArgumentException ex)
            {
                LB_noti.Text = "Lỗi: " + ex.Message;
            }
        }

        private void TB_signIn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SignIn.Visible = true;
        }
    }
}
