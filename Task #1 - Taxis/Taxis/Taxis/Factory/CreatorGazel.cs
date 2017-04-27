﻿using System;
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
    class CreatorGazel: Creator
    {
        private int _cargo;
        public CreatorGazel(int id, int speed, int fuelConsumptionm, int price, int curbWeight, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumptionm, price, curbWeight, carsControlSystemType)
        {
            _cargo = cargo;
        }
        public override Car FactoryMethod()
        {
            return new Gazel(_id, _speed, _fuelConsumption, _price, _curbWeight, _cargo, _carsControlSystemType);
        }
    }
}
