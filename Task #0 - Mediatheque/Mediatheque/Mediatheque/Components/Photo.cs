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
        private Resolutions _resolution;
        private ColorDepth _color;

        public Photo() { }
        public Photo(string path, string title, string extension, int size)
            : base(path, title, extension, size)
        {

        }
        public Photo(string path, string title, string extension, int size, Resolutions resolution, ColorDepth color)
            : base(path, title, extension, size)
        {
            _resolution = resolution;
            _color = color;
        }

        public Resolutions Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        public ColorDepth Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
