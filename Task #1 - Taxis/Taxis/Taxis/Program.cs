using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.CarsItems;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Taxi taxi = new Taxi();
            taxi.Add(new Coupe(2, 200, 12, 20000));
            taxi.Add(new Sedan(4, 100, 200, 15, 15000));
            taxi.Add(new Premium(4, 120, 150, 13, 25000));
            taxi.Add(new Gazel(500, 100, 22, 5000));

            int carriyng = taxi.Carrying;
            int passangers = taxi.NumberOfPassengers;

            //Data.Write(taxi);
        }
    }
}
