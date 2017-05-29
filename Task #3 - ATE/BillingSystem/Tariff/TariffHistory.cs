using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    class TariffHistory : ICollection<TariffChange>
    {
        private ICollection<TariffChange> _history;
        public TariffHistory()
        {
            _history = new List<TariffChange>();
        }
        public TariffHistory(ICollection<TariffChange> history)
        {
            _history = history;
        }
        public void Add(ITariff tariff, DateTime date)
        {
            _history.Add(new TariffChange(tariff, date));
        }
        public void Add(TariffChange item)
        {
            _history.Add(item);
        }
        public void Clear()
        {
            _history.Clear();
        }
        public bool Contains(TariffChange item)
        {
            return _history.Contains(item);
        }
        public void CopyTo(TariffChange[] array, int arrayIndex)
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
        public bool Remove(TariffChange item)
        {
            return _history.Remove(item);
        }
        public IEnumerator<TariffChange> GetEnumerator()
        {
            return _history.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _history.GetEnumerator();
        }
    }
}
