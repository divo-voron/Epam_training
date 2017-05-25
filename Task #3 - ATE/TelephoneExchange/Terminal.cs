using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Terminal : ITerminal
    {
        private TerminalsType _terminalType;
        public TerminalsType TerminalType
        {
            get { return _terminalType; }
            set { _terminalType = value; }
        }

        private EventHandler<CallRequest> _calling;
        private EventHandler _accepted;
        private EventHandler _dropped;

        public event EventHandler<CallRequest> Calling
        {
            add { _calling += value; }
            remove { _calling -= value; }
        }
        public event EventHandler Accepted
        {
            add { _accepted += value; }
            remove { _accepted -= value; }
        }
        public event EventHandler Dropped
        {
            add { _dropped += value; }
            remove { _dropped -= value; }
        }
        
        public void Drop()
        {
            OnDropped();
        }
        public void Accept()
        {
            OnAccepted();
        }
        public void Call(PhoneNumber number)
        {
            OnCalling(new CallRequest(number));
        }
        
        private void OnDropped()
        {
            if (_dropped != null) _dropped(this, null);
        }
        private void OnAccepted()
        {
            if (_accepted != null) _accepted(this, null);
        }
        private void OnCalling(CallRequest request)
        {
            if (_calling != null) _calling(this, request);
        }

        public void IncomimgCall(object sender, EventArgs e)
        {
            Port source = sender as Port;
            if (source != null)
            {
                Console.WriteLine("Accept incoming call?");
                string s = Console.ReadLine().Trim().ToLower();
                switch (s)
                {
                    case "y":
                        Accept();
                        break;
                    case "n":
                        Drop();
                        break;
                    default: 
                        break;
                }
            }
        }
    }
}
