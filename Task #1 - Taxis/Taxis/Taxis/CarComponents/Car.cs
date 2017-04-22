using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enums;
using TaxiStation.Factory;
using TaxiStation.Interfaces;

namespace TaxiStation.CarComponents
{
    abstract class Car : ICar
    {
        public const int HumansWeight = 75;
        private int _speed;
        private int _fuelConsumption;
        private int _price;
        private int _curbWeight;
        private CarsControlSystemType _carsControlSystemType;

        public Car(int speed, int fuelConsumption, int price, int curbWeight, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
        {
            _speed = speed;
            _fuelConsumption = fuelConsumption;
            _price = price;
            _curbWeight = curbWeight;
            _carsControlSystemType = carsControlSystemType;
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
        public int CurbWeight
        {
            get { return _curbWeight; }
            set { _curbWeight = value; }
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Car:     "); sb.Append(GetType().ToString()); sb.Append("\r\n");
            sb.Append("Control: "); sb.Append(CarsControlSystemType.ToString()); sb.Append("\r\n");
            sb.Append("Speed:   "); sb.Append(Speed.ToString()); sb.Append("\r\n");
            sb.Append("Fuel:    "); sb.Append(FuelConsumption.ToString()); sb.Append("\r\n");
            sb.Append("Price:   "); sb.Append(Price.ToString()); sb.Append("\r\n");
            sb.Append("CarMass: "); sb.Append(GetFullWeight().ToString()); sb.Append("\r\n");
            return sb.ToString();
        }


        public abstract CarData GetData();
    }
}
