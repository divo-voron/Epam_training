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
            Station station = new Station()
            {
                Ports = new List<IPort>() { new Port(new PhoneNumber("0", "01")), new Port(new PhoneNumber("0", "02")) }
            };

            ICollection<ITerminal> terminals = new List<ITerminal>() { new Terminal(), new Terminal() };

            station.AddConnection(terminals.ElementAt(0), station.Ports.ElementAt(0));
            station.AddConnection(terminals.ElementAt(1), station.Ports.ElementAt(1));

            terminals.ElementAt(0).Connect();
            terminals.ElementAt(0).Call(new PhoneNumber("0", "02"));
            
            terminals.ElementAt(1).Accept();

            //System.Threading.Thread.Sleep(1000);

            terminals.ElementAt(1).Drop();
        }
    }
}
