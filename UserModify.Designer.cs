namespace anonymous_chat
{
    partial class UserModify
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
            BT_hide1 = new Button();
            BT_hide2 = new Button();
            TB_repassword = new TextBox();
            label2 = new Label();
            TB_password = new TextBox();
            label5 = new Label();
            label1 = new Label();
            TB_username = new TextBox();
            BT_change = new Button();
            LB_noti = new Label();
            SuspendLayout();
            // 
            // BT_hide1
            // 
            BT_hide1.Image = Properties.Resources.eye20x20;
            BT_hide1.Location = new Point(445, 70);
            BT_hide1.Name = "BT_hide1";
            BT_hide1.Size = new Size(27, 27);
            BT_hide1.TabIndex = 78;
            BT_hide1.UseVisualStyleBackColor = true;
            BT_hide1.Click += BT_hide1_Click;
            // 
            // BT_hide2
            // 
            BT_hide2.Image = Properties.Resources.eye20x20;
            BT_hide2.Location = new Point(445, 116);
            BT_hide2.Name = "BT_hide2";
            BT_hide2.Size = new Size(27, 27);
            BT_hide2.TabIndex = 77;
            BT_hide2.UseVisualStyleBackColor = true;
            BT_hide2.Click += BT_hide2_Click;
            // 
            // TB_repassword
            // 
            TB_repassword.Location = new Point(167, 116);
            TB_repassword.Margin = new Padding(3, 4, 3, 4);
            TB_repassword.Name = "TB_repassword";
            TB_repassword.PasswordChar = '*';
            TB_repassword.Size = new Size(272, 27);
            TB_repassword.TabIndex = 76;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 119);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 75;
            label2.Text = "Xác nhận mật khẩu";
            // 
            // TB_password
            // 
            TB_password.Location = new Point(167, 70);
            TB_password.Margin = new Padding(3, 4, 3, 4);
            TB_password.Name = "TB_password";
            TB_password.PasswordChar = '*';
            TB_password.Size = new Size(272, 27);
            TB_password.TabIndex = 74;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 73);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 73;
            label5.Text = "Mật khẩu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 26);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 72;
            label1.Text = "Tên";
            // 
            // TB_username
            // 
            TB_username.Location = new Point(167, 23);
            TB_username.Margin = new Padding(3, 4, 3, 4);
            TB_username.Name = "TB_username";
            TB_username.Size = new Size(272, 27);
            TB_username.TabIndex = 71;
            // 
            // BT_change
            // 
            BT_change.Location = new Point(12, 160);
            BT_change.Name = "BT_change";
            BT_change.Size = new Size(94, 29);
            BT_change.TabIndex = 79;
            BT_change.Text = "Thay đổi";
            BT_change.UseVisualStyleBackColor = true;
            BT_change.Click += BT_change_Click;
            // 
            // LB_noti
            // 
            LB_noti.AutoSize = true;
            LB_noti.Location = new Point(112, 164);
            LB_noti.Name = "LB_noti";
            LB_noti.Size = new Size(0, 20);
            LB_noti.TabIndex = 80;
            // 
            // UserModify
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 201);
            Controls.Add(LB_noti);
            Controls.Add(BT_change);
            Controls.Add(BT_hide1);
            Controls.Add(BT_hide2);
            Controls.Add(TB_repassword);
            Controls.Add(label2);
            Controls.Add(TB_password);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(TB_username);
            Name = "UserModify";
            Text = "Anonymous Chat";
            Icon = new Icon("resource\\icon.ico");
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BT_hide1;
        private Button BT_hide2;
        private TextBox TB_repassword;
        private Label label2;
        private TextBox TB_password;
        private Label label5;
        private Label label1;
        private TextBox TB_username;
        private Button BT_change;
        private Label LB_noti;
    }
}