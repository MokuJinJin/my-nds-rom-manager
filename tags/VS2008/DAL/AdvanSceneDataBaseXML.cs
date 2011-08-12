//-----------------------------------------------------------------------
// <copyright file="AdvanSceneDataBaseXML.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Data Access Layer to AdvanScene XML DataBase
    /// </summary>
    public static class AdvanSceneDataBaseXML
    {
        /// <summary>
        /// XML Reader
        /// </summary>
        private static XmlReader xmlread;

        /// <summary>
        /// Xml Document
        /// </summary>
        private static XmlDocument xdoc;

        /// <summary>
        /// Constructor
        /// </summary>
        static AdvanSceneDataBaseXML()
        {
            Collection = new List<NDS_Rom>();
            AdvanSceneDataBase = new List<NDS_Rom>();
        }

        /// <summary>
        /// Version of AdvanScene XML
        /// </summary>
        public static string DatVersion { get; private set; }

        /// <summary>
        /// List of Rom collection
        /// </summary>
        public static List<NDS_Rom> Collection { get; private set; }

        /// <summary>
        /// List of AdvanScene Rom
        /// </summary>
        public static List<NDS_Rom> AdvanSceneDataBase { get; private set; }

        /// <summary>
        /// List of missing collection rom
        /// </summary>
        public static List<NDS_Rom> CollectionMissing
        {
            get
            {
                return AdvanSceneDataBase.Except(Collection).ToList();
            }
        }

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
        public static void Load(string startupPath)
        {
            if (NDSDirectories.StartupPath == null)
            {
                NDSDirectories.SetStartupPath(startupPath);
            }

            Collection = new List<NDS_Rom>();
            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            using (StreamReader rd = new StreamReader(NDSDirectories.PathXmlHaveDB))
            {
                Collection = xs.Deserialize(rd) as List<NDS_Rom>;
            }

            URLs = new Dictionary<string, string>();
            DatCreationDate = new FileInfo(NDSDirectories.PathXmlDB).LastWriteTime.ToLongDateString();
            xmlread = XmlReader.Create(NDSDirectories.PathXmlDB);
            xdoc = new XmlDocument();
            xdoc.Load(xmlread);
            LoadConfiguration();
            LoadDatasource();
            xmlread.Close();
        }

        public static void Reload()
        {
            Load(NDSDirectories.StartupPath);
        }

        /// <summary>
        /// Load information in AdvanScene xml
        /// </summary>
        private static void LoadConfiguration()
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
        private static void LoadDatasource()
        {
            XmlNode xnd = xdoc.ChildNodes[1].ChildNodes[1];
            ////DataBase = new DataTable();
            ////InitialiseDataTable();
            AdvanSceneDataBase.Clear();

            foreach (XmlNode xndd in xnd.ChildNodes)
            {
                ChargeRomInfo(xndd);
            }
        }

        /// <summary>
        /// Load Informations about rom from AdvanScene xml
        /// </summary>
        /// <param name="xnd">XmlNode form AdvanScene xml</param>
        private static void ChargeRomInfo(XmlNode xnd)
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

            AdvanSceneDataBase.Add(rom);
        }

        /// <summary>
        /// Search trough AdvanScene database for a crc
        /// </summary>
        /// <param name="crc">Searched rom CRC32</param>
        /// <returns>Founded NDS Rom or null</returns>
        public static NDS_Rom FindCRCDataBase(string crc)
        {
            List<NDS_Rom> roms =
                (from rom in AdvanSceneDataBase
                 where rom.RomCRC == crc
                 select rom).ToList();
            switch (roms.Count)
            {
                case 1:
                    return roms[0];
                case 0:
                default:
                    return null;
            }
        }

        /// <summary>
        /// Close Xml Reader
        /// </summary>
        internal static void Dispose()
        {
            xmlread.Close();
        }

        /// <summary>
        /// Check if a rom crc is in collection
        /// </summary>
        /// <param name="crc">Rom CRC32</param>
        /// <returns>true if founded, false otherwise</returns>
        public static bool IsCRCInCollection(string crc)
        {
            List<NDS_Rom> roms =
                (from rom in Collection
                 where rom.RomCRC == crc
                 select rom).ToList();
            switch (roms.Count)
            {
                case 1:
                    return true;
                case 0:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Search for a rom in Collection and get it
        /// </summary>
        /// <param name="romNumber">Searched Rom Number</param>
        /// <returns>Founded NDS Rom, null otherwise</returns>
        public static NDS_Rom GetCollectionRom(string romNumber)
        {
            List<NDS_Rom> roms =
                (from rom in Collection
                 where rom.RomNumber == romNumber
                 select rom).ToList();
            switch (roms.Count)
            {
                case 1:
                    return roms[0];
                case 0:
                    return null;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Check if Rom is in Collection
        /// </summary>
        /// <param name="romNumber">Searched Rom Number</param>
        /// <returns>True if founded, false otherwise</returns>
        public static bool IsRomNumberInCollection(string romNumber)
        {
            List<NDS_Rom> roms =
                (from rom in Collection
                 where rom.RomNumber == romNumber
                 select rom).ToList();
            switch (roms.Count)
            {
                case 1:
                    return true;
                case 0:
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Write XML Collection
        /// </summary>
        public static void SaveCollectionXML()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (StreamWriter wr = new StreamWriter(NDSDirectories.PathXmlHaveDB))
            {
                xs.Serialize(wr, Collection, ns);
            }
        }

        public static void RepairCollection()
        {
            foreach (NDS_Rom rom in Collection)
            {
                NDS_Rom romDB = FindCRCDataBase(rom.RomCRC);
                if (romDB != null)
                {
                    rom.languageString = romDB.languageString;
                    rom.languageCode = romDB.languageCode;
                }
            }
            SaveCollectionXML();
        }

        #region Filtres
        public static List<NDS_Rom> DataBaseFiltreParTitre(string titre, EnumBase dataBase)
        {
            List<NDS_Rom> Base = getDataBase(dataBase);
            List<NDS_Rom> roms =
                (from rom in Base
                 where rom.title.ToLower().Contains(titre.ToLower())
                 select rom).ToList();
            return roms;
        }
        public static List<NDS_Rom> DataBaseFiltreParLangue(int languageCode,EnumBase dataBase)
        {
            List<NDS_Rom> Base = getDataBase(dataBase);
            List<NDS_Rom> roms =
                (from rom in Base
                 where rom.languageCode.Contains(languageCode)
                 select rom).ToList();
            return roms;
        }
        private static List<NDS_Rom> getDataBase(EnumBase dataBase)
        {
            List<NDS_Rom> Base = new List<NDS_Rom>();
            switch (dataBase)
            {
                case EnumBase.AdvanScene:
                    Base = AdvanSceneDataBase;
                    break;
                case EnumBase.Collection:
                    Base = Collection;
                    break;
                case EnumBase.CollectionMissing:
                    Base = CollectionMissing;
                    break;
            }
            return Base;
        }
        #endregion
    }
}
