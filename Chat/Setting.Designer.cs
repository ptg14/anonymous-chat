namespace anonymous_chat.Chat
{
    partial class Setting
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
            BT_group = new Button();
            BT_findGroup = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // BT_group
            // 
            BT_group.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BT_group.Location = new Point(3, 3);
            BT_group.Name = "BT_group";
            BT_group.Size = new Size(119, 30);
            BT_group.TabIndex = 0;
            BT_group.Text = "Tạo nhóm";
            BT_group.UseVisualStyleBackColor = true;
            BT_group.Click += BT_group_Click;
            // 
            // BT_findGroup
            // 
            BT_findGroup.Location = new Point(3, 39);
            BT_findGroup.Name = "BT_findGroup";
            BT_findGroup.Size = new Size(119, 30);
            BT_findGroup.TabIndex = 1;
            BT_findGroup.Text = "Tìm nhóm";
            BT_findGroup.UseVisualStyleBackColor = true;
            BT_findGroup.Click += BT_findGroup_Click;
            // 
            // button3
            // 
            button3.Location = new Point(3, 75);
            button3.Name = "button3";
            button3.Size = new Size(119, 30);
            button3.TabIndex = 2;
            button3.Text = "Báo cáo";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(3, 111);
            button4.Name = "button4";
            button4.Size = new Size(119, 30);
            button4.TabIndex = 3;
            button4.Text = "Trợ giúp";
            button4.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(BT_findGroup);
            Controls.Add(BT_group);
            Name = "Setting";
            Size = new Size(125, 147);
            ResumeLayout(false);
        }

        #endregion

        private Button BT_group;
        private Button BT_findGroup;
        private Button button3;
        private Button button4;
    }
}
