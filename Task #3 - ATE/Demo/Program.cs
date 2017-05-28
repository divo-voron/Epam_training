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
        static void Main(string[] args)
        {
            //Billing billing = new Billing();
            Billing.AddClient(new Client("Jhon", new PhoneNumber(0, 100), new TariffPerSecond()));
            Billing.AddClient(new Client("Bob", new PhoneNumber(0, 200), new TariffPerSecond()));
            Billing.AddClient(new Client("Alice", new PhoneNumber(0, 300), new TariffPerSecond()));

            Station station = new Station();
            station.CallEnd += Billing.AddConnectionInfo;

            ICollection<ITerminal> terminals = new List<ITerminal>() { new Terminal(), new Terminal(), new Terminal() };

            station.RegisterNumber(Billing.Clients.Select(x => x.Number));

            station.Ports.Values.ElementAt(0).RegisterTerminal(terminals.ElementAt(0));
            station.Ports.Values.ElementAt(1).RegisterTerminal(terminals.ElementAt(1));
            station.Ports.Values.ElementAt(2).RegisterTerminal(terminals.ElementAt(2));
            
            terminals.ElementAt(0).Connect();
            terminals.ElementAt(1).Connect();
            terminals.ElementAt(2).Connect();

            for (int i = 0; i < 1; i++)
            {
                terminals.ElementAt(0).Call(new PhoneNumber(0, 200));
                terminals.ElementAt(1).Accept();
                System.Threading.Thread.Sleep(new Random().Next(3000));
                terminals.ElementAt(1).Drop();

                terminals.ElementAt(0).Call(new PhoneNumber(0, 300));
                terminals.ElementAt(2).Accept();
                System.Threading.Thread.Sleep(new Random().Next(3000));
                terminals.ElementAt(2).Drop();

                terminals.ElementAt(1).Call(new PhoneNumber(0, 100));
                terminals.ElementAt(0).Accept();
                System.Threading.Thread.Sleep(new Random().Next(3000));
                terminals.ElementAt(0).Drop();

                terminals.ElementAt(1).Call(new PhoneNumber(0, 300));
                terminals.ElementAt(2).Accept();
                System.Threading.Thread.Sleep(new Random().Next(3000));
                terminals.ElementAt(2).Drop();

                terminals.ElementAt(2).Call(new PhoneNumber(0, 100));
                terminals.ElementAt(0).Accept();
                System.Threading.Thread.Sleep(new Random().Next(3000));
                terminals.ElementAt(0).Drop();

                terminals.ElementAt(2).Call(new PhoneNumber(0, 200));
                terminals.ElementAt(1).Accept();
                System.Threading.Thread.Sleep(new Random().Next(3000));
                terminals.ElementAt(1).Drop();
            }

            string s = Billing.GetConnection(Billing.Clients.ElementAt(0)).GetInfo();
            Console.WriteLine(s);
        }
    }
}
