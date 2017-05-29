using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneExchange;

namespace BillingSystem
{
    public static class Billing
    {
        private static ClientContainer _clients = new ClientContainer();
        private static ConnectionHistory _history = new ConnectionHistory();
        public static ConnectionHistory History
        {
            get { return _history; }
        }
        public static ClientContainer Clients
        {
            get { return _clients; }
        }
        public static void AddClient(Client client)
        {
            if (_clients.Contains(client) == false) _clients.Add(client);
        }
        public static void AddConnectionInfo(object sender, TelephoneExchange.ConnectInfo e)
        {
            Client source = _clients.GetClient(e.Source);
            Client target = _clients.GetClient(e.Target);
            if (source != null && target != null)
            {
                Connect connect = new Connect(source, target, e.Start, e.End, e.State);
                _history.Add(connect);
                source.ReCountBill(connect);
            }
        }
        public static IEnumerable<Connect> GetConnection(Client client)
        {
            return _history.Where(x => x.SourceClient == client || x.TargetClient == client);
        }
        public static IEnumerable<Connect> GetIncomingConnections(Client client)
        {
            return _history.Where(x => x.TargetClient == client);
        }
        public static IEnumerable<Connect> GetOutgoingConnections(Client client)
        {
            return _history.Where(x => x.SourceClient == client);
        }
        public static IEnumerable<Connect> GetUnacceptedConnection(Client client)
        {
            return _history.Where(x => x.State == TelephoneExchange.ConnectInfoState.Unaccepted && x.TargetClient == client);
        }

        public static string GetInfo(this IEnumerable<Connect> source)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Show connection info\r\n");
            foreach (Connect connect in source)
            {
                sb.Append(string.Format("From: {0} - To: {1} - Start: {2} - End: {3} - Duration: {4}\r\n",
                    connect.SourceClient.Name, connect.TargetClient.Name, 
                    connect.Start, connect.End, connect.Duration));
            }
            return sb.ToString();
        }
    }
}
