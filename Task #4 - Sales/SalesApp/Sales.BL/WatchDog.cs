using Sales.DataAccess.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace Sales.BL
{
    public class WatchDog
    {
        public FileSystemWatcher FSW { get; set; }
        public Parser Parser { get; private set; }

        public WatchDog() 
        {
            Parser = new Parser();

            //bool existed;
            //string guid = System.Runtime.InteropServices.Marshal.GetTypeLibGuidForAssembly(System.Reflection.Assembly.GetAssembly(typeof(BL.WatchDog))).ToString();

            //Mutex mutexObj = new Mutex(true, guid, out existed);
            //if (existed)
            //{
            //    Parser.Log("Is OK");
            //}
            //else
            //{
            //    Parser.Log("Fail");
            //    Thread.CurrentThread.Abort();
            //}

            string folder = ConfigurationManager.AppSettings["PathToFolderReports"];
            string extension = ConfigurationManager.AppSettings["ExtensionReports"];

            if (folder == null) throw new ArgumentException("The path to the report folder is not specified in the configuration file");
            if (extension == null) throw new ArgumentException("The extension of the report files is not specified in the configuration file");

            FSW = new FileSystemWatcher(ConfigurationManager.AppSettings["PathToFolderReports"], ConfigurationManager.AppSettings["ExtensionReports"]);
        }

        public void Start()
        {
            FSW.Created += fsw_Created;

            FSW.EnableRaisingEvents = true;

            Parser.Log(LogMessages.WatchDogStart);
        }

        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);

            Parser.Log(string.Format(LogMessages.FileAppend, e.FullPath));

            Task task = new Task(() => Parser.Parse(e.FullPath));
            task.Start();
        }
    }
}
