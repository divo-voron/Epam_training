using System;
using TelephoneExchange.StationComponent.PortComponent;
using TelephoneExchange.StationComponent.TerminalComponent;

namespace TelephoneExchange.StationComponent
{
    public class Port : IPort
    {
        private ITerminal _terminal;

        public PhoneNumber Number { get; }

        public PortStateCall StateCall { get; set; }

        public PortStateLock StateLock { get; set; }

        public Port(PhoneNumber number)
        {
            Number = number;
        }

        public void RegisterTerminal(ITerminal terminal)
        {
            if (terminal.State == TerminalsState.Unregistered && _terminal == null)
            {
                _terminal = terminal;
                terminal.State = TerminalsState.Registered;
                terminal.Connected += OnConnectedTerminal;
                terminal.Disconnected += OnDisconnectedTerminal;
            }
            else throw new ArgumentException("Could not register terminal");
        }

        public void UnregisterTerminal(ITerminal terminal)
        {
            _terminal = null;
            terminal.State = TerminalsState.Unregistered;
            terminal.Connected -= OnConnectedTerminal;
            terminal.Disconnected -= OnDisconnectedTerminal;
        }

        private void OnConnectedTerminal(object sender, EventArgs e)
        {
            if (sender is ITerminal terminal)
            {
                OnDisconnectedTerminal(sender, e);

                terminal.Calling += OnCalling;
                terminal.Accepted += OnAccepted;
                terminal.Dropped += OnDropped;
                this.IncomingCall += terminal.IncomingCall;

                this.OnConnected();
            }
        }

        private void OnDisconnectedTerminal(object sender, EventArgs e)
        {
            if (sender is ITerminal terminal)
            {
                terminal.Calling -= OnCalling;
                terminal.Accepted -= OnAccepted;
                terminal.Dropped -= OnDropped;
                this.IncomingCall -= terminal.IncomingCall;

                this.OnDisconnected();
            }
        }

        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler<CallRequestNumber> Calling;
        public event EventHandler Accepted;
        public event EventHandler Dropped;
        public event EventHandler IncomingCall;

        private void OnConnected()
        {
            Connected?.Invoke(this, null);
        }

        private void OnDisconnected()
        {
            Disconnected?.Invoke(this, null);
        }

        private void OnCalling(object sender, CallRequestNumber request)
        {
            if (Calling != null && StateLock == PortStateLock.Unlocked) Calling(this, request);
        }

        private void OnAccepted(object sender, EventArgs e)
        {
            Accepted?.Invoke(this, null);
        }

        private void OnDropped(object sender, EventArgs e)
        {
            Dropped?.Invoke(this, null);
        }

        private void OnIncomingCall()
        {
            IncomingCall?.Invoke(this, null);
        }

        public void IncomingCallPort(object sender, EventArgs e)
        {
            OnIncomingCall();
        }

        public void Dispose()
        {
            Connected = null;
            Disconnected = null;
            Calling = null;
            Accepted = null;
            Dropped = null;
            IncomingCall = null;
        }
    }
}
