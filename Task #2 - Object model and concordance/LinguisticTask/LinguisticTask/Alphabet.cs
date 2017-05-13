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
        private ICollection<AlphabetItem> _alphabetItems;
        public Alphabet(ICollection<AlphabetItem> alphabetItems)
        {
            _alphabetItems = alphabetItems;
        }
        public char[] GetAlphabet(PrescriptionType prescriptionType = PrescriptionType.Lowercase)
        {
            return _alphabetItems.Where(item => item.PrescriptionType == prescriptionType).Select(item => item.Item).ToArray();
        }
        public char[] GetAlphabet(LetterType letterType)
        {
            return _alphabetItems.Where(item => item.LetterType == letterType).Select(item => item.Item).ToArray();
        }
    }
}
