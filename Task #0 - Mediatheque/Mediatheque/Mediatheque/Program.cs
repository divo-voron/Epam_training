using Mediatheque.Components;
using Mediatheque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Frame> videoSequence = new List<Frame>();
            for (int i = 0; i < 15; i++)
            {
                videoSequence.Add(new Frame(i + 11));
            }

            Video video = new Video("D:\\1", "SampleVideo", "avi", videoSequence, new Track(), 3);
            Console.WriteLine(video.GetMediaInfo());

            Happening happening = new Happening("", "", "", new List<Photo>(), new List<Video>());
            Console.WriteLine(happening.GetFileName());

            happening.Create(new Happening());
        }
    }
}
