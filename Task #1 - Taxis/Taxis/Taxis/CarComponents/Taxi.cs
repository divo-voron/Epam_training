using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TaxiStation.Interfaces;

namespace TaxiStation.CarComponents
{
    public class Taxi : Car, ICollection<ICar>, IPassengers, ICargo
    {
        private ICollection<ICar> _cars;

        public Taxi()
        {
            _cars = new Collection<ICar>();
        }

        public int NumberOfPassengers
        {
            get 
            {
                return _cars.OfType<IPassengers>().Sum(item => item.NumberOfPassengers);
            }
        }

        public int Carrying
        {
            get
            {
                return _cars.OfType<ICargo>().Sum(item => item.Carrying);
            }
        }


        public void Add(ICar item)
        {
            _cars.Add(item);
        }

        public void Clear()
        {
            _cars.Clear();
        }

        public bool Contains(ICar item)
        {
            return _cars.Contains(item);
        }

        public void CopyTo(ICar[] array, int arrayIndex)
        {
            _cars.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _cars.Count; }
        }

        public bool IsReadOnly
        {
            get { return _cars.IsReadOnly; }
        }

        public bool Remove(ICar item)
        {
            return _cars.Remove(item);
        }

        public IEnumerator<ICar> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
