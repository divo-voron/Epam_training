using LinguisticTask.Enums;
using LinguisticTask.TextComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = LoadText();

            IEnumerable<ISentence> sentences1 = text.GetSentences();

            IOrderedEnumerable<ISentence> sentences2 = text.GetSentences().OrderBy(item => item.Count<Word>());

            IEnumerable<ISentence> sentences3 = text.GetSentences(PunctuationMarks.Question);

            IEnumerable<Word> words = text.GetWord(PunctuationMarks.Question, 3).ToList();
        }

        static Text LoadText()
        {
            Sentence sentence_1 = new Sentence();
            sentence_1.Items = new List<ISentenceItem>()
            {
                new Word(){Items = "Привет"},
                new Punctuation() {Items = ",",PunctuationMark = PunctuationMarks.Comma},
                new Word(){Items = "как"},
                new Word(){Items = "дела"},
                new Punctuation() {Items = "?", PunctuationMark = PunctuationMarks.Question},
                new Word(){Items = "Привет"},
                new Punctuation() {Items = ",", PunctuationMark = PunctuationMarks.Comma},
                new Word(){Items = "как"},
                new Word(){Items = "дела"},
                new Punctuation() {Items = "?", PunctuationMark = PunctuationMarks.Question}
            };

            Sentence sentence_2 = new Sentence();
            sentence_2.Items = new List<ISentenceItem>()
            {
                new Word(){Items = "Чем"},
                new Word(){Items = "занят"},
                new Punctuation(){Items = "?"}
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
                new Word(){Items = "Привет"},
                new Punctuation() {Items = ","},
                new Word(){Items = "как"},
                new Word(){Items = "дела"},
                new Punctuation() {Items = "?"}
            };

            Sentence sentence_4 = new Sentence();
            sentence_4.Items = new List<ISentenceItem>()
            {
                new Word(){Items = "Чем"},
                new Word(){Items = "занят"},
                new Punctuation(){Items = "?"},
                new Word(){Items = "Чем"},
                new Word(){Items = "занят"},
                new Punctuation(){Items = "?"}
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
    }
}
