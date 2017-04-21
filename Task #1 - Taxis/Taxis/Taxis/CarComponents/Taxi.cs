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
        private IEnumerable<ICar> _cars;
        public IEnumerable<ICar> Cars
        {
            get { return _cars; }
        }

        public Taxi()
        {
            _cars = new Collection<ICar>();
        }
        public Taxi(IEnumerable<ICar> cars)
        {
            _cars = cars;
        }
    }
}
