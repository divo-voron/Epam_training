using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Session
    {
        private Port _source;
        private Port _target;
        private SessionState _state;
        public Port Source
        {
            get { return _source; }
        }
        public Port Target
        {
            get { return _target; }
        }
        public SessionState State
        {
            get { return _state; }
            set { _state = value; }
        }
        public Session(Port sourcePort, Port targetPort, SessionState state = SessionState.Close)
        {
            _source = sourcePort;
            _target = targetPort;
            _state = state;
        }
        public bool IsClose()
        {
            if (_source.State == StatePort.Free && _target.State == StatePort.Free) return true; else return false;
        }
    }
}
