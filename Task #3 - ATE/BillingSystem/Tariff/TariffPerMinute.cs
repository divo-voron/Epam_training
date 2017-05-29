using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class TariffPerMinute : ITariff
    {
        public ushort GetPrice(Connect connect)
        {
            return 15;// throw new NotImplementedException();
        }
    }
}
