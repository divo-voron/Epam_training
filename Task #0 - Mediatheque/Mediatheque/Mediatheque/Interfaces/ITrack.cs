using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Interfaces
{
    interface ITrack
    {
        int Duration { get; }
        /// <summary>
        /// Частота дискретизации аудиодорожки
        /// </summary>
        int SampleRate { get; }
    }
}
