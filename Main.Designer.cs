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
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            BT_search = new Button();
            LBox_listFriends = new ListBox();
            LB_UID = new Label();
            LB_name = new Label();
            BT_avatar = new Button();
            mainchat = new Panel();
            chatArea = new Panel();
            BT_call = new Button();
            BT_setting = new Button();
            LB_friendName = new Label();
            PB_friendAvatar = new PictureBox();
            richTextBox1 = new RichTextBox();
            BT_send = new Button();
            BT_sendFile = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            addFriend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_findResult).BeginInit();
            mainchat.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(button7);
            splitContainer1.Panel1.Controls.Add(button6);
            splitContainer1.Panel1.Controls.Add(button5);
            splitContainer1.Panel1.Controls.Add(button4);
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(BT_search);
            splitContainer1.Panel1.Controls.Add(LBox_listFriends);
            splitContainer1.Panel1.Controls.Add(LB_UID);
            splitContainer1.Panel1.Controls.Add(LB_name);
            splitContainer1.Panel1.Controls.Add(BT_avatar);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(mainchat);
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Panel2.Controls.Add(BT_send);
            splitContainer1.Panel2.Controls.Add(BT_sendFile);
            splitContainer1.Panel2.Controls.Add(button8);
            splitContainer1.Size = new Size(882, 503);
            splitContainer1.SplitterDistance = 253;
            splitContainer1.TabIndex = 0;
            // 
            // addFriend
            // 
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
            TB_findResult.BorderStyle = BorderStyle.FixedSingle;
            TB_findResult.Location = new Point(36, 56);
            TB_findResult.Name = "TB_findResult";
            TB_findResult.ReadOnly = true;
            TB_findResult.Size = new Size(207, 27);
            TB_findResult.TabIndex = 13;
            // 
            // BT_addFriend
            // 
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
            TB_friendUID.Location = new Point(3, 23);
            TB_friendUID.Name = "TB_friendUID";
            TB_friendUID.Size = new Size(204, 27);
            TB_friendUID.TabIndex = 0;
            // 
            // button7
            // 
            button7.Image = Properties.Resources.logout20x20;
            button7.Location = new Point(220, 59);
            button7.Name = "button7";
            button7.Size = new Size(30, 30);
            button7.TabIndex = 8;
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Image = Properties.Resources.noti20x20;
            button6.Location = new Point(184, 59);
            button6.Name = "button6";
            button6.Size = new Size(30, 30);
            button6.TabIndex = 7;
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(148, 59);
            button5.Name = "button5";
            button5.Size = new Size(30, 30);
            button5.TabIndex = 6;
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Image = Properties.Resources.random20x20;
            button4.Location = new Point(112, 59);
            button4.Name = "button4";
            button4.Size = new Size(30, 30);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.AI30x30;
            button3.Location = new Point(75, 59);
            button3.Name = "button3";
            button3.Size = new Size(30, 30);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.friend20x20;
            button2.Location = new Point(39, 59);
            button2.Name = "button2";
            button2.Size = new Size(30, 30);
            button2.TabIndex = 3;
            button2.UseVisualStyleBackColor = true;
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
            LBox_listFriends.BackColor = SystemColors.Info;
            LBox_listFriends.FormattingEnabled = true;
            LBox_listFriends.Location = new Point(3, 95);
            LBox_listFriends.Name = "LBox_listFriends";
            LBox_listFriends.Size = new Size(246, 404);
            LBox_listFriends.TabIndex = 0;
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
            // mainchat
            // 
            mainchat.Controls.Add(chatArea);
            mainchat.Controls.Add(BT_call);
            mainchat.Controls.Add(BT_setting);
            mainchat.Controls.Add(LB_friendName);
            mainchat.Controls.Add(PB_friendAvatar);
            mainchat.Location = new Point(3, 3);
            mainchat.Name = "mainchat";
            mainchat.Size = new Size(619, 460);
            mainchat.TabIndex = 13;
            // 
            // chatArea
            // 
            chatArea.BackColor = SystemColors.Window;
            chatArea.Location = new Point(0, 56);
            chatArea.Name = "chatArea";
            chatArea.Size = new Size(619, 401);
            chatArea.TabIndex = 11;
            // 
            // BT_call
            // 
            BT_call.Image = Properties.Resources.phone40x40;
            BT_call.Location = new Point(510, 3);
            BT_call.Name = "BT_call";
            BT_call.Size = new Size(50, 50);
            BT_call.TabIndex = 10;
            BT_call.UseVisualStyleBackColor = true;
            // 
            // BT_setting
            // 
            BT_setting.Image = Properties.Resources.setting40x40;
            BT_setting.Location = new Point(566, 3);
            BT_setting.Name = "BT_setting";
            BT_setting.Size = new Size(50, 50);
            BT_setting.TabIndex = 9;
            BT_setting.UseVisualStyleBackColor = true;
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
            PB_friendAvatar.Location = new Point(3, 0);
            PB_friendAvatar.Name = "PB_friendAvatar";
            PB_friendAvatar.Size = new Size(50, 50);
            PB_friendAvatar.TabIndex = 0;
            PB_friendAvatar.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Window;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(3, 469);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(447, 30);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // BT_send
            // 
            BT_send.Location = new Point(528, 470);
            BT_send.Name = "BT_send";
            BT_send.Size = new Size(94, 29);
            BT_send.TabIndex = 11;
            BT_send.Text = "Gửi";
            BT_send.UseVisualStyleBackColor = true;
            // 
            // BT_sendFile
            // 
            BT_sendFile.Image = Properties.Resources.folder30x30;
            BT_sendFile.Location = new Point(492, 469);
            BT_sendFile.Name = "BT_sendFile";
            BT_sendFile.Size = new Size(30, 30);
            BT_sendFile.TabIndex = 10;
            BT_sendFile.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Image = Properties.Resources.emoji20x20;
            button8.Location = new Point(456, 469);
            button8.Name = "button8";
            button8.Size = new Size(30, 30);
            button8.TabIndex = 9;
            button8.UseVisualStyleBackColor = true;
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
            mainchat.ResumeLayout(false);
            mainchat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_friendAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label LB_name;
        private Button BT_avatar;
        private ListBox LBox_listFriends;
        private Label LB_UID;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button BT_search;
        private Button BT_send;
        private Button BT_sendFile;
        private Button button8;
        private RichTextBox richTextBox1;
        private Panel mainchat;
        private Button BT_call;
        private Button BT_setting;
        private Label LB_friendName;
        private PictureBox PB_friendAvatar;
        private Panel chatArea;
        private Panel addFriend;
        private Button BT_addFriend;
        private Button BT_findFriend;
        private Label label1;
        private TextBox TB_friendUID;
        private PictureBox PB_findResult;
        private TextBox TB_findResult;
    }
}