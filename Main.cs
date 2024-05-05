using anonymous_chat.Redis;
using Newtonsoft.Json;
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

namespace anonymous_chat
{
    public partial class Main : Form
    {
        private static DataBase dataBase = new DataBase();
        private static IDatabase redis = dataBase.GetDatabase();
        private long UID;
        private string userName;
        private bool addFriendVisible = false;

        public Main()
        {
            InitializeComponent();

            if (DangNhap.ShowAndTryGetInput(out UID, out userName, this))
            {
                dataBase.AddOnlineUser(redis, UID, GetPublicIPAddressAsync().Result, false);
                LB_name.Text = userName;
                LB_UID.Text = "UID: " + UID.ToString();
            }
            else
            {
                // The user has not signed in
                Load += (s, e) => Close();
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

        private void BT_findFriend_Click(object sender, EventArgs e)
        {
            if (TB_friendUID.Text == "")
            {
                TB_findResult.Text = "Nhập UID của bạn bè";
                return;
            }

            string jsonData = redis.StringGet(TB_friendUID.Text);

            if (string.IsNullOrEmpty(jsonData))
            {
                TB_findResult.Text = "Không tìm thấy " + TB_friendUID.Text;
                return;
            }

            UserData user = JsonConvert.DeserializeObject<UserData>(jsonData);

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

            dataBase.sendFriendRequest(redis, UID, long.Parse(TB_friendUID.Text));
        }

    }
}
