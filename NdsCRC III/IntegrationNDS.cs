﻿//-----------------------------------------------------------------------
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
    using NdsCRC_III.BusinessService;
    using Utils.Configuration;

    /// <summary>
    /// Integration form
    /// </summary>
    public partial class IntegrationNDS : Form
    {
        /// <summary>
        /// path to scan for new rom ??
        /// </summary>
        private string pathToScan;

        /// <summary>
        /// worker for integration
        /// </summary>
        private BW_Integration bw;

        /// <summary>
        /// DataTable for the avancement
        /// </summary>
        private DataTable avancement = new DataTable();

        /// <summary>
        /// Constructor for IntegrationNDS
        /// </summary>
        /// <param name="path">Path to Scan</param>
        public IntegrationNDS(string path)
        {
            InitializeComponent();
            avancement.Columns.Add(Parameter.Lang.GetTranslate("IntegrateColumnWhatHappenTitle"));
            avancement.Columns.Add(Parameter.Lang.GetTranslate("IntegrateColumnFileNameTitle"));
            avancement.Columns.Add(Parameter.Lang.GetTranslate("IntegrateColumnRomNameTitle"));
            avancement.Columns.Add(Parameter.Lang.GetTranslate("IntegrateColumnCRCTitle"));
            avancement.Columns.Add(Parameter.Lang.GetTranslate("IntegrateColumnRomNumberTitle"));

            pathToScan = path;
        }

        /// <summary>
        /// Event when form show
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void IntegrationNDS_Shown(object sender, EventArgs e)
        {
            Scan();
        }

        /// <summary>
        /// Start the work
        /// </summary>
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
                listBox1.Items.Add(string.Format(Parameter.Lang.GetTranslate("IntegrateNdsFileFound"), files.Count));
                bw = new BW_Integration(files);
                bw.ProgressChanged += new ProgressChangedEventHandler(Bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
                bw.RunWorkerAsync();
            }
            else
            {
                listBox1.Items.Add(Parameter.Lang.GetTranslate("IntegrateNoNdsFileFound"));
                MajListBox();
                btnAbort.Text = Parameter.Lang.GetTranslate("Quit");
            }
        }

        /// <summary>
        /// Event when worker is finished
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                listBox1.Items.Add(Parameter.Lang.GetTranslate("Aborted"));
                this.Text = string.Format("{0} - {1}", Parameter.Lang.GetTranslate("Aborted"), Parameter.Lang.GetTranslate("Integrate-Nds"));
            }
            else
            {
                this.Text = string.Format("{0} - {1}", Parameter.Lang.GetTranslate("Completed"), Parameter.Lang.GetTranslate("Integrate-Nds"));
            }

            MajListBox();
            btnAbort.Text = Parameter.Lang.GetTranslate("Quit");
        }

        /// <summary>
        /// Event when Worker Progress Changed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ProgressChangedEventArgs</param>
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TOSortie tos = (TOSortie)e.UserState;
            switch (tos.TypeTO)
            {
                case TypeTOSortie.General:
                    progressBar1.Value = e.ProgressPercentage;
                    this.Text = string.Format("{0}% - {1}", e.ProgressPercentage.ToString("00"), Parameter.Lang.GetTranslate("Integrate-Nds"));

                    if (tos.WhatHappen != TypeAvancement.Nothing)
                    {
                        DataRow dr = avancement.NewRow();
                        dr[Parameter.Lang.GetTranslate("IntegrateColumnWhatHappenTitle")] = tos.WhatHappen.ToString();
                        dr[Parameter.Lang.GetTranslate("IntegrateColumnFileNameTitle")] = tos.FileName;
                        if (tos.RomInfo != null)
                        {
                            dr[Parameter.Lang.GetTranslate("IntegrateColumnRomNameTitle")] = tos.RomInfo.Title;
                            dr[Parameter.Lang.GetTranslate("IntegrateColumnCRCTitle")] = tos.RomInfo.RomCRC;
                            dr[Parameter.Lang.GetTranslate("IntegrateColumnRomNumberTitle")] = tos.RomInfo.RomNumber;
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

        /// <summary>
        /// To put the listbox to the last line
        /// </summary>
        private void MajListBox()
        {
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        #region Closing

        /// <summary>
        /// IntegrationNDS_FormClosing, cancel the worker
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">FormClosingEventArgs</param>
        private void IntegrationNDS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnAbort.Text != Parameter.Lang.GetTranslate("Quit"))
            {
                bw.CancelAsync();
            }
        }

        /// <summary>
        /// request abort
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnAbort_Click(object sender, EventArgs e)
        {
            if (btnAbort.Text == Parameter.Lang.GetTranslate("Quit"))
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

        /// <summary>
        /// Checkbox check changed Event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
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
