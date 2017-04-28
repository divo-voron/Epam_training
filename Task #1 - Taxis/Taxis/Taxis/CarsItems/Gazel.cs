﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Serialize;
using TaxiStation.Interfaces;

namespace TaxiStation.CarsItems
{
    class Gazel : Car, ICargo
    {
        private int _cargo;
        public Gazel(int id, int speed, int fuelConsumption, int price, int curbWeight, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumption, price, curbWeight, carsControlSystemType)
        {
            _cargo = cargo;
        }
        public int Cargo
        {
            get { return _cargo; }
        }

        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _cargo;
        }
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), " ", Cargo);
        }
        public override Creator GetCreator()
        {
            return new CreatorGazel(Id, Speed, FuelConsumption, Price, CurbWeight, Cargo, CarsControlSystemType);
        }
    }
}
