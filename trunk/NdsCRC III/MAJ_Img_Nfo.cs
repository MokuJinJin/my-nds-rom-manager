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

    /// <summary>
    /// Form for the update of Image and NFO
    /// </summary>
    public partial class MAJ_Img_Nfo : Form
    {
        /// <summary>
        /// for the download
        /// </summary>
        private WebClient client = new WebClient();

        /// <summary>
        /// list of the file to download
        /// </summary>
        private Queue<MajUrl> liste = new Queue<MajUrl>();

        /// <summary>
        /// Set it to true to have the form showing message box at the end
        /// </summary>
        private bool _showFinishMessage = true;

        /// <summary>
        /// Constructor for MAJ_Img_Nfo
        /// </summary>
        public MAJ_Img_Nfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the ShowFinnishMessage
        /// </summary>
        /// <param name="show">Set it to true to have the form showing message box at the end</param>
        public void SetShowFinishMessage(bool show)
        {
            _showFinishMessage = show;
        }

        /// <summary>
        /// Calculate the missing File and launch Download when finished
        /// </summary>
        public void StartDownloadAllMissingFiles()
        {
            label1.Text = "Checking files ...";
            label2.Text = "Not Downloading";

            BW_Maj_Img_Nfo bw = new BW_Maj_Img_Nfo();
            bw.ProgressChanged += new ProgressChangedEventHandler(Bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Event when Progress of Calculate the missing File change
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Args</param>
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Event when Calculate the missing File is complete
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Args, Result is a Queue-MajUrl-</param>
        public void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                if (_showFinishMessage)
                {
                    MessageBox.Show("Everything is there");
                }
                
                this.Close();
            }
        }

        /// <summary>
        /// Download a File In BackGround
        /// </summary>
        /// <param name="majurl">link of the file</param>
        private void DownloadFileInBackGround(MajUrl majurl)
        {
            Uri uri = new Uri(majurl.uri);
            client = new WebClient();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            client.DownloadFileAsync(uri, majurl.filepath);
        }

        /// <summary>
        /// Client Download Progress Changed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DownloadProgressChangedEventArgs</param>
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Client Download File Completed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">AsyncCompletedEventArgs</param>
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value++;
            if (liste.Count > 0)
            {
                label1.Text = string.Format("Download  {0} / {1}", progressBar1.Value, progressBar1.Maximum);
                MajUrl o = liste.Dequeue();
                label2.Text = string.Format("Downloading {0}", Path.GetFileName(o.uri));
                DownloadFileInBackGround(o);
            }
            else
            {
                if (_showFinishMessage)
                {
                    MessageBox.Show("Update done.");
                }
                
                this.Close();
            }
        }
    }
}
