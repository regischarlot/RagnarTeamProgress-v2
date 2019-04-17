using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace D3_API.Models
{
    [Serializable]
    [XmlRoot("leg")]
    [DataContract]
    public class TcLeg
    {
        [XmlElement(ElementName = "id")]
        [DataMember(Name = "id")]
        public int LegID { get; set; }

        [XmlElement(ElementName = "order")]
        [DataMember(Name = "order")]
        public int Order { get; set; }

        [XmlElement(ElementName = "van")]
        [DataMember(Name = "van")]
        public int Van { get; set; }

        [XmlElement(ElementName = "distance")]
        [DataMember(Name = "distance")]
        public double Distance { get; set; }

        [XmlElement(ElementName = "difficulty")]
        [DataMember(Name = "difficulty")]
        public int Difficulty { get; set; }

        public TcLeg()
        {
            
        }

        public TcLeg(int id, int order, int van, double distance, int difficulty)
        {
            LegID = id;
            Order = order;
            Van = van;
            Distance = distance;
            Difficulty = difficulty;
        }
    }
}
