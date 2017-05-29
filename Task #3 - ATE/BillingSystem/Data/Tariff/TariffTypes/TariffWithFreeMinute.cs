using System;
using System.Collections.Generic;
using System.Linq;

namespace BillingSystem.Data.Tariff.TariffTypes
{
    public class TariffWithFreeMinute : ITariff
    {
        private uint _freeMinutes;
        private uint _costMinute;
        public uint FreeMinutes
        {
            get { return _freeMinutes; }
        }
        public uint CostMinute
        {
            get { return _costMinute; }
        }
        public TariffWithFreeMinute(uint freeMinutes, uint costMinute)
        {
            _freeMinutes = freeMinutes;
            _costMinute = costMinute;
        }
        public int GetPrice(IEnumerable<Data.Connection.Connect> connects)
        {
            int allMinutes = connects.Sum(x => x.Duration.Minutes);
            if (_freeMinutes >= allMinutes)
                return 0;
            else
                return connects.Last().Duration.Minutes * Convert.ToInt32(_costMinute);
        }
    }
}
