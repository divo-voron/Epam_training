using System.Collections.Generic;
using System.Linq;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    static class Validator
    {
        public static bool Check(IEnumerable<ICar> cars)
        {
            return cars != null && cars.GroupBy(item => item.Id).Count() == cars.Count();
        }
    }
}
