using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WatchDog.UI
{
    public partial class FrmProcessList : Form
    {
        private Process[] _processes;
        private string _procName = "Notepad";
        private readonly string _specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);

        public FrmProcessList()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGetList_Click(object sender, EventArgs e)
        {
            BuildList();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var lastSlash = txtFileName.Text.LastIndexOf(@"\", StringComparison.Ordinal);

            var p = new ProcessStartInfo
            {
                FileName = txtFileName.Text,
                WindowStyle = ProcessWindowStyle.Normal,
                UseShellExecute = true,
                WorkingDirectory = txtFileName.Text.Substring(0, lastSlash)                
            };

            try
            {
                var proc = Process.Start(p);
                if (proc == null) return;
                proc.WaitForExit(10000);
                txtProcessName.Text = proc.ProcessName;
                BuildList();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error Encountered", MessageBoxButtons.OK);
                Console.WriteLine(exception);                
            }            
        }

        private void BuildList()
        {
            lvProcessList.Items.Clear();
            lvProcessList.Columns.Add("ProcessName");
            lvProcessList.Columns.Add("ProcessId");
            lvProcessList.View = View.Details;

            _processes = txtProcessName.Text.Length > 0 ? Process.GetProcessesByName(txtProcessName.Text) : Process.GetProcesses();

            foreach (var proc in _processes)
            {
                var name = proc.MainWindowTitle.Length > 0 ? proc.MainWindowTitle : proc.ProcessName;
                var lvItem = new ListViewItem(name);
                var itemAdd = lvProcessList.Items.Add(lvItem);                
                itemAdd.SubItems.Add(proc.Id.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _processes = Process.GetProcessesByName(_procName);
            foreach (var proc in _processes)
            {
                proc.CloseMainWindow();
                proc.WaitForExit();
            }
            BuildList();
        }
    }
}
