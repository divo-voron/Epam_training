﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mediatheque.Enums;

namespace Mediatheque.Interfaces
{
    interface IPicture:IFile
    {
        ColorDepth Color { get; }
    }
}
