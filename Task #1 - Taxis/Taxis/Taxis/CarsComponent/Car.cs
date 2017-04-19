using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxis.Interfaces;

namespace Taxis.CarsComponent
{
    abstract class Car : ICar
    {
        private int _speed;
        private int _fuelConsumption;
        private int _price;
        private CarsControlSystemType _carsControlSystemType;

        public Car(int speed, int fuelConsumption, int price, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
        {
            _speed = speed;
            _fuelConsumption = fuelConsumption;
            _price = price;
            //_carsControlSystemType = carsControlSystemType;
        }

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int FuelConsumption
        {
            get { return _fuelConsumption; }
            set { _fuelConsumption = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public CarsControlSystemType CarsControlSystemType
        {
            get { return _carsControlSystemType; }
            set { _carsControlSystemType = value; }
        }
    }
}
