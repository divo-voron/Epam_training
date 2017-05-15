using LinguisticTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask
{
    class Alphabet
    {
        private static ICollection<AlphabetItem> _alphabetItems;
        public Alphabet(ICollection<AlphabetItem> alphabetItems)
        {
            _alphabetItems = alphabetItems;
        }
        public static AlphabetItem GetAlpabetItem(char letter)
        {
            return _alphabetItems.FirstOrDefault(item => item.Item == letter);
        }
    }
}
