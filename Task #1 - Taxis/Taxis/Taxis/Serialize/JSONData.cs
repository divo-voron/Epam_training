using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using TaxiStation.Interfaces;

namespace TaxiStation.Serialize
{
    class JSONData
    {
        public static void Write(ICollection<ICar> data, string path)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(IEnumerable<Creator>));

            if (Directory.Exists(Path.GetDirectoryName(path)) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                jsonSer.WriteObject(fs, data.Select(item => item.GetCreator()));
            }
        }

        public static ICollection<ICar> Read(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(IEnumerable<Creator>));
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        return ((IEnumerable<Creator>)jsonSer.ReadObject(fs)).Select(item => item.GetCar()).ToArray();
                    }
                }
                catch (Exception) { return null; }
            }
            else return null;
        }
    }
}
