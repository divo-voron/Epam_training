using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public interface IPort : IDisposable
    {
        PortsState State { get; set; }
        PhoneNumber Number { get; set; }

        event EventHandler Connected;
        event EventHandler Disconnected;
        event EventHandler<CallRequestNumber> Calling;
        event EventHandler Accepted;
        event EventHandler Dropped;
        event EventHandler IncomingCall;

        void RegisterTerminal(ITerminal terminal);
        void UnregisterTerminal(ITerminal terminal);

        void IncomingCallPort(object sender, EventArgs e);
    }
}
