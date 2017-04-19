using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxis.CarComponents;
using Taxis.Interfaces;

namespace Taxis.CarsItems
{
    class Sedan : Car, IPassengers, ICargo
    {
        private int _numberOfPassengers;
        private int _carrying;

        public Sedan(int numberOfPassengers, int carrying, int speed, int fuelConsumption, int price, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(speed, fuelConsumption, price, carsControlSystemType)
        {
            _numberOfPassengers = numberOfPassengers;
            _carrying = carrying;
        }

        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
            set { _numberOfPassengers = value; }
        }

        public int Carrying
        {
            get { return _carrying; }
            set { _carrying = value; }
        }
    }
}
