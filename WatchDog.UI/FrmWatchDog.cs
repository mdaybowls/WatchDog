using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WatchDog.Domain;
using WatchDog.Domain.HardwareMonitor;

namespace WatchDog.UI
{
    // ReSharper disable once InconsistentNaming
    public partial class frmWatchDog : Form
    {
        private int _messageCounter;
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private readonly MinerProcess _minerProcess;

        public frmWatchDog()
        {
            InitializeComponent();

            var processName = Properties.Settings.Default.MinerProcessName;

            _minerProcess = new MinerProcess(processName, Properties.Settings.Default.AutoStartMiner,
                Properties.Settings.Default.MinerPath, Properties.Settings.Default.MinerWorkingFolder);
            _minerProcess.StatusChangedEvent += StatusChangedEvent;
            _minerProcess.Start();

            if (Properties.Settings.Default.AutoStartMiner)
            {
                lblProcessName.ForeColor = Color.Green;
                lblProcessId.ForeColor = Color.Green;
            }

            //var logger = new Logger();
            //var messageHandler = new SubscriptionMessageHandler(logger);
            //var messageController = new SubscriptionMessageController(logger, messageHandler);
            //messageController.OnRestartMiner += OnRestartMiner;
            //messageController.StartReceiving();
        }

        private void OnRestartMiner(object sender, EventArgs e)
        {
            _minerProcess.Restart();
        }

        private void StatusChangedEvent(object sender, ProcessChangedEventArgs e)
        {
            lblProcessId.Text = e.ProcessId.ToString();
            lblProcessName.Text = e.ProcessName;
            UpdateStatus(e.Status);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmr_Process.Interval = 5000;
            tmr_Process.Enabled = true;
            UpdateStatus("Started");
            tsStatus.Text = @"Started";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            _stopWatch.Start();
        }

        private void tmr_Process_Tick(object sender, EventArgs e)
        {
            try
            {
                //var publisher = new Publisher();
                //publisher.SendMessageAsync("TEST").GetAwaiter();

                tmr_Process.Enabled = false;
                var hardwareHelper = new HardwareMonitorHelper();
                var machine = hardwareHelper.GetSystemInfo();
                machine.CustomerId = Properties.Settings.Default.CustomerId;
                machine.AccessCode = Properties.Settings.Default.AccessCode;
                _messageCounter++;
                UpdateStatus("Message Sent");
                watchDogNotifyIcon.Text = $@"WatchDog Running {_messageCounter}";
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                tmr_Process.Interval = 60000;
                tmr_Process.Enabled = true;
            }
        }

        private void UpdateStatus(string status)
        {
            tsStatusMessage.Text = $@"{DateTime.Now} : {status}";
            lblMessageCount.Text = _messageCounter.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.Location;
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            tsTime.Text = DateTime.Now.ToLongTimeString();
            tsElapsed.Text = $@"{_stopWatch.Elapsed.Hours:00}:{_stopWatch.Elapsed.Minutes:00}:{_stopWatch.Elapsed.Seconds:00}";
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
            if (Properties.Settings.Default.AutoStart)
                btnStart.PerformClick();
            if (Properties.Settings.Default.StartMinimized)
                WindowState = FormWindowState.Minimized;
        }

        private void frmWatchDog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Location = Location;
            Properties.Settings.Default.Save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSettings = new FrmSettings();
            formSettings.ShowDialog(this);
            _minerProcess.Stop();
            _minerProcess.ProcessName = Properties.Settings.Default.MinerProcessName;
            _minerProcess.FilePath = Properties.Settings.Default.MinerWorkingFolder;
            _minerProcess.FileName = Properties.Settings.Default.MinerPath;
            _minerProcess.AutoStartMiner = Properties.Settings.Default.AutoStartMiner;
            _minerProcess.Start();
        }

        private void processListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmProcessList = new FrmProcessList();
            frmProcessList.ShowDialog(this);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmr_Process.Enabled = false;
            UpdateStatus("Stopped");
            tsStatus.Text = @"Stopped";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            _stopWatch.Stop();
        }
    }
}