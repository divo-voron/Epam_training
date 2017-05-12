using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Concordance
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            parser.Parse(new StreamReader(new FileStream(@"D:\1\1.txt", FileMode.Open)));

            ConcordanceContainer concordance = parser.GetConcordance();
            Show(concordance.GetDictionary(3));
        }

        static void Show(Dictionary<char, Dictionary<string, MatchData>> dictionary)
        {
            foreach (KeyValuePair<char, Dictionary<string, MatchData>> letter in dictionary.OrderBy(item => item.Key))
            {
                Console.WriteLine("{0}:", letter.Key.ToString().ToUpper());

                foreach (KeyValuePair<string, MatchData> kvp in letter.Value.OrderBy(item => item.Key))
                {
                    Console.WriteLine("{0} - {1}: {2}",
                    kvp.Key.PadLeft(15, ' '), kvp.Value.Count.ToString().PadLeft(2, ' '), string.Join(", ", kvp.Value.NumberOfLines));
                }
            }
        }
    }
}
