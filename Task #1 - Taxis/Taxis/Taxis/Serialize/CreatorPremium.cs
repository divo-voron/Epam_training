using System.Runtime.Serialization;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
using TaxiStation.Interfaces;

namespace TaxiStation.Serialize
{
    [DataContract]
    class CreatorPremium: Creator
    {
        [DataMember]
        private int _numberOfPassenger;
        [DataMember]
        private int _cargo;
        public CreatorPremium(int id, int speed, int fuelConsumptionm, int price, int curbWeight, int numberOfPassenger, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumptionm, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassenger = numberOfPassenger;
            _cargo = cargo;
        }
        public override ICar GetCar()
        {
            return new Premium(_id, _speed, _fuelConsumption, _price, _curbWeight, _numberOfPassenger, _cargo, _carsControlSystemType);
        }
    }
}
