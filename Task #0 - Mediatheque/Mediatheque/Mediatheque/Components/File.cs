using Mediatheque.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Components
{
    abstract class File : IFile
    {
        private string _name;
        private int _size;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public File(string name)
        {
            _name = name;
        }

        public string GetFileName()
        {
            return _name;
        }

        public virtual Stream GetStream()
        {
            return new Stream("");
        }
    }
}
