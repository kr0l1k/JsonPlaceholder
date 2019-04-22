using System;

namespace JsonPlaceholder.Models
{
    [Serializable]
    public class Adress
    {
        [System.Xml.Serialization.XmlElement("stret")]
        public string Street { get; set; }
        [System.Xml.Serialization.XmlElement("suite")]
        public string Suite { get; set; }
        [System.Xml.Serialization.XmlElement("city")]
        public string City { get; set; }
        [System.Xml.Serialization.XmlElement("zipcode")]
        public string Zipcode { get; set; }
        [System.Xml.Serialization.XmlElement("geo")]
        public Geo Geo { get; set; }
    }
}
