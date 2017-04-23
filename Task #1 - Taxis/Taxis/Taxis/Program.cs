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
using TaxiStation.Factory;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        static void Serial()
        {
            Car[] cars = 
            { 
                new Coupe(1, 1, 1, 1, 1), 
                new Sedan(1, 1, 1, 1, 1, 1), 
                //new Premium(1, 1, 1, 1, 1, 1), 
                //new Gazel(1, 1, 1, 1, 1) 
            };

            Car cars123 = new Coupe(1, 1, 1, 1, 1);

            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Car));

            using (FileStream fs = new FileStream(@"D:\1\Car.json", FileMode.Create))
            {
                jsonSer.WriteObject(fs, cars123);
            }
        }
        static void TestToString()
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

            foreach (ICar item in taxi.Cars)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void FactoryMethod()
        {
            // an array of creators
            Creator[] creators = 
            { 
                new CreatorCar(new Coupe(1, 1, 1, 1, 1)),
                new CreatorCar(new Sedan(1,1 ,1, 1, 1, 1)),
                new CreatorCar(new Premium(1, 1, 1, 1, 1, 1)),
                new CreatorCar(new Gazel(1, 1, 1, 1, 1)) 
            };

            foreach (Creator creator in creators)
            {
                // iterate over creators and create products
                CarData carData = creator.FactoryMethod();
                Console.WriteLine("Created {0}", carData.GetData());
            }


            CarData[] carDates = 
            {
                new Coupe(1,1,1,1,1).GetData(),
                new Sedan(1,1 ,1, 1, 1, 1).GetData(),
                new Premium(1, 1, 1, 1, 1, 1).GetData(),
                new Gazel(1, 1, 1, 1, 1).GetData() 
            };

            foreach (CarData carData in carDates)
            {
                // iterate over creators and create products
                Console.WriteLine("Created {0}", carData.GetData());
            }
        }
    }
}
