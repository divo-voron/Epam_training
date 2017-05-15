using LinguisticTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask.TextComponents
{
    interface ISentence : ITextElement
    {
        ICollection<ISentenceItem> Items { get; set; }
        int Count<T>() where T : ISentenceItem;
        PunctuationMark GetEndSentence();
        void RemoveItem(ISentenceItem item);
    }
}
