using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    class ConnectionHistory : ICollection<ConnectInfo>
    {
        private ICollection<ConnectInfo> _history;

        public ConnectionHistory() 
        {
            _history = new List<ConnectInfo>();
        }

        public void Add(ConnectInfo item)
        {
            _history.Add(item);
        }

        public void Clear()
        {
            _history.Clear();
        }

        public bool Contains(ConnectInfo item)
        {
            return _history.Contains(item);
        }

        public void CopyTo(ConnectInfo[] array, int arrayIndex)
        {
            _history.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _history.Count; }
        }

        public bool IsReadOnly
        {
            get { return _history.IsReadOnly; }
        }

        public bool Remove(ConnectInfo item)
        {
            return _history.Remove(item);
        }

        public IEnumerator<ConnectInfo> GetEnumerator()
        {
            return _history.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _history.GetEnumerator();
        }
    }
}
