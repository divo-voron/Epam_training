using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class CallRequest : EventArgs
    {
        private string _number;
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public CallRequest(string number)
        {
            _number = number;
        }
    }
}
