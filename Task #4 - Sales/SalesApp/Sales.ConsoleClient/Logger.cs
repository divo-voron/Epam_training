using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ConsoleClient
{
    public class Logger
    {
        public void Write(object sender, BL.LogInfo e)
        {
            Console.WriteLine(e.LogValue);
        }
    }
}
