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
        private void OnDropped()
        {
            if (_dropped != null) _dropped(this, null);
        }
        private void OnAccepted()
        {
            if (_accepted != null) _accepted(this, null);
        }
        private void OnCalling(CallRequestNumber request)
        {
            if (_calling != null) _calling(this, request);
        }
        private void OnIncomingCall()
        {
            if (_incomingCall != null) _incomingCall(this, null);
        }

        public void ConnectPort(object sender, CallRequestConnect e)
        {
            OnConnected();
        }
        public void DisconnectPort(object sender, CallRequestConnect e)
        {
            OnDisconnected();
        }
        public void CallPort(object sender, CallRequestNumber request)
        {
            _state = StatePort.Dialing;
            OnCalling(request);
        }
        public void AcceptPort(object sender, EventArgs e)
        {
            OnAccepted();
        }
        public void DropPort(object sender, EventArgs e)
        {
            OnDropped();
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
