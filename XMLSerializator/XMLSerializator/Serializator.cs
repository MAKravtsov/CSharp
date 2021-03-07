using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerializator
{
    public static class Serializator
    {
        public static bool SaveXml<T>(object obj, string filePath)
        {
            try
            {
                var xml = new XmlSerializer(typeof(T));
                using (var str = new StreamWriter(filePath))
                {
                    xml.Serialize(str, obj);
                    str.Close();
                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static T LoadXml<T>(string filepath)
        {
            if (!File.Exists(filepath))
                return default(T);

            try
            {
                var xml = new XmlSerializer(typeof(T));
                T obj;
                using (var str = new StreamReader(filepath))
                {
                    obj = (T)xml.Deserialize(str);
                    str.Close();
                }
                return obj;
            }
            catch (Exception e)
            {
                return default(T);
            }

        }
    }
}
