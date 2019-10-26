using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SerializationTasks
{
    public class ListOfCarFormatter
    {
        public List<Car> Cars { get; set; }
        public string BinaryPath { get; set; }
        public string XmlPath { get; set; }
        public string JsonPath { get; set; }

        public void BinarySerialize()
        {
            try
            {
                using ( FileStream fs = new FileStream(BinaryPath , FileMode.Append , FileAccess.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, Cars);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public List<Car> BinaryDeserialize()
        {
            try
            {
                using (FileStream fs = new FileStream(BinaryPath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(fs) as List<Car>;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        public void XmlSerialize()
        {
            try
            {
               using (FileStream fs = new FileStream(XmlPath, FileMode.OpenOrCreate , FileAccess.Write))
               {
                   XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));
                   formatter.Serialize(fs, Cars);
               }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Car> XmlDeserialize()
        {
            try
            {
                using (FileStream fs = new FileStream(XmlPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));
                    return formatter.Deserialize(fs) as List<Car>;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void JsonSerialize()
        {
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamWriter sw = new StreamWriter(JsonPath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, Cars);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public List<Car> JsonDeserialize()
        {
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                using (StreamReader sw = new StreamReader(JsonPath))
                using (JsonReader reader = new JsonTextReader(sw))
                {
                    return serializer.Deserialize(reader, typeof(List<Car>)) as List<Car>;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
