using LinguisticTask.TextComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask.TextComponents
{
    class Word : ISentenceItem
    {
        private char[] _items;
        public char[] Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public int Length
        {
            get { return _items.Length; }
        }
        public override string ToString()
        {
            return string.Join("", _items);
        }
    }
}
