using System;
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
    class Sedan : Car, IPassengers, ICargo
    {
        private int _numberOfPassengers;
        private int _cargo;
        public Sedan(int id, int speed, int fuelConsumption, int price, int curbWeight, int numberOfPassengers, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
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
            return string.Format("{0} | {1} | {2}", base.GetInfo(), NumberOfPassengers, Cargo.ToString().PadLeft(4,' '));
        }
        public override Creator GetCreator()
        {
            return new CreatorSedan(Id, Speed, FuelConsumption, Price, CurbWeight, NumberOfPassengers, Cargo, CarsControlSystemType);
        }
    }
}
