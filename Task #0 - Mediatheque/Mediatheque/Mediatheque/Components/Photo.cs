using Mediatheque.Enums;
using Mediatheque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Components
{
    class Photo : File, IPicture
    {
        private ColorDepth _color;

        public Photo(string name, ColorDepth color)
            : base(name)
        {
            _color = color;
        }

        public ColorDepth Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public override Stream GetStream()
        {
            return new Stream(string.Format("Name: {0}, Color: {1}", Name, _color));
        }
    }
}
