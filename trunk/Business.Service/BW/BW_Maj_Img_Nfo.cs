using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using NdsCRC_III.DAL;
using System.IO;
using NdsCRC_III;

namespace BusinessService.BW
{
    public class BW_Maj_Img_Nfo : BackgroundWorker
    {
        public BW_Maj_Img_Nfo()
        {
            WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(bw_maj_img_nfo_DoWork);
        }

        void bw_maj_img_nfo_DoWork(object sender, DoWorkEventArgs e)
        {
            Queue<MajUrl> Liste = new Queue<MajUrl>();
            // for (int i = 0; i < AdvanSceneDataBaseXML.AdvanSceneDataBase.Count; i++)
            for (int i = 0; i < DataAcessLayer.NdsAdvanScene.Count; i++)
            {
                int releaseNumber = int.Parse(DataAcessLayer.NdsAdvanScene[i].releaseNumber);
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
    public class MajUrl
    {
        public string uri;
        public string filepath;
    }
}
