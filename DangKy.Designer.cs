namespace anonymous_chat
{
    partial class DangKy
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PictureBox logo;
            TB_signIn = new Button();
            TB_password = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TB_signUp = new Button();
            label1 = new Label();
            TB_username = new TextBox();
            TB_repassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            TB_email = new TextBox();
            LB_noti = new Label();
            logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            logo.Image = Properties.Resources.logo150x150;
            logo.Location = new Point(287, 9);
            logo.Name = "logo";
            logo.Size = new Size(160, 146);
            logo.SizeMode = PictureBoxSizeMode.CenterImage;
            logo.TabIndex = 28;
            logo.TabStop = false;
            // 
            // TB_signIn
            // 
            TB_signIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TB_signIn.Location = new Point(125, 462);
            TB_signIn.Margin = new Padding(3, 4, 3, 4);
            TB_signIn.Name = "TB_signIn";
            TB_signIn.Size = new Size(141, 31);
            TB_signIn.TabIndex = 25;
            TB_signIn.Text = "Trở về đăng nhập";
            TB_signIn.UseVisualStyleBackColor = true;
            TB_signIn.Click += TB_signIn_Click;
            // 
            // TB_password
            // 
            TB_password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_password.Location = new Point(287, 320);
            TB_password.Margin = new Padding(3, 4, 3, 4);
            TB_password.Name = "TB_password";
            TB_password.Size = new Size(258, 27);
            TB_password.TabIndex = 24;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(196, 323);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 21;
            label5.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(287, 158);
            label4.Name = "label4";
            label4.Size = new Size(160, 46);
            label4.TabIndex = 20;
            label4.Text = "Đăng ký ";
            // 
            // TB_signUp
            // 
            TB_signUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TB_signUp.Location = new Point(393, 462);
            TB_signUp.Margin = new Padding(3, 4, 3, 4);
            TB_signUp.Name = "TB_signUp";
            TB_signUp.Size = new Size(152, 31);
            TB_signUp.TabIndex = 19;
            TB_signUp.Text = "Đăng ký";
            TB_signUp.UseVisualStyleBackColor = true;
            TB_signUp.Click += TB_signUP_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(220, 276);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 16;
            label1.Text = "Tên";
            // 
            // TB_username
            // 
            TB_username.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_username.Location = new Point(287, 273);
            TB_username.Margin = new Padding(3, 4, 3, 4);
            TB_username.Name = "TB_username";
            TB_username.Size = new Size(258, 27);
            TB_username.TabIndex = 13;
            // 
            // TB_repassword
            // 
            TB_repassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_repassword.Location = new Point(287, 366);
            TB_repassword.Margin = new Padding(3, 4, 3, 4);
            TB_repassword.Name = "TB_repassword";
            TB_repassword.Size = new Size(258, 27);
            TB_repassword.TabIndex = 27;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(132, 369);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 26;
            label2.Text = "Xác nhận mật khẩu";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(220, 232);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 30;
            label3.Text = "Email";
            // 
            // TB_email
            // 
            TB_email.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_email.Location = new Point(287, 229);
            TB_email.Margin = new Padding(3, 4, 3, 4);
            TB_email.Name = "TB_email";
            TB_email.Size = new Size(258, 27);
            TB_email.TabIndex = 29;
            // 
            // LB_noti
            // 
            LB_noti.AutoSize = true;
            LB_noti.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_noti.Location = new Point(196, 418);
            LB_noti.Name = "LB_noti";
            LB_noti.Size = new Size(0, 25);
            LB_noti.TabIndex = 42;
            // 
            // DangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 506);
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
            Name = "DangKy";
            Text = "Anonymous Chat";
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TB_signIn;
        private TextBox TB_password;
        private Label label5;
        private Label label4;
        private Button TB_signUp;
        private Label label1;
        private TextBox TB_username;
        private TextBox TB_repassword;
        private Label label2;
        private Label label3;
        private TextBox TB_email;
        private Label LB_noti;
    }
}