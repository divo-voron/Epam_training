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
                Ports = new List<Port>() { new Port("01"), new Port("02") },
                Terminals = new List<Terminal>() { new Terminal(), new Terminal() }
            };

            station.AddConnection(station.Terminals.ElementAt(0), station.Ports.ElementAt(0));
            station.AddConnection(station.Terminals.ElementAt(1), station.Ports.ElementAt(1));

            station.Terminals.ElementAt(0).Call();
            station.Terminals.ElementAt(1).Drop();
        }
    }
}
