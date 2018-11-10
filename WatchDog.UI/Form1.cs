using System;
using System.Windows.Forms;
using WatchDog.Azure.StorageQueue;
using WatchDog.Domain.HardwareMonitor;

namespace WatchDog.UI
{
    // ReSharper disable once InconsistentNaming
    public partial class frmWatchDog : Form
    {
        private int _messageCounter;

        public frmWatchDog()
        {
            InitializeComponent();
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            tmr_Process.Interval = 5000;
            tmr_Process.Enabled = !tmr_Process.Enabled;

            if (tmr_Process.Enabled)
            {
                tsStatus.Text = @"Running";
                btn_Process.Text = @"Stop";
                UpdateStatus("Started");
            }
            else
            {
                tsStatus.Text = @"Stopped";
                btn_Process.Text = @"Start";
                UpdateStatus("Stopped");
            }
        }

        private void tmr_Process_Tick(object sender, EventArgs e)
        {
            tmr_Process.Enabled = false;           
            var hardwareHelper = new HardwareMonitorHelper();
            var machine = hardwareHelper.GetSystemInfo();
            var messageQueue = new MessageQueue();
            messageQueue.SendMessage(machine);
            _messageCounter++;
            UpdateStatus("Message Sent");
            watchDogNotifyIcon.Text = $@"WatchDog Running {_messageCounter}";
            tmr_Process.Interval = 60000;
            tmr_Process.Enabled = true;
        }

        private void UpdateStatus(string status)
        {
            tsStatusMessage.Text = $@"{DateTime.Now} : {status}";
            lblMessageCount.Text = _messageCounter.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkMinimized.Checked = Properties.Settings.Default.StartMinimized;
            chkAutoStart.Checked = Properties.Settings.Default.AutoStart;
            Location = Properties.Settings.Default.Location;
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            tsTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                watchDogNotifyIcon.Visible = true;
                watchDogNotifyIcon.ShowBalloonTip(500);
                watchDogNotifyIcon.Text = tmr_Process.Enabled ? $"WatchDog Running {_messageCounter}" : $"WatchDog Paused {_messageCounter}";
                Hide();
            }
            else if (FormWindowState.Normal == WindowState)
            {
                watchDogNotifyIcon.Visible = false;
            }
        }

        private void watchDogNotifyIcon_Click(object sender, EventArgs e)
        {
            watchDogNotifyIcon.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void frmWatchDog_Shown(object sender, EventArgs e)
        {
            if (chkAutoStart.Checked)
                btn_Process.PerformClick();
            if (chkMinimized.Checked)
                WindowState = FormWindowState.Minimized;
        }

        private void frmWatchDog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.AutoStart = chkAutoStart.Checked;
            Properties.Settings.Default.StartMinimized = chkMinimized.Checked;
            Properties.Settings.Default.Location = Location;
            Properties.Settings.Default.Save();
        }
    }
}