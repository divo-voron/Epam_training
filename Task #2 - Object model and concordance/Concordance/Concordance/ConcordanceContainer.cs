using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concordance
{
    class ConcordanceContainer
    {
        private Dictionary<char, Dictionary<string, MatchData>> _concordance;
        public Dictionary<char, Dictionary<string, MatchData>> Concordance
        {
            get { return _concordance; }
        }
        public ConcordanceContainer(Dictionary<char, Dictionary<string, MatchData>> concordance)
        {
            _concordance = concordance;
        }
        public Dictionary<char, Dictionary<string, MatchData>> GetDictionary(int count = 0)
        {
            return _concordance
                // get where items.count > 0
                .Where(letterValue => letterValue.Value
                    .Where(item => item.Value.Count >= count).Count() > 0)
                // get dictionary from (items.Count > 0)
                .ToDictionary(
                letterKey => letterKey.Key,
                letterValue => letterValue.Value
                    .Where(item => item.Value.Count >= count)
                    .ToDictionary(key => key.Key, value => value.Value));
        }

        
    }
}
