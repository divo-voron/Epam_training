﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation.Factory
{
    abstract class Creator
    {
        public abstract CarData FactoryMethod();
    }
}
