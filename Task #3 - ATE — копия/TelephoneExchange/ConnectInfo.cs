using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    class ConnectInfo
    {
        private IPort _source;
        private IPort _target;
        private DateTime _start;
        private DateTime _end;
        public IPort Source
        {
            get { return _source; }
        }
        public IPort Target
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

        public ConnectInfo(IPort source, IPort target, DateTime start, DateTime end)
        {
            _source = source;
            _target = target;
            _start = start;
            _end = end;
        }
    }
}
