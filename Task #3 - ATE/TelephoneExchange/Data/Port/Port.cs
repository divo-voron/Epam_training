using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Port : IPort
    {
        private ITerminal _terminal;
        private PhoneNumber _number;
        private PortsState _state;
        public PhoneNumber Number
        {
            get { return _number; }
        }
        public PortsState State
        {
            get { return _state; }
            set { _state = value; }
        }
        public Port(PhoneNumber number)
        {
            _number = number;
        }
        public void RegisterTerminal(ITerminal terminal)
        {
            if (terminal.State == TerminalsState.Unregistered && _terminal == null)
            {
                _terminal = terminal;
                terminal.State = TerminalsState.Registered;
                terminal.Connected += OnConnectedTerminal;
                terminal.Disconnected += OnDisconnectedTerminal;
            }
            else throw new ArgumentException("Could not register terminal");
        }
        public void UnregisterTerminal(ITerminal terminal)
        {
            _terminal = null;
            terminal.State = TerminalsState.Unregistered;
            terminal.Connected -= OnConnectedTerminal;
            terminal.Disconnected -= OnDisconnectedTerminal;
        }
        private void OnConnectedTerminal(object sender, EventArgs e)
        {
            ITerminal terminal = sender as ITerminal;
            if (terminal != null)
            {
                OnDisconnectedTerminal(sender, e);

                terminal.Calling += OnCalling;
                terminal.Accepted += OnAccepted;
                terminal.Dropped += OnDropped;
                this.IncomingCall += terminal.IncomimgCall;

                this.OnConnected();
            }
        }
        private void OnDisconnectedTerminal(object sender, EventArgs e)
        {
            ITerminal terminal = sender as ITerminal;
            if (terminal != null)
            {
                terminal.Calling -= OnCalling;
                terminal.Accepted -= OnAccepted;
                terminal.Dropped -= OnDropped;
                this.IncomingCall -= terminal.IncomimgCall;

                this.OnDisconnected();
            }
        }

        private EventHandler _connected;
        private EventHandler _disconnected;
        private EventHandler<CallRequestNumber> _calling;
        private EventHandler _accepted;
        private EventHandler _dropped;
        private EventHandler _incomingCall;

        public event EventHandler Connected
        {
            add { _connected += value; }
            remove { _connected -= value; }
        }
        public event EventHandler Disconnected
        {
            add { _disconnected += value; }
            remove { _disconnected -= value; }
        }
        public event EventHandler<CallRequestNumber> Calling
        {
            add { _calling += value; }
            remove { _calling -= value; }
        }
        public event EventHandler Accepted
        {
            add { _accepted += value; }
            remove { _accepted -= value; }
        }
        public event EventHandler Dropped
        {
            add { _dropped += value; }
            remove { _dropped -= value; }
        }
        public event EventHandler IncomingCall
        {
            add { _incomingCall += value; }
            remove { _incomingCall -= value; }
        }

        private void OnConnected()
        {
            if (_connected != null) _connected(this, null);
        }
        private void OnDisconnected()
        {
            if (_disconnected != null) _disconnected(this, null);
        }
        private void OnCalling(object sender, CallRequestNumber request)
        {
            if (_calling != null) _calling(this, request);
        }
        private void OnAccepted(object sender, EventArgs e)
        {
            if (_accepted != null) _accepted(this, null);
        }
        private void OnDropped(object sender, EventArgs e)
        {
            if (_dropped != null) _dropped(this, null);
        }
        private void OnIncomingCall()
        {
            if (_incomingCall != null) _incomingCall(this, null);
        }

        public void IncomingCallPort(object sender, EventArgs e)
        {
            OnIncomingCall();
        }
        public void Dispose()
        {
            _connected = null;
            _disconnected = null;
            _calling = null;
            _accepted = null;
            _dropped = null;
            _incomingCall = null;
        }
    }
}
