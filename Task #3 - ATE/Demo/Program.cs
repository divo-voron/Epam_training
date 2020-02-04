using BillingSystem;
using BillingSystem.Data;
using BillingSystem.Data.Tariff.TariffTypes;
using System;
using System.Linq;
using System.Timers;
using BillingSystem.Extensions;
using TelephoneExchange;
using TelephoneExchange.StationComponent;

namespace Demo
{
    class Program
    {
        private const int maxTime = 2000;

        static void Main(string[] args)
        {
            var timer = new Timer(86400000)
            {
                AutoReset = true
            };

            timer.Start();
            timer.Elapsed += Billing.TimerElapsed;

            var johnClient = new Client("John", new PhoneNumber(0, 100), new TariffPerSecond(15), 5);
            var bobClient = new Client("Bob", new PhoneNumber(0, 200), new TariffPerSecond(5), 24);
            var aliceClient = new Client("Alice", new PhoneNumber(0, 300), new TariffWithFreeMinute(5, 45), 12);

            Billing.AddClient(johnClient);
            Billing.AddClient(bobClient);
            Billing.AddClient(aliceClient);

            var station = new Station();
            station.CallEnd += Billing.AddConnectionInfo;

            var johnTerminal = new Terminal();
            var bobTerminal = new Terminal();
            var aliceTerminal = new Terminal();

            station.RegisterPort(johnClient.Port);
            station.RegisterPort(bobClient.Port);
            station.RegisterPort(aliceClient.Port);

            station.Ports[johnClient.Port.Number].RegisterTerminal(johnTerminal);
            station.Ports[bobClient.Port.Number].RegisterTerminal(bobTerminal);
            station.Ports[aliceClient.Port.Number].RegisterTerminal(aliceTerminal);

            johnTerminal.Connect();
            bobTerminal.Connect();
            aliceTerminal.Connect();

            for (var i = 0; i < 1; i++)
            {
                johnTerminal.Call(new PhoneNumber(0, 200));
                bobTerminal.Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                bobTerminal.Drop();
                Console.WriteLine(johnClient.Bill);

                johnTerminal.Call(new PhoneNumber(0, 300));
                aliceTerminal.Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                aliceTerminal.Drop();
                Console.WriteLine(johnClient.Bill);

                bobTerminal.Call(new PhoneNumber(0, 100));
                johnTerminal.Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                johnTerminal.Drop();
                Console.WriteLine(bobClient.Bill);

                bobTerminal.Call(new PhoneNumber(0, 300));
                aliceTerminal.Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                aliceTerminal.Drop();
                Console.WriteLine(bobClient.Bill);

                aliceTerminal.Call(new PhoneNumber(0, 100));
                johnTerminal.Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                johnTerminal.Drop();
                Console.WriteLine(aliceClient.Bill);

                aliceTerminal.Call(new PhoneNumber(0, 200));
                bobTerminal.Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                bobTerminal.Drop();
                Console.WriteLine(aliceClient.Bill);
            }

            Console.WriteLine();

            Console.WriteLine(johnClient.Name);

            Console.WriteLine(Billing.GetConnections(By.Client(johnClient))
                .GetString());
            Console.WriteLine();

            Console.WriteLine(bobClient.Name);
            Console.WriteLine(Billing.GetConnections(By.Client(bobClient))
                .GetString());
            Console.WriteLine();

            Console.WriteLine(aliceClient.Name);
            Console.WriteLine(Billing.GetConnections(By.Client(aliceClient))
                .GetString());
            Console.WriteLine();


            Console.WriteLine();

            Console.WriteLine(johnClient.Name);
            Console.WriteLine(Billing.GetConnections(By.Client(johnClient))
                .Where(x => x.Cost > 0)
                .GetString());
            Console.WriteLine();

            Console.WriteLine(bobClient.Name);
            Console.WriteLine(Billing.GetConnections(By.Client(bobClient))
                .OrderByDescending(x => x.Start)
                .GetString());
            Console.WriteLine();

            Console.WriteLine(aliceClient.Name);
            Console.WriteLine(Billing.GetConnections(By.Client(aliceClient))
                .Where(x => x.Duration > new TimeSpan(0, 0, 3))
                .GetString());
            Console.WriteLine();
        }
    }
}
