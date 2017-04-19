using Mediatheque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Components
{
    class Compilation : File
    {
        private ICollection<IPicture> _photos;
        private ICollection<IVideo> _videos;

        public Compilation(string name, ICollection<IPicture> photos, ICollection<IVideo> videos)
            : base(name)
        {
            _photos = photos;
            _videos = videos;
        }

        public void Add()
        { }

        public void Remove()
        { }

        //public T this[int index]
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
