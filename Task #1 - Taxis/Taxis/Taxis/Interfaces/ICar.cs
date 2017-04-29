using TaxiStation.Enums;
using TaxiStation.Serialize;

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
        Creator GetCreator();
    }
}
