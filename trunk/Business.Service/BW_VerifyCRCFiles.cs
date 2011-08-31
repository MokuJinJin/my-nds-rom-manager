//-----------------------------------------------------------------------
// <copyright file="BW_VerifyCRCFiles.cs" company="Zed Byt Corp">
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
    using System.Xml.Serialization;

    using NdsCRC_III.DAL;
    using NdsCRC_III.TO;
    using SevenZip;

    /// <summary>
    /// Worker to verify CRC of the all rom collection
    /// </summary>
    public class BW_VerifyCRCFiles : BackgroundWorker
    {
        /// <summary>
        /// statup path of the application
        /// </summary>
        private string _startuppath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startupPath">StarupPath of the application</param>
        public BW_VerifyCRCFiles(string startupPath)
        {
            _startuppath = startupPath;
            /*
             NDSDirectories.SetStartupPath(startupPath);
             DataAcessLayer.AdvanScene.Load(startupPath);
             AdvanSceneDataBaseXML.Load(startupPath);
            */
            this.WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(BW_VerifyCRCFiles_DoWork);
        }

        /// <summary>
        /// Work of the worker
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DoWorkEventArgs</param>
        private void BW_VerifyCRCFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            List<NDS_Rom> newCollection = new List<NDS_Rom>();
            List<string> files = Directory.GetFiles(NDSDirectories.PathRom, "*.7z", SearchOption.AllDirectories).ToList<string>();
            files.Sort();
            SevenZipExtractor.SetLibraryPath("7z.dll");
            int nbFiles = files.Count;
            int numEnCours = 1;
            ReportProgress(-1);
            foreach (string file in files)
            {
                string romNumber = Path.GetFileNameWithoutExtension(file).Substring(1, 4);
                if (romNumber != "xxxx")
                {
                    // DAL.XMLExplorateur xml = new DAL.XMLExplorateur(NDSDirectories.PathXmlDB);
                    // NDS_Rom rom = new NDS_Rom(xml.SearchByRomNumberToXmlReader(RomNumber));
                    NDS_Rom rom = new NDS_Rom();
                    try
                    {
                        rom = DataAcessLayer.NdsAdvanScene.Single(r => r.RomNumber == romNumber);
                        SevenZipExtractor szip = new SevenZipExtractor(file);
                        foreach (ArchiveFileInfo adata in szip.ArchiveFileData)
                        {
                            if (adata.FileName == string.Format("{0}.nds", rom.Title))
                            {
                                string sevenZipCRC = adata.Crc.ToString("X");
                                while (sevenZipCRC.Length != 8)
                                {
                                    sevenZipCRC = string.Format("0{0}", sevenZipCRC);
                                }

                                if (sevenZipCRC == rom.RomCRC)
                                {
                                    ReportProgress(numEnCours * 100 / nbFiles);
                                    newCollection.Add(rom);
                                    numEnCours++;
                                }
                                else
                                {
                                    // NOT GOOD
                                    string log = string.Format(
                                        "{1} {0} 7z : {2}{0}Advanscene : {3}",
                                        " || ",
                                        Path.GetFileNameWithoutExtension(file),
                                        sevenZipCRC,
                                        rom.RomCRC);
                                    ReportProgress(numEnCours * 100 / nbFiles, log);
                                    File.AppendAllText(string.Format("{0}\\ReCreateCollection.log", _startuppath), string.Format("{0}{1}", log, Environment.NewLine));

                                    // ReportProgress(NumEnCours * 100 / NbFiles, Path.GetFileNameWithoutExtension(file));
                                    rom.RomCRC = sevenZipCRC;
                                    newCollection.Add(rom);
                                    numEnCours++;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        string message = string.Format(
                            "{1}{0}7z : {2}{0}Advanscene : not Found",
                            " || ",
                            Path.GetFileNameWithoutExtension(file),
                            romNumber);
                        ReportProgress(
                            numEnCours * 100 / nbFiles,
                            message);
                    }
                }
                else
                {
                    ReportProgress(numEnCours * 100 / nbFiles);
                    numEnCours++;
                }
            }

            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            string path = NDSDirectories.PathXmlHaveDB.Replace("Collection.xml", "NewCollection.xml");
            using (StreamWriter wr = new StreamWriter(path))
            {
                xs.Serialize(wr, newCollection);
            }
        }
    }
}
