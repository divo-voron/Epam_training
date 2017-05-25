using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class CallRequestConnect : EventArgs
    {
        private IPort _port;
        public IPort Port
        {
            get { return _port; }
        }
        public CallRequestConnect(IPort port)
        {
            _port = port;
        }
    }
}
