//-----------------------------------------------------------------------
// <copyright file="MAJ_Img_Nfo.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
using BusinessService.BW;

namespace NdsCRC_III
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;

    public partial class MAJ_Img_Nfo : Form
    {
        private WebClient client = new WebClient();
        private Queue<MajUrl> liste = new Queue<MajUrl>();

        /// <summary>
        /// Constructor for MAJ_Img_Nfo
        /// </summary>
        public MAJ_Img_Nfo()
        {
            InitializeComponent();
        }

        public void Start()
        {
            label1.Text = "Checking files ...";
            label2.Text = "Not Downloading";

            BW_Maj_Img_Nfo bw = new BW_Maj_Img_Nfo();
            bw.ProgressChanged += new ProgressChangedEventHandler(Bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            liste = (Queue<MajUrl>)e.Result;
            if (liste.Count > 0)
            {
                progressBar1.Maximum = liste.Count;
                progressBar1.Value = 0;
                label1.Text = string.Format("Download  {0} / {1}", progressBar1.Value, liste.Count);
                MajUrl o = liste.Dequeue();
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
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            client.DownloadFileAsync(uri, majurl.filepath);
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value++;
            if (liste.Count > 0)
            {
                label1.Text = string.Format("Download  {0} / {1}", progressBar1.Value, progressBar1.Maximum);
                client = new WebClient();
                MajUrl o = liste.Dequeue();
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
