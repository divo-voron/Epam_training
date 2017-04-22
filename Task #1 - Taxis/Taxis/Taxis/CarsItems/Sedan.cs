﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Interfaces;

namespace TaxiStation.CarsItems
{
    class Sedan : Car, IPassengers, ICargo
    {
        private int _numberOfPassengers;
        private int _cargo;
        public Sedan(int numberOfPassengers, int cargo, int speed, int fuelConsumption, int price, int curbWeight, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(speed, fuelConsumption, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassengers = numberOfPassengers;
            _cargo = cargo;
        }

        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
            set { _numberOfPassengers = value; }
        }

        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _cargo + _numberOfPassengers * HumansWeight;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(6);
            sb.Append("Pass:    "); sb.Append(this.NumberOfPassengers.ToString()); sb.Append("\r\n");
            sb.Append("Cargo:   "); sb.Append(this.Cargo.ToString()); sb.Append("\r\n");
            return string.Concat(base.ToString(), sb.ToString());
        }
    }
}
