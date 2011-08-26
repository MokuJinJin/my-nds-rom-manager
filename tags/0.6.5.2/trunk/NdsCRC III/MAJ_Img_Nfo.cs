using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System;
using BusinessService.BW;

namespace NdsCRC_III
{
    public partial class MAJ_Img_Nfo : Form
    {
        private WebClient client = new WebClient();
        Queue<MajUrl> Liste = new Queue<MajUrl>();
        //int NbDownload = 0;
        public MAJ_Img_Nfo()
        {
            InitializeComponent();
        }
        public void Start()
        {
            label1.Text = "Checking files ...";
            label2.Text = "Not Downloading";

            BW_Maj_Img_Nfo bw = new BW_Maj_Img_Nfo();
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
            
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Liste = (Queue<MajUrl>)e.Result;
            if (Liste.Count > 0)
            {
                progressBar1.Maximum = Liste.Count;
                progressBar1.Value = 0;
                label1.Text = string.Format("Download  {0} / {1}",progressBar1.Value, Liste.Count);
                MajUrl o = Liste.Dequeue();
                label2.Text = string.Format("Downloading {0}", Path.GetFileName(o.uri));
                DownloadFileInBackGround(o);
            }
            else
            {
                MessageBox.Show("Everything is there");
                this.Close();
            }
            
        }

        private void DownloadFileInBackGround(MajUrl majurl)
        {
            Uri uri = new Uri(majurl.uri);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileAsync(uri, majurl.filepath);
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value++;
            if (Liste.Count > 0)
            {
                label1.Text = string.Format("Download  {0} / {1}", progressBar1.Value, progressBar1.Maximum );
                client = new WebClient();
                MajUrl o = Liste.Dequeue();
                label2.Text = string.Format("Downloading {0}", Path.GetFileName(o.uri));
                DownloadFileInBackGround(o);
            }
            else
            {
                MessageBox.Show("Update done.");
                this.Close();
            }
        }
    }
}
