using System;
using System.Collections.Generic;
using System.Linq;
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
        public Gazel(int cargo, int speed, int fuelConsumption, int price, int curbWeight, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(speed, fuelConsumption, price, curbWeight, carsControlSystemType)
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(3);
            sb.Append("Cargo:   "); sb.Append(this.Cargo.ToString()); sb.Append("\r\n");
            return string.Concat(base.ToString(), sb.ToString());
        }

        public override CarData GetData()
        {
            return new CarData("Gazel");
        }
    }
}
