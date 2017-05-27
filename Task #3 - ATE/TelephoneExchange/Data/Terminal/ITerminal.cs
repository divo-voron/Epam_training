using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
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
