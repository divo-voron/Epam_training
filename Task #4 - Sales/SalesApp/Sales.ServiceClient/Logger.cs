using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ServiceClient
{
    class Logger
    {
        static object locker = new object();
        public void Write(object sender, BL.LogInfo e)
        {
            lock (locker)
            {
                string fileName = System.Configuration.ConfigurationManager.AppSettings["PathToLog"];
                if (fileName != null)
                {
                    File.AppendAllText(fileName, string.Format("{0}: {1}\r\n", DateTime.Now, e.LogValue));
                }
            }
        }
    }
}
