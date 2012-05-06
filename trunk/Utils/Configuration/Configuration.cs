//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace Utils.Configuration
{
    using System.Globalization;
    using System.Xml.Serialization;

    /// <summary>
    /// Application's configuration
    /// </summary>
    [XmlRoot("configuration")]
    public class Configuration
    {
        #region Fields
        /// <summary>
        /// Culture for MultiLanguage
        /// </summary>
        private CultureInfo _culture = new CultureInfo("en");

        /// <summary>
        /// Used to manipulate directory during serialisation
        /// </summary>
        private bool _serializationOntheWay = false;
        #endregion

        /// <summary>
        /// Used to manipulate directory during serialisation
        /// </summary>
        [XmlIgnore]
        public bool SerializationOntheWay
        {
            get
            {
                return _serializationOntheWay;
            }

            set
            {
                _serializationOntheWay = value;
            }
        }

        /// <summary>
        /// All Application's Path
        /// </summary>
        [XmlElement("Path")]
        public Paths Paths { get; set; }

        /// <summary>
        /// Culture string used in Xml
        /// </summary>
        [XmlElement("Culture")]
        public string CultureString
        {
            get
            {
                return Culture.Name;
            }

            set
            {
                _culture = new CultureInfo(value);
            }
        }

        /// <summary>
        /// Culture for MultiLanguage
        /// </summary>
        [XmlIgnore]
        public CultureInfo Culture 
        { 
            get 
            { 
                return _culture; 
            } 
        }
    }
}
