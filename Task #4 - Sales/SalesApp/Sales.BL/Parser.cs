using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.DataAccess;

namespace Sales.BL
{
    class Parser
    {
        DataAccess.SalesDataContainer _salesData;
        ICollection<Operation> _operations;
        public Parser() 
        {
            _salesData = new SalesDataContainer();
            _operations = new List<Operation>();
        }
        public void Parse(string path)
        {
            Validate validator = new Validate();
            string managerName;
            DateTime dateOfFile;
            if (validator.CheckFileName(path, out managerName, out dateOfFile))
                using (StreamReader sr = new StreamReader(path))
                {
                    while (true)
                    {
                        string line = sr.ReadLine();
                        if (line == null) break;
                        else
                            if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] data = line.Split(';');

                        if (validator.CheckData(data) == false) LogError(data);
                        else
                            _operations.Add(new Operation(data));
                    }

                    WriteToBase(managerName, dateOfFile);
                }
        }

        private void WriteToBase(string managerName, DateTime dateOfFile)
        {
            lock (this)
            {
                foreach (Operation operation in _operations)
                {
                    _salesData.AddOperation(operation.Date, managerName, operation.ClientName, operation.ProductName, 123, operation.Price);
                }
            }
        }

        private void LogError(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
