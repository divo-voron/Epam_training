using System.Runtime.Serialization;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
using TaxiStation.Interfaces;

namespace TaxiStation.Serialize
{
    [DataContract]
    class CreatorGazel: Creator
    {
        [DataMember]
        private int _cargo;
        public CreatorGazel(int id, int speed, int fuelConsumptionm, int price, int curbWeight, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumptionm, price, curbWeight, carsControlSystemType)
        {
            _cargo = cargo;
        }
        public override ICar GetCar()
        {
            return new Gazel(_id, _speed, _fuelConsumption, _price, _curbWeight, _cargo, _carsControlSystemType);
        }
    }
}
