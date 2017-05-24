using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Station
    {
        private ICollection<Session> _sessions;
        private ICollection<Port> _ports;
        private ICollection<Terminal> _terminals;
        public ICollection<Port> Ports
        {
            get { return _ports; }
            set { _ports = value; }
        }
        public ICollection<Terminal> Terminals
        {
            get { return _terminals; }
            set { _terminals = value; }
        }
        public ICollection<Session> Sessions
        {
            get { return _sessions; }
            set { _sessions = value; }
        }
        public Station()
        {
            _sessions = new List<Session>(); 
        }
        public Station(ICollection<Port> ports, ICollection<Terminal> terminals)
        {
            _ports = ports;
            _terminals = terminals;

            _sessions = new List<Session>();
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
        public void CallTerminalWithStation(object sender, CallRequest e)
        {
            Port portSource = sender as Port;
            Port portTarget = _ports.FirstOrDefault(x => x.Number == e.Number);
            if (portSource != null && portTarget != null)
                _sessions.Add(new Session(portSource, portTarget));
            else
                return;
        }
        public void AcceptTerminalWithStation(object sender, EventArgs e)
        {
            Port port = sender as Port;
            Session currentSession = _sessions.FirstOrDefault(x => x.Target == port);
            if (currentSession != null)
            {
                currentSession.State = SessionState.Open;
                Console.WriteLine("Icnoming call accepted");
            }
            else
            {
                Console.WriteLine("Not found incoming call");
            }
        }
        public void DropTerminalWithStation(object sender, EventArgs e)
        {
            Port port = sender as Port;
            Session currentSession = _sessions.FirstOrDefault(x => x.State == SessionState.Open && (x.Source == port || x.Target == port));
            if (currentSession != null)
            {
                _sessions.Remove(currentSession);
                // TODO: write ConnectInfo to BillingSystem

                Console.WriteLine("Call is complete");
            }
            else
            {
                Console.WriteLine("Session is not found");
            }
        }
    }
}