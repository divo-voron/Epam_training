using BillingSystem.Data.Tariff;
using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchange.StationComponent;

namespace BillingSystem.Data
{
    public class Client
    {
        private readonly List<TariffChange> _tariffHistory;

        public string Name { get; set; }

        public int Bill { get; private set; }

        public DateTime PayDay { get; private set; }

        public DateTime CurrentTariffDateChange => _tariffHistory.Last().DateAddTariff;

        public ITariff CurrentTariff => _tariffHistory.Last().Tariff;

        public IPort Port { get; set; }

        public Client(string name, PhoneNumber number, ITariff tariff, ushort money)
        {
            Name = name;
            _tariffHistory = new List<TariffChange>() { new TariffChange(tariff, DateTime.Now) };
            Port = new Port(number);
            AddMoney(money);
            PayDay = DateTime.Now;
        }

        public bool ChangeTariff(ITariff tariff, DateTime dateToChanges)
        {
            if (dateToChanges - _tariffHistory.Last().DateAddTariff > new TimeSpan(30, 0, 0, 0))
            {
                _tariffHistory.Add(new TariffChange(tariff, dateToChanges));
                return true;
            }

            return false;
        }

        public void AddMoney(ushort money)
        {
            Bill += money;
            if (Bill >= 0) 
            {
                Port.StateLock = TelephoneExchange.StationComponent.PortComponent.PortStateLock.Unlocked;
                PayDay = PayDay.AddMonths(1);
            }
        }

        internal void ReCountBill()
        {
            var connects = Billing.GetConnections(x => x.SourceClient == this || x.TargetClient == this).Where(x => x.Start > CurrentTariffDateChange);

            var priceOfCurrentCall = CurrentTariff.GetPrice(connects);
            connects.Last().Cost = priceOfCurrentCall;
            Bill -= priceOfCurrentCall;
        }

        internal void CheckBillState()
        {
            if (Bill < 0 && DateTime.Now > PayDay) Port.StateLock = TelephoneExchange.StationComponent.PortComponent.PortStateLock.Locked;
        }
    }
}
