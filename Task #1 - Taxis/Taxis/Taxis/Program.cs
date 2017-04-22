using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.CarsItems;
using TaxiStation.Enums;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Taxi taxi = new Taxi(
                            new List<ICar>() 
                            { 
                                new Coupe(1, 1, 1, 1, 1, CarsControlSystemType.Autopilot), 
                                new Coupe(1, 1, 1, 1, 1, CarsControlSystemType.Human), 
                                new Sedan(2, 2, 2, 2, 2, 2), 
                                new Premium(3, 3, 3, 3, 3, 3), 
                                new Gazel(4, 4, 4, 4, 4), 
                            });

            //foreach (ICar item in taxi.Cars)
            //{
            //    Console.WriteLine(item.CarsControlSystemType.ToString());
            //}

            foreach (ICar item in taxi.Cars)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
