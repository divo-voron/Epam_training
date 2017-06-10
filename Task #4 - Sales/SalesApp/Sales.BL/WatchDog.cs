using Sales.DataAccess.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL
{
    public class WatchDog
    {
        public FileSystemWatcher FSW { get; set; }
        public WatchDog() 
        {
            FSW = new FileSystemWatcher("D:\\1", "*.csv");
        }

        public void Start()
        {
            FSW.Created += fsw_Created;

            FSW.EnableRaisingEvents = true;
        }

        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            Parser parser = new Parser();
            parser.Parse(e.FullPath);
        }
    }
}
