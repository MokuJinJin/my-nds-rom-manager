//-----------------------------------------------------------------------
// <copyright file="IntegrationNDS.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;
    using NdsCRC_III.BusinessService.BW;

    public partial class IntegrationNDS : Form
    {
        private string pathToScan;
        private BW_Integration bw;
        private DataTable avancement = new DataTable();
        
        /// <summary>
        /// Constructor for IntegrationNDS
        /// </summary>
        /// <param name="path">Path to Scan</param>
        public IntegrationNDS(string path)
        {
            InitializeComponent();
            avancement.Columns.Add("WhatHappen");
            avancement.Columns.Add("FileName");
            avancement.Columns.Add("RomName");
            avancement.Columns.Add("CRC");
            avancement.Columns.Add("RomNumber");

            pathToScan = path;
        }

        private void IntegrationNDS_Shown(object sender, EventArgs e)
        {
            Scan();
        }

        public void Scan()
        {
            /*
            //NdsCollection = new NDS_Rom_Collection();
            //string[] ndsFiles = Directory.GetFiles(pathToScan, "*.nds", SearchOption.TopDirectoryOnly);
            //string[] zipFiles = Directory.GetFiles(pathToScan, "*.zip", SearchOption.TopDirectoryOnly);
            //string[] sevenZipFiles = Directory.GetFiles(pathToScan, "*.7z", SearchOption.TopDirectoryOnly);
            //string[] rarFiles = Directory.GetFiles(pathToScan, "*.rar", SearchOption.TopDirectoryOnly);
            */

            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(pathToScan, "*.nds", SearchOption.TopDirectoryOnly));
            files.AddRange(Directory.GetFiles(pathToScan, "*.nd5", SearchOption.TopDirectoryOnly));
            /*
            //files.AddRange(Directory.GetFiles(pathToScan, "*.zip", SearchOption.TopDirectoryOnly));
            //files.AddRange(Directory.GetFiles(pathToScan, "*.7z", SearchOption.TopDirectoryOnly));
            //files.AddRange(Directory.GetFiles(pathToScan, "*.rar", SearchOption.TopDirectoryOnly));
            */

            if (files.Count > 0)
            {
                listBox1.Items.Add("Found " + files.Count.ToString() + " NDS file.");
                bw = new BW_Integration(files);
                bw.ProgressChanged += new ProgressChangedEventHandler(Bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
                bw.RunWorkerAsync();
            }
            else
            {
                listBox1.Items.Add("No Rom Files found");
                MajListBox();
                btnAbort.Text = "Quit";
            }
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                listBox1.Items.Add("Aborted.");
                this.Text = "Aborted - IntegrationNDS";
            }
            else
            {
                this.Text = "Complete - IntegrationNDS";
            }

            MajListBox();
            btnAbort.Text = "Quit";
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TOSortie tos = (TOSortie)e.UserState;
            switch (tos.TypeTO)
            {
                case TypeTOSortie.General:
                    progressBar1.Value = e.ProgressPercentage;
                    this.Text = string.Format("{0}% - IntegrationNDS", e.ProgressPercentage.ToString("00"));

                    if (tos.WhatHappen != TypeAvancement.Nothing)
                    {
                        DataRow dr = avancement.NewRow();
                        dr["WhatHappen"] = tos.WhatHappen.ToString();
                        dr["FileName"] = tos.FileName;
                        if (tos.RomInfo != null)
                        {
                            dr["RomName"] = tos.RomInfo.Title;
                            dr["CRC"] = tos.RomInfo.RomCRC;
                            dr["RomNumber"] = tos.RomInfo.RomNumber;
                        }

                        avancement.Rows.Add(dr);
                        GridResultat.DataSource = avancement;
                    }

                    listBox1.Items.Add(tos.IntituleTraitement);

                    lblRomNotFound.Text = string.Format("{0} Rom(s) not Found in DB", tos.NbRomNotFound);
                    lblTotalRom.Text = tos.NbFichier.ToString();
                    lblNbRom.Text = tos.NbActuel.ToString();
                    lblNbFound.Text = string.Format("{0} Rom(s) Found in DB", tos.NbRomAlreadyHave + tos.NbRomIntegrated);
                    LblAlreadyHave.Text = string.Format("{0} Rom(s) Already Have", tos.NbRomAlreadyHave.ToString());
                    LblIntegrated.Text = string.Format("{0} Rom(s) Integrated", tos.NbRomIntegrated.ToString());

                    MajListBox();

                    break;
                case TypeTOSortie.Zip:
                    LblInfos.Text = tos.IntituleTraitement;
                    pb_Zip.Value = e.ProgressPercentage;
                    break;
                default:
                    break;
            }
        }

        private void MajListBox()
        {
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        #region Closing
        private void IntegrationNDS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnAbort.Text != "Quit")
            {
                bw.CancelAsync();
            }
        }

        private void BtnAbort_Click(object sender, EventArgs e)
        {
            if (btnAbort.Text == "Quit")
            {
                Close();
            }
            else
            {
                bw.CancelAsync();
                listBox1.Items.Add("Requesting Abort ...");
                MajListBox();
            }
        }
        #endregion

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            string filter = string.Empty;
            if (chkAlreadyHave.Checked)
            {
                filter += " WhatHappen = '" + TypeAvancement.RomAlreadyHave.ToString() + "'";
                if (chkIntegrated.Checked || chkNotFound.Checked)
                {
                    filter += " or ";
                }
            }

            if (chkIntegrated.Checked)
            {
                filter += " WhatHappen = '" + TypeAvancement.RomIntegrated.ToString() + "'";
                if (chkNotFound.Checked)
                {
                    filter += " or ";
                }
            }

            if (chkBadDump.Checked)
            {
                filter += " WhatHappen = '" + TypeAvancement.RomIntegratedBadDump.ToString() + "'";
                if (chkNotFound.Checked)
                {
                    filter += " or ";
                }
            }

            if (chkNotFound.Checked)
            {
                filter += " WhatHappen = '" + TypeAvancement.RomNotFound.ToString() + "'";
            }

            if (!chkNotFound.Checked && !chkIntegrated.Checked && !chkAlreadyHave.Checked && !chkBadDump.Checked)
            {
                filter = " WhatHappen = 'nothing'";
            }

            DataView dv = avancement.DefaultView;
            dv.RowFilter = filter;
            GridResultat.DataSource = dv.ToTable();
        }
    }
}
