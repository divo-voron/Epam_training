using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Station
    {
        private SessionContainer _session;
        private ICollection<Port> _ports;
        public ICollection<Port> Ports
        {
            get { return _ports; }
            set { _ports = value; }
        }
        public Station()
        {
            _session = new SessionContainer();
        }
        public Station(ICollection<Port> ports)
        {
            _ports = ports;

            _session = new SessionContainer();
        }

        public void AddConnection(ITerminal terminal, Port port)
        {
            terminal.Calling += port.CallPort;
            terminal.Accepted += port.AcceptPort;
            terminal.Dropped += port.DropPort;

            port.Calling += CallStation;
            port.Accepted += AcceptStation;
            port.Dropped += DropStation;

            port.IncomingCall += terminal.IncomimgCall;
        }
        public void RemoveConnection(ITerminal terminal, Port port)
        {
            terminal.Calling -= port.CallPort;
            terminal.Accepted -= port.AcceptPort;
            terminal.Dropped -= port.DropPort;

            port.Calling -= CallStation;
            port.Accepted -= AcceptStation;
            port.Dropped -= DropStation;

            port.IncomingCall -= terminal.IncomimgCall;
        }
        public void CallStation(object sender, CallRequest e)
        {
            Port portSource = sender as Port;
            Port portTarget = _ports.FirstOrDefault(x => x.Number == e.Number);
            if (portSource != null && portTarget != null && portSource != portTarget && 
                _session.IsOpenedSession(portSource, portTarget))
            {
                portTarget.State = StatePort.Dialing;
                _session.Add(new Session(portSource, portTarget));
                portTarget.IncomingCallPort(portTarget, null);
            }
            else
            {
                if (portSource == null) { Console.WriteLine("Source port doesn't exist"); }
                if (portTarget == null) { Console.WriteLine("Target port doesn't exist"); }
                if (portSource == portTarget) { Console.WriteLine("Port is already in use"); }
                Console.WriteLine("Connection not made");
            }
        }
        public void AcceptStation(object sender, EventArgs e)
        {
            Port port = sender as Port;
            Session currentSession = _session.GetByTarget(port, SessionState.Open);
            if (currentSession != null)
            {
                currentSession.Source.State = StatePort.Busy;
                currentSession.Target.State = StatePort.Busy;
                currentSession.State = SessionState.Connected;
                Console.WriteLine("Icnoming call accepted");
            }
            else
            {
                Console.WriteLine("Incoming call not found");
            }
        }
        public void DropStation(object sender, EventArgs e)
        {
            Port port = sender as Port;
            if (port != null)
            {
                Session currentSession = _session.GetByAny(port, SessionState.Connected);
                if (currentSession != null)
                {
                    currentSession.Source.State = StatePort.Free;
                    currentSession.Target.State = StatePort.Free;
                    currentSession.State = SessionState.Close;
                    _session.Remove(currentSession);

                    // TODO: write ConnectInfo to BillingSystem

                    Console.WriteLine("Сurrent call is completed");
                }
                else
                {
                    Console.WriteLine("Session not found");
                }
            }
        }
    }
}