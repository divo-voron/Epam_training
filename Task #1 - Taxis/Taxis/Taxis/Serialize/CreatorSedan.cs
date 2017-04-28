using System.Runtime.Serialization;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
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
        public override ICar FactoryMethod()
        {
            return new Sedan(_id, _speed, _fuelConsumption, _price, _curbWeight, _numberOfPassenger, _cargo, _carsControlSystemType);
        }
    }
}
