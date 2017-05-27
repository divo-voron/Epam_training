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
        private PhoneNumber _number;
        private Tariff _tariff;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public PhoneNumber Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public Tariff Tarrif
        {
            get { return _tariff; }
            set { _tariff = value; }
        }
        public Client(string name, PhoneNumber number, Tariff tariff)
        {
            _name = name;
            _number = number;
            _tariff = tariff;
        }
    }
}
