using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Terminal : ITerminal
    {
        private TerminalsType _terminalType;
        public TerminalsType TerminalType
        {
            get { return _terminalType; }
            set { _terminalType = value; }
        }

        private EventHandler<CallRequestConnect> _connected;
        private EventHandler<CallRequestConnect> _disconnected;
        private EventHandler<CallRequestNumber> _calling;
        private EventHandler _accepted;
        private EventHandler _dropped;

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

        public void Connect(IPort port)
        {
            OnConnected(new CallRequestConnect(port));
        }
        public void Disconnect(IPort port)
        {
            OnDisconnected(new CallRequestConnect(port));
        }
        public void Drop()
        {
            OnDropped();
        }
        public void Accept()
        {
            OnAccepted();
        }
        public void Call(PhoneNumber number)
        {
            OnCalling(new CallRequestNumber(number));
        }
        
        private void OnConnected(CallRequestConnect request)
        {
            if (_connected != null) _connected(this, request);
        }
        private void OnDisconnected(CallRequestConnect request)
        {
            if (_disconnected != null) _disconnected(this, request);
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

        public void IncomimgCall(object sender, EventArgs e)
        {
            Port source = sender as Port;
            if (source != null)
            {
                Console.WriteLine("Accept incoming call?");
                string s = Console.ReadLine().Trim().ToLower();
                switch (s)
                {
                    case "y":
                        Accept();
                        break;
                    case "n":
                        Drop();
                        break;
                    default: 
                        break;
                }
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
