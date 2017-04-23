﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Factory;
using TaxiStation.Interfaces;

namespace TaxiStation.CarsItems
{
    class Coupe : Car, IPassengers
    {
        private int _numberOfPassengers;
        public Coupe(int speed, int fuelConsumption, int price, int curbWeight, int numberOfPassengers, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(speed, fuelConsumption, price, curbWeight, carsControlSystemType)
        {
            _numberOfPassengers = numberOfPassengers;
        }

        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
            set { _numberOfPassengers = value; }
        }
        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _numberOfPassengers * HumansWeight;
        }
        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder(6);
        //    sb.Append("Pass:    "); sb.Append(this.NumberOfPassengers.ToString()); sb.Append("\r\n");
        //    return string.Concat(base.ToString(), sb.ToString());
        //}
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), NumberOfPassengers, "");
        }

        public override CarData GetData()
        {
            return new CarData("Coupe");
        }
    }
}
