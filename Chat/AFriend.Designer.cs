namespace anonymous_chat.Chat
{
    partial class AFriend
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
            LB_name = new Label();
            LB_UID = new Label();
            LB_online = new Label();
            mainFriend = new Panel();
            ((System.ComponentModel.ISupportInitialize)PB_avatar).BeginInit();
            mainFriend.SuspendLayout();
            SuspendLayout();
            // 
            // PB_avatar
            // 
            PB_avatar.Location = new Point(3, 3);
            PB_avatar.Name = "PB_avatar";
            PB_avatar.Size = new Size(71, 71);
            PB_avatar.TabIndex = 0;
            PB_avatar.TabStop = false;
            PB_avatar.Click += PB_avatar_Click;
            // 
            // LB_name
            // 
            LB_name.AutoEllipsis = true;
            LB_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_name.Location = new Point(80, 3);
            LB_name.Name = "LB_name";
            LB_name.Size = new Size(133, 28);
            LB_name.TabIndex = 1;
            LB_name.Text = "thang";
            LB_name.Click += LB_name_Click;
            // 
            // LB_UID
            // 
            LB_UID.AutoSize = true;
            LB_UID.Location = new Point(80, 31);
            LB_UID.Name = "LB_UID";
            LB_UID.Size = new Size(73, 20);
            LB_UID.TabIndex = 2;
            LB_UID.Text = "UID: 1234";
            // 
            // LB_online
            // 
            LB_online.AutoSize = true;
            LB_online.ForeColor = Color.Lime;
            LB_online.Location = new Point(80, 51);
            LB_online.Name = "LB_online";
            LB_online.Size = new Size(52, 20);
            LB_online.TabIndex = 3;
            LB_online.Text = "Online";
            // 
            // mainFriend
            // 
            mainFriend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainFriend.BorderStyle = BorderStyle.FixedSingle;
            mainFriend.Controls.Add(PB_avatar);
            mainFriend.Controls.Add(LB_online);
            mainFriend.Controls.Add(LB_name);
            mainFriend.Controls.Add(LB_UID);
            mainFriend.Location = new Point(0, 0);
            mainFriend.Name = "mainFriend";
            mainFriend.Size = new Size(244, 77);
            mainFriend.TabIndex = 4;
            mainFriend.Click += mainFriend_Click;
            // 
            // AFriend
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainFriend);
            Name = "AFriend";
            Size = new Size(244, 77);
            ((System.ComponentModel.ISupportInitialize)PB_avatar).EndInit();
            mainFriend.ResumeLayout(false);
            mainFriend.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox PB_avatar;
        private Label LB_name;
        private Label LB_UID;
        private Label LB_online;
        private Panel mainFriend;
    }
}
