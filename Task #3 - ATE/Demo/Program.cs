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
            Billing billing = new Billing();
            billing.AddClient(new Client("Jhon", new PhoneNumber("0", "01"), new Tariff()));
            billing.AddClient(new Client("Bob", new PhoneNumber("0", "02"), new Tariff()));
            billing.AddClient(new Client("Alice", new PhoneNumber("0", "03"), new Tariff()));

            Station station = new Station();
            station.CallEnd += billing.GetConnectionInfo;

            ICollection<ITerminal> terminals = new List<ITerminal>() { new Terminal(), new Terminal(), new Terminal() };

            station.RegisterNumber(billing.Clients.Select(x => x.Number));

            station.Ports.Values.ElementAt(0).RegisterTerminal(terminals.ElementAt(0));
            station.Ports.Values.ElementAt(1).RegisterTerminal(terminals.ElementAt(1));
            station.Ports.Values.ElementAt(2).RegisterTerminal(terminals.ElementAt(2));



            terminals.ElementAt(0).Connect();
            terminals.ElementAt(1).Connect();
            terminals.ElementAt(2).Connect();

            for (int i = 0; i < 2; i++)
            {
                terminals.ElementAt(0).Call(new PhoneNumber("0", "02"));
                terminals.ElementAt(1).Accept();

                System.Threading.Thread.Sleep(new Random().Next(1000));
                
                terminals.ElementAt(1).Drop();
            }

            var a = billing.History;
        }

        
    }
}
