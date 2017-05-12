using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class MatchData
    {
        private int _count;
        private ICollection<int> _numberOfLines;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public ICollection<int> NumberOfLines
        {
            get { return _numberOfLines; }
            set { _numberOfLines = value; }
        }

        public MatchData(int numberOfLines)
        {
            _count = 1;
            _numberOfLines = new List<int>() { numberOfLines };
        }

        public void Add(int numberOfLines)
        {
            if (_numberOfLines.Any(item => item == numberOfLines) == false)
            {
                _numberOfLines.Add(numberOfLines);
            }
        }
    }
}
