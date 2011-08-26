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
        public Dictionary<string, string> URLs { get; private set; }

        /// <summary>
        /// AdvanScene xml creation date
        /// </summary>
        public string DatCreationDate { get; private set; }

        /// <summary>
        /// Load Listing of roms
        /// </summary>
        /// <param name="path">Path of AdvanScene Xml Database</param>
        public void Load(string path)
        {
            URLs = new Dictionary<string, string>();
            DatCreationDate = new FileInfo(path).LastWriteTime.ToLongDateString();
            xmlread = XmlReader.Create(path);
            xdoc = new XmlDocument();
            xdoc.Load(xmlread);
            LoadConfiguration();
            LoadDatasource();
            xmlread.Close();
        }

        /// <summary>
        /// Load Listing of roms
        /// </summary>
        public void Load()
        {
            Load(NDSDirectories.PathXmlDB);
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
        private void LoadURL(XmlNode xnd)
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

            // DataBase = new DataTable();
            // InitialiseDataTable();
            DataBase.Clear();

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
                        rom.ImageNumber = xndd.InnerText;
                        if (int.Parse(xndd.InnerText) < 1000)
                        {
                            rom.ImageNumber = "0" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 100)
                        {
                            rom.ImageNumber = "00" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 10)
                        {
                            rom.ImageNumber = "000" + xndd.InnerText;
                        }

                        break;
                    case "releaseNumber":
                        rom.ReleaseNumber = xndd.InnerText;
                        if (int.Parse(xndd.InnerText) < 1000)
                        {
                            rom.ReleaseNumber = "0" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 100)
                        {
                            rom.ReleaseNumber = "00" + xndd.InnerText;
                        }

                        if (int.Parse(xndd.InnerText) < 10)
                        {
                            rom.ReleaseNumber = "000" + xndd.InnerText;
                        }

                        break;
                    case "title":
                        rom.Title = xndd.InnerText;
                        break;
                    case "saveType":
                        rom.SaveType = xndd.InnerText;
                        break;
                    case "romSize":
                        rom.RomSize = (int.Parse(xndd.InnerText) / 1024 / 1024).ToString() + " Mo";
                        break;
                    case "publisher":
                        rom.Publisher = xndd.InnerText;
                        break;
                    case "location":
                        rom.Location = LocationXML.GetStringLocation(int.Parse(xndd.InnerText));
                        break;
                    case "sourceRom":
                        rom.SourceRom = xndd.InnerText;
                        break;
                    case "language":
                        rom.LanguageString = LanguageXML.GetLanguage(int.Parse(xndd.InnerText));
                        rom.LanguageCode = LanguageXML.GetLanguagesList(int.Parse(xndd.InnerText));
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
