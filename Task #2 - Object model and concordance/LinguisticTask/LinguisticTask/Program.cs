using LinguisticTask.Impl;
using LinguisticTask.Impl.AlphabetItems;
using LinguisticTask.Impl.PunctuationItems;
using LinguisticTask.Impl.TextItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinguisticTask
{
    class Program
    {
        static void Main(string[] args)
        {
            PunctuationMarkContainer.LoadData(GetPunctuation());
            Alphabet.LoadData(GetAlphabet());

            Text text = Parser.Parse(new StreamReader(new FileStream(Directory.GetCurrentDirectory() + "\\Text.txt", FileMode.Open)));

            // Get all sentences
            Console.WriteLine("Get all sentences\n");
            IEnumerable<ISentence> sentences1 = text.GetSentences();
            Console.WriteLine(string.Join("\n", sentences1.Take(15)));
            Console.ReadKey();
            Console.Clear();

            // get all sentences order by word count
            Console.WriteLine("Get all sentences order by word count\n");
            IOrderedEnumerable<ISentence> sentences2 = text.GetSentences().OrderBy(item => item.Count<Word>());
            Console.WriteLine(string.Join("\n", sentences2.Take(15)));
            Console.ReadKey();
            Console.Clear();

            // get all sentences where end punctuation is question
            Console.WriteLine("Get all sentences where end punctuation is question\n");
            IEnumerable<ISentence> sentences3 = text.GetSentences(PunctuationMarkName.Question);
            Console.WriteLine(string.Join("\n", sentences3.Take(15)));
            Console.ReadKey();
            Console.Clear();

            // add all word lenght from sentences where end punctuation is question by lenght 3 letters
            Console.WriteLine("Add all word lenght from sentences where end punctuation is dot by lenght 3 letters\n");
            IEnumerable<Word> words = text.GetWord(PunctuationMarkName.Dot, 3).Distinct();
            Console.WriteLine(string.Join("\n", words.Take(15)));
            Console.ReadKey();
            Console.Clear();

            // replace word on 'q!!!!'
            text.ReplaceWord(3, "q!!!!");

            // delete word by lenght where fisrt letter is consonant
            text.RemoveWord(3, 0, LetterType.Consonant);

            // show all text
            Console.WriteLine(text.ToString());
        }

        static ICollection<AlphabetItem> GetAlphabet()
        {
            ICollection<AlphabetItem> alphabet = new List<AlphabetItem>();

            // add Cyrillic
            // add  [А...Я]
            int[] upperVowelsCyrillic = new int[10] { 1040, 1045, 1048, 1054, 1059, 1067, 1069, 1070, 1071, 1025 };
            for (int i = 1040; i < 1072; i++)
            {
                alphabet.Add(new AlphabetItem()
                    {
                        Item = (char)i,
                        LetterType = upperVowelsCyrillic.Contains(i) ? LetterType.Vowel : LetterType.Consonant,
                        PrescriptionType = PrescriptionType.Uppercase
                    });
                // add ['Ё']
                if (i == 1045)
                    alphabet.Add(new AlphabetItem((char)1025, LetterType.Vowel, PrescriptionType.Uppercase));
            }

            // add  [а...я]
            int[] lowerVowelsCyrillic = new int[10] { 1072, 1077, 1080, 1086, 1091, 1099, 1101, 1102, 1103, 1105 };
            for (int i = 1072; i < 1104; i++)
            {
                alphabet.Add(new AlphabetItem()
                    {
                        Item = (char)i,
                        LetterType = lowerVowelsCyrillic.Contains(i) ? LetterType.Vowel : LetterType.Consonant,
                        PrescriptionType = PrescriptionType.Lowercase
                    });
                // add ['ё']
                if (i == 1077)
                    alphabet.Add(new AlphabetItem((char)1105, LetterType.Vowel, PrescriptionType.Lowercase));
            }


            // add Latinica
            // add  [A...Z]
            int[] upperVowelsLatinica = new int[6] { 65, 69, 73, 79, 85, 89 };
            for (int i = 65; i < 91; i++)
            {
                alphabet.Add(new AlphabetItem()
                {
                    Item = (char)i,
                    LetterType = upperVowelsLatinica.Contains(i) ? LetterType.Vowel : LetterType.Consonant,
                    PrescriptionType = PrescriptionType.Uppercase
                });
            }

            // add  [а...я]
            int[] lowerVowelsLatinica = new int[6] { 97, 101, 105, 111, 117, 121 };
            for (int i = 97; i < 123; i++)
            {
                alphabet.Add(new AlphabetItem()
                {
                    Item = (char)i,
                    LetterType = lowerVowelsLatinica.Contains(i) ? LetterType.Vowel : LetterType.Consonant,
                    PrescriptionType = PrescriptionType.Lowercase
                });
            }
            return alphabet;
        }
        static ICollection<PunctuationMark> GetPunctuation()
        {
            return new List<PunctuationMark>()
            {
                new PunctuationMark() { Value = " ", Name = PunctuationMarkName.Undefined, Type = PunctuationMarkType.Inner },
                new PunctuationMark() { Value = ".", Name = PunctuationMarkName.Dot, Type = PunctuationMarkType.Terminal },
                new PunctuationMark() { Value = ",", Name = PunctuationMarkName.Comma, Type = PunctuationMarkType.Inner },
                new PunctuationMark() { Value = "!", Name = PunctuationMarkName.Exclamation, Type = PunctuationMarkType.Terminal },
                new PunctuationMark() { Value = "?", Name = PunctuationMarkName.Question, Type = PunctuationMarkType.Terminal },
                new PunctuationMark() { Value = ";", Name = PunctuationMarkName.Semicolon, Type = PunctuationMarkType.Inner },
                new PunctuationMark() { Value = ":", Name = PunctuationMarkName.Colon, Type = PunctuationMarkType.Inner },
                new PunctuationMark() { Value = "'", Name = PunctuationMarkName.SingleQuotes, Type = PunctuationMarkType.Inner },
                new PunctuationMark() { Value = "\"", Name = PunctuationMarkName.DoubleQuotes, Type = PunctuationMarkType.Inner }
            };
        }
    }
}
