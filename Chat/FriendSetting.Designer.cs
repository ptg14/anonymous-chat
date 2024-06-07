namespace anonymous_chat.Chat
{
    partial class FriendSetting
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
            PB_avatar = new PictureBox();
            LB_online = new Label();
            LB_name = new Label();
            LB_UID = new Label();
            BT_deleteFriend = new Button();
            ((System.ComponentModel.ISupportInitialize)PB_avatar).BeginInit();
            SuspendLayout();
            // 
            // PB_avatar
            // 
            PB_avatar.Location = new Point(3, 3);
            PB_avatar.Name = "PB_avatar";
            PB_avatar.Size = new Size(71, 71);
            PB_avatar.TabIndex = 4;
            PB_avatar.TabStop = false;
            // 
            // LB_online
            // 
            LB_online.AutoSize = true;
            LB_online.ForeColor = Color.Lime;
            LB_online.Location = new Point(80, 51);
            LB_online.Name = "LB_online";
            LB_online.Size = new Size(52, 20);
            LB_online.TabIndex = 7;
            LB_online.Text = "Online";
            // 
            // LB_name
            // 
            LB_name.AutoEllipsis = true;
            LB_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_name.Location = new Point(80, 3);
            LB_name.Name = "LB_name";
            LB_name.Size = new Size(83, 28);
            LB_name.TabIndex = 5;
            LB_name.Text = "thang";
            // 
            // LB_UID
            // 
            LB_UID.AutoSize = true;
            LB_UID.Location = new Point(80, 31);
            LB_UID.Name = "LB_UID";
            LB_UID.Size = new Size(73, 20);
            LB_UID.TabIndex = 6;
            LB_UID.Text = "UID: 1234";
            // 
            // BT_deleteFriend
            // 
            BT_deleteFriend.Location = new Point(169, 7);
            BT_deleteFriend.Name = "BT_deleteFriend";
            BT_deleteFriend.Size = new Size(51, 65);
            BT_deleteFriend.TabIndex = 8;
            BT_deleteFriend.Text = "Xoá bạn";
            BT_deleteFriend.UseVisualStyleBackColor = true;
            BT_deleteFriend.Click += BT_deleteFriend_Click;
            // 
            // FriendSetting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(BT_deleteFriend);
            Controls.Add(PB_avatar);
            Controls.Add(LB_online);
            Controls.Add(LB_name);
            Controls.Add(LB_UID);
            Name = "FriendSetting";
            Size = new Size(242, 75);
            ((System.ComponentModel.ISupportInitialize)PB_avatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PB_avatar;
        private Label LB_online;
        private Label LB_name;
        private Label LB_UID;
        private Button BT_deleteFriend;
    }
}
