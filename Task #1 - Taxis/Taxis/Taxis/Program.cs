using System.Collections;
using System.Collections.Generic;
using System.IO;
using TaxiStation.Enums;
using TaxiStation.Impl;
using TaxiStation.Impl.CarsTypes;
using TaxiStation.Interfaces;
using TaxiStation.Serialize;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Write(Directory.GetCurrentDirectory() + "\\Car.json");

            ICollection<ICar> data = JSONData.Read(Directory.GetCurrentDirectory() + "\\Car.json");
            if (Validator.Check(data))
            {
                Taxi taxi = new Taxi(data);
                GUI.Start(taxi);
            }
        }
        static void Write(string path)
        {
            ICollection<ICar> cars = new List<ICar>() 
            { 
                new Coupe(1) { Speed = 250, FuelConsumption = 13, Price = 50, CurbWeight = 1000, NumberOfPassengers = 2, CarsControlSystemType = CarsControlSystemType.Autopilot }, 
                new Coupe(2) { Speed = 290, FuelConsumption = 14, Price = 65, CurbWeight = 1100, NumberOfPassengers = 2, CarsControlSystemType = CarsControlSystemType.Human }, 
                new Sedan(3) { Speed = 190, FuelConsumption = 10, Price = 35, CurbWeight = 1250, NumberOfPassengers = 3, Cargo = 100, CarsControlSystemType = CarsControlSystemType.Autopilot }, 
                new Sedan(4) { Speed = 190, FuelConsumption = 11, Price = 35, CurbWeight = 1350, NumberOfPassengers = 4, Cargo = 150, CarsControlSystemType = CarsControlSystemType.Human }, 
                new Gazel(5) { Speed = 100, FuelConsumption = 16, Price = 40, CurbWeight = 1500, Cargo = 1500, CarsControlSystemType = CarsControlSystemType.Human },
                new Gazel(6) { Speed = 100, FuelConsumption = 16, Price = 45, CurbWeight = 1500, Cargo = 1800, CarsControlSystemType = CarsControlSystemType.Human }
            };
            
            JSONData.Write(cars, path);
        }


    }
}
