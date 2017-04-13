using Mediatheque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Components
{
    class Track : File, ITrack
    {
        private int _duration;
        private int _sampleRate;
        public Track() { }
        public Track(string path, string title, string extension, int size, int duration, int sampleRate)
            : base(path, title, extension, size)
        { }
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public int SampleRate
        {
            get { return _sampleRate; }
            set { _sampleRate = value; }
        }
    }
}
