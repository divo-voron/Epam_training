using System;
using TelephoneExchange.StationComponent.ConnectComponent;

namespace TelephoneExchange.StationComponent
{
    public class ConnectInfo : EventArgs
    {
        public PhoneNumber Source { get; }

        public PhoneNumber Target { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public TimeSpan Duration => End - Start;

        public ConnectInfoState State { get; }

        public ConnectInfo(PhoneNumber source, PhoneNumber target, DateTime start, DateTime end, ConnectInfoState state)
        {
            Source = source;
            Target = target;
            Start = start;
            End = end;
            State = state;
        }
    }
}
