using LinguisticTask.Impl.PunctuationItems;
using System.Collections.Generic;

namespace LinguisticTask.Impl.TextItems
{
    interface ISentence : ITextElement
    {
        ICollection<ISentenceItem> Items { get; set; }
        int Count<T>() where T : ISentenceItem;
        PunctuationMark GetEndSentence();
        void RemoveItem(ISentenceItem item);
    }
}
