using System.Runtime.Serialization;
using TaxiStation.Enums;
using TaxiStation.Impl.CarsTypes;
using TaxiStation.Interfaces;

namespace TaxiStation.Serialize
{
    [DataContract]
    class CreatorSedan: Creator
    {
        [DataMember]
        private int _numberOfPassenger;
        [DataMember]
        private int _cargo;
        public CreatorSedan(int id, int speed, int fuelConsumption, int price, int curbWeight, int numberOfPassenger, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumption, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassenger = numberOfPassenger;
            _cargo = cargo;
        }
        public override ICar GetCar()
        {
            return new Sedan(_id)
            {
                Speed = _speed,
                FuelConsumption = _fuelConsumption,
                Price = _price,
                CurbWeight = _curbWeight,
                NumberOfPassengers = _numberOfPassenger,
                Cargo = _cargo,
                CarsControlSystemType = _carsControlSystemType
            };
        }
    }
}
