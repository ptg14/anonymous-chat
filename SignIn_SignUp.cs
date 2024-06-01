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
    public partial class SignIn_SignUp : Form
    {
        public SignIn_SignUp()
        {
            InitializeComponent();

            dangKy.SignIn = dangNhap;
            dangNhap.SignUp = dangKy;
            dangNhap.signIn_signUp = this;
        }

        public static bool ShowAndTryGetInput(out int UID, out string userName, IWin32Window? owner = null)
        {
            SignIn_SignUp signIn_signUp = new SignIn_SignUp();
            if (signIn_signUp.ShowDialog(owner) == DialogResult.OK)
            {
                UID = dangNhap.UID;
                userName = dangNhap.UserName;
                return true;
            }
            else
            {
                UID = -1;
                userName = "";
                return false;
            }
        }
    }
}
