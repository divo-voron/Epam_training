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
            //try
            //{
            //    Taxi taxi = new Taxi(
            //        new List<ICar>() 
            //    { 
            //        new Coupe(1, 250, 13, 50, 1000, 2, CarsControlSystemType.Autopilot),
            //        new Coupe(2, 290, 14, 65, 1100, 2),
            //        new Sedan(3, 190, 10, 35, 1250, 3, 100),
            //        new Sedan(4, 190, 11, 35, 1350, 4, 150),
            //        new Gazel(5, 100, 16, 40, 1500, 1500),
            //        new Gazel(6, 100, 16, 45, 1500, 1800),
            //        new Premium(7, 180, 11, 80, 1000, 5, 220, CarsControlSystemType.Autopilot),
            //        new Premium(8, 180, 11, 85, 1200, 5, 250)
            //    });

            //    Data.GetTaxi(taxi);
            //    Data.ChooseAction();
            //}
            //catch (Exception error) { Console.WriteLine(string.Format("App error: {0}", error.ToString())); }

            FactoryMethod();
        }
        static void FactoryMethod()
        {
            Creator[] creators = 
            { 
                new CreatorCoupe(1, 250, 13, 50, 1000, 2, CarsControlSystemType.Autopilot),
                new CreatorCoupe(2, 290, 14, 65, 1100, 2),
                new CreatorSedan(3, 190, 10, 35, 1250, 3, 100),
                new CreatorSedan(4, 190, 11, 35, 1350, 4, 150),
                new CreatorGazel(5, 100, 16, 40, 1500, 1500),
                new CreatorGazel(6, 100, 16, 45, 1500, 1800),
                new CreatorPremium(7, 180, 11, 80, 1000, 5, 220, CarsControlSystemType.Autopilot),
                new CreatorPremium(8, 180, 11, 85, 1200, 5, 250)
            };

            Write(creators);

            creators = Read();

            foreach (Creator creator in creators)
            {
                // iterate over creators and create products
                ICar car = creator.FactoryMethod();
                Console.WriteLine("Created {0}", car.Id);
            }
        }

        static void Write(Creator[] data)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Creator[]));

            using (FileStream fs = new FileStream(@"D:\1\Car.json", FileMode.Create))
            {
                jsonSer.WriteObject(fs, data);
            }
        }

        static Creator[] Read()
        {
            Creator[] retVal;
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(Creator[]));
            using (FileStream fs = new FileStream(@"D:\1\Car.json", FileMode.Open))
            {
                retVal = (Creator[])jsonSer.ReadObject(fs);
            }

            return retVal;
        }
    }
}
