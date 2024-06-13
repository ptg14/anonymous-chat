using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
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
                if (user.Password == TB_password.Text || user.ResetToken == TB_password.Text)
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

        private async void BT_reco_Click(object sender, EventArgs e)
        {
            // Generate a token
            string token = GenerateToken();
            if (!FireBase.setEnironmentVariables())
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Không thể kết nối đến cơ sở dữ liệu";
                return;
            }
            // Store the token in Firestore
            // Create a reference to the Users collection
            CollectionReference usersRef = db.Collection("Users");

            // Create a query that filters documents by the Email field
            Query query = usersRef.WhereEqualTo("Email", TB_email.Text);

            // Execute the query
            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            if (querySnapshot.Count > 0)
            {
                await querySnapshot.Documents[0].Reference.UpdateAsync("ResetToken", token);
            }
            else
            {
                LB_noti.ForeColor = Color.Red;
                LB_noti.Text = "Email chưa được đăng ký";
            }

            // Send the token to the user's email
            SendToken(TB_email.Text, token);

            // Show a message to the user
            LB_noti.ForeColor = Color.Green;
            LB_noti.Text = "Dùng token thay cho mật khẩu của bạn";

        }

        private string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }

        private void SendToken(string email, string token)
        {
            var fromAddress = new MailAddress("auto@chat.test", "chat");
            var toAddress = new MailAddress(email);
            const string fromPassword = "@Thang140204";
            const string subject = "Password Reset Token";
            string body = $"Your password reset token is: {token}";

            var smtp = new SmtpClient
            {
                Host = "localhost",
                Port = 1000,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private void BT_hide_Click(object sender, EventArgs e)
        {
            TB_password.PasswordChar = TB_password.PasswordChar == '*' ? '\0' : '*';
        }
    }
}
