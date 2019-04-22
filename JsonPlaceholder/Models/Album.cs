using System;

namespace JsonPlaceholder.Models
{
    [Serializable]
    public class Album
    {
        [System.Xml.Serialization.XmlElement("id")]
        public int id { get; set; }
        [System.Xml.Serialization.XmlElement("userId")]
        public int UserId { get; set; }
        [System.Xml.Serialization.XmlElement("title")]
        public string Title { get; set; }
    }
}
