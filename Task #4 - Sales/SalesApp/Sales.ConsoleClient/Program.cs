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
            BL.WatchDog wd = new BL.WatchDog();
            Logger logger = new Logger();

            wd.Parser.Loging += logger.Write;
            
            wd.Start();

            Console.ReadLine();
        }
    }
}
