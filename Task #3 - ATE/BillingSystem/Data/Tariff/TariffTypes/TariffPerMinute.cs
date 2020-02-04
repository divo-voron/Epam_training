using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystem.Data.Tariff.TariffTypes
{
    public class TariffPerMinute : ITariff
    {
        public uint CostMinute { get; }
        public TariffPerMinute(uint costMinute) 
        {
            CostMinute = costMinute;
        }
        public int GetPrice(IEnumerable<Data.Connection.Connect> connects)
        {
            return connects.Last().Duration.Minutes * Convert.ToInt32(CostMinute);
        }
    }
}
