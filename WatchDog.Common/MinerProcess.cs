using System;
using System.Diagnostics;
using System.Timers;

namespace WatchDog.Domain
{
    /// <summary>
    /// This class will handle the Miner Application Process Monitoring.  
    /// 1) Check to see if the Process has been started.
    /// 2) If the process has not been started and the AutoStart property is true, try and start it.
    /// </summary>
    public class MinerProcess
    {
        private int _processId;
        private int _retryCount;
        public int ProcessId => _processId;
        public string ProcessName { get; set; }
        public bool AutoStartMiner { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public event EventHandler<ProcessChangedEventArgs> StatusChangedEvent;

        private readonly Timer _minerTimer;

        public MinerProcess(string processName, bool autoStartProcess, string fileName, string filePath)
        {
            ProcessName = processName;
            AutoStartMiner = autoStartProcess;
            FileName = fileName;
            FilePath = filePath;
            _minerTimer = new Timer(10000);
            _minerTimer.Elapsed += CheckTimerEvent;
        }

        private void CheckTimerEvent(object sender, ElapsedEventArgs e)
        {                   
            //Check for an already running process
            var processList = Process.GetProcessesByName(ProcessName);

            foreach (var proc in processList)
            {
                _processId = proc.Id;
                //ProcessName = proc.ProcessName;                
                OnStatusChangedEvent($"{ProcessName}({_processId}) is running");
                return;
            }

            //Check to see if any command prompts are running.  If they are, don't try to start another instance yet.
            processList = Process.GetProcessesByName("cmd");
            if (processList.Length > 0 && _retryCount++ < 5)
            {
                OnStatusChangedEvent($"Process cmd found retry #{_retryCount}");
                return;
            }


            if (AutoStartMiner)
            {
                //Process is not started and the AutoStartMiner option has been checked, let's start id!
                var fileName = FileName;
                var workingFolder = FilePath;

                var p = new ProcessStartInfo
                {
                    FileName = fileName,
                    WindowStyle = ProcessWindowStyle.Normal,
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true,
                    WorkingDirectory = workingFolder
                };

                try
                {
                    using (var proc = new Process {StartInfo = p})
                    {
                        proc.Start();
                        //ProcessName = proc.ProcessName;
                        _processId = proc.Id;
                        OnStatusChangedEvent($"New {ProcessName}({_processId}) started.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }            
        }

        /// <summary>
        /// Event that is fired when the Process Status has changed.
        /// </summary>
        /// <param name="status"></param>
        protected virtual void OnStatusChangedEvent(string status)
        {
            var eventArgs = new ProcessChangedEventArgs
            {
                ProcessName = ProcessName,
                ProcessId = _processId,
                Status = status
            };
            StatusChangedEvent?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Start the Monitoring of the Miner Process.
        /// </summary>
        public void Start()
        {
            _minerTimer.Start();
            OnStatusChangedEvent("Started MinerProcess Timer");
        }

        /// <summary>
        /// Stop the Monitoring of the Miner Process.
        /// </summary>
        public void Stop()
        {
            _minerTimer.Stop();
            OnStatusChangedEvent("Stopped MinerProcess Timer");
        }

        public void Restart()
        {
            if (_processId > 0)
                Process.GetProcessById(_processId).Kill();
        }
    }
}