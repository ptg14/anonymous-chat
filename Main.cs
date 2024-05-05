﻿using System;
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
        public Main()
        {
            InitializeComponent();

            if (DangNhap.ShowAndTryGetInput(this))
            {
                // The user has successfully signed in
                // Do something
            }
            else
            {
                // The user has not signed in
                Load += (s, e) => Close();
            }
        }
    }
}
