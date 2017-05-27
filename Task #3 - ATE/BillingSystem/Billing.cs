using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class Billing
    {
        private ClientContainer _clients;
        private ConnectionHistory _history;
        public ConnectionHistory History
        {
            get { return _history; }
        }
        public ClientContainer Clients
        {
            get { return _clients; }
        }
        public Billing() 
        {
            _history = new ConnectionHistory();
            _clients = new ClientContainer();
        }
        public void AddClient(Client client) 
        {
            if (_clients.Contains(client) == false) _clients.Add(client);
        }
        public void GetConnectionInfo(object sender, TelephoneExchange.ConnectInfo e)
        {
            Client source = _clients.GetClient(e.Source);
            Client target = _clients.GetClient(e.Target);
            if (source != null && target != null)
                _history.Add(new Connect(source, source.Tarrif, target, e.Start, e.End));
        }
    }
}
