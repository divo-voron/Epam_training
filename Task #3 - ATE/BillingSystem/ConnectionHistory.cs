using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    public class ConnectionHistory : ICollection<Connect>
    {
        private ICollection<Connect> _history;

        public ConnectionHistory() 
        {
            _history = new List<Connect>();
        }

        public void Add(Connect item)
        {
            _history.Add(item);
        }

        public void Clear()
        {
            _history.Clear();
        }

        public bool Contains(Connect item)
        {
            return _history.Contains(item);
        }

        public void CopyTo(Connect[] array, int arrayIndex)
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

        public bool Remove(Connect item)
        {
            return _history.Remove(item);
        }

        public IEnumerator<Connect> GetEnumerator()
        {
            return _history.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _history.GetEnumerator();
        }
    }
}
