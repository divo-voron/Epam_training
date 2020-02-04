using System;
using TelephoneExchange.StationComponent.TerminalComponent;

namespace TelephoneExchange.StationComponent
{
    public class Terminal : ITerminal
    {
        public TerminalsState State { get; set; }

        public Terminal(TerminalsState state = TerminalsState.Unregistered) 
        {
            State = state;
        }

        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<CallRequestNumber> Calling;
        public event EventHandler Accepted;
        public event EventHandler Dropped;

        public void Connect()
        {
            OnConnected();
        }
        public void Disconnect()
        {
            OnDisconnected();
        }
        public void Call(PhoneNumber number)
        {
            OnCalling(new CallRequestNumber(number));
        }
        public void Accept()
        {
            OnAccepted();
        }
        public void Drop()
        {
            OnDropped();
        }
                        
        private void OnConnected()
        {
            Connected?.Invoke(this, null);
        }
        private void OnDisconnected()
        {
            Disconnected?.Invoke(this, null);
        }
        private void OnCalling(CallRequestNumber request)
        {
            Calling?.Invoke(this, request);
        }
        private void OnAccepted()
        {
            Accepted?.Invoke(this, null);
        }
        private void OnDropped()
        {
            Dropped?.Invoke(this, null);
        }

        public void IncomingCall(object sender, EventArgs e)
        {
            if (sender is Port source)
            {
                Console.WriteLine("Accept incoming call?");
                //string s = Console.ReadLine().Trim().ToLower();
                //switch (s)
                //{
                //    case "y":
                //        Accept();
                //        break;
                //    case "n":
                //        Drop();
                //        break;
                //    default: 
                //        break;
                //}
            }
        }

        public void Dispose()
        {
            Connected = null;
            Disconnected = null;
            Calling = null;
            Accepted = null;
            Dropped = null;
        }
    }
}
