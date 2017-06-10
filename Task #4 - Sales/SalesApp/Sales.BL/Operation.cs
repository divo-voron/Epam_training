using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BL
{
    struct Operation
    {
        private DateTime _date;
        private string _clientName;
        private string _productName;
        private int _price;
        public DateTime Date 
        { 
            get { return _date; }
            set { _date = value; } 
        }
        public string ClientName 
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        public string ProductName 
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public int Price 
        {
            get { return _price; }
            set { _price = value; }
        }

        public Operation(string[] data)
        {
            _date = Convert.ToDateTime(data[0]);
            _clientName = data[1];
            _productName = data[2];
            _price = Convert.ToInt32(data[3]);
        }
        public Operation(string date, string clientName, string productName, string price)
        {
            _date = Convert.ToDateTime(date);
            _clientName = clientName;
            _productName = productName;
            _price = Convert.ToInt32(price);
        }
        public Operation(DateTime date, string clientName, string productName, int price)
        {
            _date = date;
            _clientName = clientName;
            _productName = productName;
            _price = price;
        }
    }
}
