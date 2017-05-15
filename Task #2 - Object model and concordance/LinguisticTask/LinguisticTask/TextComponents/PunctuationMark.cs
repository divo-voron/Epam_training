using LinguisticTask.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticTask.TextComponents
{
    struct PunctuationMark
    {
        private string _value;
        private PunctuationMarkName _name;
        private PunctuationMarkType _type;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public PunctuationMarkName Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public PunctuationMarkType Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
