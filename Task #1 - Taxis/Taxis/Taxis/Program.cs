using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
using TaxiStation.Serialize;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ICollection<ICar> data = JSONData.Read();
                Taxi taxi = new Taxi(data);

                GUI.GetTaxi(taxi);
                GUI.ChooseAction();
            }
            catch (Exception error) { Console.WriteLine(string.Format("App error: {0}", error.ToString())); }

        }
        static void ReadWrite()
        {
            ICollection<ICar> cars = new List<ICar>() 
            {
                new Coupe(1, 250, 13, 50, 1000, 2, CarsControlSystemType.Autopilot),
                new Coupe(2, 290, 14, 65, 1100, 2),
                new Sedan(3, 190, 10, 35, 1250, 3, 100, CarsControlSystemType.Autopilot),
                new Sedan(4, 190, 11, 35, 1350, 4, 150),
                new Gazel(5, 100, 16, 40, 1500, 1500),
                new Gazel(6, 100, 16, 45, 1500, 1800),
                new Premium(7, 180, 11, 80, 1000, 5, 220, CarsControlSystemType.Autopilot),
                new Premium(8, 180, 11, 85, 1200, 5, 250)
            };

            JSONData.Write(cars);

            cars = JSONData.Read();
        }

        
    }
}
