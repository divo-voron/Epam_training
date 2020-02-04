using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystem.Data.Tariff.TariffTypes
{
    public class TariffWithFreeMinute : ITariff
    {
        public uint FreeMinutes { get; }
        public uint CostMinute { get; }
        public TariffWithFreeMinute(uint freeMinutes, uint costMinute)
        {
            FreeMinutes = freeMinutes;
            CostMinute = costMinute;
        }
        public int GetPrice(IEnumerable<Connection.Connect> connects)
        {
            var allMinutes = connects.Sum(x => x.Duration.Minutes);
            if (FreeMinutes >= allMinutes)
            {
                return 0;
            }

            return connects.Last().Duration.Minutes * Convert.ToInt32(CostMinute);
        }
    }
}
