//-----------------------------------------------------------------------
// <copyright file="NDS_Rom.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Class of NDS Rom
    /// </summary>
    [XmlRoot("NDS_Rom")]
    public class NDS_Rom : IEquatable<NDS_Rom>
    {
        /// <summary>
        /// Constructor for NDS_Rom
        /// </summary>
        public NDS_Rom()
        {
            LanguageCode = new List<int>();
        }

        public string ImageNumber { get; set; }

        public string ReleaseNumber { get; set; }
        
        public string Title { get; set; }
        
        public string SaveType { get; set; }
        
        public string RomSize { get; set; }
        
        public string Publisher { get; set; }
        
        public string Location { get; set; }
        
        public string SourceRom { get; set; }
        
        public string LanguageString { get; set; }
        
        public List<int> LanguageCode { get; set; }
        
        public string RomCRC { get; set; }
        
        public string ImgCoverCRC { get; set; }
        
        public string ImgInGameCRC { get; set; }
        
        public string IcoCRC { get; set; }
        
        public string NfoCRC { get; set; }
        
        public string Genre { get; set; }
        
        public string DumpDate { get; set; }
        
        public string InternalName { get; set; }
        
        public string Serial { get; set; }
        
        public string Version { get; set; }
        
        public bool Wifi { get; set; }
        
        public string RomNumber { get; set; }
        
        public int DuplicateID { get; set; }

        [XmlIgnore]
        public string ImgCoverPath
        {
            get
            {
                string imgCover = string.Format(
                                "{0}{1}a.png",
                                NDSDirectories.PathImg,
                                this.ImageNumber);
                if (File.Exists(imgCover))
                {
                    return imgCover;
                }
                else
                {
                    return string.Format(
                        "{0}defaulta.png",
                        NDSDirectories.PathImg);
                }
            }
        }

        [XmlIgnore]
        public string ImgInGamePath 
        {
            get
            {
                string inGame = string.Format(
                            "{0}{1}b.png",
                            NDSDirectories.PathImg,
                            this.ImageNumber);
                if (File.Exists(inGame))
                {
                    return inGame;
                }
                else
                {
                    return string.Format(
                        "{0}defaultb.png",
                        NDSDirectories.PathImg);
                }
            }
        }

        [XmlIgnore]
        public string ImgIconPath 
        {
            get
            {
                string icon = string.Format(
                                "{0}{1}.png",
                                NDSDirectories.PathImg,
                                this.ImageNumber);
                if (File.Exists(icon))
                {
                    return icon;
                }
                else
                {
                    return string.Format(
                        "{0}default.png",
                        NDSDirectories.PathImg);
                }
            }
        }

        [XmlIgnore]
        public string FlagPath 
        {
            get
            {
                return string.Format("{0}{1}.png", NDSDirectories.PathFlags, this.Location);
            }
        }

        [XmlIgnore]
        public string NfoPath 
        {
            get
            {
                string nfoPath = string.Format(
                                "{0}{1}.nfo",
                                NDSDirectories.PathNfo,
                                this.ReleaseNumber);
                if (File.Exists(nfoPath))
                {
                    return nfoPath;
                }
                else
                {
                    return string.Format(
                        "{0}default.nfo",
                        NDSDirectories.PathNfo);
                }
            }
        }

        [XmlIgnore]
        public string RomPath 
        {
            get
            {
                string complementNomXXXX = (this.RomNumber == "xxxx") ? string.Format("({0})", this.Serial) : string.Empty;
                return string.Format(
                         "{0}{1}\\({2}) {3}{4}.7z",
                         NDSDirectories.PathRom,
                         NDSDirectories.GetDirFromReleaseNumber(this.RomNumber),
                         this.RomNumber,
                         this.Title,
                         complementNomXXXX);
            }
        }

        [XmlIgnore]
        public bool RomExist 
        {
            get
            {
                return File.Exists(this.RomPath);
            }
        }

        [XmlIgnore]
        public Image Icon
        {
            get
            {
                return Bitmap.FromFile(this.ImgIconPath);
            }
        }

        public bool IsWifi() 
        {
            return Wifi; 
        }

        public bool IsLanguage(int languageCode)
        {
            return this.LanguageCode.Contains(languageCode);
        }

        #region IEquatable<NDS_Rom> Members

        public bool Equals(NDS_Rom other)
        {
            // Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            // Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // Check whether the roms' properties are equal.
            return ReleaseNumber.Equals(other.ReleaseNumber) && RomCRC.Equals(other.RomCRC);
        }

        public override int GetHashCode()
        {
            // Get hash code for the releaseNumber field if it is not null.
            int hashreleaseNumber = ReleaseNumber == null ? 0 : ReleaseNumber.GetHashCode();

            // Get hash code for the RomCRC field.
            int hashRomCRC = RomCRC.GetHashCode();

            // Calculate the hash code for the rom.
            return hashreleaseNumber ^ hashRomCRC;
        }

        #endregion

        public bool IsDemo()
        {
            return this.RomNumber == "xxxx";
        }
    }
}
