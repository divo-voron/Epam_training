using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation
{
    public class InvalidKeyException : SystemException
    {
        private string _textExceptiton;
        public InvalidKeyException(IEnumerable<int> ids)
        {
            _textExceptiton = string.Format("Next ID repeats: {0}", string.Join(", ", ids));
        }
        public override string ToString()
        {
            return _textExceptiton;
        }
    }
}
