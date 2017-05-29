using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystem.Data.Tariff.TariffTypes
{
    public class TariffPerSecond : ITariff
    {
        private uint _costSecond;
        public uint CostSecond
        {
            get { return _costSecond; }
        }
        public TariffPerSecond(uint costSecond) 
        {
            _costSecond = costSecond;
        }
        public int GetPrice(IEnumerable<Data.Connection.Connect> connects)
        {
            return connects.Last().Duration.Seconds * Convert.ToInt32(_costSecond);
        }
    }
}
