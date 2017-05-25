using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public interface IPort : IDisposable
    {
        StatePort State { get; set; }
        PhoneNumber Number { get; set; }

        event EventHandler<CallRequestConnect> Connected;
        event EventHandler<CallRequestConnect> Disconnected;
        event EventHandler<CallRequestNumber> Calling;
        event EventHandler Accepted;
        event EventHandler Dropped;
        event EventHandler IncomingCall;

        void ConnectPort(object sender, CallRequestConnect e);
        void DisconnectPort(object sender, CallRequestConnect e);
        void CallPort(object sender, CallRequestNumber request);
        void AcceptPort(object sender, EventArgs e);
        void DropPort(object sender, EventArgs e);
        void IncomingCallPort(object sender, EventArgs e);
    }
}
