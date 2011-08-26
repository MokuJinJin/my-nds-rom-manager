//-----------------------------------------------------------------------
// <copyright file="BW_DL.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III.BusinessService.BW
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
}
////    class BW_DL : BackgroundWorker
////    {
////        private TOSortieDL tos;
////        private Queue<NDS_Rom> queue;
////        public BW_DL()
////        {
////            this.WorkerReportsProgress = true;
////            this.WorkerSupportsCancellation = true;
////            this.DoWork += new DoWorkEventHandler(BW_DL_DoWork);
////        }

////        void BW_DL_DoWork(object sender, DoWorkEventArgs e)
////        {
////            TOEntreeDL toe = (TOEntreeDL)e.Argument;
////            switch (toe.What)
////            {
////                case EntreeDL.IMG:
////                    DlImg();
////                    break;
////                case EntreeDL.NFO:
////                    DlNfo();
////                    break;
////                case EntreeDL.BOTH:
////                    DlImg();
////                    DlNfo();
////                    break;
////            }
////        }

////        private void DlNfo()
////        {
////            ////int NbRom = AdvanceSceneDataBaseXML.DataBase.Rows.Count;
////            int NbRom = AdvanSceneDataBaseXML.AdvanSceneDataBase.Count;
////            tos = new TOSortieDL(NbRom);
////            for (int i = 0; i < NbRom; i++)
////            {
////                NDS_Rom rom = AdvanSceneDataBaseXML.AdvanSceneDataBase[i];
////                ////NDS_Rom rom = new NDS_Rom(AdvanceSceneDataBaseXML.DataBase.Rows[i]);
////                string nfo = string.Format("{0}{1}.nfo", NDSDirectories.PathNfo, rom.releaseNumber);
////                if (File.Exists(nfo))
////                {
////                    //// Si le fichier fait zéro ko
////                    ////FileInfo fi = new FileInfo(nfo);
////                    ////if (fi.Length < 17)
////                    ////{
////                    ////    System.Windows.Forms.MessageBox.Show("have mais petit");
////                    ////}
////                }
////                else
////                {
////                    ////System.Windows.Forms.MessageBox.Show("Does not Have " + nfo);
////                    Download dl = new Download(true);
////                    dl.FormClosed += new System.Windows.Forms.FormClosedEventHandler(dl_FormClosed);
////                    dl.Show(dl.getUriFor(int.Parse(rom.releaseNumber), NDSCRC_URI.Nfo), NDSDirectories.PathNfo + rom.releaseNumber + ".nfo", "Downloading Nfo ...");
////                }
////            }
////        }

////        void dl_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
////        {
////            ReportProgress(tos.Avance(), tos);
////        }

////        private void DlImg()
////        {
////            int NbRom = AdvanSceneDataBaseXML.AdvanSceneDataBase.Count;
////            tos = new TOSortieDL(NbRom);
////            queue = new Queue<NDS_Rom>();
////            for (int i = 0; i < NbRom; i++)
////            {
////                queue.Enqueue(AdvanSceneDataBaseXML.AdvanSceneDataBase[i]);
////            }

////            NDS_Rom rom = queue.Dequeue(); 
////            string file = string.Format("{0}{1}a.png", NDSDirectories.PathImg, rom.releaseNumber);
////            while (File.Exists(file))
////            {
////                rom = queue.Dequeue();
////                file = string.Format("{0}{1}a.png", NDSDirectories.PathImg, rom.releaseNumber);
////            }

////            Download dl = new Download(true);
////            dl.FormClosed += new System.Windows.Forms.FormClosedEventHandler(dl_FormClosed_img);
////            dl.Show(dl.getUriFor(int.Parse(rom.releaseNumber), NDSCRC_URI.Cover), file, string.Empty);
////        }

////        void dl_FormClosed_img(object sender, System.Windows.Forms.FormClosedEventArgs e)
////        {
////            if (queue.Count > 0)
////            {
////                NDS_Rom rom = queue.Dequeue();
////                string file = string.Format("{0}{1}a.png", NDSDirectories.PathImg, rom.releaseNumber);
////                while (File.Exists(file))
////                {
////                    rom = queue.Dequeue();
////                    file = string.Format("{0}{1}a.png", NDSDirectories.PathImg, rom.releaseNumber);
////                }

////                Download dl = new Download(true);
////                dl.FormClosed += new System.Windows.Forms.FormClosedEventHandler(dl_FormClosed_img);
////                dl.Show(dl.getUriFor(int.Parse(rom.releaseNumber), NDSCRC_URI.Cover), string.Format("{0}{1}a.png", NDSDirectories.PathImg, rom.releaseNumber), string.Empty);    
////            }
////        }
////    }

////    class TOEntreeDL
////    {
////        public EntreeDL What { get; private set; }
////        public TOEntreeDL(EntreeDL what)
////        {
////            What = what;
////        }
////    }

////    public enum EntreeDL
////    {
////        IMG,
////        NFO,
////        BOTH
////    }

////    class TOSortieDL
////    {
////        public int NbMax { get; private set; }
////        public int NumEnCours { get; private set; }
////        public TOSortieDL(int Nboccurence)
////        {
////            NbMax = Nboccurence;
////        }

////        public int Avance()
////        {
////            NumEnCours++;
////            return (int)Math.Floor((double)((NumEnCours) * 100 / NbMax));
////        }
////    }
////}
