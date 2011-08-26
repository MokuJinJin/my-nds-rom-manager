using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using NdsCRC_III.BusinessService;
using NdsCRC_III.BusinessService.BW;
using System.Collections.Generic;

namespace NdsCRC_III
{
    public partial class IntegrationNDS : Form
    {
        public string MyProperty { get; set; }
        //private string[] files;
        //private NDS_Rom_Collection NdsCollection;
        private string pathToScan;
        private BW_Integration bw;
        private DataTable dtAvancement = new DataTable();

        public IntegrationNDS(string path)
        {
            InitializeComponent();
            dtAvancement.Columns.Add("WhatHappen");
            dtAvancement.Columns.Add("FileName");
            dtAvancement.Columns.Add("RomName");
            dtAvancement.Columns.Add("CRC");
            dtAvancement.Columns.Add("RomNumber");

            pathToScan = path;
        }
        private void IntegrationNDS_Shown(object sender, EventArgs e)
        {
            scan();
        }
        public void scan()
        {
            //NdsCollection = new NDS_Rom_Collection();
            //string[] ndsFiles = Directory.GetFiles(pathToScan, "*.nds", SearchOption.TopDirectoryOnly);
            //string[] zipFiles = Directory.GetFiles(pathToScan, "*.zip", SearchOption.TopDirectoryOnly);
            //string[] sevenZipFiles = Directory.GetFiles(pathToScan, "*.7z", SearchOption.TopDirectoryOnly);
            //string[] rarFiles = Directory.GetFiles(pathToScan, "*.rar", SearchOption.TopDirectoryOnly);

            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(pathToScan, "*.nds", SearchOption.TopDirectoryOnly));
            files.AddRange(Directory.GetFiles(pathToScan, "*.nd5", SearchOption.TopDirectoryOnly));
            files.AddRange(Directory.GetFiles(pathToScan, "*.zip", SearchOption.TopDirectoryOnly));
            files.AddRange(Directory.GetFiles(pathToScan, "*.7z", SearchOption.TopDirectoryOnly));
            files.AddRange(Directory.GetFiles(pathToScan, "*.rar", SearchOption.TopDirectoryOnly));


            if (files.Count > 0)
            {
                listBox1.Items.Add("Found " + files.Count.ToString() + " NDS file.");
                bw = new BW_Integration(files);
                bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                bw.RunWorkerAsync();
            }
            else
            {
                listBox1.Items.Add("No Rom Files found");
                MajListBox();
                btnAbort.Text = "Quit";
            }
        }
        
        
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                listBox1.Items.Add("Aborted.");
            }
            this.Text = "Complete - IntegrationNDS";
            MajListBox();
            btnAbort.Text = "Quit";
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TOSortie tos = (TOSortie)e.UserState;
            switch (tos.TypeTO)
            {
                case TypeTOSortie.General:
                    progressBar1.Value = e.ProgressPercentage;
                    this.Text = string.Format("{0}% - IntegrationNDS", e.ProgressPercentage.ToString("00"));

                    if (tos.WhatHappen != TypeAvancement.Nothing)
                    {
                        DataRow dr = dtAvancement.NewRow();
                        dr["WhatHappen"] = tos.WhatHappen.ToString();
                        dr["FileName"] = tos.FileName;
                        if (tos.RomInfo != null)
                        {
                            dr["RomName"] = tos.RomInfo.title;
                            dr["CRC"] = tos.RomInfo.RomCRC;
                            dr["RomNumber"] = tos.RomInfo.RomNumber;
                        }
                        dtAvancement.Rows.Add(dr);
                        GridResultat.DataSource = dtAvancement;
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
        
        //public DataTable Table()
        //{
        //    return NdsCollection.Table;
        //}
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

        private void btnAbort_Click(object sender, EventArgs e)
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

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            string Filter = "";
            if (chkAlreadyHave.Checked)
            {
                Filter += " WhatHappen = '" + TypeAvancement.RomAlreadyHave.ToString()+"'";
                if (chkIntegrated.Checked || chkNotFound.Checked)
                {
                    Filter += " or ";
                }
            }
            if (chkIntegrated.Checked)
            {
                Filter += " WhatHappen = '" + TypeAvancement.RomIntegrated.ToString() + "'";
                if (chkNotFound.Checked)
                {
                    Filter += " or ";
                }
            }
            if (chkBadDump.Checked)
            {
                Filter += " WhatHappen = '" + TypeAvancement.RomIntegratedBadDump.ToString() + "'";
                if (chkNotFound.Checked)
                {
                    Filter += " or ";
                }
            }
            if (chkNotFound.Checked)
            {
                Filter += " WhatHappen = '" + TypeAvancement.RomNotFound.ToString() + "'";
            }
            if (!chkNotFound.Checked && !chkIntegrated.Checked && !chkAlreadyHave.Checked && !chkBadDump.Checked)
            {
                Filter = " WhatHappen = 'nothing'";
            }
            DataView dv = dtAvancement.DefaultView;
            dv.RowFilter = Filter;
            GridResultat.DataSource = dv.ToTable();
        }

    }
}
