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
            BT_report = new Button();
            BT_guide = new Button();
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
            // BT_report
            // 
            BT_report.Location = new Point(3, 75);
            BT_report.Name = "BT_report";
            BT_report.Size = new Size(119, 30);
            BT_report.TabIndex = 2;
            BT_report.Text = "Báo cáo";
            BT_report.UseVisualStyleBackColor = true;
            BT_report.Click += BT_report_Click;
            // 
            // BT_guide
            // 
            BT_guide.Location = new Point(3, 111);
            BT_guide.Name = "BT_guide";
            BT_guide.Size = new Size(119, 30);
            BT_guide.TabIndex = 3;
            BT_guide.Text = "Hướng dẫn";
            BT_guide.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BT_guide);
            Controls.Add(BT_report);
            Controls.Add(BT_findGroup);
            Controls.Add(BT_group);
            Name = "Setting";
            Size = new Size(125, 147);
            ResumeLayout(false);
        }

        #endregion

        private Button BT_group;
        private Button BT_findGroup;
        private Button BT_report;
        private Button BT_guide;
    }
}
