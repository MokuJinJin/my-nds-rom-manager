using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using SevenZip;
using NdsCRC_III.DAL;

namespace NdsCRC_III.BusinessService.BW
{
    public class BW_VerifyCRCFiles : BackgroundWorker
    {
        public BW_VerifyCRCFiles()
        {
            this.WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(BW_VerifyCRCFiles_DoWork);
        }

        void BW_VerifyCRCFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> Files = Directory.GetFiles(NDSDirectories.PathRom, "*.7z", SearchOption.AllDirectories).ToList<string>();
            SevenZipExtractor.SetLibraryPath("7z.dll");
            int NbFiles = Files.Count;
            int NumEnCours = 1;
            ReportProgress(-1);
            foreach (string file in Files)
            {
                string RomNumber = Path.GetFileNameWithoutExtension(file).Substring(1, 4);
                if (RomNumber != "xxxx")
                {
                    DAL.XMLExplorateur xml = new DAL.XMLExplorateur(NDSDirectories.PathXmlDB);
                    //NDS_Rom rom = new NDS_Rom(xml.SearchByRomNumberToXmlReader(RomNumber));
                    NDS_Rom rom = new NDS_Rom();

                    SevenZipExtractor szip = new SevenZipExtractor(file);
                    foreach (ArchiveFileInfo adata in szip.ArchiveFileData)
                    {
                        if (adata.FileName == string.Format("{0}.nds", rom.title))
                        {
                            string SevenZipCRC = adata.Crc.ToString("X");
                            while (SevenZipCRC.Length != 8)
                            {
                                SevenZipCRC = string.Format("0{0}", SevenZipCRC);
                            }
                            if (SevenZipCRC == rom.RomCRC)
                            {
                                ReportProgress(NumEnCours * 100 / NbFiles);
                                NumEnCours++;
                            }
                            else
                            {
                                // NOT GOOD
                                ReportProgress(NumEnCours * 100 / NbFiles, string.Format("{1}{0}7z : {2}{0}Advanscene : {3}", " || ", Path.GetFileNameWithoutExtension(file), adata.Crc.ToString("X"), rom.RomCRC));
                                //ReportProgress(NumEnCours * 100 / NbFiles, Path.GetFileNameWithoutExtension(file));
                                NumEnCours++;
                            }
                        }
                    }
                }
                else
                {
                    ReportProgress(NumEnCours * 100 / NbFiles);
                    NumEnCours++;
                }
            }
        }
    }
}
