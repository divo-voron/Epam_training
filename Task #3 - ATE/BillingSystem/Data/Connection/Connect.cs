using System;
using TelephoneExchange.StationComponent.ConnectComponent;

namespace BillingSystem.Data.Connection
{
    public class Connect
    {
        public Client SourceClient { get; }

        public Client TargetClient { get; }

        public DateTime Start { get; }

        public DateTime End { get; }

        public TimeSpan Duration { get; }

        public ConnectInfoState State { get; }

        public int Cost { get; set; }

        public Connect(Client sourceClient, Client targetClient, DateTime start, DateTime end, TimeSpan duration, ConnectInfoState state)
        {
            SourceClient = sourceClient;
            TargetClient = targetClient;
            Start = start;
            End = end;
            Duration = duration;
            State = state;
        }
    }
}
