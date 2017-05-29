using BillingSystem.Data.Connection;
using System.Collections.Generic;

namespace BillingSystem.Data.Tariff
{
    public interface ITariff
    {
        int GetPrice(IEnumerable<Connect> connects);
    }
}
