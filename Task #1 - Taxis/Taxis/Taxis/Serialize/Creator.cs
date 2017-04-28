using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.CarComponents;
using TaxiStation.Enums;
using TaxiStation.Interfaces;

namespace TaxiStation.Serialize
{
    [DataContract]
    [KnownType(typeof(CreatorCoupe))]
    [KnownType(typeof(CreatorPremium))]
    [KnownType(typeof(CreatorSedan))]
    [KnownType(typeof(CreatorGazel))]
    public abstract class Creator
    {
        [DataMember]
        protected int _id;
        [DataMember]
        protected int _speed;
        [DataMember]
        protected int _fuelConsumption;
        [DataMember]
        protected int _price;
        [DataMember]
        protected int _curbWeight;
        [DataMember]
        protected CarsControlSystemType _carsControlSystemType;
        public Creator(int id, int speed, int fuelConsumptionm, int price, int curbWeight, CarsControlSystemType carsControlSystemType = CarsControlSystemType.Human)
        {
            _id = id;
            _speed = speed;
            _fuelConsumption = fuelConsumptionm;
            _price = price;
            _curbWeight = curbWeight;
            _carsControlSystemType = carsControlSystemType;
        }
        public abstract ICar GetCar();
    }
}
