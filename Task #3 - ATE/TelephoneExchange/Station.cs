using System;
using System.Collections.Generic;
using TelephoneExchange.StationComponent;
using TelephoneExchange.StationComponent.ConnectComponent;
using TelephoneExchange.StationComponent.PortComponent;
using TelephoneExchange.StationComponent.SessionComponent;

namespace TelephoneExchange
{
    public class Station
    {
        private readonly SessionContainer _sessionContainer;

        public IDictionary<PhoneNumber, IPort> Ports { get; }

        public Station()
        {
            Ports = new Dictionary<PhoneNumber, IPort>();
            _sessionContainer = new SessionContainer();
        }

        public event EventHandler<ConnectInfo> CallEnd;

        private void OnCallEnded(ConnectInfo connectInfo)
        {
            CallEnd?.Invoke(this, connectInfo);
        }

        public void RegisterPort(IPort port)
        {
            if (Ports.Values.Contains(port) == false)
            {
                port.Connected += ConnectStation;
                port.Disconnected += DisconnectStation;
                Ports.Add(port.Number, port);
            }
            else
            {
                UnregisterPort(port);
                port.Connected += ConnectStation;
                port.Disconnected += DisconnectStation;
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
            if (sender is IPort port)
            {
                DisconnectStation(sender, e);

                port.Calling += CallStation;
                port.Accepted += AcceptStation;
                port.Dropped += DropStation;
            }
        }

        private void DisconnectStation(object sender, EventArgs e)
        {
            if (sender is IPort port)
            {
                port.Calling -= CallStation;
                port.Accepted -= AcceptStation;
                port.Dropped -= DropStation;
            }
        }

        private void CallStation(object sender, CallRequestNumber e)
        {
            var portSource = sender as IPort;
            var portTarget = Ports[e.Number];
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
            var port = sender as IPort;
            var currentSession = _sessionContainer.GetByTarget(port, SessionState.Open);
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
            if (sender is IPort port)
            {
                var currentSession = _sessionContainer.GetByAny(port);
                if (currentSession != null)
                {
                    if (currentSession.State == SessionState.Connected)
                    {
                        currentSession.Source.StateCall = PortStateCall.Free;
                        currentSession.Target.StateCall = PortStateCall.Free;
                        currentSession.State = SessionState.Close;

                        OnCallEnded(new ConnectInfo(currentSession.Source.Number, currentSession.Target.Number, currentSession.Start, DateTime.Now, ConnectInfoState.Accepted));

                        _sessionContainer.Remove(currentSession);

                        Console.WriteLine("Current call is completed");
                    }
                    else
                    {
                        currentSession.Source.StateCall = PortStateCall.Free;
                        currentSession.Target.StateCall = PortStateCall.Free;
                        currentSession.State = SessionState.Close;

                        OnCallEnded(new ConnectInfo(currentSession.Source.Number, currentSession.Target.Number, currentSession.Start, currentSession.Start, ConnectInfoState.Unaccepted));

                        _sessionContainer.Remove(currentSession);

                        Console.WriteLine("Current dialing is interrupted");
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