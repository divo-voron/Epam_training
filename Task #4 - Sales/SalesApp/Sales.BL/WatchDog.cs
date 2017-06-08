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
            FSW = new FileSystemWatcher();
        }

        public void Start()
        {
            DataAccess.SalesDataContainer sd = new DataAccess.SalesDataContainer();
            var a = sd.Clients.ToList();

            sd.AddClient("Valera");
            sd.Save();

            foreach (IClient client in sd.Clients)
            {
                Console.WriteLine(client.Name);
            }
    
            //new Parser().Parse("D:\\1\\123.csv");


            //FSW.Path = "D:\\1";

            //FSW.Created += fsw_Created;
            
            //FSW.EnableRaisingEvents = true;
        }

        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            new Parser().Parse(e.FullPath);
        }
    }
}
