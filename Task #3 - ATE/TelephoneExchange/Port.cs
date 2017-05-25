using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Port : IPort
    {
        private PhoneNumber _number;
        private StatePort _state;
        public StatePort State
        {
            get { return _state; }
            set { _state = value; }
        }
        public PhoneNumber Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public Port(PhoneNumber number)
        {
            _number = number;
        }

        public void RegisterTerminal(ITerminal terminal)
        {
            terminal.Connected += terminal_Connected;
            terminal.Disconnected += terminal_Disconnected;
        }
        public void UnRegisterTerminal(ITerminal terminal)
        {
            terminal.Connected -= terminal_Connected;
            terminal.Disconnected -= terminal_Disconnected;
        }
        private void terminal_Connected(object sender, EventArgs e)
        {
            ITerminal terminal = sender as ITerminal;
            if (terminal != null)
            {
                terminal.Calling += OnCalling;
                terminal.Accepted += OnAccepted;
                terminal.Dropped += OnDropped;
                this.IncomingCall += terminal.IncomimgCall;

                this.OnConnected();
            }
        }
        private void terminal_Disconnected(object sender, EventArgs e)
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

        private EventHandler<CallRequestConnect> _connected;
        private EventHandler<CallRequestConnect> _disconnected;
        private EventHandler<CallRequestNumber> _calling;
        private EventHandler _accepted;
        private EventHandler _dropped;
        private EventHandler _incomingCall;

        public event EventHandler<CallRequestConnect> Connected
        {
            add { _connected += value; }
            remove { _connected -= value; }
        }
        public event EventHandler<CallRequestConnect> Disconnected
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
        private void OnDropped(object sender, EventArgs e)
        {
            if (_dropped != null) _dropped(this, null);
        }
        private void OnAccepted(object sender, EventArgs e)
        {
            if (_accepted != null) _accepted(this, null);
        }
        private void OnCalling(object sender, CallRequestNumber request)
        {
            if (_calling != null) _calling(this, request);
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
