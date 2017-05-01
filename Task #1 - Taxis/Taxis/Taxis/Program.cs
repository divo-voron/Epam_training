using System.Collections;
using System.Collections.Generic;
using System.IO;
using TaxiStation.CarComponents;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
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
                new Coupe(1, 250, 13, 50, 1000, 2, CarsControlSystemType.Autopilot),
                new Coupe(2, 290, 14, 65, 1100, 2),
                new Sedan(3, 190, 10, 35, 1250, 3, 100, CarsControlSystemType.Autopilot),
                new Sedan(4, 190, 11, 35, 1350, 4, 150),
                new Gazel(5, 100, 16, 40, 1500, 1500),
                new Gazel(6, 100, 16, 45, 1500, 1800)
            };

            JSONData.Write(cars, path);
        }

        
    }
}
