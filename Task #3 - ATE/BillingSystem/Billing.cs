using System;
using BillingSystem.Data;
using BillingSystem.Data.Connection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.StationComponent;

namespace BillingSystem
{
    public static class Billing
    {
        public static List<Connect> History { get; } = new List<Connect>();

        public static List<Client> Clients { get; } = new List<Client>();

        public static void AddClient(Client client)
        {
            if (Clients.Contains(client) == false)
            {
                Clients.Add(client);
            }
        }

        public static void AddConnectionInfo(object sender, ConnectInfo e)
        {
            var source = Clients.FirstOrDefault(x => x.Port.Number == e.Source);
            var target = Clients.FirstOrDefault(x => x.Port.Number == e.Source);
            if (source != null && target != null)
            {
                var connect = new Connect(source, target, e.Start, e.End, e.Duration, e.State);
                History.Add(connect);
                source.ReCountBill();
            }
        }

        public static IEnumerable<Connect> GetConnections(Func<Connect, bool> predicate)
        {
            return History.Where(predicate);
        }

        public static string GetString(this IEnumerable<Connect> source)
        {
            var sb = new StringBuilder();
            sb.Append("Show connection info\r\n");
            foreach (var connect in source)
            {
                sb.Append($"From: {connect.SourceClient.Name} - To: {connect.TargetClient.Name} - Start: {connect.Start} - End: {connect.End} - Duration: {connect.Duration} - Cost: {connect.Cost}\r\n");
            }
            return sb.ToString();
        }

        public static void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Clients.ForEach(client => client.CheckBillState());
        }
    }
}
