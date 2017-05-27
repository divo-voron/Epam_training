﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class CallRequestNumber : EventArgs
    {
        private PhoneNumber _number;
        public PhoneNumber Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public CallRequestNumber(PhoneNumber number)
        {
            _number = number;
        }
    }
}