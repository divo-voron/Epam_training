using BillingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneExchange;

namespace Demo
{
    class Program
    {
        private const int maxTime = 3000;

        static void Main(string[] args)
        {
            Billing.AddClient(new Client("Jhon", new PhoneNumber(0, 100), new TariffPerSecond()));
            Billing.AddClient(new Client("Bob", new PhoneNumber(0, 200), new TariffPerMinute()));
            Billing.AddClient(new Client("Alice", new PhoneNumber(0, 300), new TariffPerMinute()));

            Billing.Clients.ElementAt(0).AddMoney(5);
            Billing.Clients.ElementAt(1).AddMoney(24);
            Billing.Clients.ElementAt(2).AddMoney(12);

            Station station = new Station();
            station.CallEnd += Billing.AddConnectionInfo;

            ICollection<ITerminal> terminals = new List<ITerminal>() { new Terminal(), new Terminal(), new Terminal() };

            station.RegisterPort(Billing.Clients.Select(x => x.Port));

            station.Ports.Values.ElementAt(0).RegisterTerminal(terminals.ElementAt(0));
            station.Ports.Values.ElementAt(1).RegisterTerminal(terminals.ElementAt(1));
            station.Ports.Values.ElementAt(2).RegisterTerminal(terminals.ElementAt(2));
            
            terminals.ElementAt(0).Connect();
            terminals.ElementAt(1).Connect();
            terminals.ElementAt(2).Connect();

            for (int i = 0; i < 2; i++)
            {
                terminals.ElementAt(0).Call(new PhoneNumber(0, 200));
                terminals.ElementAt(1).Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                terminals.ElementAt(1).Drop();
                Console.WriteLine(Billing.Clients.ElementAt(0).Bill);

                terminals.ElementAt(0).Call(new PhoneNumber(0, 300));
                terminals.ElementAt(2).Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                terminals.ElementAt(2).Drop();
                Console.WriteLine(Billing.Clients.ElementAt(0).Bill);

                terminals.ElementAt(1).Call(new PhoneNumber(0, 100));
                terminals.ElementAt(0).Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                terminals.ElementAt(0).Drop();
                Console.WriteLine(Billing.Clients.ElementAt(1).Bill);

                terminals.ElementAt(1).Call(new PhoneNumber(0, 300));
                terminals.ElementAt(2).Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                terminals.ElementAt(2).Drop();
                Console.WriteLine(Billing.Clients.ElementAt(1).Bill);

                terminals.ElementAt(2).Call(new PhoneNumber(0, 100));
                terminals.ElementAt(0).Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                terminals.ElementAt(0).Drop();
                Console.WriteLine(Billing.Clients.ElementAt(2).Bill);

                terminals.ElementAt(2).Call(new PhoneNumber(0, 200));
                terminals.ElementAt(1).Accept();
                System.Threading.Thread.Sleep(new Random().Next(maxTime));
                terminals.ElementAt(1).Drop();
                Console.WriteLine(Billing.Clients.ElementAt(2).Bill);
            }

            string s = Billing.GetConnection(Billing.Clients.ElementAt(0)).GetInfo();
            Console.WriteLine(s);
        }
    }
}
