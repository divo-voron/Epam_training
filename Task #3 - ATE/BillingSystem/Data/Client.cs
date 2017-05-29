using BillingSystem.Data.Tariff;
using System;
using System.Collections.Generic;
using System.Linq;
using TelephoneExchange.StationCompoment;

namespace BillingSystem.Data
{
    public class Client
    {
        private string _name;
        private int _bill;
        private DateTime _payDay;
        private PhoneNumber _number;
        private TariffHistory _tariffHistory;
        private IPort _port;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Bill
        {
            get { return _bill; }
        }
        public DateTime PayDay
        {
            get { return _payDay; }
        }
        public PhoneNumber Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public DateTime CurrentTariffDateChange
        {
            get { return _tariffHistory.Last().DateAddTariff; }
        }
        public ITariff CurrentTariff
        {
            get { return _tariffHistory.Last().Tariff; }
        }
        public IPort Port
        {
            get { return _port; }
        }
        public Client(string name, PhoneNumber number, ITariff tariff)
        {
            _name = name;
            _number = number;
            _tariffHistory = new TariffHistory() { new TariffChange(tariff, DateTime.Now) };
            _port = new Port(number);
            _payDay = DateTime.Now;
        }
        public bool ChangeTariff(ITariff tariff, DateTime DateToChanges)
        {
            if (DateToChanges - _tariffHistory.Last().DateAddTariff > new TimeSpan(30, 0, 0, 0))
            {
                _tariffHistory.Add(tariff, DateToChanges);
                return true;
            }
            else
                return false;
        }
        public void AddMoney(ushort money)
        {
            _bill += money;
            if (_bill >= 0) 
            {
                _port.StateLock = TelephoneExchange.StationCompoment.PortComponent.PortStateLock.Unlocked;
                _payDay = _payDay.AddMonths(1);
            }
        }

        internal void ReCountBill()
        {
            IEnumerable<Data.Connection.Connect> connects = Billing.GetConnection(this).Where(x => x.Start > CurrentTariffDateChange);

            int priceOfCurrentCall = CurrentTariff.GetPrice(connects);
            connects.Last().Cost = priceOfCurrentCall;
            _bill -= priceOfCurrentCall;
        }
        internal void CheckBillState()
        {
            if (_bill < 0 && DateTime.Now > _payDay) _port.StateLock = TelephoneExchange.StationCompoment.PortComponent.PortStateLock.Locked;
        }
    }
}
