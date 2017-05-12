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
        public int Length
        {
            get { return _items.Sum(item => item.Length); }
        }
    }
}
