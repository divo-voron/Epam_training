﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Interfaces;

namespace TaxiStation.CarsItems
{
    public class Sedan : Car, IPassengers, ICargo
    {
        private int _numberOfPassengers;
        private int _carrying;
        public Sedan() { }
        public Sedan(int numberOfPassengers, int carrying, int speed, int fuelConsumption, int price, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(speed, fuelConsumption, price, carsControlSystemType)
        {
            _numberOfPassengers = numberOfPassengers;
            _carrying = carrying;
        }

        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
            set { _numberOfPassengers = value; }
        }

        public int Carrying
        {
            get { return _carrying; }
            set { _carrying = value; }
        }

        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _carrying + _numberOfPassengers * HumansWeight;
        }
    }
}
