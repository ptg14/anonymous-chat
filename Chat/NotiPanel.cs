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
    public partial class NotiPanel : UserControl
    {
        public NotiPanel()
        {
            InitializeComponent();
        }

        public Main main;

        public void addNoti(string receivedMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(addNoti), receivedMessage);
            }
            else
            {
                Noti newNoti = new Noti(main.UID, receivedMessage);
                newNoti.main = main;
                newNoti.Dock = DockStyle.Top;
                Controls.Add(newNoti);
                newNoti.BringToFront();
                ScrollControlIntoView(newNoti);
            }
        }
    }
}
