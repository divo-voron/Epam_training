using TaxiStation.Enums;
using TaxiStation.Serialize;

namespace TaxiStation.Interfaces
{
    public interface ICar
    {
        int Id { get; }
        int Speed { get; set; }
        int FuelConsumption { get; set; }
        int Price { get; set; }
        int CurbWeight { get; set; }
        CarsControlSystemType CarsControlSystemType { get; set; }
        int GetFullWeight();
        string GetInfo();
        Creator GetCreator();
    }
}
