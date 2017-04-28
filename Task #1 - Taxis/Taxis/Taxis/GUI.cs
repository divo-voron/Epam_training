using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    static class GUI
    {
        private static Taxi _taxi;
        public static void GetTaxi(Taxi taxi) 
        {
            _taxi = taxi;
        }
        public static void ChooseAction()
        {
            Console.WriteLine("Taxi contains:\r\n");

            ShowData(_taxi.Cars);

            while (true)
            {
                Console.WriteLine("\r\nPlease choose what do you want to do? " +
                                  "\r\n 1. Show all items in Taxi " +
                                  "\r\n 2. Get full price " +
                                  "\r\n 3. Get full load capacity " +
                                  "\r\n 4. Sort by property " +
                                  "\r\n 5. Find cars by property " +
                                  "\r\n 6. Exit\r\n");
                int choose;
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Taxi contains:\r\n");
                            ShowData(_taxi.Cars);
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("\nTotal cost of the taxi: {0}", _taxi.Cars.Sum(item => item.Price));
                            Console.WriteLine("-----------------------------");
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("\nTotal load capacity of the taxi: {0}", _taxi.Cars.OfType<ICargo>().Sum(item => item.Cargo));
                            Console.WriteLine("-----------------------------");
                            break;
                        case 4:
                            SortByProperty();
                            break;
                        case 5:
                            FindByProperty();
                            break;
                        case 6:
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
            ShowData(_taxi.Cars);
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
                            ShowData(_taxi.Cars.OrderBy(item => item.Speed));
                            break;
                        case 2:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by fuel consumption");
                            ShowData(_taxi.Cars.OrderBy(item => item.FuelConsumption));
                            break;
                        case 3:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by price");
                            ShowData(_taxi.Cars.OrderBy(item => item.Price));
                            break;
                        case 4:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by curb weight");
                            ShowData(_taxi.Cars.OrderBy(item => item.CurbWeight));
                            break;
                        case 5:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by full weight");
                            ShowData(_taxi.Cars.OrderBy(item => item.GetFullWeight()));
                            break;
                        case 6:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by cargo");
                            ShowData(_taxi.Cars.OfType<ICargo>().OrderBy(item => item.Cargo));
                            break;
                        case 7:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Sorted by passenger");
                            ShowData(_taxi.Cars.OfType<IPassengers>().OrderBy(item => item.NumberOfPassengers));
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
            Console.Clear();
            ShowData(_taxi.Cars);
            while (true)
            {
                Console.WriteLine("Find by:\r\n" +
                                  "1. Speed\r\n" +
                                  "2. Fuel consumption\r\n" +
                                  "3. Price\r\n" +
                                  "4. Curb weight\r\n" +
                                  "5. Full Weight\r\n" +
                                  "6. Cargo\r\n" +
                                  "7. Number of passengers\r\n" +
                                  "8. Back");
                int choose;
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    int from;
                    int to;
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Find by speed");
                            Console.Write("Enter speed from: "); int.TryParse(Console.ReadLine(), out from);
                            Console.Write("Enter speed to: "); int.TryParse(Console.ReadLine(), out to);
                            ShowData(_taxi.Cars.Where(item => from <= item.Speed && item.Speed <= to).OrderBy(item => item.Speed));
                            break;
                        case 2:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Find by fuel consumption");
                            Console.Write("Enter fuel consumption from: "); int.TryParse(Console.ReadLine(), out from);
                            Console.Write("Enter fuel consumption to: "); int.TryParse(Console.ReadLine(), out to);
                            ShowData(_taxi.Cars
                                .Where(item => from <= item.FuelConsumption && item.FuelConsumption <= to)
                                .OrderBy(item => item.FuelConsumption));
                            break;
                        case 3:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Find by price");
                            Console.Write("Enter price from: "); int.TryParse(Console.ReadLine(), out from);
                            Console.Write("Enter price to: "); int.TryParse(Console.ReadLine(), out to);
                            ShowData(_taxi.Cars
                                .Where(item => from <= item.Price && item.Price <= to).OrderBy(item => item.Price));
                            break;
                        case 4:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Find by curb weight");
                            Console.Write("Enter curb weight from: "); int.TryParse(Console.ReadLine(), out from);
                            Console.Write("Enter curb weight to: "); int.TryParse(Console.ReadLine(), out to);
                            ShowData(_taxi.Cars
                                .Where(item => from <= item.CurbWeight && item.CurbWeight <= to)
                                .OrderBy(item => item.CurbWeight));
                            break;
                        case 5:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Find by full weight");
                            Console.Write("Enter full weight from: "); int.TryParse(Console.ReadLine(), out from);
                            Console.Write("Enter full weight to: "); int.TryParse(Console.ReadLine(), out to);
                            ShowData(_taxi.Cars
                                .Where(item => from <= item.GetFullWeight() && item.GetFullWeight() <= to)
                                .OrderBy(item => item.GetFullWeight()));
                            break;
                        case 6:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Find by cargo");
                            Console.Write("Enter cargo from: "); int.TryParse(Console.ReadLine(), out from);
                            Console.Write("Enter cargo to: "); int.TryParse(Console.ReadLine(), out to);
                            ShowData(_taxi.Cars.OfType<ICargo>()
                                .Where(item => from <= item.Cargo && item.Cargo <= to)
                                .OrderBy(item => item.Cargo));
                            break;
                        case 7:
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Find by passenger");
                            Console.Write("Enter passenger from: "); int.TryParse(Console.ReadLine(), out from);
                            Console.Write("Enter passenger to: "); int.TryParse(Console.ReadLine(), out to);
                            ShowData(_taxi.Cars.OfType<IPassengers>()
                                .Where(item => from <= item.NumberOfPassengers && item.NumberOfPassengers <= to)
                                .OrderBy(item => item.NumberOfPassengers));
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
        private static void ShowData(IEnumerable cars)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("     Type |   Control | Speed | Fuel | Price | CurbWeight | FullWeight | P | C-go |");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (ICar car in cars)
            {
                Console.WriteLine(string.Concat("|", car.GetInfo() , " |"));
            }
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }
    }
}
