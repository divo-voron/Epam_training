using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.DataAccess;
using System.Threading;

namespace Sales.BL
{
    public class Parser
    {
        private EventHandler<LogInfo> _loging;
        public event EventHandler<LogInfo> Loging
        {
            add { _loging += value; }
            remove { _loging -= value; }
        }
        private void OnLog(LogInfo logInfo)
        {
            if (_loging != null) _loging(this, logInfo);
        }

        private static Mutex mutexObj = new Mutex();

        private static DataAccess.SalesDataContainer _salesData;
        private ICollection<Operation> _operations;

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

                        if (validator.CheckData(data) == false) LogError(line);
                        else
                            _operations.Add(new Operation(data));
                    }

                    WriteToBase(managerName, dateOfFile);
                }
        }

        private void WriteToBase(string managerName, DateTime dateOfFile)
        {
            mutexObj.WaitOne();
            {
                DataAccess.Components.Manager manager = _salesData.Managers.FirstOrDefault(x => x.Name == managerName);
                if (manager == null) 
                { 
                    manager = new DataAccess.Components.Manager(0, managerName);
                    _salesData.AddManager(manager);
                }

                DataAccess.Components.Session session = new DataAccess.Components.Session(0, dateOfFile, 123);
                _salesData.AddSession(session);

                foreach (Operation operation in _operations)
                {
                    _salesData.AddOperation(operation.Date, manager, operation.ClientName,
                        operation.ProductName, session, operation.Price);
                    _salesData.Save();
                }
            }
            mutexObj.ReleaseMutex();
        }

        private void LogError(string line)
        {
            OnLog(new LogInfo() { LogValue = string.Format("Something wrong in: {0}", line) });
        }
    }
}
