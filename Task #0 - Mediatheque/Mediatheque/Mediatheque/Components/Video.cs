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
    class Video : File, IPicture, ITrack
    {
        private Resolutions _resolution;
        private ColorDepth _color;
        private ICollection<Frame> _videoSequence;
        private int _fps;
        private Track _audioSequence;

        public Video() { }
        public Video(string path, string title, string extension, ICollection<Frame> videoSequence, Track audioSequence, int fps,
            Resolutions resolution = Resolutions.Undefined, ColorDepth color = ColorDepth.Undefined)
            : base(path, title, extension)
        {
            _videoSequence = videoSequence;
            _audioSequence = audioSequence;
            _fps = fps;
            _resolution = resolution;
            _color = color;
        }
        public int BitRate
        {
            get
            {
                if (_videoSequence != null && _videoSequence.Count > 0 && Duration > 0)
                    return _videoSequence.Sum(item => item.Size) / Duration;
                else
                    return 0;
            }
        }
        public string GetMediaInfo()
        {
            return string.Format("{0}\r\nBitRate: {1}\r\nResolution: {2}\r\nColor: {3}\r\nDuration: {4}\r\nSampleRate: {5}\r\nSize: {6}\r\n---------------",
                base.GetFileName(), BitRate, Resolution, Color, Duration, SampleRate, GetSize());
        }

        public override int GetSize()
        {
            return (_videoSequence != null ? _videoSequence.Sum(item => item.Size) : 0) + 
                   (_audioSequence != null ? _audioSequence.GetSize() : 0);
        }

        public Resolutions Resolution
        {
            get { return _resolution; }
        }

        public ColorDepth Color
        {
            get { return _color; }
        }

        public int Duration
        {
            get
            {
                return _videoSequence != null ? _videoSequence.Count() / _fps : 0;
            }
        }

        public int SampleRate
        {
            get
            {
                return _audioSequence != null ? _audioSequence.SampleRate : 0;
            }
        }
    }
}
