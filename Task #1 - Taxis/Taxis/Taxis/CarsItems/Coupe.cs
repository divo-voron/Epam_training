using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Serialize;
using TaxiStation.Interfaces;

namespace TaxiStation.CarsItems
{
    class Coupe : Car, IPassengers
    {
        private int _numberOfPassengers;
        public Coupe(int id, int speed, int fuelConsumption, int price, int curbWeight, int numberOfPassengers, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumption, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassengers = numberOfPassengers;
        }
        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
        }
        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _numberOfPassengers * HumansWeight;
        }
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), NumberOfPassengers, "    ");
        }
        public override Creator GetCreator()
        {
            return new CreatorCoupe(Id, Speed, FuelConsumption, Price, CurbWeight, NumberOfPassengers, CarsControlSystemType);
        }
    }
}
