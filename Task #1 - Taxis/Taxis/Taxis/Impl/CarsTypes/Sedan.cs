using TaxiStation.Enums;
using TaxiStation.Interfaces;
using TaxiStation.Serialize;

namespace TaxiStation.Impl.CarsTypes
{
    class Sedan : Car, IPassengers, ICargo
    {
        private int _numberOfPassengers;
        private int _cargo;
        public Sedan(int id) : base(id) { }
        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
            set { _numberOfPassengers = value; }
        }
        public int Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }
        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _cargo + _numberOfPassengers * HumansWeight;
        }
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), NumberOfPassengers, Cargo.ToString().PadLeft(4,' '));
        }
        public override Creator GetCreator()
        {
            return new CreatorSedan(Id, Speed, FuelConsumption, Price, CurbWeight, NumberOfPassengers, Cargo, CarsControlSystemType);
        }
    }
}
