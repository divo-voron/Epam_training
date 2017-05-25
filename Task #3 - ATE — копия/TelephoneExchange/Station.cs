using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Station
    {
        private SessionContainer _sessionContainer;
        private ICollection<IPort> _ports;
        public ICollection<IPort> Ports
        {
            get { return _ports; }
            set { _ports = value; }
        }
        public Station()
        {
            _sessionContainer = new SessionContainer();
        }
        public Station(ICollection<IPort> ports)
        {
            _ports = ports;

            _sessionContainer = new SessionContainer();
        }

        public void AddConnection(ITerminal terminal, IPort port)
        {
            terminal.Connected += port.ConnectPort;
            terminal.Disconnected += port.DisconnectPort;
            
            port.Connected += ConnectStation;
            port.Disconnected += DisconnectStation;
            
        }
        public void RemoveConnection(ITerminal terminal, IPort port)
        {
            terminal.Connected -= port.ConnectPort;
            terminal.Disconnected -= port.DisconnectPort;

            port.Connected -= ConnectStation;
            port.Disconnected -= DisconnectStation;
        }
        public void ConnectStation(object sender, CallRequestConnect e)
        {
            ITerminal terminal = sender as ITerminal;
            IPort port = e.Port;
            if (terminal != null)
            {
                terminal.Calling += port.CallPort;
                terminal.Accepted += port.AcceptPort;
                terminal.Dropped += port.DropPort;

                port.Calling += CallStation;
                port.Accepted += AcceptStation;
                port.Dropped += DropStation;

                port.IncomingCall += terminal.IncomimgCall;
            }
        }
        public void DisconnectStation(object sender, CallRequestConnect e)
        {
            ITerminal terminal = sender as ITerminal;
            IPort port = e.Port;
            if (terminal != null)
            {
                terminal.Calling -= port.CallPort;
                terminal.Accepted -= port.AcceptPort;
                terminal.Dropped -= port.DropPort;

                port.Calling -= CallStation;
                port.Accepted -= AcceptStation;
                port.Dropped -= DropStation;

                port.IncomingCall -= terminal.IncomimgCall;
            }
        }
        public void CallStation(object sender, CallRequestNumber e)
        {
            IPort portSource = sender as IPort;
            IPort portTarget = _ports.FirstOrDefault(x => x.Number == e.Number);
            if (portSource != null && portTarget != null && portSource != portTarget && 
                _sessionContainer.IsOpenedSession(portSource, portTarget))
            {
                portTarget.State = StatePort.Dialing;
                _sessionContainer.Add(new Session(portSource, portTarget));
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
            IPort port = sender as IPort;
            Session currentSession = _sessionContainer.GetByTarget(port, SessionState.Open);
            if (currentSession != null)
            {
                currentSession.Source.State = StatePort.Busy;
                currentSession.Target.State = StatePort.Busy;
                currentSession.State = SessionState.Connected;
                currentSession.Start = DateTime.Now;
                Console.WriteLine("Icnoming call accepted");
            }
            else
            {
                Console.WriteLine("Incoming call not found");
            }
        }
        public void DropStation(object sender, EventArgs e)
        {
            IPort port = sender as IPort;
            if (port != null)
            {
                Session currentSession = _sessionContainer.GetByAny(port, SessionState.Connected);
                if (currentSession != null)
                {
                    currentSession.Source.State = StatePort.Free;
                    currentSession.Target.State = StatePort.Free;
                    currentSession.State = SessionState.Close;
                    
                    ConnectInfo connectInfo = new ConnectInfo(currentSession.Source, currentSession.Target, currentSession.Start, DateTime.Now);

                    _sessionContainer.Remove(currentSession);

                    // TODO: write connectInfo to BillingSystem
                    


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