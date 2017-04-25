using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using TaxiStation.CarsItems;
using TaxiStation.Interfaces;

namespace TaxiStation.CarComponents
{
    public class Taxi
    {
        private ICollection<ICar> _cars;
        public Taxi(ICollection<ICar> cars)
        {
            if (cars.GroupBy(item => item.Id).Count() == cars.Count())
                _cars = cars;
            else
                throw new InvalidKeyException(cars.GroupBy(item => item.Id).Where(item => item.Count() > 1).Select(item => item.Key));
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
    }        
}
