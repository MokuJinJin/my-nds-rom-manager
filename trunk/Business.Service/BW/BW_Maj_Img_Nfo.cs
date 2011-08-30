//-----------------------------------------------------------------------
// <copyright file="BW_Maj_Img_Nfo.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace BusinessService.BW
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    using NdsCRC_III;
    using NdsCRC_III.DAL;

    /// <summary>
    /// Worker for Downloading all image and nfo
    /// </summary>
    public class BW_Maj_Img_Nfo : BackgroundWorker
    {
        /// <summary>
        /// Constructor of the worker
        /// </summary>
        public BW_Maj_Img_Nfo()
        {
            WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(bw_maj_img_nfo_DoWork);
        }

        /// <summary>
        /// Work of the worker
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DoWorkEventArgs</param>
        void bw_maj_img_nfo_DoWork(object sender, DoWorkEventArgs e)
        {
            Queue<MajUrl> Liste = new Queue<MajUrl>();
            // for (int i = 0; i < AdvanSceneDataBaseXML.AdvanSceneDataBase.Count; i++)
            for (int i = 0; i < DataAcessLayer.NdsAdvanScene.Count; i++)
            {
                int releaseNumber = int.Parse(DataAcessLayer.NdsAdvanScene[i].ReleaseNumber);
                string filePath = string.Format("{0}{1}.png", NDSDirectories.PathImg, releaseNumber.ToString("0000"));
                if (!File.Exists(filePath))
                {
                    Liste.Enqueue(new MajUrl()
                    {
                        uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlIco),
                        filepath = filePath
                    });
                }
                filePath = string.Format("{0}{1}a.png", NDSDirectories.PathImg, releaseNumber.ToString("0000"));
                if (!File.Exists(filePath))
                {
                    Liste.Enqueue(new MajUrl() { uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlCover), filepath = filePath });
                }
                filePath = string.Format("{0}{1}b.png", NDSDirectories.PathImg, releaseNumber.ToString("0000"));
                if (!File.Exists(filePath))
                {
                    Liste.Enqueue(new MajUrl() { uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlInGame), filepath = filePath });
                }
                filePath = string.Format("{0}{1}.nfo", NDSDirectories.PathNfo, releaseNumber.ToString("0000"));
                if (!File.Exists(filePath))
                {
                    Liste.Enqueue(new MajUrl() { uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlNfo), filepath = filePath });
                }
                ReportProgress(i * 100 / DataAcessLayer.NdsAdvanScene.Count);
            }
            e.Result = Liste;
        }
    }
}
