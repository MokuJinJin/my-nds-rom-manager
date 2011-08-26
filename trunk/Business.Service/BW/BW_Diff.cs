//-----------------------------------------------------------------------
// <copyright file="BW_Diff.cs" company="Zed Byt Corp">
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
    using System.Xml;
    using DAL;
    using System.Xml.Serialization;
    using System.IO;

    /// <summary>
    /// BackgroundWorker which makes diff with old AdvanScene data and the new one
    /// </summary>
    public class BW_Diff : BackgroundWorker
    {
        /// <summary>
        /// Old AdvanScene Xml 
        /// </summary>
        private string _xmlAvant;

        /// <summary>
        /// New AdvanScene  Xml
        /// </summary>
        private string _xmlApres;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xmlAvant">Path to the old AdvanScene xml</param>
        /// <param name="xmlApres">Path to the new AdvanScene xml</param>
        public BW_Diff(string xmlAvant, string xmlApres)
        {
            _xmlApres = xmlApres;
            _xmlAvant = xmlAvant;
            this.WorkerReportsProgress = true;
            this.DoWork += new DoWorkEventHandler(Bw_DoWork);
        }

        /// <summary>
        /// Working job
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Argument to the work (none there)</param>
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ReportProgress(0, null);

            NDSAdvanScene xmlAvant = new NDSAdvanScene();
            xmlAvant.Load(_xmlAvant);
            NDSAdvanScene xmlApres = new NDSAdvanScene();
            xmlApres.Load(_xmlApres);

            ReportProgress(0, "Calculating Differences ...");

            IEqualityComparer<NDS_Rom> comparerCRC = new LambdaComparer<NDS_Rom>(
                (o, n) =>
                    o.RomCRC == n.RomCRC
                );
            List<NDS_Rom> diffAll = xmlApres.DataBase.Except(xmlAvant.DataBase, comparerCRC).ToList();
            ReportProgress(45, string.Format("Found {0} differences", diffAll.Count));

            IEqualityComparer<NDS_Rom> comparerRomNumber = new LambdaComparer<NDS_Rom>(
                (o, n) =>
                    o.ReleaseNumber == n.ReleaseNumber
                );
            List<NDS_Rom> diffNew = xmlApres.DataBase.Except(xmlAvant.DataBase, comparerRomNumber).ToList();
            ReportProgress(90, string.Format("Found {0} new Roms", diffNew.Count));

            List<NDS_Rom> diffModified = diffAll.Except(diffNew).ToList();
            ReportProgress(100, string.Format("Found {0} modified Roms", diffModified.Count));

            for (int i = 0; i < diffNew.Count; i++)
            {
                ReportProgress((i + 1) * 100 / diffAll.Count, string.Format("New Rom : {0}", diffNew[i].Title));
            }
            for (int i = 0; i < diffModified.Count; i++)
            {
                ReportProgress((i + 1 + diffNew.Count) * 100 / diffAll.Count, string.Format("Modified Rom : {0}", diffModified[i].Title));
            }
        }
    }
}
