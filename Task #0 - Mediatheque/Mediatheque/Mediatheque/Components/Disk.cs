using Mediatheque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Components
{
    class Disk:File,ICRUDOperation
    {
        private ICollection< Photo> _photos;
        private ICollection< Video> _videos;

        public Disk(string path, string title, string extension, ICollection<Photo> photos, ICollection<Video> videos)
            : base(path, title, extension)
        {
            _photos = photos;
            _videos = videos;
        }

        //TODO: realize only READ operation here

        public bool Create(File file)
        {
            return false;
            throw new NotImplementedException();
        }

        public File Read()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
