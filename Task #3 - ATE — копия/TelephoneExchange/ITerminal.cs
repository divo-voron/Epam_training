using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public interface ITerminal : IDisposable
    {
        event EventHandler<CallRequestConnect> Connected;
        event EventHandler<CallRequestConnect> Disconnected;
        event EventHandler<CallRequestNumber> Calling;
        event EventHandler Accepted;
        event EventHandler Dropped;

        void Connect(IPort port);
        void Disconnect(IPort port);
        void Drop();
        void Accept();
        void Call(PhoneNumber number);

        void IncomimgCall(object sender, EventArgs e);
    }
}
