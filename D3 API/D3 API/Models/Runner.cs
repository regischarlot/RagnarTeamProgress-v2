using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace D3_API.Models
{
    public enum TeType { Runner, Driver }

    [Serializable]
    [XmlRoot("runner")]
    [DataContract]
    public class TcRunner
    {
        [XmlElement(ElementName = "id")]
        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [XmlElement(ElementName = "name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "displayName")]
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [XmlElement(ElementName = "pace")]
        [DataMember(Name = "pace")]
        public Double Pace { get; set; }

        [XmlElement(ElementName = "cell")]
        [DataMember(Name = "cell")]
        public string Cell { get; set; }

        [XmlElement(ElementName = "email")]
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "emergencyContact")]
        [DataMember(Name = "emergencyContact")]
        public string EmergencyContact { get; set; }

        [XmlElement(ElementName = "type")]
        [DataMember(Name = "type")]
        public TeType Type { get; set; }

        [XmlIgnore]
        public TcEnvironment Environment;

        /// <summary>
        ///     Constructor()
        /// 
        /// </summary>
        public TcRunner()
        {
        }

        /// <summary>
        ///     Constructor()
        /// 
        /// </summary>
        /// <param name="environment"></param>
        public TcRunner(TcEnvironment environment)
        {
            Environment = environment;
        }

        /// <summary>
        ///     Create()
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Create()
        {
            try
            {
                using (SqlConnection conn = Environment.dbConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("insert into [Ragnar].[dbo].[Runner] " +
                                                           "([Name], [DisplayName], [Pace], [Cell], [Email], [EmergencyContact], [Type]) " +
                                                           "OUTPUT INSERTED.[RunnerID] " +
                                                           "values " +
                                                           "(@Name, @DisplayName, @Pace, @Cell, @Email, @EmergencyContact, @type) ", conn))
                    {
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                        cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = DisplayName;
                        cmd.Parameters.Add("@Pace", SqlDbType.Float).Value = Pace;
                        cmd.Parameters.Add("@Cell", SqlDbType.NVarChar).Value = Cell;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                        cmd.Parameters.Add("@EmergencyContact", SqlDbType.NVarChar).Value = EmergencyContact;
                        cmd.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                        Id = (int)cmd.ExecuteScalar();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///     Update()
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Update()
        {
            try
            {
                using (SqlConnection conn = Environment.dbConnection())
                {
                    using (SqlCommand qry = new SqlCommand("update " +
                                                           "    [Ragnar].[dbo].[Runner] " +
                                                           "set " +
                                                           "    Name = @Name, " +
                                                           "    DisplayName = @DisplayName, " +
                                                           "    Pace = @Pace, " +
                                                           "    Cell = @Cell, " +
                                                           "    Email = @Email, " +
                                                           "    EmergencyContact = @EmergencyContact, " +
                                                           "    Type = @type " +
                                                           "where " +
                                                           "    RunnerID = @RunnerID", conn))
                    {
                        qry.Parameters.Add("@RunnerID", SqlDbType.Int).Value = Id;
                        qry.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
                        qry.Parameters.Add("@DisplayName", SqlDbType.NVarChar).Value = DisplayName;
                        qry.Parameters.Add("@Pace", SqlDbType.Float).Value = Pace;
                        qry.Parameters.Add("@Cell", SqlDbType.NVarChar).Value = Cell;
                        qry.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                        qry.Parameters.Add("@EmergencyContact", SqlDbType.NVarChar).Value = EmergencyContact;
                        qry.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                        qry.ExecuteNonQuery();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}