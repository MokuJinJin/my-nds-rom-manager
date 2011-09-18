//-----------------------------------------------------------------------
// <copyright file="Translate.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace Utils.Culture
{
    using System.Xml.Serialization;
    
    /// <summary>
    /// Translation
    /// </summary>
    public class Translate
    {
        /// <summary>
        /// Translation's Name
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Translation's Value
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }
    }
}
