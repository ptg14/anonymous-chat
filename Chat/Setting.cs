using anonymous_chat.DataBase;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anonymous_chat.Chat
{
    public partial class Setting : UserControl
    {
        public Main? main;
        private static FirestoreDb db = FireBase.dataBase;

        public Setting()
        {
            InitializeComponent();
        }

        private void BT_group_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            group.main = main;
            group.Show();
        }

        private void BT_findGroup_Click(object sender, EventArgs e)
        {
            JoinGroup join = new JoinGroup();
            join.main = main;
            join.Show();
        }

        private async void BT_report_Click(object sender, EventArgs e)
        {
            int UIDreport = main.toUID;
            if (!FireBase.setEnironmentVariables())
            {
                return;
            }

            DocumentSnapshot snapshot = await db.Collection("Users").Document(UIDreport.ToString()).GetSnapshotAsync();
            if (snapshot.Exists)
            {
                UserData user = snapshot.ConvertTo<UserData>();
                if (!user.ReportCount.Contains(main.UID))
                {
                    await db.Collection("Users").Document(UIDreport.ToString()).UpdateAsync("ReportCount", FieldValue.ArrayUnion(main.UID));
                    if (user.ReportCount.Count >= 5)
                    {
                        await db.Collection("Users").Document(UIDreport.ToString()).UpdateAsync("isBanned", true);
                    }
                }
            }
        }
    }
}
