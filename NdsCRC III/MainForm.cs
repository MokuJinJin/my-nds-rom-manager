//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using NdsCRC_III.BusinessService;
    using NdsCRC_III.TO;
    using Utils.Configuration;
    using Utils.Directories;

    /// <summary>
    /// Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// sourceCollection
        /// </summary>
        private BindingSource sourceCollection = new BindingSource();

        /// <summary>
        /// sourceAdvanScene
        /// </summary>
        private BindingSource sourceAdvanScene = new BindingSource();

        /// <summary>
        /// sourceMissing
        /// </summary>
        private BindingSource sourceMissing = new BindingSource();

        /// <summary>
        /// sourceFilter
        /// </summary>
        private BindingSource sourceFilter = new BindingSource();

        /// <summary>
        /// Controler of the form
        /// </summary>
        private MFControler _controler;

        /// <summary>
        /// Constructor for MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _controler = new MFControler();

            Thread.CurrentThread.CurrentCulture = Parameter.Config.Culture;

            sourceAdvanScene.DataSource = _controler.GetDataBase();
            GridDataBase.DataSource = sourceAdvanScene;
            sourceCollection.DataSource = _controler.GetCollection();
            GridCollection.DataSource = sourceCollection;
            sourceMissing.DataSource = _controler.GetCollectionMissing();
            GridMissing.DataSource = sourceMissing;

            sourceFilter.DataSource = _controler.GetFilterLocation();
            GridFilterLocation.DataSource = sourceFilter;

            InitDataGrid(GridCollection);
            InitDataGrid(GridDataBase);
            InitDataGrid(GridMissing);

            InitDataGrid(GridFilterLocation);

            tabFilterLocation.Hide();

            cbxLanguages.DataSource = new BindingSource(_controler.GetLanguages(), null);
            cbxLanguages.DisplayMember = "Value";
            cbxLanguages.ValueMember = "Key";

            SetLblNbRom();

            this.Text = string.Format("NdsCRC III v{0} - AdvanceSceneDat v{1} ({2})", ProductVersion, _controler.DatVersion, _controler.DatCreationDate);
        }

        #region Button Event and clicks
        /// <summary>
        /// Start the integration
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnGetNewRom_Click(object sender, EventArgs e)
        {
            IntegrationNDS f = new IntegrationNDS(Parameter.Config.Paths.DirNewRom);
            btnGetNewRom.Enabled = false;
            f.FormClosed += new FormClosedEventHandler(F_FormClosed);
            f.Show();
        }

        /// <summary>
        /// Set Duplicate filter
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnFilterDuplicate_Click(object sender, EventArgs e)
        {
            NDS_Rom currentRom = _controler.GetCurrentRom();
            string tabname = string.Format("{0} #{1}", Parameter.Lang.GetTranslate("TabFilterLocation"), currentRom.RomNumber);

            TabPage tab = tabControl2.TabPages[3];
            tab.Show();
            tab.Name = tabname;
            
            /*
            if (_controler.IsDuplicateFilterActive())
            {
                _controler.SetNoDuplicateFilter();
                btnFilterDuplicate.Text = Parameter.Lang.GetTranslate("btnFilterDuplicate_Apply");
            }
            else
            {
                _controler.SetDuplicateFilterFromCurrentRom();
                btnFilterDuplicate.Text = Parameter.Lang.GetTranslate("btnFilterDuplicate_Reset");
            }

            _controler.SetCurrentGridView(string.Empty);
            SetDataSource();
            */
        }

        /// <summary>
        /// Download all missing img/nfo
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnMAJ_Img_NFO_Click(object sender, EventArgs e)
        {
            MAJ_Img_Nfo maj = new MAJ_Img_Nfo();
            maj.Show();
            maj.StartDownloadAllMissingFiles();
        }

        /// <summary>
        /// RepairCollection
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void RepairCollection_Click(object sender, EventArgs e)
        {
            _controler.RepairCollection();
            MessageBox.Show("Done");
        }

        /// <summary>
        /// Update image nfo of the selected rom
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void DonwloadOneRomImage_Click(object sender, EventArgs e)
        {
            MAJ_Img_Nfo maj = new MAJ_Img_Nfo();
            maj.FormClosed += new FormClosedEventHandler(Maj_FormClosed);
            maj.SetShowFinishMessage(false);

            int releaseNumber = int.Parse(_controler.GetCurrentRom().ReleaseNumber);
            string filePath = string.Format("{0}{1}.png", Parameter.Config.Paths.DirImage, releaseNumber.ToString("0000"));
            Queue<MajUrl> liste = new Queue<MajUrl>();
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl() { Uri = Directories.GetUriFor(releaseNumber, DirectoriesEnum.UrlIco), Filepath = filePath });
            }

            filePath = string.Format("{0}{1}a.png", Parameter.Config.Paths.DirImage, releaseNumber.ToString("0000"));
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl() { Uri = Directories.GetUriFor(releaseNumber, DirectoriesEnum.UrlCover), Filepath = filePath });
            }

            filePath = string.Format("{0}{1}b.png", Parameter.Config.Paths.DirImage, releaseNumber.ToString("0000"));
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl() { Uri = Directories.GetUriFor(releaseNumber, DirectoriesEnum.UrlInGame), Filepath = filePath });
            }

            filePath = string.Format("{0}{1}.nfo", Parameter.Config.Paths.DirNFO, releaseNumber.ToString("0000"));
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl() { Uri = Directories.GetUriFor(releaseNumber, DirectoriesEnum.UrlNfo), Filepath = filePath });
            }

            maj.Bw_RunWorkerCompleted(null, new RunWorkerCompletedEventArgs(liste, null, false));

            maj.Show();
        }

        /// <summary>
        /// AdvansceneLink_LinkClicked
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void AdvansceneLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = string.Format("http://www.advanscene.com/html/Releases/dbrelds.php?id={0}", _controler.GetCurrentRom().ReleaseNumber);
            System.Diagnostics.Process.Start(link);
        }

        /// <summary>
        /// Make the Repair Button visible
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void ImgLocation_DoubleClick(object sender, EventArgs e)
        {
            btnRepair.Visible = !btnRepair.Visible;
        }

        /// <summary>
        /// Chk_DemoRomVisibility_CheckedChanged
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void Chk_DemoRomVisibility_CheckedChanged(object sender, EventArgs e)
        {
            _controler.SetFilterDemo(chk_DemoRomVisibility.Checked);

            // tabControl2_SelectedIndexChanged(null, new EventArgs());
            // setLblNbRom();
            SetDataSource();
        }

        #endregion

        /// <summary>
        /// Update the number of rom to display on the tabs
        /// </summary>
        private void SetLblNbRom()
        {
            // tabCollection.Text = string.Format("{0} ({1} roms)", Lang.TabCollection, _controler.GetCollection().Count);
            tabCollection.Text = string.Format("{0} ({1} {2})", Parameter.Lang.GetTranslate("TabCollection"), _controler.GetCollection().Count, Parameter.Lang.GetTranslate("Roms"));
            tabDataBase.Text = string.Format("{0} ({1} {2})", Parameter.Lang.GetTranslate("TabDataBase"), _controler.GetDataBase().Count, Parameter.Lang.GetTranslate("Roms"));
            tabMissing.Text = string.Format("{0} ({1} {2})", Parameter.Lang.GetTranslate("TabMissing"), _controler.GetCollectionMissing().Count, Parameter.Lang.GetTranslate("Roms"));
        }

        /// <summary>
        /// IntegrationNDS Close Event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">FormClosedEventArgs</param>
        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnGetNewRom.Enabled = true;
            _controler.ReloadAdvanSceneDataBase();
        }

        /// <summary>
        /// Initialize DataGrid
        /// </summary>
        /// <param name="grid">DataGrid to initialize</param>
        private void InitDataGrid(DataGridView grid)
        {
            grid.Columns["ImageNumber"].Visible = false;
            grid.Columns["ImgCoverPath"].Visible = false;
            grid.Columns["ImgInGamePath"].Visible = false;
            grid.Columns["ReleaseNumber"].Visible = false;
            grid.Columns["SaveType"].Visible = false;
            grid.Columns["RomSize"].Visible = false;
            grid.Columns["Publisher"].Visible = false;
            grid.Columns["Location"].Visible = false;
            grid.Columns["SourceRom"].Visible = false;
            grid.Columns["languageString"].Visible = false;
            grid.Columns["RomCRC"].Visible = false;
            grid.Columns["ImgCoverCRC"].Visible = false;
            grid.Columns["ImgInGameCRC"].Visible = false;
            grid.Columns["IcoCRC"].Visible = false;
            grid.Columns["NfoCRC"].Visible = false;
            grid.Columns["Genre"].Visible = false;
            grid.Columns["DumpDate"].Visible = false;
            grid.Columns["InternalName"].Visible = false;
            grid.Columns["Serial"].Visible = false;
            grid.Columns["Version"].Visible = false;
            grid.Columns["Wifi"].Visible = false;
            grid.Columns["duplicateid"].Visible = false;
            grid.Columns["ImgCoverPath"].Visible = false;
            grid.Columns["ImgInGamePath"].Visible = false;
            grid.Columns["FlagPath"].Visible = false;
            grid.Columns["ImgIconPath"].Visible = false;
            grid.Columns["NfoPath"].Visible = false;
            grid.Columns["RomPath"].Visible = false;
            grid.Columns["RomExist"].Visible = false;
            grid.Columns["ExternalFileName"].Visible = false;
            grid.Columns["ExternalDirName"].Visible = false;

            grid.Columns["Icon"].DisplayIndex = 0;
            grid.Columns["Icon"].ValueType = typeof(Image);
            grid.Columns["Icon"].Visible = true;
            grid.Columns["Icon"].Width = 34;
            grid.Columns["Icon"].SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Columns["RomNumber"].Visible = true;
            grid.Columns["RomNumber"].DisplayIndex = 1;
            grid.Columns["RomNumber"].HeaderText = "#";
            grid.Columns["RomNumber"].Width = 40;

            grid.Columns["Title"].Visible = true;
            grid.Columns["Title"].DisplayIndex = 2;
            grid.Columns["Title"].Width = 390;

            grid.ClearSelection();

            grid.GridColor = Color.White;

            grid.Sort(grid.Columns["RomNumber"], ListSortDirection.Ascending);
        }

        /// <summary>
        /// DataBinding of the selected Rom
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <param name="e">EventArgs</param>
        private void Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.SelectedRows.Count == 1)
            {
                if (dgv["ReleaseNumber", dgv.SelectedRows[0].Index].Value != null)
                {
                    _controler.SetCurrentNdsRom(dgv["ReleaseNumber", dgv.SelectedRows[0].Index].Value.ToString());
                }

                NDS_Rom currentRom = _controler.GetCurrentRom();
                lblLanguage.Text = currentRom.LanguageString;
                lblCRC.Text = currentRom.RomCRC;
                lblGenre.Text = currentRom.Genre;
                lblPublisher.Text = currentRom.Publisher;
                lblSaveType.Text = currentRom.SaveType;
                lblSize.Text = currentRom.RomSize;
                lblSource.Text = currentRom.SourceRom;
                lblSerial.Text = currentRom.Serial;
                lblInternalName.Text = currentRom.InternalName;
                lblVersion.Text = currentRom.Version;
                lblReleaseNumber.Text = currentRom.ReleaseNumber;
                lblDumpDate.Text = currentRom.DumpDate.ToShortDateString();

                txtDirName.Text = currentRom.ExternalDirName;
                txtFileName.Text = currentRom.ExternalFileName;

                ImgCover.ImageLocation = currentRom.ImgCoverPath;
                ImgInGame.ImageLocation = currentRom.ImgInGamePath;
                ImgLocation.ImageLocation = currentRom.FlagPath;
                ImgIcon.ImageLocation = currentRom.ImgIconPath;

                if (currentRom.IsWifi())
                {
                    ImgWifi.Image = Properties.Resources.wifi;
                }
                else
                {
                    ImgWifi.Image = Properties.Resources.wifi_no;
                }

                richTextBox1.LoadFile(new StreamReader(currentRom.NfoPath, Encoding.GetEncoding(437)).BaseStream, RichTextBoxStreamType.PlainText);

                if (File.Exists(_controler.GetCurrentRom().RomPath))
                {
                    btnUnzip.Enabled = true;
                    btnUnzip.Text = Parameter.Lang.GetTranslate("btnUnzip_Enabled");
                }
                else
                {
                    btnUnzip.Enabled = false;
                    btnUnzip.Text = Parameter.Lang.GetTranslate("btnUnzip_Disabled");
                }

                if (_controler.GetCurrentRom().IsAllImagePresent())
                {
                    btnDownloadImgNfoOneRom.Enabled = false;
                    btnDownloadImgNfoOneRom.Text = Parameter.Lang.GetTranslate("btnDownloadImgNfoOneRom_Disabled");
                }
                else
                {
                    btnDownloadImgNfoOneRom.Enabled = true;
                    btnDownloadImgNfoOneRom.Text = Parameter.Lang.GetTranslate("btnDownloadImgNfoOneRom_Enabled");
                }

                if (_controler.GetCurrentRom().IsDuplicate())
                {
                    btnFilterDuplicate.Enabled = true;
                    if (_controler.IsDuplicateFilterActive())
                    {
                        btnFilterDuplicate.Text = Parameter.Lang.GetTranslate("btnFilterDuplicate_Reset");
                    }
                    else
                    {
                        btnFilterDuplicate.Text = Parameter.Lang.GetTranslate("btnFilterDuplicate_Apply");
                    }
                }
                else
                {
                    btnFilterDuplicate.Enabled = false;
                    btnFilterDuplicate.Text = Parameter.Lang.GetTranslate("btnFilterDuplicate_None");
                }

                _controler.SetCurrentGridView(dgv.Name);
            }
            else
            {
                _controler.SetNoCurrentRom();

                lblLanguage.Text = string.Empty;
                lblCRC.Text = string.Empty;
                lblGenre.Text = string.Empty;
                lblPublisher.Text = string.Empty;
                lblSaveType.Text = string.Empty;
                lblSize.Text = string.Empty;
                lblSource.Text = string.Empty;
                lblSerial.Text = string.Empty;
                lblInternalName.Text = string.Empty;
                lblVersion.Text = string.Empty;
                lblReleaseNumber.Text = string.Empty;
                lblDumpDate.Text = string.Empty;

                txtDirName.Text = string.Empty;
                txtFileName.Text = string.Empty;

                ImgCover.ImageLocation = string.Empty;
                ImgInGame.ImageLocation = string.Empty;
                ImgLocation.ImageLocation = string.Empty;
                ImgIcon.ImageLocation = string.Empty;
                ImgWifi.ImageLocation = string.Empty;

                richTextBox1.Clear();

                btnUnzip.Enabled = false;
                btnUnzip.Text = Parameter.Lang.GetTranslate("btnUnzip_NoRom");
                btnDownloadImgNfoOneRom.Enabled = false;
                btnDownloadImgNfoOneRom.Text = Parameter.Lang.GetTranslate("btnDownloadImgNfoOneRom_NoRom");
                btnFilterDuplicate.Enabled = false;
                btnFilterDuplicate.Text = Parameter.Lang.GetTranslate("btnFilterDuplicate_NoRom");
            }
        }

        /// <summary>
        /// Update the database
        /// </summary>
        private void UpdateDatabase()
        {
            Download downloadXml = new Download(true);
            downloadXml.Disposed += new EventHandler(DLXml_Disposed);

            // DLXml.Show("http://www.advanscene.com/offline/datas/ADVANsCEne_NDScrc.zip", "ADVANsCEne_NDScrc.zip", "Downloading Database ...");
            downloadXml.Show(_controler.DatURL, _controler.DatFileName, Parameter.Lang.GetTranslate("downloadXmlDataBase"));
        }

        /// <summary>
        /// Download the datversion
        /// </summary>
        private void DownloadDatVersion()
        {
            // http://www.advanscene.com/offline/version/ADVANsCEne_NDScrc.txt
            Download downloadXml = new Download(true);
            downloadXml.Disposed += new EventHandler(CheckDatVersion);

            // DLXml.Show("http://www.advanscene.com/offline/datas/ADVANsCEne_NDScrc.zip", "ADVANsCEne_NDScrc.zip", "Downloading Database ...");
            downloadXml.ShowHidden(_controler.DatVersionURL, string.Format("{0}\\ADVANsCEne_NDScrc_Version.txt", Application.StartupPath), Parameter.Lang.GetTranslate("downloadTxtVersionDataBase"));
        }

        /// <summary>
        /// Check if Dat Version is greater than the actual
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void CheckDatVersion(object sender, EventArgs e)
        {
            if (File.Exists(string.Format("{0}\\ADVANsCEne_NDScrc_Version.txt", Application.StartupPath)))
            {
                string[] version = File.ReadAllLines("ADVANsCEne_NDScrc_Version.txt");
                if (version[0] == _controler.DatVersion)
                {
                    MessageBox.Show(Parameter.Lang.GetTranslate("DataBaseUpToDate"), string.Format("{0} {1}", Parameter.Lang.GetTranslate("DataBaseUpToDatePopupTitle"), _controler.DatVersion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Delete("ADVANsCEne_NDScrc_Version.txt");
                }
                else
                {
                    UpdateDatabase();
                }
            }
            else
            {
                DownloadDatVersion();
            }
        }

        /// <summary>
        /// Event Download Advanscene DataBase disposed (autoclose)
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void DLXml_Disposed(object sender, EventArgs e)
        {
            _controler.ExtractNewDataBase();

            ListboxDataBaseUpdate.Items.Clear();
            BW_Diff bw = new BW_Diff(Directory.GetParent(Parameter.Config.Paths.XmlDataBase) + "\\ADVANsCEne_NDScrc.xml.old", Parameter.Config.Paths.XmlDataBase);
            bw.ProgressChanged += new ProgressChangedEventHandler(Bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Worker diff work completed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            File.Delete(Directory.GetParent(Parameter.Config.Paths.XmlDataBase) + "\\ADVANsCEne_NDScrc.xml.old");
            File.Delete(string.Format("{0}\\ADVANsCEne_NDScrc_Version.txt", Application.StartupPath));

            this.Text = string.Format("NdsCRC III v{0} - AdvanceSceneDat v{1} ({2})", ProductVersion, _controler.DatVersion, _controler.DatCreationDate);

            _controler.ReloadAdvanSceneDataBase();

            MAJ_Img_Nfo maj = new MAJ_Img_Nfo();
            maj.Show();
            maj.StartDownloadAllMissingFiles();

            MessageBox.Show(Parameter.Lang.GetTranslate("DataBaseUpdateComplete"), Parameter.Lang.GetTranslate("DataBaseUpdateCompletePopupTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            tabControl1.SelectedIndex = 4;
        }

        /// <summary>
        /// Worker diff work progress changed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ProgressChangedEventArgs</param>
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            labelUpdatePercent.Text = string.Format("{0}%", e.ProgressPercentage.ToString("00"));
            if (e.UserState != null)
            {
                string s = (string)e.UserState;
                string[] split = s.Split('|');
                ListboxDataBaseUpdate.Items.Add(split[0]);
                string fileName = string.Format("{0}\\UpdateDataBaseLog_{1}_{2}_{3}.txt", Parameter.StartupPath, DateTime.Now.Year, DateTime.Now.Month.ToString("00"), DateTime.Now.Day.ToString("00"));
                File.AppendAllText(fileName, string.Format("{0}{1}", split[0], Environment.NewLine));

                // ListboxDataBaseUpdate.Items.Add(split[1]);
                // File.AppendAllText(NDSDirectories.PathUpdateDataBaseLogFile, split[1]);
            }
        }

        #region Search
        /// <summary>
        /// Title filter
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnRecherche_Click(object sender, EventArgs e)
        {
            _controler.SetTitleFilter(txtRecherche.Text);
            SetDataSource();
        }

        /// <summary>
        /// initialize a lot of things
        /// </summary>
        private void SetDataSource()
        {
            GridDataBase.DataSource = _controler.GetDataBase();
            GridCollection.DataSource = _controler.GetCollection();
            GridMissing.DataSource = _controler.GetCollectionMissing();
            InitDataGrid(GridCollection);
            InitDataGrid(GridDataBase);
            InitDataGrid(GridMissing);
            SetLblNbRom();
        }

        /// <summary>
        /// launch the title filter
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void TxtRecherche_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnRecherche_Click(sender, new EventArgs());
            }
        }
        #endregion

        #region Extract
        /// <summary>
        /// Unzip rom
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnUnzip_Click(object sender, EventArgs e)
        {
            progressBarExtract.Value = 0;
            labelExtractPercent.Text = "00%";
            if (File.Exists(_controler.GetCurrentRom().RomPath))
            {
                folderBrowserDialogExtract.ShowDialog();
                if (Directory.Exists(folderBrowserDialogExtract.SelectedPath) && _controler.GetCurrentRom().RomPath != string.Empty)
                {
                    BW_Extract bw = new BW_Extract(_controler.GetCurrentRom().RomPath, folderBrowserDialogExtract.SelectedPath);
                    bw.ProgressChanged += new ProgressChangedEventHandler(Bw_Extract_ProgressChanged);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_Extract_RunWorkerCompleted);
                    btnUnzip.Enabled = false;
                    bw.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show(Parameter.Lang.GetTranslate("UnzipMissingFile"), Parameter.Lang.GetTranslate("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bw_Extract_RunWorkerCompleted
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        private void Bw_Extract_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(Parameter.Lang.GetTranslate("UnzipComplete"), Parameter.Lang.GetTranslate("UnzipCompletePopupTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBarExtract.Value = 0;
            labelExtractPercent.Text = "00%";
            btnUnzip.Enabled = true;
        }

        /// <summary>
        /// Bw_Extract_ProgressChanged
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ProgressChangedEventArgs</param>
        private void Bw_Extract_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarExtract.Value = e.ProgressPercentage;
            labelExtractPercent.Text = e.ProgressPercentage.ToString("00") + "%";
        }
        #endregion

        /// <summary>
        /// Set language filter
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void CbxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int code = -10;
            if (int.TryParse(cbxLanguages.SelectedValue.ToString(), out code))
            {
                if (code == -1)
                {
                    _controler.SetNoLanguageFilter();
                }
                else
                {
                    _controler.SetLanguageFilter((int)cbxLanguages.SelectedValue);
                }

                SetDataSource();
            }
        }

        /// <summary>
        /// TabControl2_SelectedIndexChanged
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    Grid_CurrentCellChanged(GridCollection, new EventArgs());
                    break;
                case 1:
                    Grid_CurrentCellChanged(GridDataBase, new EventArgs());
                    break;
                case 2:
                    Grid_CurrentCellChanged(GridMissing, new EventArgs());
                    break;
                case 3:
                    Grid_CurrentCellChanged(GridFilterLocation, new EventArgs());
                    break;
            }

            SetLblNbRom();
        }

        /// <summary>
        /// maj_FormClosed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">FormClosedEventArgs</param>
        private void Maj_FormClosed(object sender, FormClosedEventArgs e)
        {
            TabControl2_SelectedIndexChanged(null, new EventArgs());
        }
    }
}
