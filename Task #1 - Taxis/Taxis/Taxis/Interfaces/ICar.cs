using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxis.Interfaces
{
    enum CarsControlSystemType
    {
        Human,
        Autopilot
    }
    interface ICar
    {
        int Speed { get; set; }
        int FuelConsumption { get; set; }
        int Price { get; set; }
        CarsControlSystemType CarsControlSystemType { get; set; }
    }
}
