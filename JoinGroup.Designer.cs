namespace anonymous_chat
{
    partial class JoinGroup
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
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            rTB_info = new RichTextBox();
            BT_hide = new Button();
            TB_password = new TextBox();
            label2 = new Label();
            TB_UID = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            BT_add = new Button();
            label3 = new Label();
            TB_addUID = new TextBox();
            BT_join = new Button();
            BT_find = new Button();
            LB_log = new Label();
            PB_avatar = new PictureBox();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_avatar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(PB_avatar);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(BT_hide);
            panel1.Controls.Add(TB_password);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TB_UID);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(BT_join);
            panel1.Controls.Add(BT_find);
            panel1.Controls.Add(LB_log);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(544, 295);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rTB_info);
            groupBox3.Location = new Point(199, 72);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(334, 189);
            groupBox3.TabIndex = 70;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin";
            // 
            // rTB_info
            // 
            rTB_info.BorderStyle = BorderStyle.None;
            rTB_info.Location = new Point(6, 26);
            rTB_info.Name = "rTB_info";
            rTB_info.ReadOnly = true;
            rTB_info.Size = new Size(322, 157);
            rTB_info.TabIndex = 0;
            rTB_info.Text = "";
            // 
            // BT_hide
            // 
            BT_hide.Image = Properties.Resources.eye20x20;
            BT_hide.Location = new Point(506, 39);
            BT_hide.Name = "BT_hide";
            BT_hide.Size = new Size(27, 27);
            BT_hide.TabIndex = 69;
            BT_hide.UseVisualStyleBackColor = true;
            BT_hide.Click += BT_hide_Click;
            // 
            // TB_password
            // 
            TB_password.Location = new Point(93, 39);
            TB_password.Name = "TB_password";
            TB_password.PasswordChar = '*';
            TB_password.Size = new Size(407, 27);
            TB_password.TabIndex = 68;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 42);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 67;
            label2.Text = "Mật khẩu";
            // 
            // TB_UID
            // 
            TB_UID.Location = new Point(93, 6);
            TB_UID.Name = "TB_UID";
            TB_UID.Size = new Size(440, 27);
            TB_UID.TabIndex = 66;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 65;
            label1.Text = "UID nhóm";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BT_add);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TB_addUID);
            groupBox1.Location = new Point(12, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(181, 117);
            groupBox1.TabIndex = 73;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mời thành viên";
            // 
            // BT_add
            // 
            BT_add.Enabled = false;
            BT_add.Location = new Point(6, 82);
            BT_add.Name = "BT_add";
            BT_add.Size = new Size(168, 29);
            BT_add.TabIndex = 2;
            BT_add.Text = "Mời bạn";
            BT_add.UseVisualStyleBackColor = true;
            BT_add.Click += BT_add_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 23);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 1;
            label3.Text = "UID";
            // 
            // TB_addUID
            // 
            TB_addUID.Location = new Point(6, 49);
            TB_addUID.Name = "TB_addUID";
            TB_addUID.Size = new Size(168, 27);
            TB_addUID.TabIndex = 0;
            // 
            // BT_join
            // 
            BT_join.Enabled = false;
            BT_join.Location = new Point(59, 232);
            BT_join.Name = "BT_join";
            BT_join.Size = new Size(134, 29);
            BT_join.TabIndex = 72;
            BT_join.Text = "Tham gia";
            BT_join.UseVisualStyleBackColor = true;
            BT_join.Click += BT_join_Click;
            // 
            // BT_find
            // 
            BT_find.Location = new Point(12, 195);
            BT_find.Name = "BT_find";
            BT_find.Size = new Size(181, 29);
            BT_find.TabIndex = 71;
            BT_find.Text = "Tìm nhóm";
            BT_find.UseVisualStyleBackColor = true;
            BT_find.Click += BT_find_Click;
            // 
            // LB_log
            // 
            LB_log.AutoEllipsis = true;
            LB_log.Location = new Point(59, 264);
            LB_log.Name = "LB_log";
            LB_log.Size = new Size(474, 25);
            LB_log.TabIndex = 74;
            // 
            // PB_avatar
            // 
            PB_avatar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PB_avatar.Location = new Point(3, 242);
            PB_avatar.Name = "PB_avatar";
            PB_avatar.Size = new Size(50, 50);
            PB_avatar.TabIndex = 75;
            PB_avatar.TabStop = false;
            // 
            // JoinGroup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 296);
            Controls.Add(panel1);
            Name = "JoinGroup";
            Text = "JoinGroup";
            Icon = new Icon("resource\\icon.ico");
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_avatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox3;
        private RichTextBox rTB_info;
        private Button BT_hide;
        private TextBox TB_password;
        private Label label2;
        private TextBox TB_UID;
        private Label label1;
        private GroupBox groupBox1;
        private Button BT_add;
        private Label label3;
        private TextBox TB_addUID;
        private Button BT_join;
        private Button BT_find;
        private Label LB_log;
        private PictureBox PB_avatar;
    }
}