using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL
{
    class Validate
    {
        public bool Check(string[] data)
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
