using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Terminal : ITerminal
    {
        private TerminalsState _state;
        public TerminalsState State
        {
            get { return _state; }
            set { _state = value; }
        }

        public Terminal(TerminalsState state = TerminalsState.Unregistered) 
        {
            _state = state;
        }

        private EventHandler _connected;
        private EventHandler _disconnected;
        private EventHandler<CallRequestNumber> _calling;
        private EventHandler _accepted;
        private EventHandler _dropped;

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

        public void Connect()
        {
            OnConnected();
        }
        public void Disconnect()
        {
            OnDisconnected();
        }
        public void Call(PhoneNumber number)
        {
            OnCalling(new CallRequestNumber(number));
        }
        public void Accept()
        {
            OnAccepted();
        }
        public void Drop()
        {
            OnDropped();
        }
                        
        private void OnConnected()
        {
            if (_connected != null) _connected(this, null);
        }
        private void OnDisconnected()
        {
            if (_disconnected != null) _disconnected(this, null);
        }
        private void OnCalling(CallRequestNumber request)
        {
            if (_calling != null) _calling(this, request);
        }
        private void OnAccepted()
        {
            if (_accepted != null) _accepted(this, null);
        }
        private void OnDropped()
        {
            if (_dropped != null) _dropped(this, null);
        }

        public void IncomimgCall(object sender, EventArgs e)
        {
            Port source = sender as Port;
            if (source != null)
            {
                Console.WriteLine("Accept incoming call?");
                //string s = Console.ReadLine().Trim().ToLower();
                //switch (s)
                //{
                //    case "y":
                //        Accept();
                //        break;
                //    case "n":
                //        Drop();
                //        break;
                //    default: 
                //        break;
                //}
            }
        }

        public void Dispose()
        {
            _connected = null;
            _disconnected = null;
            _calling = null;
            _accepted = null;
            _dropped = null;
        }
    }
}
