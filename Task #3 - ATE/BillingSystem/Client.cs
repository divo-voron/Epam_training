using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneExchange;

namespace BillingSystem
{
    public class Client
    {
        private string _name;
        private uint _bill;
        private PhoneNumber _number;
        private TariffHistory _tariffHistory;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public uint Bill
        {
            get { return _bill; }
        }
        public PhoneNumber Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public ITariff CurrentTariff
        {
            get { return _tariffHistory.Last().Tariff; }
        }
        public Client(string name, PhoneNumber number, ITariff tariff)
        {
            _name = name;
            _number = number;
            _tariffHistory = new TariffHistory() { new TariffChange(tariff, DateTime.Now) };
        }
        public bool ChangesTariff(ITariff tariff, DateTime DateToChanges)
        {
            if (DateToChanges - _tariffHistory.Last().DateAddTariff > new TimeSpan(30, 0, 0, 0))
            {
                _tariffHistory.Add(tariff, DateToChanges);
                return true;
            }
            else
                return false;
        }
        public void AddMoney(uint money)
        {
            _bill += money;
        }
    }
}
