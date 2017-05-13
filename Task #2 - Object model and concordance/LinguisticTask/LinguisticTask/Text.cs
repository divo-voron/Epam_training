using LinguisticTask.Enums;
using LinguisticTask.TextComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask
{
    class Text
    {
        private ICollection<Paragraph> _items;
        public ICollection<Paragraph> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public int Length
        {
            get { return _items.Sum(item => item.Length); }
        }

        public IEnumerable<ISentence> GetSentences()
        {
            IEnumerable<ISentence> retVal = new List<ISentence>();

            foreach (Paragraph paragraph in _items)
            {
                retVal = retVal.Union(paragraph.Items);
            }

            return retVal;
        }
        public IEnumerable<ISentence> GetSentences(PunctuationMarks punctuationMark)
        {
            IEnumerable<ISentence> retVal = new List<ISentence>();

            foreach (Paragraph paragraph in _items)
            {
                retVal = retVal.Union(paragraph.Items.Where(item => item.GetEndSentence() == punctuationMark));
            }

            return retVal;
        }

        public IEnumerable<Word> GetWord(int length = 0)
        {
            IEnumerable<Word> retVal = new List<Word>();

            foreach (ISentence sentence in this.GetSentences())
            {
                retVal = retVal.Union(sentence.Items.OfType<Word>().Where(item => item.Length == length));
            }

            return retVal;
        }
        public IEnumerable<Word> GetWord(PunctuationMarks punctuationMark, int length = 0)
        {
            IEnumerable<Word> retVal = new List<Word>();

            foreach (ISentence sentence in this.GetSentences(punctuationMark))
            {
                retVal = retVal.Union(sentence.Items.OfType<Word>().Where(item => item.Length == length));
            }

            return retVal;
        }

        public void ReplaceWord(int length, char[] substitution)
        {
            foreach (ISentence sentence in this.GetSentences())
            {
                foreach (Word word in sentence.Items.OfType<Word>())
                {
                    if (word.Length == length) word.Items = substitution;
                }
            }
        }

        public void RemoveWord(int length)
        {
            foreach (ISentence sentence in this.GetSentences())
            {
                List<Word> words = sentence.Items.OfType<Word>().ToList();

                for (int i = 0; i < words.Count(); i++)
                {
                    if (words[i].Length == length)
                        sentence.RemoveItem(words[i]);
                }
            }
        }
        public void RemoveWord(int length, LetterType letterType)
        {
            foreach (ISentence sentence in this.GetSentences())
            {
                List<Word> words = sentence.Items.OfType<Word>().ToList();

                for (int i = 0; i < words.Count(); i++)
                {
                    AlphabetItem alphabetItem = Alphabet.GetAlpabetItem(words[i].Items[0]);
                    if (alphabetItem.Equals(default(AlphabetItem)) == false &&
                        words[i].Length == length && alphabetItem.LetterType == letterType)
                        sentence.RemoveItem(words[i]);
                }
            }
        }
        public void RemoveWord(int length, PrescriptionType prescriptionType)
        {
            foreach (ISentence sentence in this.GetSentences())
            {
                List<Word> words = sentence.Items.OfType<Word>().ToList();

                for (int i = 0; i < words.Count(); i++)
                {
                    AlphabetItem alphabetItem = Alphabet.GetAlpabetItem(words[i].Items[0]);
                    if (alphabetItem.Equals(default(AlphabetItem)) == false &&
                        words[i].Length == length && alphabetItem.PrescriptionType == prescriptionType)
                        sentence.RemoveItem(words[i]);
                }
            }
        }
        public void RemoveWord(int length, LetterType letterType, PrescriptionType prescriptionType)
        {
            foreach (ISentence sentence in this.GetSentences())
            {
                List<Word> words = sentence.Items.OfType<Word>().ToList();

                for (int i = 0; i < words.Count(); i++)
                {
                    AlphabetItem alphabetItem = Alphabet.GetAlpabetItem(words[i].Items[0]);
                    if (alphabetItem.Equals(default(AlphabetItem)) == false && 
                        words[i].Length == length && alphabetItem.LetterType == letterType && alphabetItem.PrescriptionType == prescriptionType)
                        sentence.RemoveItem(words[i]);
                }
            }
        }
    }
}
