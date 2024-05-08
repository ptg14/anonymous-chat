namespace anonymous_chat
{
    partial class SignIn_SignUp
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
            dangNhap = new Chat.SignIn();
            dangKy = new Chat.SignUp();
            SuspendLayout();
            // 
            // dangNhap
            // 
            dangNhap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dangNhap.BackColor = SystemColors.Control;
            dangNhap.Location = new Point(12, 12);
            dangNhap.Name = "dangNhap";
            dangNhap.SignUp = null;
            dangNhap.Size = new Size(681, 482);
            dangNhap.TabIndex = 0;
            // 
            // dangKy
            // 
            dangKy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dangKy.Location = new Point(12, 12);
            dangKy.Name = "dangKy";
            dangKy.SignIn = null;
            dangKy.Size = new Size(681, 482);
            dangKy.TabIndex = 1;
            dangKy.Visible = false;
            // 
            // SignIn_SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 506);
            Controls.Add(dangKy);
            Controls.Add(dangNhap);
            Name = "SignIn_SignUp";
            Text = "Anonymous Chat";
            Icon = new Icon("resource\\icon.ico");
            ResumeLayout(false);
        }

        #endregion

        private static Chat.SignIn dangNhap;
        private static Chat.SignUp dangKy;
    }
}