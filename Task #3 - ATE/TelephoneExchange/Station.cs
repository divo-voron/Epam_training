using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Station
    {
        private List<Port> _ports;
        private List<Terminal> _terminals;
        public List<Port> Ports
        {
            get { return _ports; }
            set { _ports = value; }
        }
        public List<Terminal> Terminals
        {
            get { return _terminals; }
            set { _terminals = value; }
        }
        public Station() { }
        public Station(List<Port> ports, List<Terminal> terminals)
        {
            _ports = ports;
            _terminals = terminals;
        }

        public void AddConnection(Terminal terminal, Port port)
        {
            terminal.Calling += port.CallTerminalWithPort;
            terminal.Accepted += port.AcceptTerminalWithPort;
            terminal.Dropped += port.DropTerminalWithPort;

            port.Calling += CallTerminalWithStation;
            port.Accepted += AcceptTerminalWithStation;
            port.Dropped += DropTerminalWithStation;
        }

        //public void AddConnection(ICollection<Terminal> terminals, Port port)
        //{
        //    foreach (Terminal terminal in terminals)
        //    {
        //        terminal.Calling += port.CallTerminalWithPort;
        //        terminal.Accepted += port.AcceptTerminalWithPort;
        //        terminal.Dropped += port.DropTerminalWithPort;
        //    }

        //    port.Calling += CallTerminalWithStation;
        //    port.Accepted += AcceptTerminalWithStation;
        //    port.Dropped += DropTerminalWithStation;
        //}

        public void CallTerminalWithStation(object sender, EventArgs e)
        {
           
        }
        public void DropTerminalWithStation(object sender, EventArgs e)
        {

        }
        public void AcceptTerminalWithStation(object sender, EventArgs e)
        {

        }
    }
}