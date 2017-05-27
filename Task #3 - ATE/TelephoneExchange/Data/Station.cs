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
        private IDictionary<PhoneNumber, IPort> _ports;
        public IDictionary<PhoneNumber, IPort> Ports
        {
            get { return _ports; }
            set { _ports = value; }
        }
        public Station()
        {
            _ports = new Dictionary<PhoneNumber, IPort>();
            _sessionContainer = new SessionContainer();
        }
        public Station(IDictionary<PhoneNumber, IPort> ports)
        {
            foreach (IPort port in ports.Values)
            {
                UnregisterNumber(port.Number);
                port.Connected += ConnectStation;
                port.Disconnected += DisconnectStation;
            }

            _ports = ports;
            _sessionContainer = new SessionContainer();
        }

        private EventHandler<ConnectInfo> _callEnd;
        public event EventHandler<ConnectInfo> CallEnd
        {
            add { _callEnd += value; }
            remove { _callEnd -= value; }
        }
        private void OnCallEnded(ConnectInfo connectInfo)
        {
            if (_callEnd != null) _callEnd(this, connectInfo);
        }

        public void RegisterNumber(PhoneNumber number)
        {
            if (_ports.ContainsKey(number) == false)
            {
                IPort port = new Port(number);
                port.Connected += ConnectStation;
                port.Disconnected += DisconnectStation;
                _ports.Add(number, port);
            }
            else 
            {
                IPort port = _ports[number];
                UnregisterNumber(number);
                port.Connected += ConnectStation;
                port.Disconnected += DisconnectStation;
            }
        }
        public void RegisterNumber(IEnumerable<PhoneNumber> numbers)
        {
            foreach (PhoneNumber number in numbers)
            {
                if (_ports.ContainsKey(number) == false)
                {
                    IPort port = new Port(number);
                    port.Connected += ConnectStation;
                    port.Disconnected += DisconnectStation;
                    _ports.Add(number, port);
                }
                else
                {
                    IPort port = _ports[number];
                    UnregisterNumber(number);
                    port.Connected += ConnectStation;
                    port.Disconnected += DisconnectStation;
                }
            }
        }
        public void UnregisterNumber(PhoneNumber number)
        {
            IPort port = _ports[number];
            if (port != null)
            {
                port.Connected -= ConnectStation;
                port.Disconnected -= DisconnectStation;

                _ports.Remove(number);
            }
        }
        public void ConnectStation(object sender, EventArgs e)
        {
            IPort port = sender as IPort;
            if (port != null)
            {
                DisconnectStation(sender, e);

                port.Calling += CallStation;
                port.Accepted += AcceptStation;
                port.Dropped += DropStation;
            }
        }
        public void DisconnectStation(object sender, EventArgs e)
        {
            IPort port = sender as IPort;
            if (port != null)
            {
                port.Calling -= CallStation;
                port.Accepted -= AcceptStation;
                port.Dropped -= DropStation;
            }
        }
        public void CallStation(object sender, CallRequestNumber e)
        {
            IPort portSource = sender as IPort;
            IPort portTarget = _ports[e.Number];
            if (portSource != null && portTarget != null && portSource != portTarget && 
                _sessionContainer.IsOpenedSession(portSource, portTarget))
            {
                portTarget.State = PortsState.Dialing;
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
                currentSession.Source.State = PortsState.Busy;
                currentSession.Target.State = PortsState.Busy;
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
                Session currentSession = _sessionContainer.GetByAny(port);
                if (currentSession != null)
                {
                    if (currentSession.State == SessionState.Connected)
                    {
                        currentSession.Source.State = PortsState.Free;
                        currentSession.Target.State = PortsState.Free;
                        currentSession.State = SessionState.Close;

                        OnCallEnded(new ConnectInfo(currentSession.Source.Number, currentSession.Target.Number, currentSession.Start, DateTime.Now));

                        _sessionContainer.Remove(currentSession);

                        Console.WriteLine("Сurrent call is completed");
                    }
                    else
                    {
                        currentSession.Source.State = PortsState.Free;
                        currentSession.Target.State = PortsState.Free;
                        currentSession.State = SessionState.Close;

                        _sessionContainer.Remove(currentSession);

                        Console.WriteLine("Сurrent dialing is interrupted");
                    }
                }
                else
                {
                    Console.WriteLine("Session not found");
                }
            }
        }
    }
}