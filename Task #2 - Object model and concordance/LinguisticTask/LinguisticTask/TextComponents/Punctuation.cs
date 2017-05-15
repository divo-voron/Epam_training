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
        private PunctuationMark _punctuationMark;
        public char[] Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public PunctuationMark PunctuationMark
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
        public Punctuation(string item, PunctuationMark punctuationMark)
        {
            _items = item.Select(x => x).ToArray();
            _punctuationMark = punctuationMark;
        }
        public Punctuation(IEnumerable<char> item, PunctuationMark punctuationMark)
        {
            _items = item.ToArray();
            _punctuationMark = punctuationMark;
        }
    }
}
