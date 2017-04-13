using Mediatheque.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Interfaces
{
    interface ICRUDOperation
    {
        bool Create(File file);
        File Read();
        bool Update();
        bool Delete();
    }
}
