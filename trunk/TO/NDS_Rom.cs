using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using System.Drawing;
using System.IO;

namespace NdsCRC_III
{
    [XmlRoot("NDS_Rom_Collection")]
    public class NDS_Rom : IEquatable<NDS_Rom>
    {
        public string imageNumber { get; set; }
        public string releaseNumber { get; set; }
        public string title { get; set; }
        public string saveType { get; set; }
        public string romSize { get; set; }
        public string publisher { get; set; }
        public string location { get; set; }
        public string sourceRom { get; set; }
        public string languageString { get; set; }
        public List<int> languageCode { get; set; }
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
                                this.imageNumber);
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
                            this.imageNumber);
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
                                this.imageNumber);
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
                return string.Format("{0}{1}.png", NDSDirectories.PathFlags, this.location);
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
                                this.releaseNumber);
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
                         this.title,
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

        public NDS_Rom()
        {
            languageCode = new List<int>();
        }

        #region Commentaire
        //public NDS_Rom(XmlReader xmlR)
        //{
        //    XmlDocument xdoc = new XmlDocument();
        //    xdoc.Load(xmlR);
        //    foreach (XmlNode xndd in xdoc.ChildNodes[0].ChildNodes)
        //    {
        //        switch (xndd.Name)
        //        {
        //            case "imageNumber":
        //                imageNumber = xndd.InnerText;
        //                if (int.Parse(xndd.InnerText) < 1000) { imageNumber = "0" + xndd.InnerText; }
        //                if (int.Parse(xndd.InnerText) < 100) { imageNumber = "00" + xndd.InnerText; }
        //                if (int.Parse(xndd.InnerText) < 10) { imageNumber = "000" + xndd.InnerText; }
        //                break;
        //            case "releaseNumber":
        //                releaseNumber = xndd.InnerText;
        //                if (int.Parse(xndd.InnerText) < 1000) { releaseNumber = "0" + xndd.InnerText; }
        //                if (int.Parse(xndd.InnerText) < 100) { releaseNumber = "00" + xndd.InnerText; }
        //                if (int.Parse(xndd.InnerText) < 10) { releaseNumber = "000" + xndd.InnerText; }
        //                break;
        //            case "title": title = xndd.InnerText; break;
        //            case "saveType": saveType = xndd.InnerText; break;
        //            case "romSize":
        //                romSize = (int.Parse(xndd.InnerText) / 1024 / 1024).ToString() + " Mo";
        //                break;
        //            case "publisher": publisher = xndd.InnerText; break;
        //            case "location":
        //                //location = LocationXML.getStringLocation(int.Parse(xndd.InnerText));
        //                break;
        //            case "sourceRom": sourceRom = xndd.InnerText; break;
        //            case "language":
        //                //language = LanguageXML.getLanguage(int.Parse(xndd.InnerText));
        //                break;
        //            case "files":
        //                RomCRC = xndd.ChildNodes[0].InnerText;
        //                break;
        //            case "im1CRC": ImgCoverCRC = xndd.InnerText; break;
        //            case "im2CRC": ImgInGameCRC = xndd.InnerText; break;
        //            case "nfoCRC": NfoCRC = xndd.InnerText; break;
        //            case "icoCRC": IcoCRC = xndd.InnerText; break;
        //            case "genre": Genre = xndd.InnerText; break;
        //            case "dumpdate": DumpDate = xndd.InnerText; break;
        //            case "internalname": InternalName = xndd.InnerText; break;
        //            case "serial": Serial = xndd.InnerText; break;
        //            case "version": Version = xndd.InnerText; break;
        //            case "wifi":
        //                if (xndd.InnerText == "Yes") { Wifi = true; } else { Wifi = false; }
        //                break;
        //            case "comment": RomNumber = xndd.InnerText; break;
        //            case "duplicateid": DuplicateID = int.Parse(xndd.InnerText); break;
        //        }
        //    }
        //}


        //public NDS_Rom(DataRow dr)
        //{
        //    imageNumber = dr["ImageNumber"].ToString();
        //    releaseNumber = dr["ReleaseNumber"].ToString();
        //    title = dr["Title"].ToString();
        //    saveType = dr["SaveType"].ToString();
        //    romSize = dr["RomSize"].ToString();
        //    publisher = dr["Publisher"].ToString();
        //    location = dr["Location"].ToString();
        //    sourceRom = dr["SourceRom"].ToString();
        //    language = dr["Language"].ToString();
        //    RomCRC = dr["RomCRC"].ToString();
        //    ImgCoverCRC = dr["ImgCoverCRC"].ToString();
        //    ImgInGameCRC = dr["ImgInGameCRC"].ToString();
        //    IcoCRC = dr["IcoCRC"].ToString();
        //    NfoCRC = dr["NFO_CRC"].ToString();
        //    Genre = dr["Genre"].ToString();
        //    DumpDate = dr["DumpDate"].ToString();
        //    InternalName = dr["InternalName"].ToString();
        //    Serial = dr["Serial"].ToString();
        //    Version = dr["Version"].ToString();
        //    if (dr["Wifi"].ToString() == "Yes") { Wifi = true; } else { Wifi = false; }
        //    if (dr["duplicateid"].ToString() != "None") { DuplicateID = int.Parse(dr["duplicateid"].ToString()); } else { DuplicateID = 0; }

        //    RomNumber = dr["RomNumber"].ToString();
        //    Have = bool.Parse(dr["have"].ToString());
        //}
        #endregion

        public bool isWifi() { return Wifi; }

        public bool isLanguage(int languageCode)
        {
            return this.languageCode.Contains(languageCode);
        }

        #region IEquatable<NDS_Rom> Members

        public bool Equals(NDS_Rom other)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the roms' properties are equal.
            return releaseNumber.Equals(other.releaseNumber) && RomCRC.Equals(other.RomCRC);
        }
        public override int GetHashCode()
        {

            //Get hash code for the releaseNumber field if it is not null.
            int hashreleaseNumber = releaseNumber == null ? 0 : releaseNumber.GetHashCode();

            //Get hash code for the RomCRC field.
            int hashRomCRC = RomCRC.GetHashCode();

            //Calculate the hash code for the rom.
            return hashreleaseNumber ^ hashRomCRC;
        }

        #endregion
    }
}
