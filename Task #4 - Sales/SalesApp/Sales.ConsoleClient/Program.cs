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
            Logger logger = new Logger();
            logger.Write(null, new BL.LogInfo() { LogValue = "Console client is started" });

            BL.WatchDog wd = new BL.WatchDog();            

            wd.Parser.Loging += logger.Write;

            wd.Start();

            Console.ReadKey();
        }
    }
}
