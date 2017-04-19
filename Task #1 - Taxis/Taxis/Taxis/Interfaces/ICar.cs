using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation.Interfaces
{
    public enum CarsControlSystemType
    {
        Human,
        Autopilot
    }
    public interface ICar
    {
        int Speed { get; set; }
        int FuelConsumption { get; set; }
        int Price { get; set; }
        CarsControlSystemType CarsControlSystemType { get; set; }
    }
}
