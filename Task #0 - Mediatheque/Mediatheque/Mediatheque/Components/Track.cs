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
        public Track(string name, int duration)
            : base(name)
        {
            _duration = duration;
        }
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
    }
}
