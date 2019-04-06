using System;
using Laba5.Tools;

namespace Laba5.Models
{
    [Serializable]
    class Proc : BaseViewModel
    {
    
        #region Fields
       
        private string _processName;
        public int ProcessId { get; private set; }
        public float ProcessLoad { get; private set; }

   
        public float MemoryUse { get; private set; }
        public string Modules{ get;  set; }
        public string MachineName { get; private set; }
        public DateTime StartTime { get; private set; }
        string  now = DateTime.Now.ToString();
        private string taskStatus;

        #endregion

        #region Properties
        
        

        public string ProcessName
        {
            get
            {
                return _processName;
            }
            private set
            {
                _processName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public Proc(string processName, int processId, float processLoad = 0)
        {
            _processName = processName;
            ProcessId = processId;
            ProcessLoad = processLoad;
        }
        public Proc(string processName, int processId, DateTime starttime, string machineName, string _taskStatus, float processLoad = 0,  float memoryUse =0, string modules ="")
        {
            _processName = processName;
            ProcessId = processId;
            ProcessLoad = processLoad;
            taskStatus = _taskStatus;
            MemoryUse = memoryUse;
            Modules = modules;
            MachineName = machineName;
            StartTime = starttime;
        }
    }
    
}
