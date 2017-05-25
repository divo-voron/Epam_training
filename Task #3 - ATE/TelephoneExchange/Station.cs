﻿using System;
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

        public void AddConnection(IPort port)
        {
            port.Connected += ConnectStation;
            port.Disconnected += DisconnectStation;
        }
        public void RemoveConnection(IPort port)
        {
            port.Connected -= ConnectStation;
            port.Disconnected -= DisconnectStation;
        }
        public void ConnectStation(object sender, EventArgs e)
        {
            IPort port = sender as IPort;
            if (port != null)
            {
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
                Session currentSession = _sessionContainer.GetByAny(port);
                if (currentSession != null)
                {
                    if (currentSession.State == SessionState.Connected)
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
                        currentSession.Source.State = StatePort.Free;
                        currentSession.Target.State = StatePort.Free;
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