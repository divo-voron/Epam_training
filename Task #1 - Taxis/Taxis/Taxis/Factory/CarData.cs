using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation.Factory
{
    public class CarData
    {
        string _s;
        public CarData(string s)
        {
            _s = s;
        }
        public string GetData()
        {
            return _s;
        }
    }
}
