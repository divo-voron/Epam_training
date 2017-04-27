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
    class CreatorCoupe: Creator
    {
        [DataMember]
        private int _numberOfPassenger;
        public CreatorCoupe(int id, int speed, int fuelConsumptionm, int price, int curbWeight, int numberOfPassenger, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumptionm, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassenger = numberOfPassenger;
        }
        public override Car FactoryMethod()
        {
            return new Coupe(_id, _speed, _fuelConsumption, _price, _curbWeight, _numberOfPassenger, _carsControlSystemType);
        }
    }
}
