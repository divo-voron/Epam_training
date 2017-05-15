using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask.TextComponents
{
    class Paragraph
    {
        private ICollection<ISentence> _items;
        public ICollection<ISentence> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public Paragraph() 
        {
            _items = new List<ISentence>();
        }
        public Paragraph(ICollection<ISentence> items)
        {
            _items = items;
        }
        public int Length
        {
            get { return _items.Sum(item => item.Length); }
        }
        public override string ToString()
        {
            return string.Join("", _items);
        }
    }
}
