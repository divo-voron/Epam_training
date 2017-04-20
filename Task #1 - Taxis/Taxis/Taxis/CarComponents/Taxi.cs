using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using TaxiStation.CarsItems;
using TaxiStation.Interfaces;

namespace TaxiStation.CarComponents
{
    [Serializable, XmlInclude(typeof(Coupe)), XmlInclude(typeof(Sedan)), XmlInclude(typeof(Premium)), XmlInclude(typeof(Gazel))]
    public class Taxi : Car, ICollection<Car>, IPassengers, ICargo
    {
        private ICollection<Car> _cars;

        public Taxi()
        {
            _cars = new Collection<Car>();
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


        public void Add(Car item)
        {
            _cars.Add(item);
        }

        public void Clear()
        {
            _cars.Clear();
        }

        public bool Contains(Car item)
        {
            return _cars.Contains(item);
        }

        public void CopyTo(Car[] array, int arrayIndex)
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

        public bool Remove(Car item)
        {
            return _cars.Remove(item);
        }

        public IEnumerator<Car> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
