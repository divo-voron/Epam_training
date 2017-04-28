using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation
{
    class InvalidKeyException : SystemException
    {
        private string _textExceptiton;
        public InvalidKeyException(IEnumerable<int> ids)
        {
            _textExceptiton = string.Format("The following IDs are repeated: {0}", string.Join(", ", ids));
        }
        public override string ToString()
        {
            return _textExceptiton;
        }
    }
}
