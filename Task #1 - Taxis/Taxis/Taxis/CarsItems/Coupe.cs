using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxis.CarComponents;
using Taxis.Interfaces;

namespace Taxis.CarsItems
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
    }
}
