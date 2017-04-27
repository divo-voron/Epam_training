using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
using TaxiStation.Factory;
using TaxiStation.Interfaces;

namespace TaxiStation.CarComponents
{
    abstract class Car : ICar
    {
        public const int HumansWeight = 75;
        private int _id;
        private int _speed;
        private int _fuelConsumption;
        private int _price;
        private int _curbWeight;
        private CarsControlSystemType _carsControlSystemType;

        public Car(int id, int speed, int fuelConsumption, int price, int curbWeight, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
        {
            _id = id;
            _speed = speed;
            _fuelConsumption = fuelConsumption;
            _price = price;
            _curbWeight = curbWeight;
            _carsControlSystemType = carsControlSystemType;
        }

        public int Id
        {
            get { return _id; }
        }
        public int Speed
        {
            get { return _speed; }
        }
        public int FuelConsumption
        {
            get { return _fuelConsumption; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int CurbWeight
        {
            get { return _curbWeight; }
        }
        public CarsControlSystemType CarsControlSystemType
        {
            get { return _carsControlSystemType; }
            set { _carsControlSystemType = value; }
        }
        public virtual int GetFullWeight()
        {
            return _curbWeight + (_carsControlSystemType == CarsControlSystemType.Human ? HumansWeight : 0);
        }
        public virtual string GetInfo()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5}",
                          GetType().Name.PadLeft(8, ' '), CarsControlSystemType.ToString().PadLeft(9, ' '),
                          Speed.ToString().PadLeft(5, ' '), FuelConsumption.ToString().PadLeft(4, ' '),
                          Price.ToString().PadLeft(5, ' '), GetFullWeight().ToString().PadLeft(10, ' '));
        }
    }
}
