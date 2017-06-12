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

        public void Parse(string path)
        {
            DataAccess.SalesDataContainer _salesData = new SalesDataContainer();
            ICollection<Operation> _operations = new List<Operation>();

            Validate validator = new Validate();
            string managerName;
            DateTime dateOfFile;
            string fileName;
            
            Thread.Sleep(1000);

            if (validator.CheckFileName(path, out managerName, out dateOfFile, out fileName))
                using (StreamReader sr = new StreamReader(path))
                {
                    Log(string.Format(LogMessages.OpenRead, fileName));
                    while (true)
                    {
                        string line = sr.ReadLine();
                        if (line == null) break;
                        else
                            if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] data = line.Split(';');

                        if (validator.CheckData(data) == false) Log(string.Format(LogMessages.Error, line));
                        else
                            _operations.Add(new Operation(data));
                    }
                    Log(string.Format(LogMessages.ReadDone, fileName));

                    if (_operations.Count > 0)
                        WriteToBase(_salesData, _operations, managerName, dateOfFile, fileName);
                }
        }

        private void WriteToBase(DataAccess.SalesDataContainer _salesData, ICollection<Operation> _operations, string managerName, DateTime dateOfFile, string fileName)
        {
            mutexObj.WaitOne();
            {
                Log(string.Format(LogMessages.BeginCriticalSection, fileName));

                Thread.Sleep(1000);

                DataAccess.Components.Manager manager = _salesData.Managers.FirstOrDefault(x => x.Name == managerName);
                if (manager == null)
                {
                    manager = new DataAccess.Components.Manager(0, managerName);
                    _salesData.AddManager(manager);
                }

                DataAccess.Components.Session session = new DataAccess.Components.Session(0, dateOfFile, fileName);
                _salesData.AddSession(session);

                foreach (Operation operation in _operations)
                {
                    _salesData.AddOperation(operation.Date, manager, operation.ClientName,
                        operation.ProductName, session, operation.Price);
                }

                Log(string.Format(LogMessages.EndCriticalSection, fileName));
            }

            mutexObj.ReleaseMutex();
        }

        public void Log(string line)
        {
            OnLog(new LogInfo() { LogValue = line });
        }
    }
}
