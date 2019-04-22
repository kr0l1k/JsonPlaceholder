using System;

namespace JsonPlaceholder.Models
{
    [Serializable]
    public class User
    {
        [System.Xml.Serialization.XmlElement("id")]
        public int Id { get; set; }
        [System.Xml.Serialization.XmlElement("name")]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlElement("username")]
        public string Username { get; set; }
        [System.Xml.Serialization.XmlElement("email")]
        public string Email { get; set; }
        [System.Xml.Serialization.XmlElement("adress")]
        public Adress Address { get; set; }
        [System.Xml.Serialization.XmlElement("phone")]
        public string Phone { get; set; }
        [System.Xml.Serialization.XmlElement("website")]
        public string Website { get; set; }
        [System.Xml.Serialization.XmlElement("company")]
        public Company Company { get; set; }
    }
}
