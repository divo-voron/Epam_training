using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL
{
    class Parser
    {
        public void Parse(string path)
        {
            //DataAccess.SalesDataContainer sd = new DataAccess.SalesDataContainer();

            //ICollection<Operation> operations = new List<Operation>();

            //StreamReader sr = new StreamReader(path);

            //while (true)
            //{
            //    string line = sr.ReadLine();
            //    if (line == null) break;
            //    else
            //        if (string.IsNullOrWhiteSpace(line)) continue;

            //    string[] data = line.Split(';');

            //    if (new Validate().Check(data) == false) LogError(data);
            //    else
            //    {
            //        //operations.Add(new Operation(data));

            //        sd.AddClient(new Sales.DAL.Component.Client(data[1]));
            //    }
            //}

            //sd.Save();
        }

        private void LogError(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
