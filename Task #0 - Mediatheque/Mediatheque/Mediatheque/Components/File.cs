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
        private string _path;
        private string _title;
        private string _extension;
        private int _size;

        public File() { }
        public File(string path, string title, string extension, int size = 0)
        {
            _path = path;
            _title = title;
            _extension = extension;
            _size = size;
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public string GetFileName()
        {
            return string.Concat(_path, "\\", _title, ".", _extension);
        }

        public virtual int GetSize()
        {
            return _size;
        }
    }
}
