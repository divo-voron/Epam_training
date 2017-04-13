﻿using Mediatheque.Interfaces;
using Mediatheque.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Components
{
    class Happening : File
    {
        private ICollection<IPicture> _photos;
        private ICollection<IVideo> _videos;

        public Happening(string name, ICollection<IPicture> photos, ICollection<IVideo> videos)
            : base(name)
        {
            _photos = photos;
            _videos = videos;
        }
    }
}
