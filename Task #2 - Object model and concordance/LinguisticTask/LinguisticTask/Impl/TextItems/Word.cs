﻿using System.Collections.Generic;
using System.Linq;

namespace LinguisticTask.Impl.TextItems
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
        public Word() { }
        public Word(string item)
        {
            _items = item.Select(x => x).ToArray();
        }
        public Word(IEnumerable<char> item)
        {
            _items = item.ToArray();
        }
    }
}
