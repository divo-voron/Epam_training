using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque
{
    class Player
    {
        private string _player;
        public Player(Stream stream)
        {
            _player = stream.Play();
        }
        public void Play() 
        {
            Console.WriteLine(string.Format("Now playing: {0}", _player));
        }
    }
}
