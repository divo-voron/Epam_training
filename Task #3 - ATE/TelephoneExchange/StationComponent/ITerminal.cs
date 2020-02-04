using System;
using TelephoneExchange.StationComponent.TerminalComponent;

namespace TelephoneExchange.StationComponent
{
    public interface ITerminal : IDisposable
    {
        TerminalsState State { get; set; }

        event EventHandler Connected;
        event EventHandler Disconnected;
        event EventHandler<CallRequestNumber> Calling;
        event EventHandler Accepted;
        event EventHandler Dropped;

        void Connect();
        void Disconnect();
        void Drop();
        void Accept();
        void Call(PhoneNumber number);

        void IncomingCall(object sender, EventArgs e);
    }
}
