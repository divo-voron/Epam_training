using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Factory;

namespace TaxiStation.Interfaces
{
    public interface ICar
    {
        int Id { get; }
        int Speed { get; }
        int FuelConsumption { get; }
        int Price { get; set; }
        int CurbWeight { get; }
        CarsControlSystemType CarsControlSystemType { get; }
        int GetFullWeight();
        string GetInfo();
        CarData GetData();
    }
}
