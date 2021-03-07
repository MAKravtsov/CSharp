using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerializator
{
    [Serializable]
    public class Settings
    {
        [XmlAttribute]
        public int Num { get; set; }
        [XmlAttribute]
        public string Str { get; set; }
        [XmlAttribute]
        public float Fl { get; set; }

    }
}
