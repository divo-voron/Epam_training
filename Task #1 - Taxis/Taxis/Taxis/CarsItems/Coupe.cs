using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Interfaces;

namespace TaxiStation.CarsItems
{
    class Coupe : Car, IPassengers
    {
        private int _numberOfPassengers;
        public Coupe(int numberOfPassengers, int speed, int fuelConsumption, int price, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(speed, fuelConsumption, price, carsControlSystemType)
        {
            _numberOfPassengers = numberOfPassengers;
        }

        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
            set { _numberOfPassengers = value; }
        }
        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _numberOfPassengers * HumansWeight;
        }
    }
}
