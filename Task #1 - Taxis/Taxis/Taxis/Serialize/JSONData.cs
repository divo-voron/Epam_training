using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Interfaces;

namespace TaxiStation.Serialize
{
    static class JSONData
    {
        public static void Write(ICollection<ICar> data)
        {
            IEnumerable<Creator> serData = data.Select(item => item.GetCreator());
            
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(IEnumerable<Creator>));

            using (FileStream fs = new FileStream(@"D:\1\Car.json", FileMode.Create))
            {
                jsonSer.WriteObject(fs, serData);
            }
        }

        public static ICollection<ICar> Read()
        {
            IEnumerable<Creator> retVal;
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(IEnumerable<Creator>));
            using (FileStream fs = new FileStream(@"D:\1\Car.json", FileMode.Open))
            {
                retVal = (IEnumerable<Creator>)jsonSer.ReadObject(fs);
            }

            return retVal.Select(item => item.FactoryMethod()).ToList();
        }
    }
}
