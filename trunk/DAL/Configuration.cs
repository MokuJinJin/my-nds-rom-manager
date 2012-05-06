//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.DAL
{
    using System.Xml.Serialization;

    /// <summary>
    /// Application's Configuration 
    /// </summary>
    [XmlRoot("configuration")]
    public class Configuration
    {
        /// <summary>
        /// Paths for the application
        /// </summary>
        [XmlElement("Path")]
        public ApplicationPath Paths { get; set; }
    }

    /// <summary>
    /// Application's Paths
    /// </summary>
    [XmlRoot("Path")]
    public class ApplicationPath
    {
        /// <summary>
        /// Image Path
        /// </summary>
        [XmlElement("img")]
        public string Img { get; set; }

        /// <summary>
        /// NFO Path
        /// </summary>
        [XmlElement("nfo")]
        public string Nfo { get; set; }

        /// <summary>
        /// NDS Roms Path
        /// </summary>
        [XmlElement("rom")]
        public string NDSRoms { get; set; }

        /// <summary>
        /// Trash Path
        /// </summary>
        [XmlElement("trash")]
        public string Trash { get; set; }

        /// <summary>
        /// Temp Path
        /// </summary>
        [XmlElement("temp")]
        public string Temp { get; set; }

        /// <summary>
        /// New Rom Path
        /// </summary>
        [XmlElement("newrom")]
        public string NewRom { get; set; }

        /// <summary>
        /// Unknown Rom Path
        /// </summary>
        [XmlElement("unknowrom")]
        public string UnknowRom { get; set; }

        /// <summary>
        /// Already Have Rom Path
        /// </summary>
        [XmlElement("AlreadyHave")]
        public string AlreadyHave { get; set; }

        /// <summary>
        /// Collection DataBase Path
        /// </summary>
        [XmlElement("HaveDB")]
        public string HaveDB { get; set; }

        /// <summary>
        /// DataBase Path
        /// </summary>
        [XmlElement("DB")]
        public string DB { get; set; }

        /// <summary>
        /// Flag's Image Path
        /// </summary>
        [XmlElement("Flags")]
        public string Flags { get; set; }
    }
}
