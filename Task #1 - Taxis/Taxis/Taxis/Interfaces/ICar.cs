using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enums;
using TaxiStation.Factory;

namespace TaxiStation.Interfaces
{
    public interface ICar
    {
        int Speed { get; set; }
        int FuelConsumption { get; set; }
        int Price { get; set; }
        int CurbWeight { get; set; }
        CarsControlSystemType CarsControlSystemType { get; set; }
        int GetFullWeight();
        string GetInfo();
        CarData GetData();
    }
}
