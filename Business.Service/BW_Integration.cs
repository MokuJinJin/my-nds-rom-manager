﻿//-----------------------------------------------------------------------
// <copyright file="BW_Integration.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III.BusinessService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using DAL;
    using SevenZip;
    using TO;
    using Utils;
    using Utils.Configuration;
    using Utils.Directory;

    /// <summary>
    /// Type advance
    /// </summary>
    public enum TypeAvancement
    {
        /// <summary>
        /// Rom not found
        /// </summary>
        RomNotFound,

        /// <summary>
        /// Rom already have
        /// </summary>
        RomAlreadyHave,

        /// <summary>
        /// Rom added to the collection
        /// </summary>
        RomIntegrated,

        /// <summary>
        /// Rom adde to the collection BUT already have a bad dump (moving to trash)
        /// </summary>
        RomIntegratedBadDump,

        /// <summary>
        /// Nothing
        /// </summary>
        Nothing,
    }

    /// <summary>
    /// Type of work
    /// </summary>
    public enum TypeTOSortie
    {
        /// <summary>
        /// general
        /// </summary>
        General,

        /// <summary>
        /// zip
        /// </summary>
        Zip
    }

    /// <summary>
    /// BackgroundWorker which add rom in the collection
    /// </summary>
    public class BW_Integration : BackgroundWorker
    {
        /// <summary>
        /// Object use to report progress (general)
        /// </summary>
        private TOSortie tos;

        /// <summary>
        /// Object use to report progress (compression)
        /// </summary>
        private TOSortie tosCmp;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="files">List of files to be integrated</param>
        public BW_Integration(List<string> files)
        {
            Files = files;
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
            this.DoWork += new DoWorkEventHandler(BW_Integration_DoWork);
        }

        /// <summary>
        /// List of rom to be integrated
        /// </summary>
        public List<string> Files { get; private set; }

        /// <summary>
        /// Working method
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument (none)</param>
        private void BW_Integration_DoWork(object sender, DoWorkEventArgs e)
        {
            tos = new TOSortie(Files.Count, string.Empty, TypeTOSortie.General);
            foreach (string file in Files)
            {
                switch (Path.GetExtension(file))
                {
                    /*
                    case ".7z":
                    case ".zip":
                    case ".rar":
                        SevenZipExtractor ex = new SevenZipExtractor(file);
                        foreach (ArchiveFileInfo adata in ex.ArchiveFileData)
                        {
                            if (adata.FileName.EndsWith(".rar"))
                            {
                                MemoryStream ms = new MemoryStream();
                                ex.ExtractFile(adata.Index, ms);
                                SevenZipExtractor ex2 = new SevenZipExtractor(ms);
                                foreach (ArchiveFileInfo adata2 in ex2.ArchiveFileData)
                                {
                                    if (adata.FileName == ".nds")
                                    {

                                    }
                                }
                            }
                        }
                        LocateFirstVolume(file);
                        SearchNdsInArchive(file);
                        break;
                    */
                    case ".nds":
                    case ".nd5":
                        string crc = GetCRC32FromFile(file);
                        NdsFileIntegration(file, crc);
                        break;
                    default:
                        // nothing to do
                        break;
                }
            }
        }

        /// <summary>
        /// Search Nds In Archive
        /// </summary>
        /// <param name="archive">archive path</param>
        private void SearchNdsInArchive(string archive)
        {
            SevenZipExtractor.SetLibraryPath("7z.dll");
            SevenZipExtractor szip = new SevenZipExtractor(archive);
            foreach (ArchiveFileInfo adata in szip.ArchiveFileData)
            {
                if (adata.FileName.EndsWith(".nds"))
                {
                    IntegrationArchive(archive, adata);
                }
                else
                {
                    if (adata.FileName.EndsWith(".rar"))
                    {
                        // TODO : continuer
                    }
                }
            }
        }

        /// <summary>
        /// Locate first volume of an archive
        /// </summary>
        /// <param name="filename">filename of the archive</param>
        /// <returns>firstvolume</returns>
        private string LocateFirstVolume(string filename)
        {
            var boolVolume = false;
            var parts = 1u;

            using (var extractor = new SevenZipExtractor(filename))
            {
                boolVolume =
                    extractor.ArchiveProperties.Any(x =>
                        x.Name.Equals("IsVolume") && x.Value.Equals(true));

                parts = (
                    from x in extractor.ArchiveProperties
                    where x.Name.Equals("Number of volumes")
                    select (uint)x.Value).DefaultIfEmpty(1u).SingleOrDefault();
            }

            if (!boolVolume)
            {
                return null;
            }

            if (parts > 1)
            {
                return filename;
            }

            if (!Path.GetExtension(filename).Equals(".rar", StringComparison.OrdinalIgnoreCase))
            {
                var rarFile =
                    Path.Combine(
                        Path.GetDirectoryName(filename),
                        Path.GetFileNameWithoutExtension(filename) + ".rar");

                if (File.Exists(rarFile))
                {
                    var firstVolume = LocateFirstVolume(rarFile);

                    if (firstVolume != null)
                    {
                        return firstVolume;
                    }
                }
            }

            var directoryFiles = Directory.GetFiles(Path.GetDirectoryName(filename));

            foreach (var directoryFile in directoryFiles)
            {
                var firstVolume = LocateFirstVolume(directoryFile);

                if (firstVolume != null)
                {
                    using (var extractor = new SevenZipExtractor(firstVolume))
                    {
                        if (extractor.VolumeFileNames.Contains(filename))
                        {
                            return firstVolume;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// IntegrationArchive
        /// </summary>
        /// <param name="archive">archive</param>
        /// <param name="adata">ArchiveFileInfo</param>
        private void IntegrationArchive(string archive, ArchiveFileInfo adata)
        {
            string sevenZipCRC = adata.Crc.ToString("X");
            while (sevenZipCRC.Length != 8)
            {
                sevenZipCRC = string.Format("0{0}", sevenZipCRC);
            }

            NDS_Rom romInfo = DataAcessLayer.FindCRCDataBase(sevenZipCRC.ToUpper());
            if (romInfo != null)
            {
                if (!DataAcessLayer.IsCRCInCollection(sevenZipCRC.ToUpper()))
                {
                    SevenZipExtractor szip = new SevenZipExtractor(archive);
                    szip.Extracting += new EventHandler<ProgressEventArgs>(Szip_Extracting);
                    szip.ExtractionFinished += new EventHandler<EventArgs>(Szip_ExtractionFinished);
                    szip.FileExtractionStarted += new EventHandler<FileInfoEventArgs>(Szip_FileExtractionStarted);
                    szip.ExtractFiles(Parameter.Config.Paths.DirTemp, new int[] { adata.Index });
                    NdsFileIntegration(string.Format("{0}{1}", Parameter.Config.Paths.DirTemp, adata.FileName), sevenZipCRC);
                }
                else
                {
                    RomInCollection(romInfo, archive);
                }
            }
            else
            {
                RomNotFound(archive, sevenZipCRC);
            }
        }

        /// <summary>
        /// szip_FileExtractionStarted
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">FileInfoEventArgs</param>
        private void Szip_FileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            tosCmp = new TOSortie(100, string.Format("Extracting \"{0}\" ...", e.FileInfo.FileName), TypeTOSortie.Zip);
        }

        /// <summary>
        /// Szip_ExtractionFinished
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void Szip_ExtractionFinished(object sender, EventArgs e)
        {
            tos.SetIntituleTraitement("Finished");
            ReportProgress(0, tosCmp);
        }

        /// <summary>
        /// Szip_Extracting
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ProgressEventArgs</param>
        private void Szip_Extracting(object sender, ProgressEventArgs e)
        {
            ReportProgress(tosCmp.Avance(e.PercentDone), tosCmp);
        }

        /// <summary>
        /// Add (or not) the file in the collection
        /// </summary>
        /// <param name="file">File path</param>
        /// <param name="crc">crc of the file</param>
        private void NdsFileIntegration(string file, string crc)
        {
            // string crc = GetCRC32FromFile(file);
            NDS_Rom romInfo = DataAcessLayer.FindCRCDataBase(crc.ToUpper());
            if (romInfo != null)
            {
                if (DataAcessLayer.IsCRCInCollection(crc.ToUpper()))
                {
                    RomInCollection(romInfo, file);
                }
                else
                {
                    TypeAvancement infoAvancement = TypeAvancement.RomIntegrated;
                    string complementNomXXXX = (romInfo.RomNumber == "xxxx") ? string.Format("({0})", romInfo.Serial) : string.Empty;
                    if (DataAcessLayer.IsRomNumberInCollection(romInfo.RomNumber))
                    {
                        NDS_Rom romBadDump = DataAcessLayer.GetCollectionRom(romInfo.RomNumber);
                        /*
                        string fileArchive = string.Format(
                            "{0}{1}\\({2}) {3}{4}.7z",
                            NDSDirectories.PathRom,
                            NDSDirectories.GetDirFromReleaseNumber(romBadDump.RomNumber),
                            romBadDump.RomNumber,
                            romBadDump.title,
                            complementNomXXXX);
                        */
                        string badDump = string.Format("{0}{1}", Parameter.Config.Paths.DirTrash, Path.GetFileName(romBadDump.RomPath));
                        if (File.Exists(badDump))
                        {
                            File.Delete(badDump);
                        }

                        if (File.Exists(romBadDump.RomPath))
                        {
                            File.Move(romBadDump.RomPath, badDump);
                        }

                        DataAcessLayer.NdsCollection.Remove(romBadDump);
                        infoAvancement = TypeAvancement.RomIntegratedBadDump;
                    }

                    tos.SetIntituleTraitement(string.Format("CRC : {0} => {1} => Compressing ...", crc.ToUpper(), romInfo.Title));

                    ReportProgress(tos.Avance(infoAvancement), tos);

                    Directory.CreateDirectory(Parameter.Config.Paths.DirTemp + crc.ToUpper());

                    string source = string.Format("{0}{1}\\{2}{3}.nds", Parameter.Config.Paths.DirTemp, crc.ToUpper(), romInfo.Title, complementNomXXXX);
                    File.Move(file, source);

                    string zipFile = string.Format("{0}({1}) {2}{3}.7z", Parameter.Config.Paths.DirTemp, romInfo.RomNumber, romInfo.Title, complementNomXXXX);
                    try
                    {
                        ZipRom(zipFile, source);
                        tos.SetIntituleTraitement(string.Format("Compressing {0} done", romInfo.Title));
                        File.Delete(source);
                        Directory.Delete(Path.GetDirectoryName(source));
                        tos.SetRomInfo(romInfo);
                        tos.SetRomInfoIntegration(infoAvancement, Path.GetFileName(file));
                        ReportProgress(tos.PourcentageAvancement(), tos);

                        Directories.ArchiveRom(zipFile, romInfo.RomNumber);
                        DataAcessLayer.NdsCollection.Add(romInfo);
                        DataAcessLayer.SaveCollectionXML();
                    }
                    catch (Exception ex)
                    {
                        // throw;
                        tos.SetIntituleTraitement(string.Format("Une erreur est survenue pendant la compression:{0}{1}", Environment.NewLine, ex.Message));
                        File.Move(source, file);
                        tos.SetRomInfo(romInfo);
                        tos.SetRomInfoIntegration(TypeAvancement.Nothing, Path.GetFileName(file));
                        ReportProgress(tos.PourcentageAvancement(), tos);
                    }
                }
            }
            else
            {
                RomNotFound(file, crc);
            }

            tos.SetRomInfo(null);
            tos.SetRomInfoIntegration(TypeAvancement.Nothing, null);
        }

        /// <summary>
        /// RomNotFound
        /// </summary>
        /// <param name="file">file path</param>
        /// <param name="crc">crc</param>
        private void RomNotFound(string file, string crc)
        {
            tos.SetIntituleTraitement(string.Format("CRC : {0} => Not found in DataBase", crc.ToUpper()));
            if (File.Exists(Parameter.Config.Paths.DirUnknowRom + crc.ToUpper() + "-" + Path.GetFileName(file)))
            {
                File.Delete(Parameter.Config.Paths.DirUnknowRom + crc.ToUpper() + "-" + Path.GetFileName(file));
            }

            File.Move(file, Parameter.Config.Paths.DirUnknowRom + crc.ToUpper() + "-" + Path.GetFileName(file));
            tos.SetRomInfoIntegration(TypeAvancement.RomNotFound, Path.GetFileName(file));
            ReportProgress(tos.Avance(TypeAvancement.RomNotFound), tos);
        }

        /// <summary>
        /// RomInCollection
        /// </summary>
        /// <param name="romInfo">rom</param>
        /// <param name="file">file</param>
        private void RomInCollection(NDS_Rom romInfo, string file)
        {
            tos.SetIntituleTraitement(string.Format("Already have {0} ({1}) => This will not be integrated.", romInfo.Title, romInfo.RomNumber));
            tos.SetRomInfo(romInfo);
            tos.SetRomInfoIntegration(TypeAvancement.RomAlreadyHave, Path.GetFileName(file));

            ReportProgress(tos.Avance(TypeAvancement.RomAlreadyHave), tos);
            File.Move(file, Parameter.Config.Paths.DirAlreadyHave + Path.GetFileName(file));
        }

        /// <summary>
        /// Return CRC32 from single file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>CRC32 of the file</returns>
        private string GetCRC32FromFile(string filePath)
        {
            Crc32 crc32 = new Crc32();
            string hash = string.Empty;

            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                foreach (byte b in crc32.ComputeHash(fs))
                {
                    hash += b.ToString("x2").ToLower();
                }
            }

            return hash;
        }

        #region zip
        /// <summary>
        /// Method to zip rom
        /// </summary>
        /// <param name="zipFile">Path to the final zip file, including the name</param>
        /// <param name="filePath">Path to the file which will be zipped</param>
        private void ZipRom(string zipFile, string filePath)
        {
            SevenZipCompressor.SetLibraryPath("7z.dll");
            SevenZipCompressor cmp = new SevenZipCompressor();
            cmp.ArchiveFormat = OutArchiveFormat.SevenZip;
            cmp.CompressionLevel = CompressionLevel.Normal;
            cmp.CompressionMethod = CompressionMethod.Default;
            cmp.VolumeSize = 0;
            cmp.Compressing += new EventHandler<ProgressEventArgs>(Cmp_Compressing);
            cmp.CompressionFinished += new EventHandler<EventArgs>(Cmp_CompressionFinished);
            cmp.FileCompressionStarted += new EventHandler<FileNameEventArgs>(Cmp_FileCompressionStarted);
            try
            {
                cmp.CompressFiles(zipFile, new string[] { filePath });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// File Compression Started
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void Cmp_FileCompressionStarted(object sender, FileNameEventArgs e)
        {
            tosCmp = new TOSortie(100, string.Format("Compressing \"{0}\" ...", e.FileName), TypeTOSortie.Zip);
        }

        /// <summary>
        /// File Compression Finished
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void Cmp_CompressionFinished(object sender, EventArgs e)
        {
            tos.SetIntituleTraitement("Finished");
            ReportProgress(0, tosCmp);
        }

        /// <summary>
        /// During compression
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void Cmp_Compressing(object sender, ProgressEventArgs e)
        {
            ReportProgress(tosCmp.Avance(e.PercentDone), tosCmp);
        }
        #endregion
    }

    /// <summary>
    /// Transfert object use to report integration progress
    /// </summary>
    public class TOSortie
    {
        /// <summary>
        /// DateTime of the start of the process
        /// </summary>
        private DateTime dt;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nombreDeFichier">Number of files</param>
        /// <param name="titreTraitement">Title of the work</param>
        /// <param name="typeTO">Type of the informations</param>
        public TOSortie(long nombreDeFichier, string titreTraitement, TypeTOSortie typeTO)
        {
            IntituleTraitement = titreTraitement;
            NbFichier = nombreDeFichier;
            dt = DateTime.Now;
            NbActuel = 0;
            NbRomAlreadyHave = 0;
            NbRomIntegrated = 0;
            NbRomNotFound = 0;
            this.TypeTO = typeTO;
        }

        /// <summary>
        /// Type of the informations
        /// </summary>
        public TypeTOSortie TypeTO { get; private set; }

        /// <summary>
        /// Total number of files
        /// </summary>
        public long NbFichier { get; private set; }

        /// <summary>
        /// Number of files not found in database
        /// </summary>
        public int NbRomNotFound { get; private set; }

        /// <summary>
        /// Number of files which are already in the collection
        /// </summary>
        public int NbRomAlreadyHave { get; private set; }

        /// <summary>
        /// Number of files which have been integrated
        /// </summary>
        public int NbRomIntegrated { get; private set; }

        /// <summary>
        /// Actual number of the file which is integrated
        /// </summary>
        public int NbActuel { get; private set; }

        /// <summary>
        /// Rom information
        /// </summary>
        public NDS_Rom RomInfo { get; private set; }

        /// <summary>
        /// What happen during integration
        /// </summary>
        public TypeAvancement WhatHappen { get; private set; }

        /// <summary>
        /// Filename which is actually integrated
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// What the worker is doing
        /// </summary>
        public string IntituleTraitement { get; private set; }

        /// <summary>
        /// set actual informations of the worker job
        /// </summary>
        /// <param name="ta">What happen during integration</param>
        /// <param name="fn">File name</param>
        public void SetRomInfoIntegration(TypeAvancement ta, string fn)
        {
            WhatHappen = ta;
            FileName = fn;
        }

        /// <summary>
        /// set informations about the rom
        /// </summary>
        /// <param name="rom">NDS Rom</param>
        public void SetRomInfo(NDS_Rom rom)
        {
            RomInfo = rom;
        }

        /// <summary>
        /// set What the worker is doing
        /// </summary>
        /// <param name="intitule">What the worker is doing</param>
        public void SetIntituleTraitement(string intitule)
        {
            this.IntituleTraitement = intitule;
        }

        /// <summary>
        /// Avance
        /// </summary>
        /// <param name="ta">Type of work</param>
        /// <returns>Pourcentage d'avancement</returns>
        public int Avance(TypeAvancement ta)
        {
            switch (ta)
            {
                case TypeAvancement.RomNotFound:
                    NbRomNotFound++;
                    break;
                case TypeAvancement.RomAlreadyHave:
                    NbRomAlreadyHave++;
                    break;
                case TypeAvancement.RomIntegrated:
                    NbRomIntegrated++;
                    break;
                default:
                    break;
            }

            NbActuel = NbRomNotFound + NbRomIntegrated + NbRomAlreadyHave;
            return PourcentageAvancement();
        }

        /// <summary>
        /// Avance pour la compression
        /// </summary>
        /// <param name="pourcentageAvancementCompression">Pourcentage Avancement Compression</param>
        /// <returns>Percent progress</returns>
        public int Avance(int pourcentageAvancementCompression)
        {
            NbActuel = pourcentageAvancementCompression;
            return PourcentageAvancement();
        }

        /// <summary>
        /// calc the percent progress
        /// </summary>
        /// <returns>Percent progress</returns>
        public int PourcentageAvancement()
        {
            return (int)Math.Floor((double)(NbActuel * 100 / NbFichier));
        }

        /// <summary>
        /// New work (reset)
        /// </summary>
        /// <param name="titreTraitement">What work</param>
        public void NouveauTraitement(string titreTraitement)
        {
            IntituleTraitement = titreTraitement;
            dt = DateTime.Now;
            NbActuel = 0;
            NbRomAlreadyHave = 0;
            NbRomIntegrated = 0;
            NbRomNotFound = 0;
        }
    }
}
