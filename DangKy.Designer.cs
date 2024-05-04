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
            PictureBox pictureBox1;
            TB_signIn = new Button();
            TB_password = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TB_signUP = new Button();
            label1 = new Label();
            TB_email = new TextBox();
            TB_repassword = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TB_signIn
            // 
            TB_signIn.Location = new Point(132, 388);
            TB_signIn.Margin = new Padding(3, 4, 3, 4);
            TB_signIn.Name = "TB_signIn";
            TB_signIn.Size = new Size(141, 31);
            TB_signIn.TabIndex = 25;
            TB_signIn.Text = "Trở về đăng nhập";
            TB_signIn.UseVisualStyleBackColor = true;
            // 
            // TB_password
            // 
            TB_password.Location = new Point(287, 274);
            TB_password.Margin = new Padding(3, 4, 3, 4);
            TB_password.Name = "TB_password";
            TB_password.Size = new Size(258, 27);
            TB_password.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(196, 277);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 21;
            label5.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(287, 158);
            label4.Name = "label4";
            label4.Size = new Size(160, 46);
            label4.TabIndex = 20;
            label4.Text = "Đăng ký ";
            // 
            // TB_signUP
            // 
            TB_signUP.Location = new Point(393, 388);
            TB_signUP.Margin = new Padding(3, 4, 3, 4);
            TB_signUP.Name = "TB_signUP";
            TB_signUP.Size = new Size(152, 31);
            TB_signUP.TabIndex = 19;
            TB_signUP.Text = "Đăng ký";
            TB_signUP.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(196, 230);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 16;
            label1.Text = "Email";
            // 
            // TB_email
            // 
            TB_email.Location = new Point(287, 227);
            TB_email.Margin = new Padding(3, 4, 3, 4);
            TB_email.Name = "TB_email";
            TB_email.Size = new Size(258, 27);
            TB_email.TabIndex = 13;
            // 
            // TB_repassword
            // 
            TB_repassword.Location = new Point(287, 320);
            TB_repassword.Margin = new Padding(3, 4, 3, 4);
            TB_repassword.Name = "TB_repassword";
            TB_repassword.Size = new Size(258, 27);
            TB_repassword.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 323);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 26;
            label2.Text = "Xác nhận mật khẩu";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo150x150;
            pictureBox1.Location = new Point(287, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // DangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 449);
            Controls.Add(pictureBox1);
            Controls.Add(TB_repassword);
            Controls.Add(label2);
            Controls.Add(TB_signIn);
            Controls.Add(TB_password);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TB_signUP);
            Controls.Add(label1);
            Controls.Add(TB_email);
            Name = "DangKy";
            Text = "DangKy";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TB_signIn;
        private TextBox TB_password;
        private Label label5;
        private Label label4;
        private Button TB_signUP;
        private Label label1;
        private TextBox TB_email;
        private TextBox TB_repassword;
        private Label label2;
    }
}