using System.Collections.Generic;
using Laba5.Models;
using Laba5.Tools;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace Laba5.ViewModels
{
    class ProcViewModel : BaseViewModel
    {
        private ObservableCollection<Proc> _procs;
        private Process selected;
        private ICommand _mod;

        public ObservableCollection<Proc> Procs
        {
            get => _procs;
            private set
            {
                _procs = value;
                OnPropertyChanged();
            }
        }

        public PerformanceCounter RamCounter { get; }
        public PerformanceCounter CpuCounter { get; }
        public int CpuTaken { get; }
        public double RamTaken { get; }
        public Process Selected
        {
            get => selected;
            set
            {
                selected = value;

                OnPropertyChanged();
                OnPropertyChanged("ProcessModules");
                
            }
        }
        public ProcessModuleCollection ProcessModules
        {
            get { return Selected?.Modules; }
        }
        public ICommand Mod
        {
            get { return _mod ?? (_mod = new RelayCommand<object>(ShowMod)); }
        }
        public void ShowMod(object obj)
        {
            
        }

        public ProcViewModel(int sortIndex = 1)
        {

            
                Thread myThread = new Thread(new ParameterizedThreadStart(Load));
                myThread.Start(sortIndex);
            


        }
        public void Load(object sortIndex)
        {
            
            _procs = new ObservableCollection<Proc>();
            var list = Process.GetProcesses();
            var sorted = new List<Process>();
            switch ((int)sortIndex)
            {
                case 0:

                    sorted = list.OrderBy(p => p.Id).ToList();
                    break;
                case 1:
                    sorted = list.OrderBy(p => p.ProcessName).ToList();
                    break;
                case 2:
                    sorted = list.OrderBy(p => p.Id).ToList();
                    break;
                case 3:
                    sorted = list.OrderBy(p => p.ProcessName).ToList();
                    break;
                case 4:
                    sorted = list.OrderBy(p => p.Id).ToList();
                    break;
                case 5:
                    sorted = list.OrderBy(p => p.Id).ToList();
                    break;
                case 6:
                    sorted = list.OrderBy(p => p.Id).ToList();
                    break;
                case 7:
                    try { sorted = list.OrderBy(p => p.StartTime).ToList(); }
                    catch
                    (Exception exp)
                    { }

                    break;
            }
            foreach (Process process in sorted)
            {
                string fullPath = "";

                int i = 0;
                var procs = _procs.ToList();
                //var cpuCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                //cpuCounter.NextValue();


                try
                {

                  // var RamCounter = new PerformanceCounter("Process", "Private Bytes", process.ProcessName);
                   // var CpuCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                    //int CpuTaken = Convert.ToInt32(CpuCounter.NextValue() / Environment.ProcessorCount);
                   //int RamTaken = Convert.ToInt32(Math.Round(RamCounter.NextValue() / (1024 * 1024), 2));
                    // bool IsResponding = System.Diagnostics.Process.GetProcessesByName(process.ProcessName).Any();
                    //string isworking = IsResponding.ToString();
                    string isworking = "";
                    var proc = Process.GetCurrentProcess();
                    fullPath = process.MainModule.FileName;
                    procs.Add(new Proc(process.ProcessName, process.Id, process.StartTime, process.MachineName, isworking, 3, process.VirtualMemorySize64, fullPath)); // , cpuCounter.NextValue()
                    Procs = new ObservableCollection<Proc>(procs);

                }
                catch
                    (Exception exp)
                { }


            }

        }
    }
}
