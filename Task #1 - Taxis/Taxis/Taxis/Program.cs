using System;
using System.Collections;
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
            Taxi taxi = new Taxi(
                    new List<ICar>() 
                    { 
                        new Coupe(1, 1, 1, 1),
                        new Sedan(2, 2, 2, 2, 2),
                    });

            IEnumerable<ICar> a = taxi.Cars;
        }
    }
}
