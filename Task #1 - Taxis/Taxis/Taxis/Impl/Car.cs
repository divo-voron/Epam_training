using TaxiStation.Enums;
using TaxiStation.Interfaces;
using TaxiStation.Serialize;

namespace TaxiStation.Impl
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

        public Car(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
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
        public virtual string GetInfo()
        {
            return string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6}",
                          GetType().Name.PadLeft(8, ' '), CarsControlSystemType.ToString().PadLeft(9, ' '),
                          Speed.ToString().PadLeft(5, ' '), FuelConsumption.ToString().PadLeft(4, ' '),
                          Price.ToString().PadLeft(5, ' '), CurbWeight.ToString().PadLeft(10, ' '), GetFullWeight().ToString().PadLeft(10, ' '));
        }


        public abstract Creator GetCreator();
    }
}
