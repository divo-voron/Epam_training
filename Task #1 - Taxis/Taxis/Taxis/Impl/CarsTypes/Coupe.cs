using TaxiStation.Enums;
using TaxiStation.Interfaces;
using TaxiStation.Serialize;

namespace TaxiStation.Impl.CarsTypes
{
    class Coupe : Car, IPassengers
    {
        private int _numberOfPassengers;
        public Coupe(int id) : base(id) { }
        public int NumberOfPassengers
        {
            get { return _numberOfPassengers; }
            set { _numberOfPassengers = value; }
        }
        public override int GetFullWeight()
        {
            return base.GetFullWeight() + _numberOfPassengers * HumansWeight;
        }
        public override string GetInfo()
        {
            return string.Format("{0} | {1} | {2}", base.GetInfo(), NumberOfPassengers, "    ");
        }
        public override Creator GetCreator()
        {
            return new CreatorCoupe(Id, Speed, FuelConsumption, Price, CurbWeight, NumberOfPassengers, CarsControlSystemType);
        }
    }
}
