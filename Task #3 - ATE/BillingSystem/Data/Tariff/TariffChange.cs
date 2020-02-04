using System;

namespace BillingSystem.Data.Tariff
{
    public struct TariffChange
    {
        public TariffChange(ITariff tariff, DateTime dateAddTariff)
        {
            Tariff = tariff;
            DateAddTariff = dateAddTariff;
        }

        public ITariff Tariff { get; }

        public DateTime DateAddTariff { get; }
    }
}
