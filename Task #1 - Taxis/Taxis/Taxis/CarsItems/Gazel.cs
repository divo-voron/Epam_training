using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Interfaces;
using TaxiStation.Serialize;

namespace TaxiStation.CarsItems
{
    class Gazel : Car, ICargo
    {
        private int _cargo;
        public Gazel(int id, int speed, int fuelConsumption, int price, int curbWeight, int cargo, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
            : base(id, speed, fuelConsumption, price, curbWeight, carsControlSystemType)
        {
            _cargo = cargo;
        }
        public int Cargo
        {
            get { return _cargo; }
        }

        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _cargo;
        }
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), " ", Cargo);
        }
        public override Creator GetCreator()
        {
            return new CreatorGazel(Id, Speed, FuelConsumption, Price, CurbWeight, Cargo, CarsControlSystemType);
        }
    }
}
