//-----------------------------------------------------------------------
// <copyright file="NDSAdvanScene.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Data Access Layer to AdvanScene XML DataBase
    /// </summary>
    public class NDSAdvanScene
    {
        /// <summary>
        /// XML Reader
        /// </summary>
        private XmlReader xmlread;

        /// <summary>
        /// Xml Document
        /// </summary>
        private XmlDocument xdoc;

        /// <summary>
        /// Constructor
        /// </summary>
        public NDSAdvanScene()
        {
            DataBase = new List<NDS_Rom>();
            Load();
        }

        /// <summary>
        /// Version of AdvanScene XML
        /// </summary>
        public string DatVersion { get; private set; }

        /// <summary>
        /// List of AdvanScene Rom
        /// </summary>
        public List<NDS_Rom> DataBase { get; private set; }

        /// <summary>
        /// Urls in AdvanScene Xml
        /// </summary>
        public static Dictionary<string, string> URLs { get; private set; }

        /// <summary>
        /// AdvanScene xml creation date
        /// </summary>
        public static string DatCreationDate { get; private set; }

        /// <summary>
        /// Load Listing of roms
        /// </summary>
        /// <param name="startupPath">Application Startup Path</param>
        public void Load()
        {
            URLs = new Dictionary<string, string>();
            DatCreationDate = new FileInfo(NDSDirectories.PathXmlDB).LastWriteTime.ToLongDateString();
            xmlread = XmlReader.Create(NDSDirectories.PathXmlDB);
            xdoc = new XmlDocument();
            xdoc.Load(xmlread);
            LoadConfiguration();
            LoadDatasource();
            xmlread.Close();
        }

        /// <summary>
        /// Reload the Class
        /// </summary>
        public void Reload()
        {
            Load();
        }

        /// <summary>
        /// Load information in AdvanScene xml
        /// </summary>
        private void LoadConfiguration()
        {
            XmlNode xnd = xdoc.ChildNodes[1].ChildNodes[0];
            foreach (XmlNode xndd in xnd.ChildNodes)
            {
                switch (xndd.Name)
                {
                    case "datVersion":
                        DatVersion = xndd.InnerText;
                        break;
                    case "newDat":
                        LoadURL(xndd);
                        break;
                }
            }
        }

        /// <summary>
        /// Load Urls in AdvanScene xml
        /// </summary>
        /// <param name="xnd">Xml Node</param>
        private static void LoadURL(XmlNode xnd)
        {
            foreach (XmlNode xndd in xnd.ChildNodes)
            {
                URLs.Add(xndd.Name, xndd.InnerText);
                if (xndd.Name == "datURL")
                {
                    foreach (XmlAttribute xat in xndd.Attributes)
                    {
                        URLs.Add("datFileName", xat.InnerText);
                    }
                }
            }
        }

        /// <summary>
        /// Load AdvanScene Database
        /// </summary>
        private void LoadDatasource()
        {
            XmlNode xnd = xdoc.ChildNodes[1].ChildNodes[1];
            ////DataBase = new DataTable();
            ////InitialiseDataTable();
            DataBase.Clear();

            //XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            //using (StreamReader rd = new StreamReader())
            //{
            //    AdvanSceneDataBase = xs.Deserialize(rd) as List<NDS_Rom>;
            //}

            foreach (XmlNode xndd in xnd.ChildNodes)
            {
                ChargeRomInfo(xndd);
            }
        }

        /// <summary>
        /// Load Informations about rom from AdvanScene xml
        /// </summary>
        /// <param name="xnd">XmlNode form AdvanScene xml</param>
        private void ChargeRomInfo(XmlNode xnd)
        {
            NDS_Rom rom = new NDS_Rom();
            foreach (XmlNode xndd in xnd.ChildNodes)
            {
                switch (xndd.Name)
                {
                    case "imageNumber":
                        rom.imageNumber = xndd.InnerText;
                        if (int.Parse(xndd.InnerText) < 1000)
                        {
                            rom.imageNumber = "0" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 100)
                        {
                            rom.imageNumber = "00" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 10)
                        {
                            rom.imageNumber = "000" + xndd.InnerText;
                        }

                        break;
                    case "releaseNumber":
                        rom.releaseNumber = xndd.InnerText;
                        if (int.Parse(xndd.InnerText) < 1000)
                        {
                            rom.releaseNumber = "0" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 100)
                        {
                            rom.releaseNumber = "00" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 10)
                        {
                            rom.releaseNumber = "000" + xndd.InnerText;
                        }

                        break;
                    case "title":
                        rom.title = xndd.InnerText;
                        break;
                    case "saveType":
                        rom.saveType = xndd.InnerText;
                        break;
                    case "romSize":
                        rom.romSize = (int.Parse(xndd.InnerText) / 1024 / 1024).ToString() + " Mo";
                        break;
                    case "publisher":
                        rom.publisher = xndd.InnerText;
                        break;
                    case "location":
                        rom.location = LocationXML.getStringLocation(int.Parse(xndd.InnerText));
                        break;
                    case "sourceRom":
                        rom.sourceRom = xndd.InnerText;
                        break;
                    case "language":
                        rom.languageString = LanguageXML.getLanguage(int.Parse(xndd.InnerText));
                        rom.languageCode = LanguageXML.getLanguagesList(int.Parse(xndd.InnerText));
                        break;
                    case "files":
                        rom.RomCRC = xndd.ChildNodes[0].InnerText;
                        break;
                    case "im1CRC":
                        rom.ImgCoverCRC = xndd.InnerText;
                        break;
                    case "im2CRC":
                        rom.ImgInGameCRC = xndd.InnerText;
                        break;
                    case "nfoCRC":
                        rom.NfoCRC = xndd.InnerText;
                        break;
                    case "icoCRC":
                        rom.IcoCRC = xndd.InnerText;
                        break;
                    case "genre":
                        rom.Genre = xndd.InnerText;
                        break;
                    case "dumpdate":
                        rom.DumpDate = xndd.InnerText;
                        break;
                    case "internalname":
                        rom.InternalName = xndd.InnerText;
                        break;
                    case "serial":
                        rom.Serial = xndd.InnerText;
                        break;
                    case "version":
                        rom.Version = xndd.InnerText;
                        break;
                    case "wifi":
                        switch (xndd.InnerText)
                        {
                            case "No":
                                rom.Wifi = false;
                                break;
                            case "Yes":
                                rom.Wifi = true;
                                break;
                            default:
                                break;
                        }

                        break;
                    case "comment":
                        rom.RomNumber = xndd.InnerText;
                        break;
                    case "duplicateid":
                        if (xndd.InnerText == "0")
                        {
                            rom.DuplicateID = 0;
                        }
                        else
                        {
                            rom.DuplicateID = int.Parse(xndd.InnerText);
                        }

                        break;
                }
            }

            DataBase.Add(rom);
        }

        
        /// <summary>
        /// Close Xml Reader
        /// </summary>
        internal void Dispose()
        {
            xmlread.Close();
        }
    }
}
