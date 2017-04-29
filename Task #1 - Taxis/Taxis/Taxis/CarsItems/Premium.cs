﻿using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Interfaces;
using TaxiStation.Serialize;

namespace TaxiStation.CarsItems
{
    class Premium : Car, IPassengers, ICargo
    {
        private int _numberOfPassengers;
        private int _cargo;
        public Premium(int id, int speed, int fuelConsumption, int price, int curbWeight, int numberOfPassengers, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumption, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassengers = numberOfPassengers;
            _cargo = cargo;
        }
        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
        }

        public int Cargo
        {
            get { return _cargo; }
        }

        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _cargo + _numberOfPassengers * HumansWeight;
        }
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), NumberOfPassengers, Cargo.ToString().PadLeft(4, ' '));
        }
        public override Creator GetCreator()
        {
            return new CreatorPremium(Id, Speed, FuelConsumption, Price, CurbWeight, NumberOfPassengers, Cargo, CarsControlSystemType);
        }
    }
}
