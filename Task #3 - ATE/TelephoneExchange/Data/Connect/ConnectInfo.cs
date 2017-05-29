using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class ConnectInfo : EventArgs
    {
        private PhoneNumber _source;
        private PhoneNumber _target;
        private DateTime _start;
        private DateTime _end;
        private ConnectInfoState _state;
        public PhoneNumber Source
        {
            get { return _source; }
        }
        public PhoneNumber Target
        {
            get { return _target; }
        }
        public DateTime Start
        {
            get { return _start; }
        }
        public DateTime End
        {
            get { return _end; }
        }
        public TimeSpan Duration
        {
            get { return _end - _start; }
        }
        public ConnectInfoState State
        {
            get { return _state; }
        }
        public ConnectInfo(PhoneNumber source, PhoneNumber target, DateTime start, DateTime end, ConnectInfoState state)
        {
            _source = source;
            _target = target;
            _start = start;
            _end = end;
            _state = state;
        }
    }
}
