using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Port
    {
        private string _number;
        private StatePort _state;
        public StatePort State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public Port(string number)
        {
            _number = number;
        }
        public void CallTerminalWithPort(object sender, CallRequest request)
        {
            OnCalling(request);
        }
        public void AcceptTerminalWithPort(object sender, EventArgs e)
        {
            OnAccepted();
        }
        public void DropTerminalWithPort(object sender, EventArgs e)
        {
            OnDropped();
        }

        private EventHandler<CallRequest> _calling;
        private EventHandler _accepted;
        private EventHandler _dropped;

        public event EventHandler<CallRequest> Calling
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

        //public void Drop()
        //{
        //    OnDropped();
        //}
        //public void Accept()
        //{
        //    OnAccepted();
        //}
        //public void Call(CallRequest request)
        //{
        //    OnCalling(request);
        //}

        private void OnDropped()
        {
            if (_dropped != null) _dropped(this, null);
        }
        private void OnAccepted()
        {
            if (_accepted != null) _accepted(this, null);
        }
        private void OnCalling(CallRequest request)
        {
            _state = StatePort.Busy;
            
            if (_calling != null) _calling(this, request);
            
            _state = StatePort.Free;
        }
    }
}
