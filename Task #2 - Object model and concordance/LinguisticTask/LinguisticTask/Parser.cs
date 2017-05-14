using LinguisticTask.TextComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask
{
    static class Parser
    {
        private static ICollection<string> separators = new List<string>() { " ", ",", "." };
        private static ICollection<string> separatorsTerminal = new List<string>() { "." };
        public static Text Parse(TextReader reader)
        {
            Text text = new Text();
            string line = reader.ReadLine();
            while (line != null)
            {
                Paragraph paragraph = new Paragraph();
                Sentence sentence = new Sentence();
                while (line.Length > 0)
                {
                    int firstSentenceSeparatorOccurence = -1;
                    string firstSentenceSeparator = separators.FirstOrDefault(
                        x =>
                        {
                            firstSentenceSeparatorOccurence = line.IndexOf(x);
                            return firstSentenceSeparatorOccurence >= 0;
                        });
                    if (firstSentenceSeparator != null)
                    {
                        Word word = new Word(line.Substring(0, firstSentenceSeparatorOccurence));
                        Punctuation punctuation = new Punctuation(line.Substring(firstSentenceSeparatorOccurence, firstSentenceSeparator.Length));

                        line = line.Remove(0, word.Length + punctuation.Length);

                        sentence.Items.Add(word);
                        sentence.Items.Add(punctuation);
                    }
                    else
                    {
                        Word word = new Word(line);
                        line = line.Remove(0, word.Length);
                        sentence.Items.Add(word);
                        continue;
                    }
                    if (separatorsTerminal.Contains(firstSentenceSeparator)) 
                    {
                        paragraph.Items.Add(sentence);
                        sentence = new Sentence();
                    }
                }
                
                line = reader.ReadLine();

                paragraph.Items.Add(sentence);
                text.Items.Add(paragraph);
            }
            return text;
        }

        private static Sentence GetSentence(this string source)
        {
            return new Sentence();// source.Substring(0, 3);
        }
    }
}
