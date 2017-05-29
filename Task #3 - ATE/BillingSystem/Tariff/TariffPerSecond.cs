using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingSystem
{
    public class TariffPerSecond : ITariff
    {
        public ushort GetPrice(Connect connect)
        {
            return 10; // throw new NotImplementedException();
        }
    }
}
