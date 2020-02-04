using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystem.Data.Tariff.TariffTypes
{
    public class TariffPerSecond : ITariff
    {
        public uint CostSecond { get; }
        public TariffPerSecond(uint costSecond) 
        {
            CostSecond = costSecond;
        }
        public int GetPrice(IEnumerable<Data.Connection.Connect> connects)
        {
            return connects.Last().Duration.Seconds * Convert.ToInt32(CostSecond);
        }
    }
}
