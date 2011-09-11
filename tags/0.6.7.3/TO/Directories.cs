//-----------------------------------------------------------------------
// <copyright file="Directories.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III
{
    using System;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Listing of Directories
    /// </summary>
    public enum NDSDirectoriesEnum
    {
        /// <summary>
        /// Path to rom
        /// </summary>
        Rom,

        /// <summary>
        /// Path to image
        /// </summary>
        Img,

        /// <summary>
        /// Path to Flags
        /// </summary>
        Flags,

        /// <summary>
        /// Path to NFO
        /// </summary>
        Nfo,

        /// <summary>
        /// Path to trash
        /// </summary>
        Trash,

        /// <summary>
        /// Path to temp
        /// </summary>
        Temp,

        /// <summary>
        /// Path to new rom
        /// </summary>
        NewRom,

        /// <summary>
        /// Url of Cover image
        /// </summary>
        UrlCover,

        /// <summary>
        /// Url of InGame image
        /// </summary>
        UrlInGame,

        /// <summary>
        /// Url of the icon image
        /// </summary>
        UrlIco,

        /// <summary>
        /// Url of Nfo file
        /// </summary>
        UrlNfo,
    }

    /// <summary>
    /// Static class wich have all fixed and calculated directories
    /// </summary>
    public static class NDSDirectories
    {
        /// <summary>
        /// Xml Reader
        /// </summary>
        private static XmlReader xmlread;

        /// <summary>
        /// Xml document
        /// </summary>
        private static XmlDocument xdoc;

        /// <summary>
        /// Application Startup path
        /// </summary>
        public static string StartupPath { get; private set; }

        /// <summary>
        /// Path to image
        /// </summary>
        public static string PathImg { get; private set; }
        
        /// <summary>
        /// Path to image
        /// </summary>
        public static string PathFlags { get; private set; }

        /// <summary>
        /// Path to NFO
        /// </summary>
        public static string PathNfo { get; private set; }

        /// <summary>
        /// Path to Rom
        /// </summary>
        public static string PathRom { get; private set; }

        /// <summary>
        /// Path to trash
        /// </summary>
        public static string PathTrash { get; private set; }

        /// <summary>
        /// Path to temp
        /// </summary>
        public static string PathTemp { get; private set; }

        /// <summary>
        /// Path to new rom
        /// </summary>
        public static string PathNewRom { get; private set; }

        /// <summary>
        /// Path to unknown rom
        /// </summary>
        public static string PathUnknowRom { get; private set; }

        /// <summary>
        /// Path to already have rom
        /// </summary>
        public static string PathAlreadyHave { get; private set; }

        /// <summary>
        /// Path to Have Database 
        /// </summary>
        public static string PathXmlHaveDB { get; private set; }

        /// <summary>
        /// Path to AdvanceScene Database
        /// </summary>
        public static string PathXmlDB { get; private set; }

        /// <summary>
        /// Path to the Update DataBase Log File
        /// </summary>
        public static string PathUpdateDataBaseLogFile 
        {
            get
            {
                return string.Format("{0}\\UpdateDataBaseLog_{1}_{2}_{3}.txt", NDSDirectories.StartupPath, DateTime.Now.Year, DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"));
            }
        }
        
        /// <summary>
        /// Method to set Application Startup path and all other directories link to it
        /// </summary>
        /// <param name="path">Application Startup Path</param>
        public static void SetStartupPath(string path)
        {
            StartupPath = path;
            LoadDir();
        }
        
        /// <summary>
        /// Re Load directories linked to Application Startup Path
        /// </summary>
        public static void ReloadDir()
        {
            LoadDir();
        }
        
        /// <summary>
        /// Load all directories stored in Xml linked to Application Startup Path
        /// </summary>
        private static void LoadDir()
        {
            if (StartupPath == string.Empty)
            {
                throw new Exception("StartupPath Not defined");
            }

            xmlread = XmlReader.Create(string.Format("data{0}xml{0}NDScrc_III.xml", Path.DirectorySeparatorChar));
            xdoc = new XmlDocument();
            xdoc.Load(xmlread);

            XmlNode xnd = xdoc.ChildNodes[1].ChildNodes[0];
            foreach (XmlNode xndd in xnd.ChildNodes)
            {
                switch (xndd.Name)
                {
                    case "Flags":
                        PathFlags = StartupPath + xndd.InnerText;
                        break;
                    case "img":
                        PathImg = StartupPath + xndd.InnerText;
                        break;
                    case "nfo": 
                        PathNfo = StartupPath + xndd.InnerText;
                        break;
                    case "rom": 
                        PathRom = StartupPath + xndd.InnerText;
                        break;
                    case "newrom": 
                        PathNewRom = StartupPath + xndd.InnerText;
                        break;
                    case "unknowrom": 
                        PathUnknowRom = StartupPath + xndd.InnerText;
                        break;
                    case "trash": 
                        PathTrash = StartupPath + xndd.InnerText;
                        break;
                    case "temp": 
                        PathTemp = StartupPath + xndd.InnerText;
                        break;
                    case "HaveDB": 
                        PathXmlHaveDB = StartupPath + xndd.InnerText;
                        break;
                    case "AlreadyHave": 
                        PathAlreadyHave = StartupPath + xndd.InnerText;
                        break;
                    case "DB": 
                        PathXmlDB = StartupPath + xndd.InnerText;
                        break;
                }
            }

            xmlread.Close();
            xdoc = null;
            xmlread = null;
        }
        
        /// <summary>
        /// Create all directories
        /// </summary>
        /// <param name="dir">Directorie from listing</param>
        private static void CreateOtherDir(NDSDirectoriesEnum dir)
        {
            switch (dir)
            {
                case NDSDirectoriesEnum.Img:
                    if (!Directory.Exists(PathImg))
                    {
                        Directory.CreateDirectory(PathImg);
                    }

                    break;
                case NDSDirectoriesEnum.NewRom:
                    if (!Directory.Exists(PathNewRom))
                    {
                        Directory.CreateDirectory(PathNewRom);
                    }

                    break;
                case NDSDirectoriesEnum.Nfo:
                    if (!Directory.Exists(PathNfo))
                    {
                        Directory.CreateDirectory(PathNfo);
                    }

                    break;
                case NDSDirectoriesEnum.Trash:
                    if (!Directory.Exists(PathTrash))
                    {
                        Directory.CreateDirectory(PathTrash);
                    }

                    break;
            }
        }
        
        /// <summary>
        /// Create rom directorie
        /// </summary>
        /// <param name="releaseNumber">Release number of the rom wich goes to the new directorie</param>
        private static void CreateRomDir(string releaseNumber)
        {
            string dirFromReleaseNumber = string.Empty;
            if (releaseNumber == "xxxx")
            {
                dirFromReleaseNumber = "xxxx";
            }
            else
            {
                dirFromReleaseNumber = GetDirFromReleaseNumber(releaseNumber);
            }

            if (!Directory.Exists(PathRom + dirFromReleaseNumber))
            {
                Directory.CreateDirectory(PathRom + dirFromReleaseNumber);
            }
        }
        
        /// <summary>
        /// Get directorie from rom release number
        /// </summary>
        /// <param name="releaseNumber">Rom Release number</param>
        /// <returns>Directorie string</returns>
        public static string GetDirFromReleaseNumber(string releaseNumber)
        {
            if (releaseNumber == "xxxx")
            {
                return "xxxx";
            }
            else
            {
                string r = string.Empty;
                double d = int.Parse(releaseNumber) / 100;
                d = Math.Floor(d);
                if (d == 0)
                {
                    r = "00000";
                }

                if (d < 10)
                {
                    r = "00" + d.ToString() + "00";
                }

                if (d < 100 && d >= 10)
                {
                    r = "0" + d.ToString() + "00";
                }

                if (d < 1000 && d >= 100)
                {
                    r = d.ToString() + "00";
                }

                return r;
            }
        }

        /// <summary>
        /// return the URL asked for a release number
        /// </summary>
        /// <param name="releaseNumber">Rom release number</param>
        /// <param name="uri">url asked</param>
        /// <returns>Url</returns>
        public static string GetUriFor(int releaseNumber, NDSDirectoriesEnum uri)
        {
            string r = string.Empty;
            switch (uri)
            {
                case NDSDirectoriesEnum.UrlCover:
                    #region Exemple
                    /*
                    r = "http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/" + getUriFromReleaseNumber(releaseNumber) + "/" + getFileNameFromReleaseNumber(releaseNumber) + "a.png";
                    http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/1-500/1a.png
                    */
                    #endregion

                    r = string.Format("http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/{0}/{1}a.png", GetUriFromReleaseNumber(releaseNumber), releaseNumber);
                    break;
                case NDSDirectoriesEnum.UrlInGame:
                    #region Exemple
                    /*
                    http://www.advanscene.com/html/Releases/imr2.php?id=1
                    r = "http://www.advanscene.com/html/Releases/imr2.php?id=" + releaseNumber;
                    r = "http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/" + getUriFromReleaseNumber(releaseNumber) + "/" + getFileNameFromReleaseNumber(releaseNumber) + "b.png";
                    http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/1-500/1b.png
                    */
                    #endregion

                    r = string.Format("http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/{0}/{1}b.png", GetUriFromReleaseNumber(releaseNumber), releaseNumber);
                    break;
                case NDSDirectoriesEnum.UrlIco:
                    #region Exemple
                    /*        
                    http://www.advanscene.com/offline/imgs/NDSicon/1-500/0001.png
                    r = "http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/" + getUriFromReleaseNumber(releaseNumber) + "/" + getFileNameFromReleaseNumber(releaseNumber) + ".png";
                    */
                    #endregion

                    r = string.Format("http://www.advanscene.com/offline/imgs/NDSicon/{0}/{1}.png", GetUriFromReleaseNumber(releaseNumber), releaseNumber.ToString("0000"));
                    break;
                case NDSDirectoriesEnum.UrlNfo:
                    r = string.Format("http://www.advanscene.com/offline/nfo/NDSnfo/{0}/{1}.nfo", GetUriFromReleaseNumber(releaseNumber), releaseNumber.ToString("0000"));
                    break;
            }

            return r;
        }

        /// <summary>
        /// Calculate URI from release number
        /// </summary>
        /// <param name="releaseNumber">the release number</param>
        /// <returns>URI</returns>
        private static string GetUriFromReleaseNumber(int releaseNumber)
        {
            string r = string.Empty;
            if (releaseNumber % 500 == 0)
            {
                releaseNumber--;
            }

            double d = Math.Floor((double)releaseNumber / 500) * 500;
            r = string.Format("{0}-{1}", d + 1, d + 500);
            return r;
        }

        /// <summary>
        /// Move file to the directorie wich belong
        /// </summary>
        /// <param name="source">Source file</param>
        /// <param name="releaseNumber">release number of the rom</param>
        public static void ArchiveRom(string source, string releaseNumber)
        {
            CreateRomDir(releaseNumber);
            string trashFile = PathTrash + Path.GetFileName(source);
            string archiveFile = string.Empty;
            if (releaseNumber != "xxxx")
            {
                archiveFile = PathRom + GetDirFromReleaseNumber(releaseNumber) + "\\" + Path.GetFileName(source);
            }
            else
            {
                archiveFile = PathRom + "xxxx\\" + Path.GetFileName(source);
            }
                            
            if (!File.Exists(archiveFile))
            {
                File.Move(source, archiveFile);
            }
            else
            {
                CreateOtherDir(NDSDirectoriesEnum.Trash);
                if (File.Exists(trashFile))
                {
                    File.Delete(trashFile);
                }

                File.Move(archiveFile, trashFile);
                File.Move(source, archiveFile);
            }
        }
    }
}
