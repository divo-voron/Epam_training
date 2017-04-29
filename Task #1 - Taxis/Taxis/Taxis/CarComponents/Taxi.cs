using System.Collections.Generic;
using System.Linq;
using TaxiStation.Interfaces;

namespace TaxiStation.CarComponents
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
        public ICar GetCarByID(int id)
        {
            return _cars.FirstOrDefault(item => item.Id == id);
        }
        public bool AddCar(ICar car)
        {
            if (_cars.Any(item => item.Id == car.Id))
                return false;
            else
            {
                _cars.Add(car);
                return true;
            }
        }
        public bool RemoveCar(ICar car)
        {
            return _cars.Remove(car);
        }
        public void UpdateCar(ICar car)
        {
            ICar value = _cars.FirstOrDefault(item => item.Id == car.Id);
            if (value != null)
            {
                _cars.Remove(value);
                _cars.Add(car);
            }
            else
                _cars.Add(car);
        }
    }        
}
