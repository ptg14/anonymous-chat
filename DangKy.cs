using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;
using System.Net.Http;
using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using System.Text.RegularExpressions;

namespace anonymous_chat
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private static FirestoreDb db = FireBase.dataBase;

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

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
            return regex.IsMatch(email);
        }

        private async void TB_signUP_Click(object sender, EventArgs e)
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
