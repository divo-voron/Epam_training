using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Interfaces;

namespace TaxiStation.CarsItems
{
    class Gazel : Car, ICargo
    {
        private int _carrying;

        public Gazel(int carrying, int speed, int fuelConsumption, int price, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(speed, fuelConsumption, price, carsControlSystemType)
        {
            _carrying = carrying;
        }

        public int Carrying
        {
            get { return _carrying; }
            set { _carrying = value; }
        }
    }
}
