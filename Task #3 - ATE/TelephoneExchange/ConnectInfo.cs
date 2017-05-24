using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    class ConnectInfo
    {
        private string _client;
        private DateTime _start;
        private DateTime _end;

        public string Client
        {
            get { return _client; }
            set { _client = value; }
        }
        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }
        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }

        public ConnectInfo(string client, DateTime start, DateTime end)
        {
            _client = client;
            _start = start;
            _end = end;
        }
    }
}
