//-----------------------------------------------------------------------
// <copyright file="Language.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace Utils.Culture
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    using Utils.Configuration;

    /// <summary>
    /// Multi Language
    /// </summary>
    [XmlRoot("Language")]
    public class Language
    {
        /// <summary>
        /// Name of the Language
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// List of translation
        /// </summary>
        [XmlArray("translate")]
        [XmlArrayItem("data")]
        public List<Translate> Translate { get; set; }

        /// <summary>
        /// Get a translation
        /// </summary>
        /// <param name="name">What is to translate</param>
        /// <returns>Translation if found, default language otherwise</returns>
        public string GetTranslate(string name)
        {
            string retour = string.Empty;
            try
            {
                retour = Translate.Single(t => t.Name == name).Value;
            }
            catch (System.Exception)
            {
                retour = Parameter.DefaultLang.Translate.Single(t => t.Name == name).Value;
            }

            return retour;
        }
    }
}
