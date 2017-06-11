using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL
{
    class Validate
    {
        public bool CheckFileName(string path, out string managerName, out DateTime dateOfFile, out string fileName)
        {
            managerName = null;
            dateOfFile = new DateTime();
            fileName = Path.GetFileNameWithoutExtension(path);
            
            string[] data = fileName.Split('_');
            if (data.Count() == 2)
            {
                DateTime date;
                if (DateTime.TryParse(data[1], out date))
                {
                    managerName = data[0];
                    dateOfFile = date;
                    return true;
                }
                else return false;
            }
            else
                return false;
        }
        public bool CheckData(string[] data)
        {
            if (data.Count() != 4) return false;
            else
            {
                DateTime date;
                int summ;

                return DateTime.TryParse(data[0], out date) && Int32.TryParse(data[3], out summ);
            }
        }
    }
}
