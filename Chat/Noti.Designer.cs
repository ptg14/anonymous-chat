namespace anonymous_chat.Chat
{
    partial class Noti
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
            LB_title = new Label();
            BT_yes = new Button();
            BT_no = new Button();
            SuspendLayout();
            // 
            // LB_title
            // 
            LB_title.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_title.Location = new Point(3, 9);
            LB_title.Name = "LB_title";
            LB_title.Size = new Size(218, 46);
            LB_title.TabIndex = 0;
            LB_title.Text = "2205 đã gửi lời mời kết bạn";
            // 
            // BT_yes
            // 
            BT_yes.Location = new Point(6, 58);
            BT_yes.Name = "BT_yes";
            BT_yes.Size = new Size(94, 29);
            BT_yes.TabIndex = 1;
            BT_yes.Text = "Đồng ý";
            BT_yes.UseVisualStyleBackColor = true;
            BT_yes.Click += BT_yes_Click;
            // 
            // BT_no
            // 
            BT_no.Location = new Point(127, 58);
            BT_no.Name = "BT_no";
            BT_no.Size = new Size(94, 29);
            BT_no.TabIndex = 2;
            BT_no.Text = "Từ chối";
            BT_no.UseVisualStyleBackColor = true;
            BT_no.Click += BT_no_Click;
            // 
            // Noti
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(BT_no);
            Controls.Add(BT_yes);
            Controls.Add(LB_title);
            Name = "Noti";
            Size = new Size(244, 93);
            ResumeLayout(false);
        }

        #endregion

        private Label LB_title;
        private Button BT_yes;
        private Button BT_no;
    }
}
