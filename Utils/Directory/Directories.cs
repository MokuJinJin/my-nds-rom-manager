//-----------------------------------------------------------------------
// <copyright file="Directories.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace Utils.Directories
{
    using System;
    using System.IO;
    using Utils.Configuration;

    /// <summary>
    /// Directories Utils
    /// </summary>
    public static class Directories
    {
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
        public static string GetUriFor(int releaseNumber, DirectoriesEnum uri)
        {
            string r = string.Empty;
            switch (uri)
            {
                case DirectoriesEnum.UrlCover:
                    #region Exemple
                    /*
                    r = "http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/" + getUriFromReleaseNumber(releaseNumber) + "/" + getFileNameFromReleaseNumber(releaseNumber) + "a.png";
                    http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/1-500/1a.png
                    */
                    #endregion

                    r = string.Format("http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/{0}/{1}a.png", GetUriFromReleaseNumber(releaseNumber), releaseNumber);
                    break;
                case DirectoriesEnum.UrlInGame:
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
                case DirectoriesEnum.UrlIco:
                    #region Exemple
                    /*        
                    http://www.advanscene.com/offline/imgs/NDSicon/1-500/0001.png
                    r = "http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/" + getUriFromReleaseNumber(releaseNumber) + "/" + getFileNameFromReleaseNumber(releaseNumber) + ".png";
                    */
                    #endregion

                    r = string.Format("http://www.advanscene.com/offline/imgs/NDSicon/{0}/{1}.png", GetUriFromReleaseNumber(releaseNumber), releaseNumber.ToString("0000"));
                    break;
                case DirectoriesEnum.UrlNfo:
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
            string trashFile = Parameter.Config.Paths.DirTrash + Path.GetFileName(source);
            string archiveFile = string.Empty;
            if (releaseNumber != "xxxx")
            {
                archiveFile = Parameter.Config.Paths.DirNdsRom + GetDirFromReleaseNumber(releaseNumber) + "\\" + Path.GetFileName(source);
            }
            else
            {
                archiveFile = Parameter.Config.Paths.DirNdsRom + "xxxx\\" + Path.GetFileName(source);
            }

            if (!File.Exists(archiveFile))
            {
                File.Move(source, archiveFile);
            }
            else
            {
                CreateOtherDir(DirectoriesEnum.Trash);
                if (File.Exists(trashFile))
                {
                    File.Delete(trashFile);
                }

                File.Move(archiveFile, trashFile);
                File.Move(source, archiveFile);
            }
        }

        /// <summary>
        /// Create all directories
        /// </summary>
        /// <param name="dir">Directorie from listing</param>
        private static void CreateOtherDir(DirectoriesEnum dir)
        {
            switch (dir)
            {
                case DirectoriesEnum.Img:
                    if (!Directory.Exists(Parameter.Config.Paths.DirImage))
                    {
                        Directory.CreateDirectory(Parameter.Config.Paths.DirImage);
                    }

                    break;
                case DirectoriesEnum.NewRom:
                    if (!Directory.Exists(Parameter.Config.Paths.DirNewRom))
                    {
                        Directory.CreateDirectory(Parameter.Config.Paths.DirNewRom);
                    }

                    break;
                case DirectoriesEnum.Nfo:
                    if (!Directory.Exists(Parameter.Config.Paths.DirNFO))
                    {
                        Directory.CreateDirectory(Parameter.Config.Paths.DirNFO);
                    }

                    break;
                case DirectoriesEnum.Trash:
                    if (!Directory.Exists(Parameter.Config.Paths.DirTrash))
                    {
                        Directory.CreateDirectory(Parameter.Config.Paths.DirTrash);
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

            if (!Directory.Exists(Parameter.Config.Paths.DirNdsRom + dirFromReleaseNumber))
            {
                Directory.CreateDirectory(Parameter.Config.Paths.DirNdsRom + dirFromReleaseNumber);
            }
        }
    }
}
