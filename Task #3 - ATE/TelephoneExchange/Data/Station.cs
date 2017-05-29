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
        }
        public Station()
        {
            _ports = new Dictionary<PhoneNumber, IPort>();
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

        public void RegisterPort(IPort port)
        {
            if (_ports.Values.Contains(port) == false)
            {
                port.Connected += ConnectStation;
                port.Disconnected += DisconnectStation;
                _ports.Add(port.Number, port);
            }
            else
            {
                UnregisterPort(port);
                port.Connected += ConnectStation;
                port.Disconnected += DisconnectStation;
            }
        }
        public void RegisterPort(IEnumerable<IPort> ports)
        {
            foreach (IPort port in ports)
            {
                if (_ports.Values.Contains(port) == false)
                {
                    port.Connected += ConnectStation;
                    port.Disconnected += DisconnectStation;
                    _ports.Add(port.Number, port);
                }
                else
                {
                    UnregisterPort(port);
                    port.Connected += ConnectStation;
                    port.Disconnected += DisconnectStation;
                }
            }
        }
        public void UnregisterPort(IPort port)
        {
            if (port != null)
            {
                port.Connected -= ConnectStation;
                port.Disconnected -= DisconnectStation;

                //_ports.Remove(port);
            }
        }
        private void ConnectStation(object sender, EventArgs e)
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
        private void DisconnectStation(object sender, EventArgs e)
        {
            IPort port = sender as IPort;
            if (port != null)
            {
                port.Calling -= CallStation;
                port.Accepted -= AcceptStation;
                port.Dropped -= DropStation;
            }
        }
        private void CallStation(object sender, CallRequestNumber e)
        {
            IPort portSource = sender as IPort;
            IPort portTarget = _ports[e.Number];
            if (portSource != null && portTarget != null && portSource != portTarget && 
                _sessionContainer.IsOpenedSession(portSource, portTarget))
            {
                portTarget.StateCall = PortStateCall.Dialing;
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
        private void AcceptStation(object sender, EventArgs e)
        {
            IPort port = sender as IPort;
            Session currentSession = _sessionContainer.GetByTarget(port, SessionState.Open);
            if (currentSession != null)
            {
                currentSession.Source.StateCall = PortStateCall.Busy;
                currentSession.Target.StateCall = PortStateCall.Busy;
                currentSession.State = SessionState.Connected;
                currentSession.Start = DateTime.Now;
                Console.WriteLine("Incoming call accepted");
            }
            else
            {
                Console.WriteLine("Incoming call not found");
            }
        }
        private void DropStation(object sender, EventArgs e)
        {
            IPort port = sender as IPort;
            if (port != null)
            {
                Session currentSession = _sessionContainer.GetByAny(port);
                if (currentSession != null)
                {
                    if (currentSession.State == SessionState.Connected)
                    {
                        currentSession.Source.StateCall = PortStateCall.Free;
                        currentSession.Target.StateCall = PortStateCall.Free;
                        currentSession.State = SessionState.Close;

                        OnCallEnded(new ConnectInfo(currentSession.Source.Number, currentSession.Target.Number, currentSession.Start, DateTime.Now, ConnectInfoState.Accepted));

                        _sessionContainer.Remove(currentSession);

                        Console.WriteLine("Сurrent call is completed");
                    }
                    else
                    {
                        currentSession.Source.StateCall = PortStateCall.Free;
                        currentSession.Target.StateCall = PortStateCall.Free;
                        currentSession.State = SessionState.Close;

                        OnCallEnded(new ConnectInfo(currentSession.Source.Number, currentSession.Target.Number, currentSession.Start, currentSession.Start, ConnectInfoState.Unaccepted));

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