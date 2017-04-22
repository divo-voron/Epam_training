using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Interfaces;

namespace TaxiStation.Factory
{
    class CreatorCar: Creator
    {
        CarData _carData;
        public CreatorCar(ICar car)
        {   
            _carData = car.GetData();
        }
        public override CarData FactoryMethod()
        {
            return _carData;
        }
    }
}
