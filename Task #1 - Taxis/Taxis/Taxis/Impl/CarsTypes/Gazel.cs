using TaxiStation.Enums;
using TaxiStation.Interfaces;
using TaxiStation.Serialize;

namespace TaxiStation.Impl.CarsTypes
{
    class Gazel : Car, ICargo
    {
        private int _cargo;
        public Gazel(int id) : base(id) { }
        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
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
