namespace anonymous_chat.Chat
{
    partial class ChatItem
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
            authorPanel = new Panel();
            authorLabel = new Label();
            bodyPanel = new Panel();
            bodyTextBox = new TextBox();
            authorPanel.SuspendLayout();
            bodyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // authorPanel
            // 
            authorPanel.Controls.Add(authorLabel);
            authorPanel.Dock = DockStyle.Bottom;
            authorPanel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            authorPanel.ForeColor = SystemColors.ButtonShadow;
            authorPanel.Location = new Point(14, 69);
            authorPanel.Margin = new Padding(5, 4, 5, 4);
            authorPanel.Name = "authorPanel";
            authorPanel.Padding = new Padding(0, 8, 0, 0);
            authorPanel.Size = new Size(780, 40);
            authorPanel.TabIndex = 8;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Dock = DockStyle.Left;
            authorLabel.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            authorLabel.Location = new Point(0, 8);
            authorLabel.Margin = new Padding(5, 0, 5, 0);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(142, 19);
            authorLabel.TabIndex = 0;
            authorLabel.Text = "System - 10/05/2024";
            // 
            // bodyPanel
            // 
            bodyPanel.BackColor = Color.RoyalBlue;
            bodyPanel.Controls.Add(bodyTextBox);
            bodyPanel.Dock = DockStyle.Left;
            bodyPanel.Location = new Point(14, 8);
            bodyPanel.Margin = new Padding(5, 4, 5, 4);
            bodyPanel.Name = "bodyPanel";
            bodyPanel.Padding = new Padding(2, 3, 2, 3);
            bodyPanel.Size = new Size(485, 61);
            bodyPanel.TabIndex = 9;
            // 
            // bodyTextBox
            // 
            bodyTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bodyTextBox.BackColor = Color.RoyalBlue;
            bodyTextBox.BorderStyle = BorderStyle.None;
            bodyTextBox.Font = new Font("Segoe UI Emoji", 9F);
            bodyTextBox.ForeColor = Color.White;
            bodyTextBox.Location = new Point(7, 8);
            bodyTextBox.Margin = new Padding(5, 4, 5, 4);
            bodyTextBox.Multiline = true;
            bodyTextBox.Name = "bodyTextBox";
            bodyTextBox.ReadOnly = true;
            bodyTextBox.Size = new Size(471, 47);
            bodyTextBox.TabIndex = 4;
            bodyTextBox.Text = "This is a test for the longer word usage.";
            // 
            // ChatItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(bodyPanel);
            Controls.Add(authorPanel);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ChatItem";
            Padding = new Padding(14, 8, 14, 8);
            Size = new Size(808, 117);
            authorPanel.ResumeLayout(false);
            authorPanel.PerformLayout();
            bodyPanel.ResumeLayout(false);
            bodyPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel authorPanel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.TextBox bodyTextBox;
    }
}
