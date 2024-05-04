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
            TB_signIn = new Button();
            TB_password = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TB_signUP = new Button();
            label1 = new Label();
            TB_email = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo150x150;
            pictureBox1.Location = new Point(287, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 38;
            pictureBox1.TabStop = false;
            // 
            // TB_signIn
            // 
            TB_signIn.Location = new Point(125, 350);
            TB_signIn.Margin = new Padding(3, 4, 3, 4);
            TB_signIn.Name = "TB_signIn";
            TB_signIn.Size = new Size(141, 44);
            TB_signIn.TabIndex = 35;
            TB_signIn.Text = "Đăng ký";
            TB_signIn.UseVisualStyleBackColor = true;
            // 
            // TB_password
            // 
            TB_password.Location = new Point(287, 293);
            TB_password.Margin = new Padding(3, 4, 3, 4);
            TB_password.Name = "TB_password";
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
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(287, 177);
            label4.Name = "label4";
            label4.Size = new Size(194, 46);
            label4.TabIndex = 32;
            label4.Text = "Đăng nhập";
            // 
            // TB_signUP
            // 
            TB_signUP.Location = new Point(393, 350);
            TB_signUP.Margin = new Padding(3, 4, 3, 4);
            TB_signUP.Name = "TB_signUP";
            TB_signUP.Size = new Size(152, 44);
            TB_signUP.TabIndex = 31;
            TB_signUP.Text = "Đăng nhập";
            TB_signUP.UseVisualStyleBackColor = true;
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
            TB_email.Location = new Point(287, 246);
            TB_email.Margin = new Padding(3, 4, 3, 4);
            TB_email.Name = "TB_email";
            TB_email.Size = new Size(258, 27);
            TB_email.TabIndex = 29;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 449);
            Controls.Add(pictureBox1);
            Controls.Add(TB_signIn);
            Controls.Add(TB_password);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(TB_signUP);
            Controls.Add(label1);
            Controls.Add(TB_email);
            Name = "DangNhap";
            Text = "Anonymous Chat";
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
    }
}