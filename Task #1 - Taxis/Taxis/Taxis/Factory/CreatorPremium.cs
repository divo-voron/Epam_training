using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
using TaxiStation.Interfaces;

namespace TaxiStation.Factory
{
    [DataContract]
    class CreatorPremium: Creator
    {
        private int _numberOfPassenger;
        private int _cargo;
        public CreatorPremium(int id, int speed, int fuelConsumptionm, int price, int curbWeight, int numberOfPassenger, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumptionm, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassenger = numberOfPassenger;
            _cargo = cargo;
        }
        public override Car FactoryMethod()
        {
            return new Premium(_id, _speed, _fuelConsumption, _price, _curbWeight, _numberOfPassenger, _cargo, _carsControlSystemType);
        }
    }
}
