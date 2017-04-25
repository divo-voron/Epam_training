using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Factory;
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
            set { _cargo = value; }
        }

        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _cargo;
        }
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), " ", Cargo);
        }

        public override CarData GetData()
        {
            return new CarData("Gazel");
        }
    }
}
