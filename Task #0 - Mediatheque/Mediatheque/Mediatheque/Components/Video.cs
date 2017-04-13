using Mediatheque.Enums;
using Mediatheque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Components
{
    class Frame
    {
        private int _size;
        public Frame(int size = 0)
        {
            _size = size;
        }
        public int Size
        {
            get { return _size; }
        }
    }
    class Video : File, IVideo
    {
        private Resolutions _resolution;

        public Video(string name, Resolutions resolution)
            : base(name)
        {
            _resolution = resolution;
        }

        public Resolutions Resolution
        {
            get { return _resolution; }
        }
    }
}
