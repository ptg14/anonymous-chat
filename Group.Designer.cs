namespace anonymous_chat
{
    partial class Group
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
            taoNhom = new Panel();
            LB_log = new Label();
            BT_group = new Button();
            BT_modify = new Button();
            BT_review = new Button();
            groupBox3 = new GroupBox();
            rTB_info = new RichTextBox();
            groupBox2 = new GroupBox();
            LB_banNoti = new Label();
            BT_ban = new Button();
            label5 = new Label();
            TB_banUID = new TextBox();
            groupBox1 = new GroupBox();
            LB_addNoti = new Label();
            BT_add = new Button();
            label3 = new Label();
            TB_addUID = new TextBox();
            BT_hide = new Button();
            TB_password = new TextBox();
            label2 = new Label();
            TB_Name = new TextBox();
            label1 = new Label();
            taoNhom.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // taoNhom
            // 
            taoNhom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            taoNhom.Controls.Add(LB_log);
            taoNhom.Controls.Add(BT_group);
            taoNhom.Controls.Add(BT_modify);
            taoNhom.Controls.Add(BT_review);
            taoNhom.Controls.Add(groupBox3);
            taoNhom.Controls.Add(groupBox2);
            taoNhom.Controls.Add(groupBox1);
            taoNhom.Controls.Add(BT_hide);
            taoNhom.Controls.Add(TB_password);
            taoNhom.Controls.Add(label2);
            taoNhom.Controls.Add(TB_Name);
            taoNhom.Controls.Add(label1);
            taoNhom.Location = new Point(0, 0);
            taoNhom.Name = "taoNhom";
            taoNhom.Size = new Size(544, 295);
            taoNhom.TabIndex = 0;
            // 
            // LB_log
            // 
            LB_log.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LB_log.AutoEllipsis = true;
            LB_log.Location = new Point(18, 256);
            LB_log.Name = "LB_log";
            LB_log.Size = new Size(514, 25);
            LB_log.TabIndex = 61;
            // 
            // BT_group
            // 
            BT_group.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_group.Enabled = false;
            BT_group.Location = new Point(218, 224);
            BT_group.Name = "BT_group";
            BT_group.Size = new Size(94, 29);
            BT_group.TabIndex = 60;
            BT_group.Text = "Tạo nhóm";
            BT_group.UseVisualStyleBackColor = true;
            BT_group.Click += BT_group_Click;
            // 
            // BT_modify
            // 
            BT_modify.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_modify.Location = new Point(118, 224);
            BT_modify.Name = "BT_modify";
            BT_modify.Size = new Size(94, 29);
            BT_modify.TabIndex = 59;
            BT_modify.Text = "Chỉnh sửa";
            BT_modify.UseVisualStyleBackColor = true;
            // 
            // BT_review
            // 
            BT_review.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_review.Location = new Point(18, 224);
            BT_review.Name = "BT_review";
            BT_review.Size = new Size(94, 29);
            BT_review.TabIndex = 58;
            BT_review.Text = "Xem lại";
            BT_review.UseVisualStyleBackColor = true;
            BT_review.Click += BT_review_Click;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(rTB_info);
            groupBox3.Location = new Point(348, 78);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(184, 175);
            groupBox3.TabIndex = 57;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin";
            // 
            // rTB_info
            // 
            rTB_info.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rTB_info.BorderStyle = BorderStyle.None;
            rTB_info.Location = new Point(6, 26);
            rTB_info.Name = "rTB_info";
            rTB_info.ReadOnly = true;
            rTB_info.Size = new Size(172, 143);
            rTB_info.TabIndex = 0;
            rTB_info.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(LB_banNoti);
            groupBox2.Controls.Add(BT_ban);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(TB_banUID);
            groupBox2.Location = new Point(180, 78);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(162, 140);
            groupBox2.TabIndex = 56;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cấm thành viên";
            // 
            // LB_banNoti
            // 
            LB_banNoti.AutoSize = true;
            LB_banNoti.Location = new Point(6, 76);
            LB_banNoti.Name = "LB_banNoti";
            LB_banNoti.Size = new Size(0, 20);
            LB_banNoti.TabIndex = 3;
            // 
            // BT_ban
            // 
            BT_ban.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_ban.Location = new Point(6, 105);
            BT_ban.Name = "BT_ban";
            BT_ban.Size = new Size(150, 29);
            BT_ban.TabIndex = 2;
            BT_ban.Text = "Cấm";
            BT_ban.UseVisualStyleBackColor = true;
            BT_ban.Click += BT_ban_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 23);
            label5.Name = "label5";
            label5.Size = new Size(34, 20);
            label5.TabIndex = 1;
            label5.Text = "UID";
            // 
            // TB_banUID
            // 
            TB_banUID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_banUID.Location = new Point(6, 46);
            TB_banUID.Name = "TB_banUID";
            TB_banUID.Size = new Size(150, 27);
            TB_banUID.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(LB_addNoti);
            groupBox1.Controls.Add(BT_add);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TB_addUID);
            groupBox1.Location = new Point(12, 78);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(162, 140);
            groupBox1.TabIndex = 55;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mời thành viên";
            // 
            // LB_addNoti
            // 
            LB_addNoti.AutoSize = true;
            LB_addNoti.Location = new Point(6, 76);
            LB_addNoti.Name = "LB_addNoti";
            LB_addNoti.Size = new Size(0, 20);
            LB_addNoti.TabIndex = 3;
            // 
            // BT_add
            // 
            BT_add.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_add.Location = new Point(6, 105);
            BT_add.Name = "BT_add";
            BT_add.Size = new Size(150, 29);
            BT_add.TabIndex = 2;
            BT_add.Text = "Mời";
            BT_add.UseVisualStyleBackColor = true;
            BT_add.Click += BT_add_Click;
            BT_add.Enabled = false;
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
            TB_addUID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_addUID.Location = new Point(6, 46);
            TB_addUID.Name = "TB_addUID";
            TB_addUID.Size = new Size(150, 27);
            TB_addUID.TabIndex = 0;
            // 
            // BT_hide
            // 
            BT_hide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_hide.Image = Properties.Resources.eye20x20;
            BT_hide.Location = new Point(505, 45);
            BT_hide.Name = "BT_hide";
            BT_hide.Size = new Size(27, 27);
            BT_hide.TabIndex = 54;
            BT_hide.UseVisualStyleBackColor = true;
            BT_hide.Click += BT_hide_Click;
            // 
            // TB_password
            // 
            TB_password.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_password.Location = new Point(92, 45);
            TB_password.Name = "TB_password";
            TB_password.PasswordChar = '*';
            TB_password.Size = new Size(407, 27);
            TB_password.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu";
            // 
            // TB_Name
            // 
            TB_Name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_Name.Location = new Point(92, 12);
            TB_Name.Name = "TB_Name";
            TB_Name.Size = new Size(440, 27);
            TB_Name.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên nhóm";
            // 
            // Group
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 296);
            Controls.Add(taoNhom);
            Name = "Group";
            Text = "Group";
            Icon = new Icon("resource\\icon.ico");
            taoNhom.ResumeLayout(false);
            taoNhom.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel taoNhom;
        private TextBox TB_password;
        private Label label2;
        private TextBox TB_Name;
        private Label label1;
        private Button BT_hide;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Label LB_banNoti;
        private Button BT_ban;
        private Label label5;
        private TextBox TB_banUID;
        private GroupBox groupBox1;
        private Label LB_addNoti;
        private Button BT_add;
        private Label label3;
        private TextBox TB_addUID;
        private Button BT_group;
        private Button BT_modify;
        private Button BT_review;
        private RichTextBox rTB_info;
        private Label LB_log;
    }
}