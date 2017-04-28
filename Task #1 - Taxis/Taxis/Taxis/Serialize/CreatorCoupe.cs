using System.Runtime.Serialization;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
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
        public override ICar FactoryMethod()
        {
            return new Coupe(_id, _speed, _fuelConsumption, _price, _curbWeight, _numberOfPassenger, _carsControlSystemType);
        }
    }
}
