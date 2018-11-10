namespace WatchDog.UI
{
    partial class frmWatchDog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWatchDog));
            this.tmr_Process = new System.Windows.Forms.Timer(this.components);
            this.btn_Process = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsStatus = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsStatusMessage = new System.Windows.Forms.ToolStripLabel();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.watchDogNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkMinimized = new System.Windows.Forms.CheckBox();
            this.lblMessageCount = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmr_Process
            // 
            this.tmr_Process.Interval = 60000;
            this.tmr_Process.Tick += new System.EventHandler(this.tmr_Process_Tick);
            // 
            // btn_Process
            // 
            this.btn_Process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Process.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Process.Location = new System.Drawing.Point(426, 21);
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(70, 35);
            this.btn_Process.TabIndex = 0;
            this.btn_Process.Text = "Start";
            this.btn_Process.UseVisualStyleBackColor = true;
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTime,
            this.toolStripSeparator4,
            this.tsStatus,
            this.toolStripSeparator1,
            this.tsStatusMessage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 67);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(508, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsTime
            // 
            this.tsTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsTime.Name = "tsTime";
            this.tsTime.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsStatus
            // 
            this.tsStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(51, 22);
            this.tsStatus.Text = "Stopped";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsStatusMessage
            // 
            this.tsStatusMessage.Name = "tsStatusMessage";
            this.tsStatusMessage.Size = new System.Drawing.Size(39, 22);
            this.tsStatusMessage.Text = "Status";
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 500;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // watchDogNotifyIcon
            // 
            this.watchDogNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.watchDogNotifyIcon.BalloonTipText = "Miner WatchDog";
            this.watchDogNotifyIcon.BalloonTipTitle = "WatchDog";
            this.watchDogNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("watchDogNotifyIcon.Icon")));
            this.watchDogNotifyIcon.Text = "Miner WatchDog";
            this.watchDogNotifyIcon.Visible = true;
            this.watchDogNotifyIcon.Click += new System.EventHandler(this.watchDogNotifyIcon_Click);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Checked = global::WatchDog.UI.Properties.Settings.Default.AutoStart;
            this.chkAutoStart.Location = new System.Drawing.Point(12, 12);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(73, 17);
            this.chkAutoStart.TabIndex = 7;
            this.chkAutoStart.Text = "Auto Start";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // chkMinimized
            // 
            this.chkMinimized.AutoSize = true;
            this.chkMinimized.Checked = global::WatchDog.UI.Properties.Settings.Default.StartMinimized;
            this.chkMinimized.Location = new System.Drawing.Point(12, 35);
            this.chkMinimized.Name = "chkMinimized";
            this.chkMinimized.Size = new System.Drawing.Size(97, 17);
            this.chkMinimized.TabIndex = 8;
            this.chkMinimized.Text = "Start Minimized";
            this.chkMinimized.UseVisualStyleBackColor = true;
            // 
            // lblMessageCount
            // 
            this.lblMessageCount.AutoSize = true;
            this.lblMessageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageCount.Location = new System.Drawing.Point(235, 16);
            this.lblMessageCount.Name = "lblMessageCount";
            this.lblMessageCount.Size = new System.Drawing.Size(36, 39);
            this.lblMessageCount.TabIndex = 9;
            this.lblMessageCount.Text = "0";
            // 
            // frmWatchDog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 92);
            this.Controls.Add(this.lblMessageCount);
            this.Controls.Add(this.chkMinimized);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btn_Process);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::WatchDog.UI.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::WatchDog.UI.Properties.Settings.Default.Location;
            this.Name = "frmWatchDog";
            this.Text = "WatchDog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWatchDog_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.frmWatchDog_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmr_Process;
        private System.Windows.Forms.Button btn_Process;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsTime;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.NotifyIcon watchDogNotifyIcon;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkMinimized;
        private System.Windows.Forms.ToolStripLabel tsStatusMessage;
        private System.Windows.Forms.Label lblMessageCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

