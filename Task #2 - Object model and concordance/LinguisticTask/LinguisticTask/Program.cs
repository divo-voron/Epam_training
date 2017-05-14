using LinguisticTask.Enums;
using LinguisticTask.TextComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = Parser.Parse(new StreamReader(new FileStream(@"D:\1\2.txt", FileMode.Open)));
            
            Alphabet alphabet = new Alphabet(GetAlphabet());

            IEnumerable<ISentence> sentences1 = text.GetSentences();

            IOrderedEnumerable<ISentence> sentences2 = text.GetSentences().OrderBy(item => item.Count<Word>());

            IEnumerable<ISentence> sentences3 = text.GetSentences(PunctuationMarks.Question);

            IEnumerable<Word> words = text.GetWord(PunctuationMarks.Question, 3).Distinct();

            text.ReplaceWord(3, new char[] { 'б', 'л', 'а', 'б', 'л', 'а' });

            text.RemoveWord(6, LetterType.Consonant);
        }

        static Text LoadText()
        {
            Sentence sentence_1 = new Sentence();
            sentence_1.Items = new List<ISentenceItem>() 
            { 
                new Word() { Items = new char[] { 'П', 'р', 'и', 'в', 'е', 'т' } }, 
                new Punctuation() { Items = new char[] { ',' }, PunctuationMark = PunctuationMarks.Comma }, 
                new Word() { Items = new char[] { 'к', 'а', 'к' } }, 
                new Word() { Items = new char[] { 'д', 'е', 'л', 'а' } }, 
                new Punctuation() { Items = new char[] { '?' }, PunctuationMark = PunctuationMarks.Question }, 
                new Word() { Items = new char[] { 'П', 'р', 'и', 'в', 'е', 'т' } }, 
                new Punctuation() { Items = new char[] { ',' }, PunctuationMark = PunctuationMarks.Comma }, 
                new Word() { Items = new char[] { 'к', 'а', 'к' } }, 
                new Word() { Items = new char[] { 'д', 'е', 'л', 'а' } }, 
                new Punctuation() { Items = new char[] { '?' }, PunctuationMark = PunctuationMarks.Question } 
            };

            Sentence sentence_2 = new Sentence();
            sentence_2.Items = new List<ISentenceItem>() 
            { 
                new Word() { Items = new char[] { 'Ч', 'е', 'м' } },
                new Word() { Items = new char[] { 'з', 'а', 'н', 'я', 'т' } }, 
                new Punctuation() { Items = new char[] { '?' }, PunctuationMark = PunctuationMarks.Question } 
            };

            Paragraph paragraph_1 = new Paragraph();
            paragraph_1.Items = new List<ISentence>()
            {
                sentence_1,
                sentence_2
            };

            Sentence sentence_3 = new Sentence();
            sentence_3.Items = new List<ISentenceItem>()
            {
                new Word() { Items = new char[] { 'П', 'р', 'и', 'в', 'е', 'т' } }, 
                new Punctuation() { Items = new char[] { ',' }, PunctuationMark = PunctuationMarks.Comma }, 
                new Word() { Items = new char[] { 'к', 'а', 'к' } }, 
                new Word() { Items = new char[] { 'д', 'е', 'л', 'а' } }, 
                new Punctuation() { Items = new char[] { '?' }, PunctuationMark = PunctuationMarks.Question }, 
            };

            Sentence sentence_4 = new Sentence();
            sentence_4.Items = new List<ISentenceItem>()
            {
                new Word() { Items = new char[] { 'Ч', 'е', 'м' } },
                new Word() { Items = new char[] { 'з', 'а', 'н', 'я', 'т' } }, 
                new Punctuation() { Items = new char[] { '?' }, PunctuationMark = PunctuationMarks.Question },
                new Word() { Items = new char[] { 'Ч', 'е', 'м' } },
                new Word() { Items = new char[] { 'з', 'а', 'н', 'я', 'т' } }, 
                new Punctuation() { Items = new char[] { '?' }, PunctuationMark = PunctuationMarks.Question } 
            };

            Paragraph paragraph_2 = new Paragraph();
            paragraph_2.Items = new List<ISentence>()
            {
                sentence_3,
                sentence_4
            };

            Text text = new Text();
            text.Items = new List<Paragraph>() 
            {
                paragraph_1,
                paragraph_2
            };

            return text;
        }
        static ICollection<AlphabetItem> GetAlphabet()
        {
            ICollection<AlphabetItem> alphabet = new List<AlphabetItem>();

            // add  [А...Я]
            int[] upperVowels = new int[10] { 1040, 1045, 1048, 1054, 1059, 1067, 1069, 1070, 1071, 1025 };
            for (int i = 1040; i < 1072; i++)
            {
                alphabet.Add(new AlphabetItem()
                    {
                        Item = (char)i,
                        LetterType = upperVowels.Contains(i) ? LetterType.Vowel : LetterType.Consonant,
                        PrescriptionType = PrescriptionType.Uppercase
                    });
                // add ['Ё']
                if (i == 1045)
                    alphabet.Add(new AlphabetItem((char)1025, LetterType.Vowel, PrescriptionType.Uppercase));
            }

            // add  [а...я]
            int[] lowerVowels = new int[10] { 1072, 1077, 1080, 1086, 1091, 1099, 1101, 1102, 1103, 1105 };
            for (int i = 1072; i < 1104; i++)
            {
                alphabet.Add(new AlphabetItem()
                    {
                        Item = (char)i,
                        LetterType = lowerVowels.Contains(i) ? LetterType.Vowel : LetterType.Consonant,
                        PrescriptionType = PrescriptionType.Lowercase
                    });
                // add ['ё']
                if (i == 1077)
                    alphabet.Add(new AlphabetItem((char)1105, LetterType.Vowel, PrescriptionType.Lowercase));
            }

            return alphabet;
        }
    }
}
