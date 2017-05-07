using System.Runtime.Serialization;
using TaxiStation.Enums;
using TaxiStation.Impl.CarsTypes;
using TaxiStation.Interfaces;

namespace TaxiStation.Serialize
{
    [DataContract]
    class CreatorCoupe: Creator
    {
        [DataMember]
        private int _numberOfPassenger;
        public CreatorCoupe(int id, int speed, int fuelConsumptionm, int price, int curbWeight, int numberOfPassenger, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumptionm, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassenger = numberOfPassenger;
        }
        public override ICar GetCar()
        {
            return new Coupe(_id) 
            { 
                Speed = _speed, 
                FuelConsumption = _fuelConsumption, 
                Price = _price, 
                CurbWeight = _curbWeight, 
                NumberOfPassengers = _numberOfPassenger, 
                CarsControlSystemType = _carsControlSystemType 
            };
        }
    }
}
