using anonymous_chat.Chat;
using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anonymous_chat
{
    public partial class Main : Form
    {
        private static FirestoreDb db = FireBase.dataBase;
        private int UID;
        private string userName;
        private bool addFriendVisible = false;
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Main()
        {
            InitializeComponent();

            /*
            if (DangNhap.ShowAndTryGetInput(out UID, out userName, this))
            {
                isOnline();
                LB_name.Text = userName;
                LB_UID.Text = "UID: " + UID.ToString();
            }
            else
            {
                // The user has not signed in
                Load += (s, e) => Close();
            }
            */

            if (SignIn_SignUp.ShowAndTryGetInput(out UID, out userName, this))
            {
                isOnline();
                LoadFriendList();
                LB_name.Text = userName;
                chatBox.chatbox_info.User = userName;
                LB_UID.Text = "UID: " + UID.ToString();
            }
            else
            {
                // The user has not signed in
                Load += (s, e) => Close();
            }
        }

        private async void isOnline()  // Create a new async method
        {
            // Get the user's public IP address
            string ip = await GetPublicIPAddressAsync();

            // Create a new Online object
            Online online = new Online
            {
                UID = UID,
                IP = ip,
                Searching = false
            };

            // Add the Online object to the Online collection in the Firestore database
            await db.Collection("Online").Document(UID.ToString()).SetAsync(online);
        }

        public async Task ConnectToMessageServerAsync(string ipAddress, int port)
        {
            try
            {
                await socket.ConnectAsync(new IPEndPoint(IPAddress.Parse(ipAddress), port));
                // Connection successful
            }
            catch (Exception ex)
            {
                // Handle connection errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }

        public async Task<string> GetPublicIPAddressAsync()
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync("https://api.ipify.org");
            }
        }

        private void BT_search_Click(object sender, EventArgs e)
        {
            if (addFriendVisible)
            {
                addFriendVisible = false;
                addFriend.Visible = false;
            }
            else
            {
                addFriendVisible = true;
                addFriend.Visible = true;
            }
        }

        private void LoadFriendList()
        {
            // Query the database for the user's friend list
            QuerySnapshot snapshot = db.Collection("Users").Document(UID.ToString()).Collection("Friends").GetSnapshotAsync().Result;

            // Clear the friend list
            LBox_listFriends.Items.Clear();

            // Add each friend to the friend list
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                UserData friend = document.ConvertTo<UserData>();
                LBox_listFriends.Items.Add(friend.UserName);
            }
        }

        private async void BT_findFriend_Click(object sender, EventArgs e)
        {
            if (TB_friendUID.Text == "")
            {
                TB_findResult.Text = "Nhập UID của bạn bè";
                return;
            }
            if (TB_friendUID.Text == UID.ToString())
            {
                TB_findResult.Text = "Đây là UID của bạn";
                return;
            }

            // Query the database for the UID
            DocumentSnapshot snapshot = await db.Collection("Users").Document(TB_friendUID.Text).GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                // The UID does not exist in the database
                TB_findResult.Text = "UID không tồn tại";
                return;
            }

            // The UID exists in the database
            // Get the user data
            UserData user = snapshot.ConvertTo<UserData>();

            // Display the user's name
            TB_findResult.Text = user.UserName;
        }


        private void BT_addFriend_Click(object sender, EventArgs e)
        {
            if (TB_friendUID.Text == "")
            {
                TB_findResult.Text = "Nhập UID của bạn bè";
                return;
            }
            else if (TB_friendUID.Text == UID.ToString())
            {
                TB_findResult.Text = "Đây là UID của bạn";
                return;
            }
            // send to server
        }

        private void BT_refresh_Click(object sender, EventArgs e)
        {
            LoadFriendList();
        }
    }
}
