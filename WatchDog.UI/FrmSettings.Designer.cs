namespace WatchDog.UI
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtAccessCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinerPath = new System.Windows.Forms.TextBox();
            this.chkAutoStartMiner = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinerWorkingFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Access Code:";
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkAutoStart.Location = new System.Drawing.Point(73, 154);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(73, 17);
            this.chkAutoStart.TabIndex = 2;
            this.chkAutoStart.Text = "Auto Start";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chkStartMinimized.Location = new System.Drawing.Point(49, 200);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(97, 17);
            this.chkStartMinimized.TabIndex = 3;
            this.chkStartMinimized.Text = "Start Minimized";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(499, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(581, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(133, 13);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(523, 20);
            this.txtCustomerId.TabIndex = 6;
            // 
            // txtAccessCode
            // 
            this.txtAccessCode.Location = new System.Drawing.Point(133, 40);
            this.txtAccessCode.Name = "txtAccessCode";
            this.txtAccessCode.Size = new System.Drawing.Size(523, 20);
            this.txtAccessCode.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Miner Path:";
            // 
            // txtMinerPath
            // 
            this.txtMinerPath.Location = new System.Drawing.Point(133, 68);
            this.txtMinerPath.Name = "txtMinerPath";
            this.txtMinerPath.Size = new System.Drawing.Size(523, 20);
            this.txtMinerPath.TabIndex = 9;
            // 
            // chkAutoStartMiner
            // 
            this.chkAutoStartMiner.AutoSize = true;
            this.chkAutoStartMiner.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoStartMiner.Location = new System.Drawing.Point(44, 177);
            this.chkAutoStartMiner.Name = "chkAutoStartMiner";
            this.chkAutoStartMiner.Size = new System.Drawing.Size(102, 17);
            this.chkAutoStartMiner.TabIndex = 10;
            this.chkAutoStartMiner.Text = "Auto Start Miner";
            this.chkAutoStartMiner.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Miner Working Folder:";
            // 
            // txtMinerWorkingFolder
            // 
            this.txtMinerWorkingFolder.Location = new System.Drawing.Point(134, 97);
            this.txtMinerWorkingFolder.Name = "txtMinerWorkingFolder";
            this.txtMinerWorkingFolder.Size = new System.Drawing.Size(522, 20);
            this.txtMinerWorkingFolder.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Process Name:";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(133, 126);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(523, 20);
            this.txtProcessName.TabIndex = 14;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 275);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMinerWorkingFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAutoStartMiner);
            this.Controls.Add(this.txtMinerPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccessCode);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkStartMinimized);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Text = "WatchDog Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtAccessCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMinerPath;
        private System.Windows.Forms.CheckBox chkAutoStartMiner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinerWorkingFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProcessName;
    }
}