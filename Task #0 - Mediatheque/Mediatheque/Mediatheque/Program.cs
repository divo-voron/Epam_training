using Mediatheque.Components;
using Mediatheque.Interfaces;
using Mediatheque.Enums;
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
            Photo photo = new Photo("Dog", ColorDepth.GrayScale);

            Player player = new Player(photo.GetStream());
            player.Play();
        }
    }
}
