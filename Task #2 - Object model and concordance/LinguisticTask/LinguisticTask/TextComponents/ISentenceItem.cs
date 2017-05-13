using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask.TextComponents
{
    interface ISentenceItem : ITextElement
    {
        char[] Items { get; set; }
    }
}
