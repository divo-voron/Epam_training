using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public struct TariffChange
    {
        private ITariff _tariff;
        private DateTime _dateAddTariff;
        public TariffChange(ITariff tariff, DateTime dateAddTariff)
        {
            _tariff = tariff;
            _dateAddTariff = dateAddTariff;
        }
        public ITariff Tariff
        {
            get { return _tariff; }
        }
        public DateTime DateAddTariff
        {
            get { return _dateAddTariff; }
        }
    }
}
