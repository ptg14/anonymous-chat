namespace anonymous_chat
{
    partial class Call
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
            PB_me = new PictureBox();
            PB_you = new PictureBox();
            BT_cam = new Button();
            BT_sound = new Button();
            BT_mic = new Button();
            BT_exit = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            CB_cam = new ComboBox();
            PBar_sound = new ProgressBar();
            PBar_resound = new ProgressBar();
            LB_log = new Label();
            ((System.ComponentModel.ISupportInitialize)PB_me).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PB_you).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // PB_me
            // 
            PB_me.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PB_me.Location = new Point(3, 3);
            PB_me.Name = "PB_me";
            PB_me.Size = new Size(382, 349);
            PB_me.TabIndex = 0;
            PB_me.TabStop = false;
            // 
            // PB_you
            // 
            PB_you.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PB_you.Location = new Point(391, 3);
            PB_you.Name = "PB_you";
            PB_you.Size = new Size(382, 349);
            PB_you.TabIndex = 1;
            PB_you.TabStop = false;
            // 
            // BT_cam
            // 
            BT_cam.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_cam.BackColor = Color.Red;
            BT_cam.Image = Properties.Resources.cam55x55;
            BT_cam.Location = new Point(261, 373);
            BT_cam.Name = "BT_cam";
            BT_cam.Size = new Size(65, 65);
            BT_cam.TabIndex = 2;
            BT_cam.UseVisualStyleBackColor = false;
            BT_cam.Click += BT_cam_Click;
            // 
            // BT_sound
            // 
            BT_sound.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BT_sound.Image = Properties.Resources.sound55x55;
            BT_sound.Location = new Point(332, 373);
            BT_sound.Name = "BT_sound";
            BT_sound.Size = new Size(65, 65);
            BT_sound.TabIndex = 3;
            BT_sound.UseVisualStyleBackColor = true;
            BT_sound.Click += BT_sound_Click;
            // 
            // BT_mic
            // 
            BT_mic.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BT_mic.BackColor = Color.Red;
            BT_mic.ForeColor = SystemColors.ControlText;
            BT_mic.Image = Properties.Resources.mic60x60;
            BT_mic.Location = new Point(403, 373);
            BT_mic.Name = "BT_mic";
            BT_mic.Size = new Size(65, 65);
            BT_mic.TabIndex = 4;
            BT_mic.UseVisualStyleBackColor = false;
            BT_mic.Click += BT_mic_Click;
            // 
            // BT_exit
            // 
            BT_exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BT_exit.Image = Properties.Resources.exitcall60x60;
            BT_exit.Location = new Point(474, 373);
            BT_exit.Name = "BT_exit";
            BT_exit.Size = new Size(65, 65);
            BT_exit.TabIndex = 5;
            BT_exit.UseVisualStyleBackColor = true;
            BT_exit.Click += BT_exit_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(PB_you, 1, 0);
            tableLayoutPanel1.Controls.Add(PB_me, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(776, 355);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // CB_cam
            // 
            CB_cam.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            CB_cam.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_cam.FormattingEnabled = true;
            CB_cam.Location = new Point(12, 374);
            CB_cam.Name = "CB_cam";
            CB_cam.Size = new Size(240, 28);
            CB_cam.TabIndex = 7;
            // 
            // PBar_sound
            // 
            PBar_sound.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PBar_sound.Location = new Point(545, 373);
            PBar_sound.Name = "PBar_sound";
            PBar_sound.Size = new Size(243, 29);
            PBar_sound.TabIndex = 8;
            // 
            // PBar_resound
            // 
            PBar_resound.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            PBar_resound.Location = new Point(545, 409);
            PBar_resound.Name = "PBar_resound";
            PBar_resound.Size = new Size(243, 29);
            PBar_resound.TabIndex = 9;
            // 
            // LB_log
            // 
            LB_log.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LB_log.Location = new Point(15, 413);
            LB_log.Name = "LB_log";
            LB_log.Size = new Size(237, 25);
            LB_log.TabIndex = 10;
            // 
            // Call
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LB_log);
            Controls.Add(PBar_resound);
            Controls.Add(PBar_sound);
            Controls.Add(CB_cam);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(BT_exit);
            Controls.Add(BT_mic);
            Controls.Add(BT_sound);
            Controls.Add(BT_cam);
            Name = "Call";
            Text = "Anonymous Chat";
            ((System.ComponentModel.ISupportInitialize)PB_me).EndInit();
            ((System.ComponentModel.ISupportInitialize)PB_you).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PB_me;
        private PictureBox PB_you;
        private Button BT_cam;
        private Button BT_sound;
        private Button BT_mic;
        private Button BT_exit;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox CB_cam;
        private ProgressBar PBar_sound;
        private ProgressBar PBar_resound;
        public Label LB_log;
    }
}