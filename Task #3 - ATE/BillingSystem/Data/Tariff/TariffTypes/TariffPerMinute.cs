using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystem.Data.Tariff.TariffTypes
{
    public class TariffPerMinute : ITariff
    {
        private uint _costMinute;
        public uint CostMinute
        {
            get { return _costMinute; }
        }
        public TariffPerMinute(uint costMinute) 
        {
            _costMinute = costMinute;
        }
        public int GetPrice(IEnumerable<Data.Connection.Connect> connects)
        {
            return connects.Last().Duration.Minutes * Convert.ToInt32(_costMinute);
        }
    }
}
