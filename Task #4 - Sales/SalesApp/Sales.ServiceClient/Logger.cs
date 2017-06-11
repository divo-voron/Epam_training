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
        public void Write(object sender, BL.LogInfo e)
        {
            string fileName = System.Configuration.ConfigurationManager.AppSettings["PathToLog"];
            if (fileName != null)
            {
                File.AppendAllText(fileName, e.LogValue);
            }
        }
    }
}
