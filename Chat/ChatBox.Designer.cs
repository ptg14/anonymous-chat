using anonymous_chat.Properties;
using static System.Windows.Forms.MonthCalendar;

namespace anonymous_chat.Chat
{
    partial class ChatBox
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
            ChatPanel = new Panel();
            BT_send = new Button();
            BT_clear = new Button();
            BT_file = new Button();
            TB_message = new TextBox();
            bottomPanel = new Panel();
            LB_fileName = new Label();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ChatPanel
            // 
            ChatPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChatPanel.AutoScroll = true;
            ChatPanel.BackColor = SystemColors.Window;
            ChatPanel.Location = new Point(0, 0);
            ChatPanel.Margin = new Padding(4, 3, 4, 3);
            ChatPanel.Name = "ChatPanel";
            ChatPanel.Size = new Size(619, 360);
            ChatPanel.TabIndex = 1;
            // 
            // BT_send
            // 
            BT_send.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BT_send.BackColor = Color.RoyalBlue;
            BT_send.FlatStyle = FlatStyle.Flat;
            BT_send.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            BT_send.Location = new Point(537, 15);
            BT_send.Margin = new Padding(4, 3, 4, 3);
            BT_send.Name = "BT_send";
            BT_send.Size = new Size(78, 50);
            BT_send.TabIndex = 1;
            BT_send.Text = "Send";
            BT_send.UseVisualStyleBackColor = false;
            // 
            // BT_clear
            // 
            BT_clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BT_clear.BackColor = Color.Red;
            BT_clear.FlatStyle = FlatStyle.Popup;
            BT_clear.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Bold);
            BT_clear.ForeColor = SystemColors.ControlLightLight;
            BT_clear.Location = new Point(515, 15);
            BT_clear.Margin = new Padding(4, 3, 4, 3);
            BT_clear.Name = "BT_clear";
            BT_clear.Size = new Size(20, 50);
            BT_clear.TabIndex = 5;
            BT_clear.Text = "X";
            BT_clear.UseVisualStyleBackColor = false;
            BT_clear.Visible = false;
            // 
            // BT_file
            // 
            BT_file.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BT_file.BackColor = Color.GhostWhite;
            BT_file.BackgroundImageLayout = ImageLayout.Center;
            BT_file.FlatStyle = FlatStyle.Flat;
            BT_file.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BT_file.ForeColor = SystemColors.ControlText;
            BT_file.Image = Resources.folder20x20;
            BT_file.Location = new Point(463, 15);
            BT_file.Margin = new Padding(4, 3, 4, 3);
            BT_file.Name = "BT_file";
            BT_file.Size = new Size(50, 50);
            BT_file.TabIndex = 6;
            BT_file.UseVisualStyleBackColor = false;
            // 
            // TB_message
            // 
            TB_message.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TB_message.Location = new Point(4, 15);
            TB_message.Margin = new Padding(4, 3, 4, 3);
            TB_message.Multiline = true;
            TB_message.Name = "TB_message";
            TB_message.Size = new Size(459, 50);
            TB_message.TabIndex = 7;
            // 
            // bottomPanel
            // 
            bottomPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bottomPanel.BackColor = Color.PowderBlue;
            bottomPanel.Controls.Add(LB_fileName);
            bottomPanel.Controls.Add(BT_send);
            bottomPanel.Controls.Add(BT_clear);
            bottomPanel.Controls.Add(TB_message);
            bottomPanel.Controls.Add(BT_file);
            bottomPanel.ForeColor = SystemColors.ControlLightLight;
            bottomPanel.Location = new Point(0, 360);
            bottomPanel.Margin = new Padding(4, 3, 4, 3);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(18, 12, 18, 12);
            bottomPanel.Size = new Size(619, 80);
            bottomPanel.TabIndex = 0;
            // 
            // LB_fileName
            // 
            LB_fileName.AutoSize = true;
            LB_fileName.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_fileName.ForeColor = Color.Red;
            LB_fileName.Location = new Point(483, 0);
            LB_fileName.Name = "LB_fileName";
            LB_fileName.Size = new Size(0, 12);
            LB_fileName.TabIndex = 2;
            // 
            // ChatBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(bottomPanel);
            Controls.Add(ChatPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChatBox";
            Size = new Size(619, 440);
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        public Panel ChatPanel;
        private Panel bottomPanel;

        private System.Windows.Forms.Button BT_clear;
        public System.Windows.Forms.Button BT_send;
        private System.Windows.Forms.Button BT_file;
        private System.Windows.Forms.TextBox TB_message;
        private Label LB_fileName;
    }
}
