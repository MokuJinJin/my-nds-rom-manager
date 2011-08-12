//-----------------------------------------------------------------------
// <copyright file="DAL.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2011
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;

    public static partial class DataAcessLayer
    {
        static DataAcessLayer()
        {
            _NdsCollection = new NDSCollection();
            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            using (StreamReader rd = new StreamReader(NDSDirectories.PathXmlHaveDB))
            {
                _NdsCollection.DataBase = xs.Deserialize(rd) as List<NDS_Rom>;
            }

            _NdsAdvanScene = new NDSAdvanScene();
            // NdsCollectionMissing = _NdsAdvanScene.DataBase.Except(_NdsCollection.DataBase).ToList();
        }

        /// <summary>
        /// Nds Rom Collection
        /// </summary>
        public static List<NDS_Rom> NdsCollection
        {
            get
            {
                return _NdsCollection.DataBase;
            }
        }

        /// <summary>
        /// Nds Rom AdvanScene
        /// </summary>
        public static List<NDS_Rom> NdsAdvanScene
        {
            get
            {
                return _NdsAdvanScene.DataBase;
            }
        }

        /// <summary>
        /// AdvanScene DatVersion
        /// </summary>
        public static string DatVersion
        {
            get
            {
                return _NdsAdvanScene.DatVersion;
            }
        }

        /// <summary>
        /// List of Rom collection
        /// </summary>
        private static NDSCollection _NdsCollection;

        /// <summary>
        /// Advanscene DataBase
        /// </summary>
        private static NDSAdvanScene _NdsAdvanScene;

        /// <summary>
        /// List of missing collection rom
        /// </summary>
        public static List<NDS_Rom> NdsCollectionMissing
        {
            get
            {
                return _NdsAdvanScene.DataBase.Except(_NdsCollection.DataBase).ToList();
            }
        }

        /// <summary>
        /// Search trough AdvanScene database for a crc
        /// </summary>
        /// <param name="crc">Searched rom CRC32</param>
        /// <returns>Founded NDS Rom or null</returns>
        public static NDS_Rom FindCRCDataBase(string crc)
        {
            return FindCRC(crc, _NdsAdvanScene.DataBase);
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
                    rom.RomCRC == crc
                ).ToList();
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
            if (FindCRC(crc, _NdsCollection.DataBase) != null)
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
            return GetRomByRomNumber(romNumber, _NdsCollection.DataBase);
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
                    rom.RomNumber == romNumber
                ).ToList();
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
            if (GetRomByRomNumber(romNumber, _NdsCollection.DataBase) != null)
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
                xs.Serialize(wr, _NdsCollection.DataBase);
            }
        }

        /// <summary>
        /// Recalculate the collection and write it
        /// </summary>
        public static void RepairCollection()
        {
            foreach (NDS_Rom rom in _NdsCollection.DataBase)
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
                    rom.title.ToLower().Contains(titre.ToLower())
                ).ToList();
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
                    rom.languageCode.Contains(languageCode)
                ).ToList();

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
                    database = _NdsAdvanScene.DataBase;
                    break;
                case EnumBase.Collection:
                    database = _NdsCollection.DataBase;
                    break;
                case EnumBase.CollectionMissing:
                    database = NdsCollectionMissing;
                    break;
            }

            return database;
        }
        #endregion

        public static void NdsAdvanSceneReload()
        {
            _NdsAdvanScene.Reload();
        }
    }
}
