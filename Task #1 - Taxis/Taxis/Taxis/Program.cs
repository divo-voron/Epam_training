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
        static Taxi taxi;
        static void Main(string[] args)
        {
            taxi = Initial();
            ProgramInitialize();
        }
        static Taxi Initial()
        {
            return new Taxi(
                new List<ICar>() 
                { 
                    new Coupe(250, 13, 50, 1000, 2),
                    new Coupe(290, 14, 65, 1100, 2),
                    new Sedan(190, 10, 35, 1250, 3, 100),
                    new Sedan(190, 11, 35, 1350, 4, 150),
                    new Gazel(100, 16, 40, 1500, 1500),
                    new Gazel(100, 16, 45, 1500, 1800),
                    new Premium(180, 11, 80, 1000, 5, 220),
                    new Premium(180, 11, 85, 1200, 5, 250)
                });
        }
        private static void ProgramInitialize()
        {
            while (true)
            {
                Console.WriteLine("Choose action:\r\n1.Show Cars content\r\n2.Exit");
                int choose;
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    switch (choose)
                    {
                        case 1:
                            ChooseAction();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong input data\r\n-----------------------------\r\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input data\r\n-----------------------------\r\n");
                }
            }
        }
        static void ShowData(IEnumerable cars)
        {
            foreach (ICar car in cars)
            {
                Console.WriteLine(car.GetInfo());
            }
        }
        private static void ChooseAction()
        {
            Console.Clear();
            Console.WriteLine("Taxi contains:\r\n" +
                              "-------------------------------------------------");

            ShowData(taxi.Cars);

            while (true)
            {
                Console.WriteLine("\r\nPlease choose what do you want to do? " +
                                  "\r\n1.Get full price " +
                                  "\r\n2.Get full load capacity " +
                                  "\r\n3.Sort by property " +
                                  "\r\n4.Find cars by property " +
                                  "\r\n5.Back\r\n");
                int choose;
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    switch (choose)
                    {
                        case 1:
                            //var totalWeight = Core.Gift.Weight;
                            Console.Clear();
                            //Console.WriteLine("\nTotal weight of the gift: {0}", totalWeight);
                            Console.WriteLine("-----------------------------");
                            break;
                        case 2:
                            //var totalNetWeight = Core.Gift.NetWeight;
                            Console.Clear();
                            //Console.WriteLine("\nTotal net weight of the gift: {0}", totalNetWeight);
                            Console.WriteLine("-----------------------------");
                            break;
                        case 3:
                            SortByProperty();
                            break;
                        case 4:
                            FindByProperty();
                            break;
                        case 5:
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong input data");
                            Console.WriteLine("-----------------------------");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input data");
                    Console.WriteLine("-----------------------------");
                }
            }
        }
        private static void SortByProperty()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Sort by: " +
                                  "\n1. Speed " +
                                  "\n2. Fuel consumption " +
                                  "\n3. Price " +
                                  "\n4. Curb weight " +
                                  "\n5. Full Weight " +
                                  "\n6. Cargo " +
                                  "\n7. Number of passengers " +
                                  "\n8. Exit");
                int choose;
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by speed");
                            ShowData(taxi.Cars.OrderBy(item => item.Speed));
                            break;
                        case 2:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by fuel consumption");
                            ShowData(taxi.Cars.OrderBy(item => item.FuelConsumption));
                            break;
                        case 3:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by price");
                            ShowData(taxi.Cars.OrderBy(item => item.Price));
                            break;
                        case 4:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by curb weight");
                            ShowData(taxi.Cars.OrderBy(item => item.CurbWeight));
                            break;
                        case 5:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by full weight");
                            ShowData(taxi.Cars.OrderBy(item => item.GetFullWeight()));
                            break;
                        case 6:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by cargo");
                            ShowData(taxi.Cars.OfType<ICargo>().OrderBy(item => item.Cargo));
                            break;
                        case 7:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by passenger");
                            ShowData(taxi.Cars.OfType<IPassengers>().OrderBy(item => item.NumberOfPassengers));
                            break;
                        case 8:
                            Console.Clear();
                            return;
                        default:
                            Console.WriteLine("Wrong input data");
                            Console.WriteLine("-----------------------------");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input data");
                    Console.WriteLine("-----------------------------");
                }
            }
        }
        private static void FindByProperty()
        {
            //Console.Clear();
            //while (true)
            //{
            //    Console.WriteLine("Find by: " +
            //                      "\n1.Weight " +
            //                      "\n2.Sugar " +
            //                      "\n3.Name " +
            //                      "\n4.Company name " +
            //                      "\n5.Wrapper type " +
            //                      "\n6.Back");
            //    int choose;
            //    if (int.TryParse(Console.ReadLine(), out choose))
            //    {
            //        IEnumerable<IGiftComponent> giftComponents;

            //        switch (choose)
            //        {
            //            case 1:
            //                {
            //                    Console.WriteLine("-----------------------------");
            //                    Console.WriteLine("Find by weight");
            //                    Console.Write("Enter weight from:");
            //                    int weightFrom;
            //                    int.TryParse(Console.ReadLine(), out weightFrom);
            //                    Console.Write("Enter weight to:");
            //                    int weightTo;
            //                    int.TryParse(Console.ReadLine(), out weightTo);
            //                    giftComponents = Core.Gift.Where(component =>
            //                        weightFrom <= component.Weight && component.Weight <= weightTo);
            //                }
            //                break;
            //            case 2:
            //                {
            //                    Console.WriteLine("-----------------------------");
            //                    Console.WriteLine("Find by sugar");
            //                    Console.Write("Enter sugar from:");
            //                    int sugarFrom;
            //                    int.TryParse(Console.ReadLine(), out sugarFrom);
            //                    Console.Write("Enter sugar to:");
            //                    int sugarTo;
            //                    int.TryParse(Console.ReadLine(), out sugarTo);
            //                    giftComponents = Core.Gift.Where(component =>
            //                        sugarFrom <= component.Sugar && component.Sugar <= sugarTo);
            //                }
            //                break;
            //            case 3:
            //                {
            //                    Console.WriteLine("-----------------------------");
            //                    Console.WriteLine("Find by name");
            //                    Console.Write("Enter name:");
            //                    var name = Console.ReadLine();
            //                    giftComponents = Core.Gift.Where(component =>
            //                        !string.IsNullOrEmpty(component.Name) && component.Name.Contains(name));
            //                }
            //                break;
            //            case 4:
            //                {
            //                    Console.WriteLine("-----------------------------");
            //                    Console.WriteLine("Find by company name");
            //                    Console.Write("Enter name:");
            //                    var name = Console.ReadLine();
            //                    giftComponents = Core.Gift.Where(component =>
            //                        !string.IsNullOrEmpty(component.CompanyName) && component.CompanyName.Contains(name));
            //                }
            //                break;
            //            case 5:
            //                {
            //                    Console.WriteLine("-----------------------------");
            //                    Console.WriteLine("Find by wrapper type");
            //                    Console.WriteLine("1.Loose wrapper \n2.TightWrapper");
            //                    int wrapperType;
            //                    int.TryParse(Console.ReadLine(), out wrapperType);
            //                    switch (wrapperType)
            //                    {
            //                        case 1:
            //                            giftComponents = Core.Gift.Where(component =>
            //                                component.Wrapper != null && component.Wrapper.WrapperType == WrapperType.LooseWrapper);
            //                            break;
            //                        case 2:
            //                            giftComponents = Core.Gift.Where(component =>
            //                                component.Wrapper != null && component.Wrapper.WrapperType == WrapperType.TightWrapper);
            //                            break;
            //                        default:
            //                            continue;
            //                    }
            //                }
            //                break;
            //            case 6:
            //                Console.Clear();
            //                return;
            //            default:
            //                Console.WriteLine("Wrong input data");
            //                Console.WriteLine("-----------------------------");
            //                continue;
            //        }

            //        if (giftComponents.Any())
            //        {
            //            Console.Clear();
            //            var i = 1;
            //            foreach (var giftComponent in giftComponents)
            //            {
            //                ShowComponentInfo(giftComponent, i);
            //                i++;
            //            }
            //        }
            //        else
            //        {
            //            Console.Clear();
            //            Console.WriteLine("Cannot find elements by search criteria");
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("Wrong input data");
            //        Console.WriteLine("-----------------------------");
            //    }
            //}
        }
        static void Serial()
        {
            Car[] cars = 
            { 
                new Coupe(1, 1, 1, 1, 1), 
                new Sedan(1, 1, 1, 1, 1, 1), 
                new Premium(1, 1, 1, 1, 1, 1), 
                new Gazel(1, 1, 1, 1, 1) 
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
                new CreatorCar(new Sedan(1, 1, 1, 1, 1, 1)),
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
                new Coupe(1, 1, 1, 1, 1).GetData(),
                new Sedan(1, 1, 1, 1, 1, 1).GetData(),
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
