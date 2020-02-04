using System;
using TelephoneExchange.StationComponent.PortComponent;
using TelephoneExchange.StationComponent.SessionComponent;

namespace TelephoneExchange.StationComponent
{
    class Session
    {
        public IPort Source { get; }

        public IPort Target { get; }

        public SessionState State { get; set; }

        public DateTime Start { get; set; }

        public Session(IPort sourcePort, IPort targetPort, SessionState state = SessionState.Open)
        {
            Source = sourcePort;
            Target = targetPort;
            State = state;
        }

        public bool IsClose()
        {
            return Source.StateCall == PortStateCall.Free && Target.StateCall == PortStateCall.Free;
        }
    }
}
