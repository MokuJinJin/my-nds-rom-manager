//-----------------------------------------------------------------------
// <copyright file="DAL.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2011
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.DAL
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using NdsCRC_III.TO;
    using Utils;

    /// <summary>
    /// Data Access Layer
    /// </summary>
    public static class DataAcessLayer
    {
        /// <summary>
        /// List of Rom collection
        /// </summary>
        private static NDSCollection _ndsCollection;

        /// <summary>
        /// Advanscene DataBase
        /// </summary>
        private static NDSAdvanScene _ndsAdvanScene;

        /// <summary>
        /// Constructor for DataAcessLayer
        /// </summary>
        static DataAcessLayer()
        {
            _ndsCollection = new NDSCollection();
            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            using (StreamReader rd = new StreamReader(NDSDirectories.PathXmlHaveDB))
            {
                _ndsCollection.DataBase = xs.Deserialize(rd) as List<NDS_Rom>;
            }

            // NdsCollectionMissing = _NdsAdvanScene.DataBase.Except(_NdsCollection.DataBase).ToList();
            _ndsAdvanScene = new NDSAdvanScene();
        }

        /// <summary>
        /// Nds Rom Collection
        /// </summary>
        public static List<NDS_Rom> NdsCollection
        {
            get
            {
                return _ndsCollection.DataBase;
            }
        }

        /// <summary>
        /// Nds Rom AdvanScene
        /// </summary>
        public static List<NDS_Rom> NdsAdvanScene
        {
            get
            {
                return _ndsAdvanScene.DataBase;
            }
        }

        /// <summary>
        /// AdvanScene DatVersion
        /// </summary>
        public static string DatVersion
        {
            get
            {
                return _ndsAdvanScene.DatVersion;
            }
        }

        /// <summary>
        /// AdvanScene xml creation date
        /// </summary>
        public static string DatCreationDate
        {
            get
            {
                return _ndsAdvanScene.DatCreationDate;
            }
        }

        /// <summary>
        /// Urls in AdvanScene Xml
        /// </summary>
        public static Dictionary<string, string> URLs
        {
            get
            {
                return _ndsAdvanScene.URLs;
            }
        }

        /// <summary>
        /// List of missing collection rom
        /// </summary>
        public static List<NDS_Rom> NdsCollectionMissing
        {
            get
            {
                IEqualityComparer<NDS_Rom> cmp = new LambdaComparer<NDS_Rom>((x, y) => x.ReleaseNumber == y.ReleaseNumber);
                return _ndsAdvanScene.DataBase.Except(_ndsCollection.DataBase, cmp).ToList();
            }
        }

        /// <summary>
        /// Search trough AdvanScene database for a crc
        /// </summary>
        /// <param name="crc">Searched rom CRC32</param>
        /// <returns>Founded NDS Rom or null</returns>
        public static NDS_Rom FindCRCDataBase(string crc)
        {
            return FindCRC(crc, _ndsAdvanScene.DataBase);
        }

        /// <summary>
        /// Search in a dataBase for a crc
        /// </summary>
        /// <param name="crc">Searched rom CRC32</param>
        /// <param name="dataBase">A dataBase</param>
        /// <returns>Founded NDS Rom or null</returns>
        private static NDS_Rom FindCRC(string crc, List<NDS_Rom> dataBase)
        {
            List<NDS_Rom> roms = dataBase.Where(
                rom =>
                    rom.RomCRC == crc).ToList();
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
        /// Check if a rom crc is in collection
        /// </summary>
        /// <param name="crc">Rom CRC32</param>
        /// <returns>true if founded, false otherwise</returns>
        public static bool IsCRCInCollection(string crc)
        {
            if (FindCRC(crc, _ndsCollection.DataBase) != null)
            {
                return true;
            }
            else
            {
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
            return GetRomByRomNumber(romNumber, _ndsCollection.DataBase);
        }

        /// <summary>
        /// Search for a rom by RomNumber
        /// </summary>
        /// <param name="romNumber">RomNumber searched</param>
        /// <param name="dataBase">a DataBase</param>
        /// <returns>Founded NDS Rom, null otherwise</returns>
        private static NDS_Rom GetRomByRomNumber(string romNumber, List<NDS_Rom> dataBase)
        {
            List<NDS_Rom> roms = dataBase.Where(
                rom =>
                    rom.RomNumber == romNumber).ToList();
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
        /// Check if Rom is in Collection
        /// </summary>
        /// <param name="romNumber">Searched Rom Number</param>
        /// <returns>True if founded, false otherwise</returns>
        public static bool IsRomNumberInCollection(string romNumber)
        {
            if (GetRomByRomNumber(romNumber, _ndsCollection.DataBase) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Write XML Collection
        /// </summary>
        public static void SaveCollectionXML()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            using (StreamWriter wr = new StreamWriter(NDSDirectories.PathXmlHaveDB))
            {
                xs.Serialize(wr, _ndsCollection.DataBase);
            }
        }

        /// <summary>
        /// Recalculate the collection and write it
        /// </summary>
        public static void RepairCollection()
        {
            // foreach (NDS_Rom rom in _ndsCollection.DataBase)
            for (int i = 0; i < _ndsCollection.DataBase.Count; i++)
            {
                NDS_Rom romDB = FindCRCDataBase(_ndsCollection.DataBase[i].RomCRC);
                if (romDB != null)
                {
                    _ndsCollection.DataBase[i] = romDB;
                }
            }

            SaveCollectionXML();
        }

        #region Filtres

        /// <summary>
        /// Filter a database with the title
        /// </summary>
        /// <param name="titre">the title</param>
        /// <param name="dataBase">the database</param>
        /// <returns>DataBase filtered</returns>
        public static List<NDS_Rom> DataBaseFiltreParTitre(string titre, EnumBase dataBase)
        {
            List<NDS_Rom> database = GetDataBase(dataBase);
            List<NDS_Rom> roms = database.Where(
                rom =>
                    rom.Title.ToLower().Contains(titre.ToLower())).ToList();
            return roms;
        }

        /// <summary>
        /// Get database filtered by single language
        /// </summary>
        /// <param name="languageCode">language's code</param>
        /// <param name="dataBase">the database</param>
        /// <returns>filtered database</returns>
        public static List<NDS_Rom> DataBaseFiltreParLangue(int languageCode, EnumBase dataBase)
        {
            List<NDS_Rom> database = GetDataBase(dataBase);
            List<NDS_Rom> roms = database.Where(
                rom =>
                    rom.LanguageCode.Contains(languageCode)).ToList();

            return roms;
        }

        /// <summary>
        /// Get specific dataBase
        /// </summary>
        /// <param name="dataBase">Wich dataBase</param>
        /// <returns>The database you ask for</returns>
        private static List<NDS_Rom> GetDataBase(EnumBase dataBase)
        {
            List<NDS_Rom> database = new List<NDS_Rom>();
            switch (dataBase)
            {
                case EnumBase.AdvanScene:
                    database = _ndsAdvanScene.DataBase;
                    break;
                case EnumBase.Collection:
                    database = _ndsCollection.DataBase;
                    break;
                case EnumBase.CollectionMissing:
                    database = NdsCollectionMissing;
                    break;
            }

            return database;
        }
        #endregion

        /// <summary>
        /// Reload the Advnascene DataBase
        /// </summary>
        public static void NdsAdvanSceneReload()
        {
            _ndsAdvanScene.Reload();
        }
    }
}
