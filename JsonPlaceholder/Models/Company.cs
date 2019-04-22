using System;

namespace JsonPlaceholder.Models
{
    [Serializable]
    public class Company
    {
        [System.Xml.Serialization.XmlElement("name")]
        public string  Name { get; set; }
        [System.Xml.Serialization.XmlElement("catchPhrase")]
        public string CatchPhrase { get; set; }
        [System.Xml.Serialization.XmlElement("bs")]
        public string Bs { get; set; }
    }
}
