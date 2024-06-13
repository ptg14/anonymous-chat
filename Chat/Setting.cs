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
        public Main main;

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
    }
}
