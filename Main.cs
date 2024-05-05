using anonymous_chat.Redis;
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

        public Main()
        {
            InitializeComponent();

            if (DangNhap.ShowAndTryGetInput(out UID, this))
            {
                dataBase.AddOnlineUser(redis, UID, GetPublicIPAddressAsync().Result, false);
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
    }
}
