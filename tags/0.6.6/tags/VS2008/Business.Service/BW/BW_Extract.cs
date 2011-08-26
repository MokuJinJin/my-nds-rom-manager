//-----------------------------------------------------------------------
// <copyright file="BW_Extract.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III.BusinessService.BW
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using SevenZip;

    /// <summary>
    /// BackgroundWorker which extract rom
    /// </summary>
    public class BW_Extract : BackgroundWorker
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="zipRomPath">Path to the zipped rom</param>
        /// <param name="extractPath">Path where rom will be extracted</param>
        public BW_Extract(string zipRomPath, string extractPath)
        {
            ZipRomPath = zipRomPath;
            ExtractPath = extractPath;
            this.WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(BW_Extract_DoWork);
        }

        /// <summary>
        /// Path to the zipped rom
        /// </summary>
        public string ZipRomPath { get; private set; }

        /// <summary>
        /// Path where rom will be extracted
        /// </summary>
        public string ExtractPath { get; private set; }
        
        /// <summary>
        /// Work : Extract rom to path
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument : TOEntreeExtract</param>
        private void BW_Extract_DoWork(object sender, DoWorkEventArgs e)
        {
            SevenZipExtractor.SetLibraryPath("7z.dll");
            SevenZipExtractor extract = new SevenZipExtractor(ZipRomPath);
            extract.Extracting += new EventHandler<ProgressEventArgs>(Extract_Extracting);
            extract.ExtractionFinished += new EventHandler<EventArgs>(Extract_ExtractionFinished);
            extract.ExtractArchive(ExtractPath);
        }

        /// <summary>
        /// While extracting
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void Extract_Extracting(object sender, ProgressEventArgs e)
        {
            ReportProgress(e.PercentDone);
        }
        
        /// <summary>
        /// Finished extract
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument</param>
        private void Extract_ExtractionFinished(object sender, EventArgs e)
        {
        }
    }
}
