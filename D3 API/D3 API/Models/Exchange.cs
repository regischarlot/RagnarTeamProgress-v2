using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace D3_API.Models
{
    [Serializable]
    [XmlRoot("exchange")]
    [DataContract]
    public class Exchange
    {
        [XmlElement(ElementName = "id")]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "address")]
        [DataMember(Name = "address")]
        public string Address { get; set; }

        [XmlElement(ElementName = "van")]
        [DataMember(Name = "van")]
        public int Van { get; set; }

        [XmlElement(ElementName = "latitude")]
        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [XmlElement(ElementName = "longitude")]
        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        [XmlIgnore]
        public string FollowingLeg => string.Format("<a href=\"https://www.ragnarrelay.com/race/chicago/legs/{0}\" target=\"_blank\">Leg {0}</a>", Id);

        public Exchange(int id, string name, string address, int van, string latitude, string longitude)
        {
            Id = id;
            Name = name;
            Address = address;
            Van = van;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}