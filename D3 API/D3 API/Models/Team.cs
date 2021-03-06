﻿using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace D3_API.Models
{
    [Serializable]
    [XmlRoot("team")]
    [DataContract]
    public class Team: IDisposable
    {
        [XmlElement(ElementName = "id")]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        public void Dispose()
        {
        }
    }
}

