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
            //DataAccess.SalesDataContainer sd = new DataAccess.SalesDataContainer();
            //var a = sd.Clients.First();

            //Client client = new Client(0, "Vitaly");
            //Manager manager = sd.Managers.Last();
            //Product product = sd.Products.Last();
            //Session session = sd.Sessions.Last();

            //DataAccess.Components.Operation op = new DataAccess.Components.Operation()
            //{
            //    Client = client,
            //    Manager = manager,
            //    Product = product,
            //    Session = session,
            //    DateOfOperation = DateTime.Now,
            //    Price = 12
            //};

            //sd.AddOperation(op);

            //sd.Save();

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
