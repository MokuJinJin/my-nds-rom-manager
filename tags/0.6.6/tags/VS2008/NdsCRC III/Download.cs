//-----------------------------------------------------------------------
// <copyright file="Download.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using System.Windows.Forms;

    #region Exemple
    /*
    DownLoadFileInBackground2("http://www.retrocovers.com/offline/imgs/ADVANsCEne_NDS/3501-4000/3919b.png", "3919.png");
    DownLoadFileInBackground2("http://www.advanscene.com/offline/nfo/NDSnfo/3501-4000/3919.nfo", "3919.nfo");
    DownLoadFileInBackground2("http://www.advanscene.com/offline/datas/ADVANsCEne_NDScrc.zip", "ADVANsCEne_NDScrc.zip");
    "http://www.advanscene.com/offline/version/ADVANsCEne_NDScrc.txt",
     */
    #endregion

    /// <summary>
    /// Form used to download
    /// </summary>
    public partial class Download : Form
    {
        /// <summary>
        /// Object to download Async
        /// </summary>
        private WebClient client = new WebClient();
        
        /// <summary>
        /// The form will close automaticly ?
        /// </summary>
        private bool _autoclose = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public Download()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="autoClose">Auto close ?</param>
        public Download(bool autoClose)
        {
            this._autoclose = autoClose;
            InitializeComponent();
        }
        
        /// <summary>
        /// The form will close automaticly ?
        /// </summary>
        public bool AutoClose
        {
            get
            {
                return this._autoclose;
            }

            set
            {
                _autoclose = value;
                chkAutoQuit.Checked = value;
            }
        }

        /// <summary>
        /// Close the form and cancel download
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void BtnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Cancel")
            {
                client.CancelAsync();
                this.Close();
            } 
            else 
            {
                this.Close();
            }
        }

        /// <summary>
        /// Start the download
        /// </summary>
        /// <param name="address">URL to download</param>
        /// <param name="fileName">File name will have the file downloaded</param>
        private void DownLoadFileInBackground(string address, string fileName)
        {
            Uri uri = new Uri(address);
            
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
            client.DownloadFileAsync(uri, fileName);
        }
        
        /// <summary>
        /// DownloadProgressCallback
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Maximum = int.Parse(e.TotalBytesToReceive.ToString());
            progressBar1.Value = int.Parse(e.BytesReceived.ToString());
            lblDownload.Text = e.ProgressPercentage + " % complete...";
        }
        
        /// <summary>
        /// DownloadFileCallback
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
        {
            btnAction.Text = "Quit";
            if (_autoclose)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Start the download without showning the form
        /// </summary>
        /// <param name="url">URL to download</param>
        /// <param name="fileName">File name on the computer</param>
        /// <param name="formText">Text of the form (will be show in the windows status bar)</param>
        public void ShowHidden(string url, string fileName, string formText)
        {
            this.Text = formText;
            chkAutoQuit.Checked = _autoclose;
            DownLoadFileInBackground(url, fileName);
        }
        
        /// <summary>
        /// Show the form
        /// </summary>
        /// <param name="url">URL to download</param>
        /// <param name="fileName">File name on the computer</param>
        /// <param name="formText">Text of the form (will be show in the windows status bar)</param>
        public void Show(string url, string fileName, string formText)
        {
            base.Show();
            ShowHidden(url, fileName, formText);
        }
        
        /// <summary>
        /// active/deactive auto close
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Argument</param>
        private void ChkAutoQuit_CheckedChanged(object sender, EventArgs e)
        {
            _autoclose = chkAutoQuit.Checked;
        }

        public void ShowDialog(string url, string fileName, string formText)
        {
            base.ShowDialog();
            ShowHidden(url, fileName, formText);
        }
    }
}
