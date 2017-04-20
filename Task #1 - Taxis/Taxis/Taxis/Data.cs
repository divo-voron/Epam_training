using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TaxiStation.CarComponents;

namespace TaxiStation
{
    static class Data
    {
        static string folder = @"d:\!Учеба\Epam_training\Task #1 - Taxis\Taxis\";
        static string file = @"taxi.xml";

        public static Taxi Read()
        {
            if ((Directory.Exists(folder)) && (File.Exists(folder + file)))
            {
                // десериализуем
                using (TextReader reader = new StreamReader(folder + file))
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Taxi));
                        Taxi taxi = (Taxi)serializer.Deserialize(reader);
                        reader.Close();

                        return taxi;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        if (reader != null) reader.Close();

                        return null;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error! Folder or/and file doesn't exist.");
                return null; 
            }
        }

        public static bool Write(Taxi taxi)
        {
            if (Directory.Exists(folder))
            {
                // сериализуем
                using (TextWriter writer = new StreamWriter(folder + file))
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Taxi));
                        serializer.Serialize(writer, taxi);
                        writer.Close();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        if (writer != null) writer.Close();

                        return false;
                    }
                }
            }
            else 
                return false;
        }
    }
}
