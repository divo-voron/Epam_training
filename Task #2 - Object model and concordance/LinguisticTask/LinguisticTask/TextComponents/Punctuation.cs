using LinguisticTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask.TextComponents
{
    class Punctuation : ISentenceItem
    {
        private char[] _items;
        private PunctuationMarks _punctuationMark;
        public char[] Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public PunctuationMarks PunctuationMark
        {
            get { return _punctuationMark; }
            set { _punctuationMark = value; }
        }
        public int Length
        {
            get { return _items.Length; }
        }
        public override string ToString()
        {
            return string.Join("", _items);
        }
        public Punctuation() { }
        public Punctuation(string item)
        {
            _items = item.Select(x => x).ToArray();
        }
        public Punctuation(IEnumerable<char> item)
        {
            _items = item.ToArray();
        }
    }
}
