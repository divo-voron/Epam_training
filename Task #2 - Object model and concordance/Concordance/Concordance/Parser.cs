using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Concordance
{
    class Parser
    {
        private Dictionary<char, Dictionary<string, MatchData>> _concordance;
        public void Parse(TextReader reader)
        {
            _concordance = new Dictionary<char, Dictionary<string, MatchData>>();

            Regex regex = new Regex("[А-Яа-яA-Za-z]+");
            int lineNumber = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                lineNumber++;
                MatchCollection matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    string value = match.Value.ToLower();
                    char key = value[0];

                    if (_concordance.ContainsKey(key))
                    {
                        if (_concordance[key].ContainsKey(value))
                        {
                            MatchData matchData = _concordance[key][value];
                            matchData.Count++;
                            matchData.Add(lineNumber);
                        }
                        else
                            _concordance[key].Add(value, new MatchData(lineNumber));
                    }
                    else
                    {
                        Dictionary<string, MatchData> dic = new Dictionary<string, MatchData>();
                        dic.Add(value, new MatchData(1));
                        _concordance.Add(key, dic);
                    }
                }
                line = reader.ReadLine();
            }
        }
        public ConcordanceContainer GetConcordance()
        {
            return new ConcordanceContainer(_concordance);
        }
    }
}
