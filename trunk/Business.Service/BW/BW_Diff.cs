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
            ////Dictionary<string, string> Files = (Dictionary<string, string>)e.Argument;
            ////@"E:\Games\-=Mes Documents=-\Visual Studio 2008\Projects\AdvanceSceneDiff\ADVANsCEne_NDScrc_2010-07-16.xml"
            XMLExplorateur xexplo = new XMLExplorateur(_xmlAvant);
            XmlDocument xdoc = new XmlDocument();
            ////@"E:\Games\-=Mes Documents=-\Visual Studio 2008\Projects\AdvanceSceneDiff\ADVANsCEne_NDScrc_2010-07-28.xml"
            xdoc.Load(_xmlApres);
            int max = xdoc.ChildNodes[1].ChildNodes[1].ChildNodes.Count;
            for (int i = 0; i < max; i++)
            {
                XmlNode xnode = xdoc.ChildNodes[1].ChildNodes[1].ChildNodes[i];
                if (xexplo.Search(XPathSearch.romCRC, xnode.ChildNodes[9].ChildNodes[0].InnerText))
                {
                    ReportProgress((i + 1) * 100 / max, null);
                    ////MessageBox.Show("Founded");
                }
                else
                {
                    if (xexplo.Search(XPathSearch.releaseNumber, xnode.ChildNodes[1].InnerText))
                    {
                        ReportProgress((i + 1) * 100 / max, string.Format("MODIFY ({0}) {2}|{1}", xnode.ChildNodes[23].InnerText, xnode.ChildNodes[20].InnerText, xnode.ChildNodes[2].InnerText));
                    }
                    else
                    {
                        ReportProgress((i + 1) * 100 / max, string.Format("NEW ({0}) {2}|{1}", xnode.ChildNodes[23].InnerText, xnode.ChildNodes[20].InnerText, xnode.ChildNodes[2].InnerText));
                    }
                }
            }
        }

        private void Bw_DoWork2(object sender, DoWorkEventArgs e)
        {
            
            List<NDS_Rom> xmlAvant = new List<NDS_Rom>();
            XmlSerializer xs = new XmlSerializer(typeof(List<NDS_Rom>));
            using (StreamReader rd = new StreamReader(_xmlAvant))
            {
                xmlAvant = xs.Deserialize(rd) as List<NDS_Rom>;
            }

            List<NDS_Rom> xmlApres = new List<NDS_Rom>();
            xs = new XmlSerializer(typeof(List<NDS_Rom>));
            using (StreamReader rd = new StreamReader(_xmlApres))
            {
                xmlApres = xs.Deserialize(rd) as List<NDS_Rom>;
            }

            IEqualityComparer<NDS_Rom> comparerRomNumberAndCRC = new LambdaComparer<NDS_Rom>(
                (o, n) =>
                    o.ReleaseNumber == n.ReleaseNumber &&
                    o.RomCRC == n.RomCRC
                );
            List<NDS_Rom> diff = xmlApres.Except(xmlAvant, comparerRomNumberAndCRC).ToList();
            
            IEqualityComparer<NDS_Rom> comparerRomNumber = new LambdaComparer<NDS_Rom>(
                (o, n) =>
                    o.ReleaseNumber == n.ReleaseNumber
                );
            List<NDS_Rom> diffCRC = xmlApres.Intersect(diff, comparerRomNumber).ToList();
        }
    }
}
