using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // new Logger().Write(null, new BL.LogInfo() { LogValue = "Console client is started" }); - // is too hard :)

            Console.WriteLine("Console client is started");

            BL.WatchDog wd = new BL.WatchDog();
            Logger logger = new Logger();

            wd.Parser.Loging += logger.Write;
            
            wd.Start();

            Console.ReadKey();
        }
    }
}
