//-----------------------------------------------------------------------
// <copyright file="Parameter.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace Utils.Configuration
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Utils.Culture;
    
    /// <summary>
    /// Applications's Parameter 
    /// </summary>
    public static class Parameter
    {
        /// <summary>
        /// Application's configuration
        /// </summary>
        public static Configuration Config { get; private set; }

        /// <summary>
        /// Actual Language
        /// </summary>
        public static Language Lang { get; private set; }

        /// <summary>
        /// Default Language (en)
        /// </summary>
        public static Language DefaultLang { get; private set; }

        /// <summary>
        /// Application's Startup Path
        /// </summary>
        public static string StartupPath { get; private set; }

        /// <summary>
        /// Initialize All Parameters by reading NDScrc_III.xml
        /// </summary>
        /// <param name="path">Full Path to NDScrc_III.xml</param>
        public static void Initializer(string path)
        {
            StartupPath = path;

            Config = new Configuration();
            XmlSerializer xs = new XmlSerializer(typeof(Configuration));
            using (StreamReader rd = new StreamReader(string.Format("{0}\\data\\xml\\NDScrc_III.xml", StartupPath)))
            {
                Config = xs.Deserialize(rd) as Configuration;
            }

            xs = new XmlSerializer(typeof(Language));
            byte[] b = Encoding.UTF8.GetBytes(Utils.Properties.Resources.en);
            MemoryStream m = new MemoryStream(b);
            using (StreamReader rd = new StreamReader(m))
            {
                DefaultLang = xs.Deserialize(rd) as Language;
            }

            xs = new XmlSerializer(typeof(Language));
            string filePath = string.Format("{0}{1}.xml", Config.Paths.DirLanguage, Config.CultureString);
            if (File.Exists(filePath))
            {
                using (StreamReader rd = new StreamReader(filePath))
                {
                    Lang = xs.Deserialize(rd) as Language;
                }
            }
            else
            {
                Lang = DefaultLang;
            }
        }

        /// <summary>
        /// Save Configuration and Write the XML
        /// </summary>
        public static void SaveConfiguration()
        {
            Config.SerializationOntheWay = true;
            XmlSerializer xs = new XmlSerializer(typeof(Configuration));
            using (StreamWriter wr = new StreamWriter(string.Format("{0}\\data\\xml\\NDScrc_III.xml", StartupPath)))
            {
                xs.Serialize(wr, Config);
            }

            Config.SerializationOntheWay = false;
        }
    }
}
