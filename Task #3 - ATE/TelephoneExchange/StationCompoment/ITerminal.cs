using System;
using TelephoneExchange.StationCompoment.TerminalComponent;

namespace TelephoneExchange.StationCompoment
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

        void IncomimgCall(object sender, EventArgs e);
    }
}
