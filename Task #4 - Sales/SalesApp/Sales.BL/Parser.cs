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
    public class Parser : IDisposable
    {
        private static Mutex mutexObj = new Mutex();

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
                }

            if (_operations.Count > 0)
                WriteToBase(_salesData, _operations, managerName, dateOfFile, fileName);

            ReplaceFile(path);
        }

        private void WriteToBase(DataAccess.SalesDataContainer _salesData, ICollection<Operation> _operations, string managerName, DateTime dateOfFile, string fileName)
        {
            try
            {
                mutexObj.WaitOne();

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
            catch (Exception e) { Log(e.ToString()); }
            finally
            {
                mutexObj.ReleaseMutex();
            }
        }

        private void ReplaceFile(string path)
        {
            try
            {
                Log(string.Format(LogMessages.StartMoveFile, Path.GetFileName(path)));

                string folder = System.Configuration.ConfigurationManager.AppSettings["PathToProcessedReports"];
                if (folder != null)
                {
                    if (Directory.Exists(folder) == false)
                    {
                        try
                        {
                            Directory.CreateDirectory(folder);
                        }
                        catch (PathTooLongException) { Log(LogMessages.PathTooLongException); }
                    }

                    try
                    {
                        string pathDestination = Path.Combine(folder, Path.GetFileNameWithoutExtension(path));
                        string extension = Path.GetExtension(path);

                        if (File.Exists(string.Concat(pathDestination, extension)))
                        {
                            int i = 1;
                            while (File.Exists(string.Concat(pathDestination, "_", i.ToString(), extension)))
                            {
                                i++;
                            }
                            pathDestination = string.Concat(pathDestination, "_", i.ToString());
                        }

                        File.Move(path, string.Concat(pathDestination, extension));
                    }
                    catch (PathTooLongException) { Log(LogMessages.PathTooLongException); }

                    Log(string.Format(LogMessages.EndMoveFile, Path.GetFileName(path)));
                }
            }
            catch (Exception e) { Log(e.ToString()); }
        }

        public void Log(string line)
        {
            OnLog(new LogInfo() { LogValue = line });
        }

        public void Dispose()
        {
            _loging = null;
        }
    }
}
