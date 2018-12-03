using System;
using System.Windows.Forms;

namespace WatchDog.UI
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtCustomerId.Text = Properties.Settings.Default.CustomerId;
            txtAccessCode.Text = Properties.Settings.Default.AccessCode;
            chkAutoStart.Checked = Properties.Settings.Default.AutoStart;
            chkStartMinimized.Checked = Properties.Settings.Default.StartMinimized;
            txtMinerPath.Text = Properties.Settings.Default.MinerPath;
            chkAutoStartMiner.Checked = Properties.Settings.Default.AutoStartMiner;
            txtMinerWorkingFolder.Text = Properties.Settings.Default.MinerWorkingFolder;
            txtProcessName.Text = Properties.Settings.Default.MinerProcessName;
            Location = Properties.Settings.Default.Location;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CustomerId = txtCustomerId.Text;
            Properties.Settings.Default.AccessCode = txtAccessCode.Text;
            Properties.Settings.Default.AutoStart = chkAutoStart.Checked;
            Properties.Settings.Default.StartMinimized = chkStartMinimized.Checked;
            Properties.Settings.Default.MinerPath = txtMinerPath.Text;
            Properties.Settings.Default.AutoStartMiner = chkAutoStartMiner.Checked;
            Properties.Settings.Default.MinerWorkingFolder = txtMinerWorkingFolder.Text;
            Properties.Settings.Default.MinerProcessName = txtProcessName.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
