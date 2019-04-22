using System;

namespace JsonPlaceholder.Models
{
    [Serializable]
    public class Geo
    {
        [System.Xml.Serialization.XmlElement("lat")]
        public string Lat { get; set; }
        [System.Xml.Serialization.XmlElement("lng")]
        public string Lng { get; set; }
    }
}
