using System.Collections.Generic;
using System.Linq;

namespace LinguisticTask.Impl.PunctuationItems
{
    static class PunctuationMarkContainer
    {
        private static ICollection<PunctuationMark> _marks;

        public static ICollection<PunctuationMark> AllMarks
        {
            get { return _marks; }
        }
        public static ICollection<PunctuationMark> TerminalMarks
        {
            get { return _marks.Where(item => item.Type == PunctuationMarkType.Terminal).ToList(); }
        }
        public static ICollection<PunctuationMark> InnerMarks
        {
            get { return _marks.Where(item => item.Type == PunctuationMarkType.Inner).ToList(); }
        }

        public static void LoadData(ICollection<PunctuationMark> marks)
        {
            _marks = marks;
        }
    }
}
