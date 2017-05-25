using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public interface ITerminal
    {
        event EventHandler<CallRequest> Calling;
        event EventHandler Accepted;
        event EventHandler Dropped;

        void Drop();
        void Accept();
        void Call(PhoneNumber number);

        void IncomimgCall(object sender, EventArgs e);
    }
}
