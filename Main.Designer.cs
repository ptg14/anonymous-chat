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
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            BT_search = new Button();
            LB_listFriends = new ListBox();
            LB_UID = new Label();
            LB_name = new Label();
            BT_avatar = new Button();
            mainchat = new Panel();
            richTextBox1 = new RichTextBox();
            BT_send = new Button();
            BT_sendFile = new Button();
            button8 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            BT_setting = new Button();
            BT_call = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            mainchat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(button7);
            splitContainer1.Panel1.Controls.Add(button6);
            splitContainer1.Panel1.Controls.Add(button5);
            splitContainer1.Panel1.Controls.Add(button4);
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(BT_search);
            splitContainer1.Panel1.Controls.Add(LB_listFriends);
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
            // button7
            // 
            button7.Location = new Point(220, 59);
            button7.Name = "button7";
            button7.Size = new Size(30, 30);
            button7.TabIndex = 8;
            button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
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
            button4.Location = new Point(112, 59);
            button4.Name = "button4";
            button4.Size = new Size(30, 30);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(75, 59);
            button3.Name = "button3";
            button3.Size = new Size(30, 30);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
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
            // 
            // LB_listFriends
            // 
            LB_listFriends.BackColor = SystemColors.Info;
            LB_listFriends.FormattingEnabled = true;
            LB_listFriends.Location = new Point(3, 95);
            LB_listFriends.Name = "LB_listFriends";
            LB_listFriends.Size = new Size(246, 404);
            LB_listFriends.TabIndex = 0;
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
            mainchat.Controls.Add(BT_call);
            mainchat.Controls.Add(BT_setting);
            mainchat.Controls.Add(label1);
            mainchat.Controls.Add(pictureBox1);
            mainchat.Location = new Point(3, 3);
            mainchat.Name = "mainchat";
            mainchat.Size = new Size(619, 460);
            mainchat.TabIndex = 13;
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
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 6);
            label1.Name = "label1";
            label1.Size = new Size(97, 41);
            label1.TabIndex = 1;
            label1.Text = "Name";
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
            // BT_call
            // 
            BT_call.Image = Properties.Resources.phone40x40;
            BT_call.Location = new Point(510, 3);
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
            mainchat.ResumeLayout(false);
            mainchat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label LB_name;
        private Button BT_avatar;
        private ListBox LB_listFriends;
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
        private Label label1;
        private PictureBox pictureBox1;
    }
}