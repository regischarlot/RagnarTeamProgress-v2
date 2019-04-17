using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace D3_API.Models
{
    [Serializable]
    [XmlRoot("response")]
    [DataContract]
    public class TcResponse : IDisposable
    {
        #region Public Members
        [XmlAttribute(AttributeName = "success")]
        [DataMember(Name = "success")]
        public bool Success;

        [XmlAttribute(AttributeName = "elapsed")]
        [DataMember(Name = "elapsed")]
        public double Elapsed;

        [XmlAttribute(AttributeName = "error")]
        [DataMember(Name = "error")]
        public string Error;

        [XmlAttribute(AttributeName = "data")]
        [DataMember(Name = "data")]
        public object Data;
        #endregion

        #region Private Members
        private Stopwatch _watch;
        #endregion

        #region Public Methods
        /// <summary>
        ///     Dispose()
        /// 
        /// </summary>
        public void Dispose()
        {
        }
        #endregion

        #region Telemetry
        /// <summary>
        ///     TelemetryStart()
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public void TelemetryStart(string title, HttpRequestMessage requestMessage)
        {
            _watch = Stopwatch.StartNew();
        }

        /// <summary>
        ///     SetRequestTelemetryProperty()
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="value"></param>
        public void SetRequestTelemetryProperty(string title, string value)
        {
        }

        /// <summary>
        ///     TelemetryException()
        /// 
        /// </summary>
        public void TelemetryException(Exception e)
        {
        }

        /// <summary>
        ///     TelemetryStop()
        /// 
        /// </summary>
        public void TelemetryStop()
        {
            if (_watch != null)
            {
                _watch.Stop();
                Elapsed = _watch.Elapsed.TotalMilliseconds / 1000;
            }
        }
        #endregion
    }
}