﻿using LinguisticTask.Impl.PunctuationItems;
using System.Collections.Generic;
using System.Linq;

namespace LinguisticTask.Impl.TextItems
{
    class Sentence : ISentence
    {
        private ICollection<ISentenceItem> _items;
        public ICollection<ISentenceItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public int Length
        {
            get { return _items.Sum(item => item.Length); }
        }
        public Sentence() 
        {
            _items = new List<ISentenceItem>();
        }
        public Sentence(ICollection<ISentenceItem> items)
        {
            _items = items;
        }
        public int Count<T>() where T : ISentenceItem
        {
            return _items.OfType<T>().Count();
        }

        public PunctuationMark GetEndSentence()
        {
            ITextElement last = _items.Last();
            if (last is Punctuation)
                return ((Punctuation)last).PunctuationMark;
            else
                return default(PunctuationMark);
        }
        public void RemoveItem(ISentenceItem item)
        {
            _items.Remove(item);
        }
        public override string ToString()
        {
            return string.Join("", _items);
        }
    }
}
