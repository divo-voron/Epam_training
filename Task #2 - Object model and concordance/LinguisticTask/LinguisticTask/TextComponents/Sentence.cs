using LinguisticTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask.TextComponents
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

        public int Count<T>() where T : ISentenceItem
        {
            return _items.OfType<T>().Count();
        }

        public PunctuationMarks GetEndSentence()
        {
            ITextElement last = _items.Last();
            if (last is Punctuation) 
                return ((Punctuation)last).PunctuationMark;
            else
                return PunctuationMarks.Nothing;
        }


        public void RemoveItem(ISentenceItem item)
        {
            _items.Remove(item);
        }
    }
}
