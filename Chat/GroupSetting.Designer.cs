namespace anonymous_chat.Chat
{
    partial class GroupSetting
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
            label1 = new Label();
            TB_groupUID = new TextBox();
            BT_find = new Button();
            LB_log = new Label();
            groupBox1 = new GroupBox();
            BT_description = new Button();
            rTB_description = new RichTextBox();
            BT_rename = new Button();
            TB_groupName = new TextBox();
            groupBox2 = new GroupBox();
            BT_unBan = new Button();
            rTB_list = new RichTextBox();
            BT_ban = new Button();
            BT_kick = new Button();
            TB_kickbanUID = new TextBox();
            panel1 = new Panel();
            BT_avatar = new Button();
            PB_avatar = new PictureBox();
            BT_admin = new Button();
            TB_admin = new TextBox();
            label6 = new Label();
            BT_password = new Button();
            label5 = new Label();
            BT_hide = new Button();
            TB_password = new TextBox();
            BT_group = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_avatar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 7);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "UID nhóm";
            // 
            // TB_groupUID
            // 
            TB_groupUID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_groupUID.Location = new Point(93, 4);
            TB_groupUID.Name = "TB_groupUID";
            TB_groupUID.Size = new Size(144, 27);
            TB_groupUID.TabIndex = 1;
            // 
            // BT_find
            // 
            BT_find.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_find.Location = new Point(243, 3);
            BT_find.Name = "BT_find";
            BT_find.Size = new Size(117, 29);
            BT_find.TabIndex = 2;
            BT_find.Text = "Tìm nhóm";
            BT_find.UseVisualStyleBackColor = true;
            BT_find.Click += BT_find_Click;
            // 
            // LB_log
            // 
            LB_log.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LB_log.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_log.Location = new Point(103, 261);
            LB_log.Name = "LB_log";
            LB_log.Size = new Size(438, 25);
            LB_log.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(BT_description);
            groupBox1.Controls.Add(rTB_description);
            groupBox1.Controls.Add(BT_rename);
            groupBox1.Controls.Add(TB_groupName);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(3, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(234, 221);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đổi tên, mô tả";
            // 
            // BT_description
            // 
            BT_description.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_description.Location = new Point(8, 186);
            BT_description.Name = "BT_description";
            BT_description.Size = new Size(220, 29);
            BT_description.TabIndex = 3;
            BT_description.Text = "Đổi mô tả";
            BT_description.UseVisualStyleBackColor = true;
            BT_description.Click += BT_description_Click;
            // 
            // rTB_description
            // 
            rTB_description.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTB_description.Location = new Point(8, 61);
            rTB_description.Name = "rTB_description";
            rTB_description.Size = new Size(220, 119);
            rTB_description.TabIndex = 2;
            rTB_description.Text = "";
            // 
            // BT_rename
            // 
            BT_rename.Location = new Point(137, 25);
            BT_rename.Name = "BT_rename";
            BT_rename.Size = new Size(91, 29);
            BT_rename.TabIndex = 1;
            BT_rename.Text = "Đổi tên";
            BT_rename.UseVisualStyleBackColor = true;
            BT_rename.Click += BT_rename_Click;
            // 
            // TB_groupName
            // 
            TB_groupName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_groupName.Location = new Point(8, 26);
            TB_groupName.Name = "TB_groupName";
            TB_groupName.Size = new Size(125, 27);
            TB_groupName.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(BT_unBan);
            groupBox2.Controls.Add(rTB_list);
            groupBox2.Controls.Add(BT_ban);
            groupBox2.Controls.Add(BT_kick);
            groupBox2.Controls.Add(TB_kickbanUID);
            groupBox2.Enabled = false;
            groupBox2.Location = new Point(243, 38);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(123, 220);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Đuổi, Cấm";
            // 
            // BT_unBan
            // 
            BT_unBan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_unBan.Location = new Point(6, 185);
            BT_unBan.Name = "BT_unBan";
            BT_unBan.Size = new Size(111, 29);
            BT_unBan.TabIndex = 5;
            BT_unBan.Text = "Bỏ cấm";
            BT_unBan.UseVisualStyleBackColor = true;
            BT_unBan.Click += BT_unBan_Click;
            // 
            // rTB_list
            // 
            rTB_list.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTB_list.BorderStyle = BorderStyle.FixedSingle;
            rTB_list.Location = new Point(6, 26);
            rTB_list.Name = "rTB_list";
            rTB_list.ReadOnly = true;
            rTB_list.Size = new Size(111, 60);
            rTB_list.TabIndex = 4;
            rTB_list.Text = "";
            // 
            // BT_ban
            // 
            BT_ban.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_ban.Location = new Point(6, 150);
            BT_ban.Name = "BT_ban";
            BT_ban.Size = new Size(111, 29);
            BT_ban.TabIndex = 3;
            BT_ban.Text = "Cấm";
            BT_ban.UseVisualStyleBackColor = true;
            BT_ban.Click += BT_ban_Click;
            // 
            // BT_kick
            // 
            BT_kick.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_kick.Location = new Point(6, 115);
            BT_kick.Name = "BT_kick";
            BT_kick.Size = new Size(111, 29);
            BT_kick.TabIndex = 1;
            BT_kick.Text = "Đuổi";
            BT_kick.UseVisualStyleBackColor = true;
            BT_kick.Click += BT_kick_Click;
            // 
            // TB_kickbanUID
            // 
            TB_kickbanUID.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TB_kickbanUID.Location = new Point(6, 89);
            TB_kickbanUID.Name = "TB_kickbanUID";
            TB_kickbanUID.Size = new Size(111, 27);
            TB_kickbanUID.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(BT_avatar);
            panel1.Controls.Add(PB_avatar);
            panel1.Controls.Add(BT_admin);
            panel1.Controls.Add(TB_admin);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(BT_password);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(BT_hide);
            panel1.Controls.Add(TB_password);
            panel1.Enabled = false;
            panel1.Location = new Point(372, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(169, 246);
            panel1.TabIndex = 8;
            // 
            // BT_avatar
            // 
            BT_avatar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_avatar.Location = new Point(59, 199);
            BT_avatar.Name = "BT_avatar";
            BT_avatar.Size = new Size(107, 29);
            BT_avatar.TabIndex = 61;
            BT_avatar.Text = "Đổi avatar";
            BT_avatar.UseVisualStyleBackColor = true;
            BT_avatar.Click += BT_avatar_Click;
            // 
            // PB_avatar
            // 
            PB_avatar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            PB_avatar.Location = new Point(3, 188);
            PB_avatar.Name = "PB_avatar";
            PB_avatar.Size = new Size(50, 50);
            PB_avatar.TabIndex = 60;
            PB_avatar.TabStop = false;
            // 
            // BT_admin
            // 
            BT_admin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BT_admin.Location = new Point(3, 148);
            BT_admin.Name = "BT_admin";
            BT_admin.Size = new Size(163, 29);
            BT_admin.TabIndex = 59;
            BT_admin.Text = "Đổi trưởng nhóm";
            BT_admin.UseVisualStyleBackColor = true;
            BT_admin.Click += BT_admin_Click;
            // 
            // TB_admin
            // 
            TB_admin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_admin.Location = new Point(3, 115);
            TB_admin.Name = "TB_admin";
            TB_admin.Size = new Size(163, 27);
            TB_admin.TabIndex = 58;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 92);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 57;
            label6.Text = "UID trưởng nhóm";
            // 
            // BT_password
            // 
            BT_password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BT_password.Location = new Point(3, 60);
            BT_password.Name = "BT_password";
            BT_password.Size = new Size(163, 29);
            BT_password.TabIndex = 56;
            BT_password.Text = "Đổi mật khẩu";
            BT_password.UseVisualStyleBackColor = true;
            BT_password.Click += BT_password_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 4);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 55;
            label5.Text = "Mật khẩu";
            // 
            // BT_hide
            // 
            BT_hide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_hide.Image = Properties.Resources.eye20x20;
            BT_hide.Location = new Point(139, 26);
            BT_hide.Name = "BT_hide";
            BT_hide.Size = new Size(27, 27);
            BT_hide.TabIndex = 54;
            BT_hide.UseVisualStyleBackColor = true;
            BT_hide.Click += BT_hide_Click;
            // 
            // TB_password
            // 
            TB_password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_password.Location = new Point(3, 27);
            TB_password.Name = "TB_password";
            TB_password.PasswordChar = '*';
            TB_password.Size = new Size(130, 27);
            TB_password.TabIndex = 0;
            // 
            // BT_group
            // 
            BT_group.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_group.Location = new Point(3, 259);
            BT_group.Name = "BT_group";
            BT_group.Size = new Size(94, 29);
            BT_group.TabIndex = 9;
            BT_group.Text = "Tạo nhóm";
            BT_group.UseVisualStyleBackColor = true;
            BT_group.Click += BT_group_Click;
            // 
            // GroupSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BT_group);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(LB_log);
            Controls.Add(BT_find);
            Controls.Add(TB_groupUID);
            Controls.Add(label1);
            Name = "GroupSetting";
            Size = new Size(544, 295);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_avatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TB_groupUID;
        private Button BT_find;
        private Label LB_log;
        private GroupBox groupBox1;
        private Button BT_description;
        private RichTextBox rTB_description;
        private Button BT_rename;
        private TextBox TB_groupName;
        private GroupBox groupBox2;
        private Panel panel1;
        private Button BT_kick;
        private TextBox TB_kickbanUID;
        private Button BT_ban;
        private TextBox TB_password;
        private Button BT_admin;
        private TextBox TB_admin;
        private Label label6;
        private Button BT_password;
        private Label label5;
        private Button BT_hide;
        private Button BT_avatar;
        private PictureBox PB_avatar;
        private RichTextBox rTB_list;
        private Button BT_group;
        private Button BT_unBan;
    }
}
