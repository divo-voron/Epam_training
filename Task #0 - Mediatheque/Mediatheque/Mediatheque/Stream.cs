using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque
{
    class Stream
    {
        private string _stream;
        public Stream(string stream)
        {
            _stream = stream;
        }

        public string Play()
        {
            return _stream;
        }
    }
}
