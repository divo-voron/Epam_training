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
            _cars = cars;
        }
        public ICollection<ICar> Cars
        {
            get { return _cars; }
            set { _cars = value; }
        }
        public IEnumerator GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        public Taxi()
        {
            _cars = new Collection<ICar>();
        }
    }        
}
