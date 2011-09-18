//-----------------------------------------------------------------------
// <copyright file="NDS_Rom.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III.TO
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Xml.Serialization;
    using Utils.Configuration;
    using Utils.Directories;

    /// <summary>
    /// Class of NDS Rom
    /// </summary>
    [XmlRoot("NDS_Rom")]
    public class NDS_Rom
    {
        /// <summary>
        /// Constructor for NDS_Rom
        /// </summary>
        public NDS_Rom()
        {
            LanguageCode = new List<int>();
        }

        /// <summary>
        /// Number for Img
        /// </summary>
        public string ImageNumber { get; set; }

        /// <summary>
        /// Number of the release
        /// </summary>
        public string ReleaseNumber { get; set; }
        
        /// <summary>
        /// Rom's title
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Game's save type
        /// </summary>
        public string SaveType { get; set; }
        
        /// <summary>
        /// Rom's size
        /// </summary>
        public string RomSize { get; set; }
        
        /// <summary>
        /// Game's publisher
        /// </summary>
        public string Publisher { get; set; }
        
        /// <summary>
        /// Location's Integer
        /// </summary>
        /// <remarks>For the list of Location's integer see : DAL.LocationXML</remarks>
        public string Location { get; set; }

        /// <summary>
        /// Rom's Dumper
        /// </summary>
        public string SourceRom { get; set; }

        /// <summary>
        /// Language string for display, all language available
        /// </summary>
        public string LanguageString { get; set; }
        
        /// <summary>
        /// List of language integer : available language in the rom
        /// </summary>
        /// <remarks>For the list of Language's integer see : DAL.LanguageXML</remarks>
        public List<int> LanguageCode { get; set; }
        
        /// <summary>
        /// Rom's CRC32
        /// </summary>
        public string RomCRC { get; set; }
        
        /// <summary>
        /// Cover image CRC32
        /// </summary>
        public string ImgCoverCRC { get; set; }
        
        /// <summary>
        /// In game image CRC32
        /// </summary>
        public string ImgInGameCRC { get; set; }
        
        /// <summary>
        /// Icon CRC32
        /// </summary>
        public string IcoCRC { get; set; }
        
        /// <summary>
        /// NFO CRC32
        /// </summary>
        public string NfoCRC { get; set; }
        
        /// <summary>
        /// Genre Category
        /// </summary>
        public string Genre { get; set; }
        
        /// <summary>
        /// Date of the dump/release
        /// </summary>
        public string DumpDate { get; set; }
        
        /// <summary>
        /// Rom's Internal Name
        /// </summary>
        /// <remarks>Is it unique ?</remarks>
        public string InternalName { get; set; }
        
        /// <summary>
        /// Serial
        /// </summary>
        /// <remarks>Is it unique ?</remarks>
        public string Serial { get; set; }
        
        /// <summary>
        /// If multiple sales of the rom, it may have multiple version
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// If the game has the wifi
        /// </summary>
        public bool Wifi { get; set; }
        
        /// <summary>
        /// Rom's Number in Advanscene web display
        /// </summary>
        /// <remarks>Found it in the comment</remarks>
        public string RomNumber { get; set; }
        
        /// <summary>
        /// Duplicate ID, all rom which are location duplicate have de same Duplicate ID
        /// </summary>
        public int DuplicateID { get; set; }

        /// <summary>
        /// Cover Image path for the display
        /// </summary>
        public string ImgCoverPath
        {
            get
            {
                if (File.Exists(_coverImg))
                {
                    return _coverImg;
                }
                else
                {
                    /*
                    return string.Format(
                        "{0}defaulta.png",
                        NDSDirectories.PathImg);
                    */
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Cover image path
        /// </summary>
        private string _coverImg
        {
            get
            {
                return string.Format(
                                "{0}{1}a.png",
                                Parameter.Config.Paths.DirImage,
                                this.ImageNumber);
            }
        }

        /// <summary>
        /// In Game image for the display
        /// </summary>
        public string ImgInGamePath 
        {
            get
            {
                if (File.Exists(_inGameImg))
                {
                    return _inGameImg;
                }
                else
                {
                    return string.Format(
                        "{0}defaultb.png",
                        Parameter.Config.Paths.DirImage);
                }
            }
        }

        /// <summary>
        /// In Game image
        /// </summary>
        private string _inGameImg
        {
            get
            {
                return string.Format(
                            "{0}{1}b.png",
                            Parameter.Config.Paths.DirImage,
                            this.ImageNumber);
            }
        }
        
        /// <summary>
        /// Icon image for the display
        /// </summary>
        public string ImgIconPath 
        {
            get
            {
                if (File.Exists(_iconImg))
                {
                    return _iconImg;
                }
                else
                {
                    return string.Format(
                        "{0}default.png",
                        Parameter.Config.Paths.DirImage);
                }
            }
        }

        /// <summary>
        /// Icon image
        /// </summary>
        private string _iconImg
        {
            get
            {
                return string.Format(
                                "{0}{1}.png",
                                Parameter.Config.Paths.DirImage,
                                this.ImageNumber);
            }
        }

        /// <summary>
        /// Flag path for display
        /// </summary>
        public string FlagPath 
        {
            get
            {
                return string.Format("{0}{1}.png", Parameter.Config.Paths.DirImageFlag, this.Location);
            }
        }

        /// <summary>
        /// Nfo path for display
        /// </summary>
        public string NfoPath 
        {
            get
            {
                if (File.Exists(_nfoPath))
                {
                    return _nfoPath;
                }
                else
                {
                    return string.Format(
                        "{0}default.nfo",
                        Parameter.Config.Paths.DirNFO);
                }
            }
        }

        /// <summary>
        /// Nfo Path
        /// </summary>
        private string _nfoPath
        {
            get
            {
                return string.Format(
                                "{0}{1}.nfo",
                                Parameter.Config.Paths.DirNFO,
                                this.ReleaseNumber);
            }
        }

        /// <summary>
        /// Rom path
        /// </summary>
        public string RomPath 
        {
            get
            {
                string complementNomDemo = string.Empty;
                if (this.IsDemo())
                {
                    complementNomDemo = string.Format("({0})", this.Serial);
                }

                return string.Format(
                         "{0}{1}\\({2}) {3}{4}.7z",
                         Parameter.Config.Paths.DirNdsRom,
                         Directories.GetDirFromReleaseNumber(this.RomNumber),
                         this.RomNumber,
                         this.Title,
                         complementNomDemo);
            }
        }

        /// <summary>
        /// True if Rom file exist
        /// </summary>
        public bool RomExist 
        {
            get
            {
                return File.Exists(this.RomPath);
            }
        }

        /// <summary>
        /// Bitmap of the Icon
        /// </summary>
        public Image Icon
        {
            get
            {
                // TODO : why there is an InsufisantMemoryException ?
                Image i = null;
                try
                {
                    i = Bitmap.FromFile(this.ImgIconPath);
                }
                catch (System.Exception)
                {
                    // throw;
                }

                return i;
            }
        }

        /// <summary>
        /// Check if the rom has wifi
        /// </summary>
        /// <returns>True if Wifi is used in the game, false otherwise</returns>
        public bool IsWifi() 
        {
            return Wifi; 
        }

        /// <summary>
        /// Search if the Rom have a certain language by its code
        /// </summary>
        /// <param name="languageCode">Language Code integer</param>
        /// <returns>True if the rom have the language, false otherwise</returns>
        public bool IsLanguage(int languageCode)
        {
            return this.LanguageCode.Contains(languageCode);
        }

        /// <summary>
        /// Check if the rom is a demo
        /// </summary>
        /// <returns>True if the rom is a demo, false otherwise</returns>
        public bool IsDemo()
        {
            return this.RomNumber == "xxxx";
        }

        /// <summary>
        /// Check if all image are present
        /// </summary>
        /// <returns>True if all image are present, false otherwise</returns>
        public bool IsAllImagePresent()
        {
            return File.Exists(_coverImg) && File.Exists(_iconImg) && File.Exists(_inGameImg);
        }

        /// <summary>
        /// Check if a rom has a duplicate
        /// </summary>
        /// <returns>Ture if it has a duplicate, false otherwise</returns>
        public bool IsDuplicate()
        {
            if (DuplicateID.ToString() == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// External File name
        /// </summary>
        public string ExternalFileName { get; set; }

        /// <summary>
        /// External Dir name
        /// </summary>
        public string ExternalDirName { get; set; }
    }
}
