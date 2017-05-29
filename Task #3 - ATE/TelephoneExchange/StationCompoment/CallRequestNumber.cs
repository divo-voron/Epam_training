using System;

namespace TelephoneExchange.StationCompoment
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
