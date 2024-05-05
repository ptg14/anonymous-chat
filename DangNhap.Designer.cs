namespace anonymous_chat
{
    partial class DangNhap
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
            PictureBox pictureBox1;
            TB_signUp = new Button();
            TB_password = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TB_signIn = new Button();
            label1 = new Label();
            TB_email = new TextBox();
            label2 = new Label();
            button1 = new Button();
            LB_noti = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.logo150x150;
            pictureBox1.Location = new Point(287, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 38;
            pictureBox1.TabStop = false;
            // 
            // TB_signUp
            // 
            TB_signUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TB_signUp.Location = new Point(125, 399);
            TB_signUp.Margin = new Padding(3, 4, 3, 4);
            TB_signUp.Name = "TB_signUp";
            TB_signUp.Size = new Size(141, 44);
            TB_signUp.TabIndex = 35;
            TB_signUp.Text = "Đăng ký";
            TB_signUp.UseVisualStyleBackColor = true;
            TB_signUp.Click += TB_signUp_Click;
            // 
            // TB_password
            // 
            TB_password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_password.Location = new Point(287, 293);
            TB_password.Margin = new Padding(3, 4, 3, 4);
            TB_password.Name = "TB_password";
            TB_password.PasswordChar = '*';
            TB_password.Size = new Size(258, 27);
            TB_password.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(196, 296);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 33;
            label5.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(287, 177);
            label4.Name = "label4";
            label4.Size = new Size(194, 46);
            label4.TabIndex = 32;
            label4.Text = "Đăng nhập";
            // 
            // TB_signIn
            // 
            TB_signIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TB_signIn.Location = new Point(393, 399);
            TB_signIn.Margin = new Padding(3, 4, 3, 4);
            TB_signIn.Name = "TB_signIn";
            TB_signIn.Size = new Size(152, 44);
            TB_signIn.TabIndex = 31;
            TB_signIn.Text = "Đăng nhập";
            TB_signIn.UseVisualStyleBackColor = true;
            TB_signIn.Click += TB_signIn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(220, 249);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 30;
            label1.Text = "Email";
            // 
            // TB_email
            // 
            TB_email.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_email.Location = new Point(287, 246);
            TB_email.Margin = new Padding(3, 4, 3, 4);
            TB_email.Name = "TB_email";
            TB_email.Size = new Size(258, 27);
            TB_email.TabIndex = 29;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(196, 461);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 39;
            label2.Text = "Quên mật khẩu ?";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(322, 457);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 40;
            button1.Text = "Khôi phục";
            button1.UseVisualStyleBackColor = true;
            // 
            // LB_noti
            // 
            LB_noti.AutoSize = true;
            LB_noti.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_noti.Location = new Point(196, 350);
            LB_noti.Name = "LB_noti";
            LB_noti.Size = new Size(0, 25);
            LB_noti.TabIndex = 41;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 506);
            Controls.Add(LB_noti);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(TB_signUp);
            Controls.Add(TB_password);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TB_signIn);
            Controls.Add(label1);
            Controls.Add(TB_email);
            Name = "DangNhap";
            Text = "Anonymous Chat";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TB_signUp;
        private TextBox TB_password;
        private Label label5;
        private Label label4;
        private Button TB_signIn;
        private Label label1;
        private TextBox TB_email;
        private Label label2;
        private Button button1;
        private Label LB_noti;
    }
}