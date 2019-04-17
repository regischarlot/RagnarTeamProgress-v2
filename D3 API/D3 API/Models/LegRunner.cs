using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace D3_API.Models
{
    [Serializable]
    [XmlRoot("legrunner")]
    [DataContract]
    public class TcLegRunner : TcLeg
    {
        [XmlElement(ElementName = "teamId")]
        [DataMember(Name = "teamId")]
        public int TeamID { get; set; }

        [XmlElement(ElementName = "legRunnerId")]
        [DataMember(Name = "legRunnerId")]
        public int? LegRunnerID { get; set; }

        [XmlElement(ElementName = "runner1Id")]
        [DataMember(Name = "runner1Id")]
        public int? Runner1ID { get; set; }

        [XmlElement(ElementName = "runner1Name")]
        [DataMember(Name = "runner1Name")]
        public string Runner1Name { get; set; }

        [XmlElement(ElementName = "runner1Pace")]
        [DataMember(Name = "runner1Pace")]
        public string Runner1Pace { get; set; }

        [XmlElement(ElementName = "runner1Cell")]
        [DataMember(Name = "runner1Cell")]
        public string Runner1Cell { get; set; }

        [XmlElement(ElementName = "runner2Id")]
        [DataMember(Name = "runner2Id")]
        public int? Runner2ID { get; set; }

        [XmlElement(ElementName = "runner2Name")]
        [DataMember(Name = "runner2Name")]
        public string Runner2Name { get; set; }

        [XmlElement(ElementName = "runner2Pace")]
        [DataMember(Name = "runner2Pace")]
        public string Runner2Pace { get; set; }

        [XmlElement(ElementName = "runner2Cell")]
        [DataMember(Name = "runner2Cell")]
        public string Runner2Cell { get; set; }

        [XmlElement(ElementName = "pace")]
        [DataMember(Name = "pace")]
        public double? Pace { get; set; }

        [XmlElement(ElementName = "truePace")]
        [DataMember(Name = "truePace")]
        public string TruePace { get; set; }



        [XmlElement(ElementName = "startTime")]
        [DataMember(Name = "startTime")]
        public DateTime? StartTime { get; set; }

        [XmlElement(ElementName = "startTimeEstimated")]
        [DataMember(Name = "startTimeEstimated")]
        public Boolean StartTimeEstimated { get; set; }

        [XmlElement(ElementName = "endTime")]
        [DataMember(Name = "endTime")]
        public DateTime? EndTime { get; set; }

        [XmlElement(ElementName = "endTimeEstimated")]
        [DataMember(Name = "endTimeEstimated")]
        public Boolean EndTimeEstimated { get; set; }

        [XmlElement(ElementName = "legTime")]
        [DataMember(Name = "legTime")]
        public string LegTime { get; set; }

        [XmlElement(ElementName = "legMap")]
        [DataMember(Name = "legMap")]
        public string LegMap { get; set; }
    }
}
