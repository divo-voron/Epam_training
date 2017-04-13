using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Interfaces
{
    interface IFile
    {
        string Path { get; set; }
        string Title { get; set; }
        string Extension { get; set; }
        string GetFileName();
        int GetSize();
    }
}
