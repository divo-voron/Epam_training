using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    public class Terminal
    {
        private TerminalsType _terminalType;
        public TerminalsType TerminalType
        {
            get { return _terminalType; }
            set { _terminalType = value; }
        }

        private EventHandler _calling;
        private EventHandler _accepted;
        private EventHandler _dropped;

        public event EventHandler Calling
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
        public void Call()
        {
            OnCalling();
        }
        
        private void OnDropped()
        {
            if (_dropped != null) _dropped(this, null);
        }
        private void OnAccepted()
        {
            if (_accepted != null) _accepted(this, null);
        }
        private void OnCalling()
        {
            if (_calling != null) _calling(this, null);
        }
    }
}
