using anonymous_chat.Chat;

namespace anonymous_chat
{
    partial class Main
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
            this.Send("DISCONNECT=" + this.UID);
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
            splitContainer1 = new SplitContainer();
            addFriend = new Panel();
            PB_findResult = new PictureBox();
            TB_findResult = new TextBox();
            BT_addFriend = new Button();
            BT_findFriend = new Button();
            label1 = new Label();
            TB_friendUID = new TextBox();
            BT_logOut = new Button();
            BT_noti = new Button();
            BT_refresh = new Button();
            BT_random = new Button();
            BT_AI = new Button();
            BT_listFriends = new Button();
            BT_search = new Button();
            LBox_listFriends = new ListBox();
            LB_UID = new Label();
            LB_name = new Label();
            BT_avatar = new Button();
            mainChat = new Panel();
            mainLogo = new PictureBox();
            setting = new Setting();
            topChatPanel = new Panel();
            BT_setting = new Button();
            LB_friendName = new Label();
            PB_friendAvatar = new PictureBox();
            BT_call = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            addFriend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_findResult).BeginInit();
            mainChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainLogo).BeginInit();
            topChatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_friendAvatar).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ActiveCaption;
            splitContainer1.Panel1.Controls.Add(addFriend);
            splitContainer1.Panel1.Controls.Add(BT_logOut);
            splitContainer1.Panel1.Controls.Add(BT_noti);
            splitContainer1.Panel1.Controls.Add(BT_refresh);
            splitContainer1.Panel1.Controls.Add(BT_random);
            splitContainer1.Panel1.Controls.Add(BT_AI);
            splitContainer1.Panel1.Controls.Add(BT_listFriends);
            splitContainer1.Panel1.Controls.Add(BT_search);
            splitContainer1.Panel1.Controls.Add(LBox_listFriends);
            splitContainer1.Panel1.Controls.Add(LB_UID);
            splitContainer1.Panel1.Controls.Add(LB_name);
            splitContainer1.Panel1.Controls.Add(BT_avatar);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(mainChat);
            splitContainer1.Panel2.Controls.Add(topChatPanel);
            splitContainer1.Size = new Size(882, 503);
            splitContainer1.SplitterDistance = 253;
            splitContainer1.TabIndex = 0;
            // 
            // addFriend
            // 
            addFriend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addFriend.Controls.Add(PB_findResult);
            addFriend.Controls.Add(TB_findResult);
            addFriend.Controls.Add(BT_addFriend);
            addFriend.Controls.Add(BT_findFriend);
            addFriend.Controls.Add(label1);
            addFriend.Controls.Add(TB_friendUID);
            addFriend.Location = new Point(3, 95);
            addFriend.Name = "addFriend";
            addFriend.Size = new Size(246, 126);
            addFriend.TabIndex = 9;
            addFriend.Visible = false;
            // 
            // PB_findResult
            // 
            PB_findResult.Location = new Point(3, 56);
            PB_findResult.Name = "PB_findResult";
            PB_findResult.Size = new Size(27, 27);
            PB_findResult.TabIndex = 12;
            PB_findResult.TabStop = false;
            // 
            // TB_findResult
            // 
            TB_findResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_findResult.BorderStyle = BorderStyle.FixedSingle;
            TB_findResult.Location = new Point(36, 56);
            TB_findResult.Name = "TB_findResult";
            TB_findResult.ReadOnly = true;
            TB_findResult.Size = new Size(207, 27);
            TB_findResult.TabIndex = 13;
            // 
            // BT_addFriend
            // 
            BT_addFriend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_addFriend.Location = new Point(3, 89);
            BT_addFriend.Name = "BT_addFriend";
            BT_addFriend.Size = new Size(240, 29);
            BT_addFriend.TabIndex = 12;
            BT_addFriend.Text = "Thêm bạn";
            BT_addFriend.UseVisualStyleBackColor = true;
            BT_addFriend.Click += BT_addFriend_Click;
            // 
            // BT_findFriend
            // 
            BT_findFriend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_findFriend.Image = Properties.Resources.search20x20;
            BT_findFriend.Location = new Point(213, 21);
            BT_findFriend.Name = "BT_findFriend";
            BT_findFriend.Size = new Size(30, 30);
            BT_findFriend.TabIndex = 10;
            BT_findFriend.UseVisualStyleBackColor = true;
            BT_findFriend.Click += BT_findFriend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 1;
            label1.Text = "UID";
            // 
            // TB_friendUID
            // 
            TB_friendUID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TB_friendUID.Location = new Point(3, 23);
            TB_friendUID.Name = "TB_friendUID";
            TB_friendUID.Size = new Size(204, 27);
            TB_friendUID.TabIndex = 0;
            // 
            // BT_logOut
            // 
            BT_logOut.Image = Properties.Resources.logout20x20;
            BT_logOut.Location = new Point(220, 59);
            BT_logOut.Name = "BT_logOut";
            BT_logOut.Size = new Size(30, 30);
            BT_logOut.TabIndex = 8;
            BT_logOut.UseVisualStyleBackColor = true;
            // 
            // BT_noti
            // 
            BT_noti.Image = Properties.Resources.noti20x20;
            BT_noti.Location = new Point(184, 59);
            BT_noti.Name = "BT_noti";
            BT_noti.Size = new Size(30, 30);
            BT_noti.TabIndex = 7;
            BT_noti.UseVisualStyleBackColor = true;
            // 
            // BT_refresh
            // 
            BT_refresh.Image = Properties.Resources.refresh20x20;
            BT_refresh.Location = new Point(148, 59);
            BT_refresh.Name = "BT_refresh";
            BT_refresh.Size = new Size(30, 30);
            BT_refresh.TabIndex = 6;
            BT_refresh.UseVisualStyleBackColor = true;
            BT_refresh.Click += BT_refresh_Click;
            // 
            // BT_random
            // 
            BT_random.Image = Properties.Resources.random20x20;
            BT_random.Location = new Point(112, 59);
            BT_random.Name = "BT_random";
            BT_random.Size = new Size(30, 30);
            BT_random.TabIndex = 5;
            BT_random.UseVisualStyleBackColor = true;
            // 
            // BT_AI
            // 
            BT_AI.Image = Properties.Resources.AI30x30;
            BT_AI.Location = new Point(75, 59);
            BT_AI.Name = "BT_AI";
            BT_AI.Size = new Size(30, 30);
            BT_AI.TabIndex = 4;
            BT_AI.UseVisualStyleBackColor = true;
            BT_AI.Click += BT_AI_Click;
            // 
            // BT_listFriends
            // 
            BT_listFriends.Image = Properties.Resources.friend20x20;
            BT_listFriends.Location = new Point(39, 59);
            BT_listFriends.Name = "BT_listFriends";
            BT_listFriends.Size = new Size(30, 30);
            BT_listFriends.TabIndex = 3;
            BT_listFriends.UseVisualStyleBackColor = true;
            // 
            // BT_search
            // 
            BT_search.Image = Properties.Resources.search20x20;
            BT_search.Location = new Point(3, 59);
            BT_search.Name = "BT_search";
            BT_search.Size = new Size(30, 30);
            BT_search.TabIndex = 0;
            BT_search.UseVisualStyleBackColor = true;
            BT_search.Click += BT_search_Click;
            // 
            // LBox_listFriends
            // 
            LBox_listFriends.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LBox_listFriends.BackColor = SystemColors.Info;
            LBox_listFriends.FormattingEnabled = true;
            LBox_listFriends.Location = new Point(3, 95);
            LBox_listFriends.Name = "LBox_listFriends";
            LBox_listFriends.Size = new Size(246, 404);
            LBox_listFriends.TabIndex = 0;
            LBox_listFriends.SelectedIndexChanged += LBox_listFriends_SelectedIndexChanged;
            // 
            // LB_UID
            // 
            LB_UID.AutoSize = true;
            LB_UID.Location = new Point(59, 33);
            LB_UID.Name = "LB_UID";
            LB_UID.Size = new Size(34, 20);
            LB_UID.TabIndex = 2;
            LB_UID.Text = "UID";
            // 
            // LB_name
            // 
            LB_name.AutoSize = true;
            LB_name.Location = new Point(59, 9);
            LB_name.Name = "LB_name";
            LB_name.Size = new Size(49, 20);
            LB_name.TabIndex = 1;
            LB_name.Text = "Name";
            // 
            // BT_avatar
            // 
            BT_avatar.Location = new Point(3, 3);
            BT_avatar.Name = "BT_avatar";
            BT_avatar.Size = new Size(50, 50);
            BT_avatar.TabIndex = 0;
            BT_avatar.UseVisualStyleBackColor = true;
            // 
            // mainChat
            // 
            mainChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainChat.Controls.Add(mainLogo);
            mainChat.Controls.Add(setting);
            mainChat.Location = new Point(3, 59);
            mainChat.Name = "mainChat";
            mainChat.Size = new Size(619, 440);
            mainChat.TabIndex = 0;
            // 
            // mainLogo
            // 
            mainLogo.Image = Properties.Resources.logo300x300;
            mainLogo.Location = new Point(160, 70);
            mainLogo.Name = "mainLogo";
            mainLogo.Size = new Size(300, 300);
            mainLogo.TabIndex = 1;
            mainLogo.TabStop = false;
            // 
            // setting
            // 
            setting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            setting.Location = new Point(494, 0);
            setting.Name = "setting";
            setting.Size = new Size(125, 147);
            setting.TabIndex = 0;
            setting.Visible = false;
            // 
            // topChatPanel
            // 
            topChatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            topChatPanel.Controls.Add(BT_setting);
            topChatPanel.Controls.Add(LB_friendName);
            topChatPanel.Controls.Add(PB_friendAvatar);
            topChatPanel.Controls.Add(BT_call);
            topChatPanel.Location = new Point(3, 3);
            topChatPanel.Name = "topChatPanel";
            topChatPanel.Size = new Size(619, 50);
            topChatPanel.TabIndex = 13;
            // 
            // BT_setting
            // 
            BT_setting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_setting.Image = Properties.Resources.setting40x40;
            BT_setting.Location = new Point(566, 0);
            BT_setting.Name = "BT_setting";
            BT_setting.Size = new Size(50, 50);
            BT_setting.TabIndex = 9;
            BT_setting.UseVisualStyleBackColor = true;
            BT_setting.Click += BT_setting_Click;
            // 
            // LB_friendName
            // 
            LB_friendName.AutoSize = true;
            LB_friendName.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_friendName.Location = new Point(59, 6);
            LB_friendName.Name = "LB_friendName";
            LB_friendName.Size = new Size(0, 41);
            LB_friendName.TabIndex = 1;
            // 
            // PB_friendAvatar
            // 
            PB_friendAvatar.Location = new Point(0, 0);
            PB_friendAvatar.Name = "PB_friendAvatar";
            PB_friendAvatar.Size = new Size(50, 50);
            PB_friendAvatar.TabIndex = 0;
            PB_friendAvatar.TabStop = false;
            // 
            // BT_call
            // 
            BT_call.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BT_call.Image = Properties.Resources.phone40x40;
            BT_call.Location = new Point(513, 0);
            BT_call.Name = "BT_call";
            BT_call.Size = new Size(50, 50);
            BT_call.TabIndex = 10;
            BT_call.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 503);
            Controls.Add(splitContainer1);
            Name = "Main";
            Text = "Anonymous Chat";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            addFriend.ResumeLayout(false);
            addFriend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_findResult).EndInit();
            mainChat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainLogo).EndInit();
            topChatPanel.ResumeLayout(false);
            topChatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_friendAvatar).EndInit();
            Icon = new Icon("resource\\icon.ico");
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label LB_name;
        private Button BT_avatar;
        private ListBox LBox_listFriends;
        private Label LB_UID;
        private Button BT_logOut;
        private Button BT_noti;
        private Button BT_refresh;
        private Button BT_random;
        private Button BT_AI;
        private Button BT_listFriends;
        private Button BT_search;
        private Panel topChatPanel;
        private Button BT_call;
        private Button BT_setting;
        private Label LB_friendName;
        private PictureBox PB_friendAvatar;
        private Panel addFriend;
        private Button BT_addFriend;
        private Button BT_findFriend;
        private Label label1;
        private TextBox TB_friendUID;
        private PictureBox PB_findResult;
        private TextBox TB_findResult;
        // main chat
        private Panel mainChat;
        private Setting setting;
        private PictureBox mainLogo;
    }

    /*
    setting = new Setting();
    mainChat = new Panel();
    chatBox = new ChatBox(new MessageData());
    splitContainer1.Panel2.Controls.Add(mainChat);
    //
    // setting
    // 
    setting.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    setting.Location = new Point(494, 0);
    setting.Name = "setting";
    setting.Size = new Size(125, 147);
    setting.Visible = false;
    //
    // chatBox
    // 
    chatBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    chatBox.BackColor = SystemColors.Window;
    chatBox.Location = new Point(0, 0);
    chatBox.Margin = new Padding(3, 4, 3, 4);
    chatBox.Name = "chatBox";
    chatBox.Size = new Size(619, 440);
    chatBox.TabIndex = 14;
    // 
    // mainChat
    // 
    mainChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    mainChat.Location = new Point(3, 59);
    mainChat.Name = "mainChat";
    mainChat.Size = new Size(619, 440);
    mainChat.Controls.Add(chatBox);
    mainChat.Controls.Add(setting);
    */
}