using LinguisticTask.Impl;
using LinguisticTask.Impl.PunctuationItems;
using LinguisticTask.Impl.TextItems;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LinguisticTask
{
    static class Parser
    {
        public static Text Parse(TextReader reader)
        {
            Text text = new Text();
            reader.Dispose();
            string line = reader.ReadLine();
            while (line != null)
            {
                while (string.IsNullOrWhiteSpace(line) == false)
                {
                    line = CleanLine(line);
                    Paragraph paragraph = new Paragraph();
                    Sentence sentence = new Sentence();

                    while (line.Length > 0)
                    {
                        int firstSentenceSeparatorOccurence;
                        PunctuationMark firstSentenceSeparator;
                        SearchSeparator(line, out firstSentenceSeparatorOccurence, out firstSentenceSeparator);

                        if (firstSentenceSeparator.Equals(default(PunctuationMark)) == false)
                        {
                            if (firstSentenceSeparatorOccurence > 0)
                            {
                                Word word = new Word(line.Substring(0, firstSentenceSeparatorOccurence));
                                sentence.Items.Add(word);
                            }

                            Punctuation punctuation =
                                new Punctuation(line.Substring(firstSentenceSeparatorOccurence, firstSentenceSeparator.Value.Length),
                                    firstSentenceSeparator);

                            line = line.Remove(0, firstSentenceSeparatorOccurence + punctuation.Length);

                            sentence.Items.Add(punctuation);
                        }
                        else
                        {
                            Word word = new Word(line);
                            line = line.Remove(0, word.Length);
                            sentence.Items.Add(word);
                        }
                        if (firstSentenceSeparator.Equals(default(PunctuationMark)) == false &&
                            firstSentenceSeparator.Type == PunctuationMarkType.Terminal || line.Length == 0)
                        {
                            paragraph.Items.Add(sentence);
                            sentence = new Sentence();
                        }
                    }
                    text.Items.Add(paragraph);
                }
                line = reader.ReadLine();
            }
            return text;
        }
        private static void SearchSeparator(string line, out int firstSentenceSeparatorOccurence, out PunctuationMark firstSentenceSeparator)
        {
            firstSentenceSeparatorOccurence = line.Length;
            firstSentenceSeparator = default(PunctuationMark);
            for (int i = 0; i < PunctuationMarkContainer.AllMarks.Count; i++)
            {
                int a = line.IndexOf(PunctuationMarkContainer.AllMarks.ElementAt(i).Value);
                if (a >= 0 && firstSentenceSeparatorOccurence > a)
                {
                    firstSentenceSeparatorOccurence = a;
                    firstSentenceSeparator = PunctuationMarkContainer.AllMarks.ElementAt(i);
                }
            }
        }

        private static string CleanLine(string line)
        {
            line = line.Trim();
            line = Regex.Replace(line, @"[ |\t]+", " ");
            return line;
        }
    }
}
