using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using SevenZip;
using NdsCRC_III.DAL;
using System.Xml.Serialization;

namespace NdsCRC_III.BusinessService.BW
{
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
            // NDSDirectories.SetStartupPath(startupPath);
            // DataAcessLayer.AdvanScene.Load(startupPath);
            // AdvanSceneDataBaseXML.Load(startupPath);
            this.WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(BW_VerifyCRCFiles_DoWork);
        }

        /// <summary>
        /// Work of the worker
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DoWorkEventArgs</param>
        void BW_VerifyCRCFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            List<NDS_Rom> NewCollection = new List<NDS_Rom>();
            List<string> Files = Directory.GetFiles(NDSDirectories.PathRom, "*.7z", SearchOption.AllDirectories).ToList<string>();
            Files.Sort();
            SevenZipExtractor.SetLibraryPath("7z.dll");
            int NbFiles = Files.Count;
            int NumEnCours = 1;
            ReportProgress(-1);
            foreach (string file in Files)
            {
                string RomNumber = Path.GetFileNameWithoutExtension(file).Substring(1, 4);
                if (RomNumber != "xxxx")
                {
                    //DAL.XMLExplorateur xml = new DAL.XMLExplorateur(NDSDirectories.PathXmlDB);
                    //NDS_Rom rom = new NDS_Rom(xml.SearchByRomNumberToXmlReader(RomNumber));
                    NDS_Rom DBrom = new NDS_Rom();
                    try
                    {
                        DBrom = DataAcessLayer.NdsAdvanScene.Single(rom => rom.RomNumber == RomNumber);
                        SevenZipExtractor szip = new SevenZipExtractor(file);
                        foreach (ArchiveFileInfo adata in szip.ArchiveFileData)
                        {
                            if (adata.FileName == string.Format("{0}.nds", DBrom.Title))
                            {
                                string SevenZipCRC = adata.Crc.ToString("X");
                                while (SevenZipCRC.Length != 8) { SevenZipCRC = string.Format("0{0}", SevenZipCRC); }
                                if (SevenZipCRC == DBrom.RomCRC)
                                {
                                    ReportProgress(NumEnCours * 100 / NbFiles);
                                    NewCollection.Add(DBrom);
                                    NumEnCours++;
                                }
                                else
                                {
                                    // NOT GOOD
                                    string log = string.Format("{1} {0} 7z : {2}{0}Advanscene : {3}",
                                        " || ",
                                        Path.GetFileNameWithoutExtension(file),
                                        SevenZipCRC,
                                        DBrom.RomCRC);
                                    ReportProgress(NumEnCours * 100 / NbFiles, log);
                                    File.AppendAllText(string.Format("{0}\\ReCreateCollection.log", _startuppath), string.Format("{0}{1}",log,Environment.NewLine));
                                    //ReportProgress(NumEnCours * 100 / NbFiles, Path.GetFileNameWithoutExtension(file));
                                    DBrom.RomCRC = SevenZipCRC;
                                    NewCollection.Add(DBrom);
                                    NumEnCours++;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        ReportProgress(NumEnCours * 100 / NbFiles,
                                        string.Format("{1}{0}7z : {2}{0}Advanscene : not Found",
                                        " || ",
                                        Path.GetFileNameWithoutExtension(file),
                                        RomNumber));
                    }
                }
                else
                {
                    ReportProgress(NumEnCours * 100 / NbFiles);
                    NumEnCours++;
                }
            }
            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            string path = NDSDirectories.PathXmlHaveDB.Replace("Collection.xml", "NewCollection.xml");
            using (StreamWriter wr = new StreamWriter(path))
            {
                xs.Serialize(wr, NewCollection);
            }
        }
    }
}
