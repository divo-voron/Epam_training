using System;
using TelephoneExchange.StationCompoment.PortComponent;

namespace TelephoneExchange.StationCompoment
{
    public interface IPort : IDisposable
    {
        PortStateCall StateCall { get; set; }
        PortStateLock StateLock { get; set; }
        PhoneNumber Number { get; }

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
