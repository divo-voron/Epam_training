using System;
using BillingSystem.Data;
using BillingSystem.Data.Connection;
using ConnectInfoState = TelephoneExchange.StationComponent.ConnectComponent.ConnectInfoState;

namespace BillingSystem.Extensions
{
    public class By
    {
        public static Func<Connect, bool> Client(Client client) => x => x.SourceClient == client || x.TargetClient == client;

        public static Func<Connect, bool> IncomingConnections(Client client) => x => x.TargetClient == client;

        public static Func<Connect, bool> OutgoingConnections(Client client) => x => x.SourceClient == client;

        public static Func<Connect, bool> UnacceptedConnections(Client client) => x => x.State == ConnectInfoState.Unaccepted && x.TargetClient == client;
    }
}
