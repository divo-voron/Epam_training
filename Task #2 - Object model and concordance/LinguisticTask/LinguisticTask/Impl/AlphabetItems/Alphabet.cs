using System.Collections.Generic;
using System.Linq;

namespace LinguisticTask.Impl.AlphabetItems
{
    static class Alphabet
    {
        private static ICollection<AlphabetItem> _alphabetItems;
        public static void LoadData(ICollection<AlphabetItem> alphabetItems)
        {
            _alphabetItems = alphabetItems;
        }
        public static AlphabetItem GetAlpabetItem(char letter)
        {
            return _alphabetItems.FirstOrDefault(item => item.Item == letter);
        }
    }
}
