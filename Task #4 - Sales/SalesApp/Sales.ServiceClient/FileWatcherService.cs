﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ServiceClient
{
    public partial class FileWatcherService : ServiceBase
    {
        private BL.WatchDog _wd;
        private Logger _logger;
        private Task _task;
        public FileWatcherService()
        {
            InitializeComponent();

            this.CanStop = true;
            this.CanPauseAndContinue = true;

            _wd = new BL.WatchDog();
            _logger = new Logger();
            _task = new Task(_wd.Start);
        }

        protected override void OnStart(string[] args)
        {
            _logger.Write(null, new BL.LogInfo() { LogValue = LogMessages.Start });
            _wd.Parser.Loging += _logger.Write;
            _task.Start();
        }

        
        protected override void OnPause()
        {
            _logger.Write(null, new BL.LogInfo() { LogValue = LogMessages.Pause });
            _wd.Parser.Loging -= _logger.Write;
            _task.Dispose();
        }

        protected override void OnContinue()
        {
            _logger.Write(null, new BL.LogInfo() { LogValue = LogMessages.Continue });
            _wd.Parser.Loging += _logger.Write;
            _task.Start();
        }
        protected override void OnStop()
        {
            _logger.Write(null, new BL.LogInfo() { LogValue = LogMessages.Stop });
            _wd.Parser.Loging -= _logger.Write;
            _task.Dispose();
        }
    }
}
