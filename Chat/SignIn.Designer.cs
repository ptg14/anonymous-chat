namespace anonymous_chat.Chat
{
    partial class SignIn
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
            PictureBox pictureBox1;
            LB_noti = new Label();
            BT_reco = new Button();
            label2 = new Label();
            BT_signUp = new Button();
            TB_password = new TextBox();
            label5 = new Label();
            label4 = new Label();
            BT_signIn = new Button();
            label1 = new Label();
            TB_email = new TextBox();
            BT_hide = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.logo150x150;
            pictureBox1.Location = new Point(292, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 49;
            pictureBox1.TabStop = false;
            // 
            // LB_noti
            // 
            LB_noti.AutoSize = true;
            LB_noti.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_noti.ForeColor = SystemColors.ControlText;
            LB_noti.Location = new Point(201, 334);
            LB_noti.Name = "LB_noti";
            LB_noti.Size = new Size(0, 25);
            LB_noti.TabIndex = 52;
            // 
            // BT_reco
            // 
            BT_reco.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BT_reco.Location = new Point(327, 441);
            BT_reco.Name = "BT_reco";
            BT_reco.Size = new Size(94, 29);
            BT_reco.TabIndex = 51;
            BT_reco.Text = "Khôi phục";
            BT_reco.UseVisualStyleBackColor = true;
            BT_reco.Click += BT_reco_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(201, 445);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 50;
            label2.Text = "Quên mật khẩu ?";
            // 
            // BT_signUp
            // 
            BT_signUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_signUp.Location = new Point(130, 383);
            BT_signUp.Margin = new Padding(3, 4, 3, 4);
            BT_signUp.Name = "BT_signUp";
            BT_signUp.Size = new Size(141, 44);
            BT_signUp.TabIndex = 48;
            BT_signUp.Text = "Đăng ký";
            BT_signUp.UseVisualStyleBackColor = true;
            BT_signUp.Click += BT_signUp_Click;
            // 
            // TB_password
            // 
            TB_password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_password.Location = new Point(292, 277);
            TB_password.Margin = new Padding(3, 4, 3, 4);
            TB_password.Name = "TB_password";
            TB_password.PasswordChar = '*';
            TB_password.Size = new Size(258, 27);
            TB_password.TabIndex = 47;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(201, 280);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 46;
            label5.Text = "Mật khẩu";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(292, 158);
            label4.Name = "label4";
            label4.Size = new Size(194, 46);
            label4.TabIndex = 45;
            label4.Text = "Đăng nhập";
            // 
            // BT_signIn
            // 
            BT_signIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BT_signIn.Location = new Point(398, 383);
            BT_signIn.Margin = new Padding(3, 4, 3, 4);
            BT_signIn.Name = "BT_signIn";
            BT_signIn.Size = new Size(152, 44);
            BT_signIn.TabIndex = 44;
            BT_signIn.Text = "Đăng nhập";
            BT_signIn.UseVisualStyleBackColor = true;
            BT_signIn.Click += BT_signIn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(225, 233);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 43;
            label1.Text = "Email";
            // 
            // TB_email
            // 
            TB_email.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_email.Location = new Point(292, 230);
            TB_email.Margin = new Padding(3, 4, 3, 4);
            TB_email.Name = "TB_email";
            TB_email.Size = new Size(258, 27);
            TB_email.TabIndex = 42;
            // 
            // BT_hide
            // 
            BT_hide.Image = Properties.Resources.eye25x25;
            BT_hide.Location = new Point(556, 277);
            BT_hide.Name = "BT_hide";
            BT_hide.Size = new Size(27, 27);
            BT_hide.TabIndex = 53;
            BT_hide.UseVisualStyleBackColor = true;
            BT_hide.Click += BT_hide_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(BT_hide);
            Controls.Add(LB_noti);
            Controls.Add(BT_reco);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(BT_signUp);
            Controls.Add(TB_password);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(BT_signIn);
            Controls.Add(label1);
            Controls.Add(TB_email);
            Name = "SignIn";
            Size = new Size(681, 482);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label LB_noti;
        private Button BT_reco;
        private Label label2;
        private Button BT_signUp;
        public TextBox TB_password;
        private Label label5;
        private Label label4;
        private Button BT_signIn;
        private Label label1;
        public TextBox TB_email;
        private Button BT_hide;
    }
}
