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

        public async Task<string> GetPublicIPAddressAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync("https://api.ipify.org");
            }
        }

        private async void TB_signUP_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            try
            {
                // Get the public IP address of the user
                string ipAddress = await GetPublicIPAddressAsync();
                // Store the user data in the database
                bool result = dataBase.StoreUserData(dataBase.GetDatabase(), TB_email.Text, TB_username.Text, TB_password.Text, ipAddress);

                if (result)
                {
                    MessageBox.Show("SignUp successfully");
                }
                else
                {
                    MessageBox.Show("Failed to SignUp");
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
            // Create an instance of the DangNhap form
            DangNhap dangNhap = new DangNhap();

            // Show the DangNhap form
            dangNhap.Show();

            // Close the DangKy form
            this.Close();
        }
    }
}
