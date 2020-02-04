using System;

namespace TelephoneExchange.StationComponent
{
    public class CallRequestNumber : EventArgs
    {
        public PhoneNumber Number { get; set; }

        public CallRequestNumber(PhoneNumber number)
        {
            Number = number;
        }
    }
}
