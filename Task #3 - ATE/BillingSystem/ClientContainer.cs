using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneExchange;

namespace BillingSystem
{
    public class ClientContainer : ICollection<Client>
    {
        private ICollection<Client> _clients;
        public ClientContainer() 
        {
            _clients = new List<Client>();
        }
        public Client GetClient(PhoneNumber number)
        {
            return _clients.FirstOrDefault(x => x.Number == number);
        }

        public void Add(Client item)
        {
            if (_clients.Contains(item) == false)
                _clients.Add(item);
        }
        public void Clear()
        {
            _clients.Clear();
        }
        public bool Contains(Client item)
        {
            return _clients.Contains(item);
        }
        public void CopyTo(Client[] array, int arrayIndex)
        {
            _clients.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _clients.Count; }
        }
        public bool IsReadOnly
        {
            get { return _clients.IsReadOnly; }
        }
        public bool Remove(Client item)
        {
            return _clients.Remove(item);
        }
        public IEnumerator<Client> GetEnumerator()
        {
            return _clients.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _clients.GetEnumerator();
        }
    }
}
