using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace D3_API.Models
{
    [Serializable]
    [XmlRoot("environment")]
    [DataContract]
    public class TcEnvironment
    {
        #region Public Members
        [XmlIgnore]
        public int Team = 1;

        [XmlAttribute(AttributeName = "transactionalStore")]
        [DataMember(Name = "transactionalStore")]
        public string TransactionalStore { get; set; }
        #endregion

        /// <summary>
        ///     TcEnvironment()
        /// 
        /// </summary>
        public TcEnvironment()
        {
            // General
            TransactionalStore = ConfigurationManager.AppSettings["Transactional Store"];
        }

        /// <summary>
        ///     TcEnvironment()
        /// 
        /// </summary>
        /// <param name="transactionalStore"></param>
        public TcEnvironment(string transactionalStore)
        {
            TransactionalStore = transactionalStore;
        }

        public SqlConnection dbConnection()
        {
            SqlConnection conn = new SqlConnection(TransactionalStore);
            conn.Open();
            return conn;
        } 
    }
}

