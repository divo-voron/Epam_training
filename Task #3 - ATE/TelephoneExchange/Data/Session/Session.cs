using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    class Session
    {
        private IPort _source;
        private IPort _target;
        private SessionState _state;
        private DateTime _start;
        public IPort Source
        {
            get { return _source; }
        }
        public IPort Target
        {
            get { return _target; }
        }
        public SessionState State
        {
            get { return _state; }
            set { _state = value; }
        }
        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }
        public Session(IPort sourcePort, IPort targetPort, SessionState state = SessionState.Open)
        {
            _source = sourcePort;
            _target = targetPort;
            _state = state;
        }
        public bool IsClose()
        {
            if (_source.State == PortsState.Free && _target.State == PortsState.Free) return true; else return false;
        }
    }
}
