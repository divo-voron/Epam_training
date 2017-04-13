using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatheque.Components;

namespace Mediatheque.Interfaces
{
    interface IFile
    {
        string Name { get; set; }
        string GetFileName();
        Stream GetStream();
    }
}
