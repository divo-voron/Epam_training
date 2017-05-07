using System.Collections.Generic;
using System.Linq;
using TaxiStation.Interfaces;

namespace TaxiStation.Impl
{
    class Taxi
    {
        private ICollection<ICar> _cars;
        public Taxi(ICollection<ICar> cars)
        {
            _cars = cars;
        }
        public ICollection<ICar> Cars
        {
            get { return _cars; }
        }
        public int GetTotalLoadCapacity()
        {
            return _cars.OfType<ICargo>().Sum(item => item.Cargo);
        }
        public int GetTotalCost()
        {
            return _cars.Sum(item => item.Price);
        }
    }        
}
