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
        private string _items;
        private PunctuationMarks _punctuationMark;
        public string Items
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
    }
}
