using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.CarsItems;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Taxi taxi = Data.Read();

            foreach (var item in taxi)
            {
                Console.WriteLine(item.GetFullWeight().ToString());
            }
        }
        
        // Hardcode data
        static void Write()
        {
            Taxi taxi = new Taxi();
            taxi.Add(new Sedan() { Speed = 20, Price = 30, NumberOfPassengers = 2, CurbWeight = 100, FuelConsumption = 50, CarsControlSystemType = CarsControlSystemType.Human });
            taxi.Add(new Premium() { Speed = 20, Price = 30, NumberOfPassengers = 2, CurbWeight = 100, FuelConsumption = 50, CarsControlSystemType = CarsControlSystemType.Autopilot });

            Data.Write(taxi);
        }
    }
}
