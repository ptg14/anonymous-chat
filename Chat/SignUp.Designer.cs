namespace anonymous_chat.Chat
{
    partial class SignUp
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PictureBox logo;
            LB_noti = new Label();
            label3 = new Label();
            TB_email = new TextBox();
            TB_repassword = new TextBox();
            label2 = new Label();
            TB_signIn = new Button();
            TB_password = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TB_signUp = new Button();
            label1 = new Label();
            TB_username = new TextBox();
            BT_hide2 = new Button();
            BT_hide1 = new Button();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logo.Image = Properties.Resources.logo150x150;
            logo.Location = new Point(292, 9);
            logo.Name = "logo";
            logo.Size = new Size(160, 146);
            logo.SizeMode = PictureBoxSizeMode.CenterImage;
            logo.TabIndex = 65;
            logo.TabStop = false;
            // 
            // LB_noti
            // 
            LB_noti.AutoSize = true;
            LB_noti.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_noti.ForeColor = SystemColors.ControlText;
            LB_noti.Location = new Point(201, 404);
            LB_noti.Name = "LB_noti";
            LB_noti.Size = new Size(0, 25);
            LB_noti.TabIndex = 68;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(225, 229);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 67;
            label3.Text = "Email";
            // 
            // TB_email
            // 
            TB_email.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_email.Location = new Point(292, 226);
            TB_email.Margin = new Padding(3, 4, 3, 4);
            TB_email.Name = "TB_email";
            TB_email.Size = new Size(258, 27);
            TB_email.TabIndex = 66;
            // 
            // TB_repassword
            // 
            TB_repassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_repassword.Location = new Point(292, 363);
            TB_repassword.Margin = new Padding(3, 4, 3, 4);
            TB_repassword.Name = "TB_repassword";
            TB_repassword.PasswordChar = '*';
            TB_repassword.Size = new Size(258, 27);
            TB_repassword.TabIndex = 64;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 366);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 63;
            label2.Text = "Xác nhận mật khẩu";
            // 
            // TB_signIn
            // 
            TB_signIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TB_signIn.Location = new Point(130, 443);
            TB_signIn.Margin = new Padding(3, 4, 3, 4);
            TB_signIn.Name = "TB_signIn";
            TB_signIn.Size = new Size(141, 31);
            TB_signIn.TabIndex = 62;
            TB_signIn.Text = "Trở về đăng nhập";
            TB_signIn.UseVisualStyleBackColor = true;
            TB_signIn.Click += TB_signIn_Click;
            // 
            // TB_password
            // 
            TB_password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_password.Location = new Point(292, 317);
            TB_password.Margin = new Padding(3, 4, 3, 4);
            TB_password.Name = "TB_password";
            TB_password.PasswordChar = '*';
            TB_password.Size = new Size(258, 27);
            TB_password.TabIndex = 61;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(201, 320);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 60;
            label5.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(292, 158);
            label4.Name = "label4";
            label4.Size = new Size(160, 46);
            label4.TabIndex = 59;
            label4.Text = "Đăng ký ";
            // 
            // TB_signUp
            // 
            TB_signUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TB_signUp.Location = new Point(398, 443);
            TB_signUp.Margin = new Padding(3, 4, 3, 4);
            TB_signUp.Name = "TB_signUp";
            TB_signUp.Size = new Size(152, 31);
            TB_signUp.TabIndex = 58;
            TB_signUp.Text = "Đăng ký";
            TB_signUp.UseVisualStyleBackColor = true;
            TB_signUp.Click += TB_signUp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(225, 273);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 57;
            label1.Text = "Tên";
            // 
            // TB_username
            // 
            TB_username.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_username.Location = new Point(292, 270);
            TB_username.Margin = new Padding(3, 4, 3, 4);
            TB_username.Name = "TB_username";
            TB_username.Size = new Size(258, 27);
            TB_username.TabIndex = 56;
            // 
            // BT_hide2
            // 
            BT_hide2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_hide2.Image = Properties.Resources.eye20x20;
            BT_hide2.Location = new Point(556, 363);
            BT_hide2.Name = "BT_hide2";
            BT_hide2.Size = new Size(27, 27);
            BT_hide2.TabIndex = 69;
            BT_hide2.UseVisualStyleBackColor = true;
            BT_hide2.Click += BT_hide2_Click;
            // 
            // BT_hide1
            // 
            BT_hide1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_hide1.Image = Properties.Resources.eye20x20;
            BT_hide1.Location = new Point(556, 317);
            BT_hide1.Name = "BT_hide1";
            BT_hide1.Size = new Size(27, 27);
            BT_hide1.TabIndex = 70;
            BT_hide1.UseVisualStyleBackColor = true;
            BT_hide1.Click += BT_hide1_Click;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BT_hide1);
            Controls.Add(BT_hide2);
            Controls.Add(LB_noti);
            Controls.Add(label3);
            Controls.Add(TB_email);
            Controls.Add(logo);
            Controls.Add(TB_repassword);
            Controls.Add(label2);
            Controls.Add(TB_signIn);
            Controls.Add(TB_password);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TB_signUp);
            Controls.Add(label1);
            Controls.Add(TB_username);
            Name = "SignUp";
            Size = new Size(681, 482);
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label LB_noti;
        private Label label3;
        private TextBox TB_email;
        private TextBox TB_repassword;
        private Label label2;
        private Button TB_signIn;
        private TextBox TB_password;
        private Label label5;
        private Label label4;
        private Button TB_signUp;
        private Label label1;
        private TextBox TB_username;
        private Button BT_hide2;
        private Button BT_hide1;
    }
}
