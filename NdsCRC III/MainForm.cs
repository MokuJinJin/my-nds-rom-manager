//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
using BusinessService.BW;

namespace NdsCRC_III
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using NdsCRC_III.BusinessService;
    using NdsCRC_III.BusinessService.BW;

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
        /// Controler of the form
        /// </summary>
        private MFControler _controler;

        /// <summary>
        /// current Path of the Selected Rom
        /// </summary>
        private string currentPathSelectedRom = string.Empty;

        /// <summary>
        /// current Selected Rom
        /// </summary>
        private NDS_Rom currentSelectedRom = new NDS_Rom();

        /// <summary>
        /// Constructor for MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _controler = new MFControler(Application.StartupPath);

            sourceAdvanScene.DataSource = _controler.GetDataBase();
            GridDataBase.DataSource = sourceAdvanScene;
            sourceCollection.DataSource = _controler.GetCollection();
            GridCollection.DataSource = sourceCollection;
            sourceMissing.DataSource = _controler.GetCollectionMissing();
            GridMissing.DataSource = sourceMissing;

            InitDataGrid(GridCollection);
            InitDataGrid(GridDataBase);
            InitDataGrid(GridMissing);

            cbxLanguages.DataSource = new BindingSource(_controler.GetLanguages(), null);
            cbxLanguages.DisplayMember = "Value";
            cbxLanguages.ValueMember = "Key";

            SetLblNbRom();

            this.Text = string.Format("NdsCRC III v{0} - AdvanceSceneDat v{1} ({2})", ProductVersion, _controler.DatVersion, _controler.DatCreationDate);
        }

        /*
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                //lblLanguage.Text = (sender as DataGridView)["language", e.RowIndex].Value.ToString();
                lblLanguage.DataBindings.Clear();
                lblLanguage.DataBindings.Add("Text", dgv.DataSource, "language");

                //lblCRC.Text = (sender as DataGridView)["RomCRC", e.RowIndex].Value.ToString();
                lblCRC.DataBindings.Clear();
                lblCRC.DataBindings.Add("Text", dgv.DataSource, "RomCRC");
                
                //lblGenre.Text = (sender as DataGridView)["Genre", e.RowIndex].Value.ToString();
                lblGenre.DataBindings.Clear();
                lblGenre.DataBindings.Add("Text", dgv.DataSource, "Genre");
                
                //lblPublisher.Text = (sender as DataGridView)["Publisher", e.RowIndex].Value.ToString();
                lblPublisher.DataBindings.Clear();
                lblPublisher.DataBindings.Add("Text", dgv.DataSource, "Publisher");
                
                //lblSaveType.Text = (sender as DataGridView)["SaveType", e.RowIndex].Value.ToString();
                lblSaveType.DataBindings.Clear();
                lblSaveType.DataBindings.Add("Text", dgv.DataSource, "SaveType");
                
                //lblSize.Text = (sender as DataGridView)["RomSize", e.RowIndex].Value.ToString();
                lblSize.DataBindings.Clear();
                lblSize.DataBindings.Add("Text", dgv.DataSource, "RomSize");
                
                //lblSource.Text = (sender as DataGridView)["SourceRom", e.RowIndex].Value.ToString();
                lblSource.DataBindings.Clear();
                lblSource.DataBindings.Add("Text", dgv.DataSource, "SourceRom");

                //if ((sender as DataGridView)["duplicateid", e.RowIndex].Value.ToString() != "None")
                //{
                //    lblDuplicateID.Text = (sender as DataGridView)["duplicateid", e.RowIndex].Value.ToString();
                //    btnFilterDuplicate.Enabled = true;
                //}
                //else
                //{
                //    lblDuplicateID.Text = "None";
                //    btnFilterDuplicate.Enabled = false;
                //} 
                lblDuplicateID.DataBindings.Clear();
                lblDuplicateID.DataBindings.Add("Text", dgv.DataSource, "duplicateid");
                if (lblDuplicateID.Text == "None")
                {
                    btnFilterDuplicate.Enabled = true;
                }
                else
                {
                    btnFilterDuplicate.Enabled = false;
                }

                //lblReleaseNumber.Text = (sender as DataGridView)["ReleaseNumber", e.RowIndex].Value.ToString();
                lblReleaseNumber.DataBindings.Clear();
                lblReleaseNumber.DataBindings.Add("Text", dgv.DataSource, "ReleaseNumber");

                //ImgCover.ImageLocation = NDSDirectories.PathImg + (sender as DataGridView)["ImageNumber", e.RowIndex].Value + "a.png";
                ImgCover.DataBindings.Clear();
                ImgCover.DataBindings.Add("ImageLocation", dgv.DataSource, "ImgCoverPath");

                //ImgInGame.ImageLocation = NDSDirectories.PathImg + (sender as DataGridView)["ImageNumber", e.RowIndex].Value + "b.png";
                ImgInGame.DataBindings.Clear();
                ImgInGame.DataBindings.Add("ImageLocation", dgv.DataSource, "ImgInGamePath");

                //imgLocation.Image = Flags.Images[(sender as DataGridView)["Location", e.RowIndex].Value.ToString() + ".png"];
                imgLocation.DataBindings.Clear();
                imgLocation.DataBindings.Add("ImageLocation", dgv.DataSource, "FlagPath");
                
                Encoding encoding = Encoding.GetEncoding(437);
                //richTextBox1.DataBindings.Clear();
                //richTextBox1.DataBindings.Add("Text", dgv.DataSource, "NfoPath");
                //StreamReader file = new StreamReader(richTextBox1.Text, encoding);
                //richTextBox1.LoadFile(file.BaseStream, RichTextBoxStreamType.PlainText);

                //if (File.Exists(NDSDirectories.PathNfo + (sender as DataGridView)["ReleaseNumber", e.RowIndex].Value + ".nfo"))
                //{
                StreamReader file = new StreamReader((sender as DataGridView)["NfoPath", e.RowIndex].Value.ToString(), encoding);
                richTextBox1.LoadFile(file.BaseStream, RichTextBoxStreamType.PlainText);
                //}
                //else
                //{
                //    richTextBox1.Clear();
                //}

                bool RomExist = bool.Parse((sender as DataGridView)["RomExist", e.RowIndex].Value.ToString());
                if (RomExist)
                {
                    btnUnzip.Enabled = true;
                    btnUnzip.Text = "Copier sur Carte";
                }
                else
                {
                    btnUnzip.Enabled = false;
                    btnUnzip.Text = "Fichier Manquant";
                }

                #region Commentaire
                /*
                if ((sender as DataGridView)["RomNumber", e.RowIndex].Value.ToString() != "xxxx")
                {
                    currentPathSelectedRom = string.Format("{0}{3}\\({1}) {2}.7z",
                                NDSDirectories.PathRom,
                                (sender as DataGridView)["RomNumber", e.RowIndex].Value.ToString(),
                                (sender as DataGridView)["title", e.RowIndex].Value.ToString(),
                                NDSDirectories.GetDirFromReleaseNumber(int.Parse((sender as DataGridView)["RomNumber", e.RowIndex].Value.ToString()))
                            );
                    if (File.Exists(currentPathSelectedRom))
                    {
                        btnUnzip.Enabled = true;
                        btnUnzip.Text = "Copier sur Carte";
                    }
                    else
                    {
                        btnUnzip.Enabled = false;
                        btnUnzip.Text = "Fichier Manquant";
                    }
                }
                else
                {
                    btnUnzip.Enabled = false;
                    btnUnzip.Text = "Copie xxxx Disabled";
                }
                
                #endregion

                //MessageBox.Show(Grid["Location", e.RowIndex].Value.ToString());
            }
        }
*/

        /// <summary>
        /// Start the integration
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnGetNewRom_Click(object sender, EventArgs e)
        {
            IntegrationNDS f = new IntegrationNDS(_controler.PathNewRom);
            btnGetNewRom.Enabled = false;
            f.FormClosed += new FormClosedEventHandler(F_FormClosed);
            f.Show();
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
        /// Set Duplicate filter
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void BtnFilterDuplicate_Click(object sender, EventArgs e)
        {
            /*
            //if (lblDuplicateID.Text != "None")
            //{
            //    StringBuilder strFiltre = new StringBuilder();
            //    DataView dtv = new DataView(AdvanceSceneDataBaseXML.DataBase);

            //    strFiltre.Append("duplicateid = '" + lblDuplicateID.Text + "'");

            //    dtv.RowFilter = strFiltre.ToString();
            //    dtv.Sort = "RomNumber";
            //    GridDataBase.DataSource = dtv.ToTable();

            //}
            */
        }

        /// <summary>
        /// DataBinding of the selected Rom
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <param name="e">EventArgs</param>
        private void Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count == 1)
            {
                // Grid_CellClick(sender, new DataGridViewCellEventArgs(1, GridCollection.SelectedRows[0].Index));
                DataGridView dgv = (DataGridView)sender;

                // lblLanguage.Text = (sender as DataGridView)["language", e.RowIndex].Value.ToString();
                lblLanguage.DataBindings.Clear();
                lblLanguage.DataBindings.Add("Text", dgv.DataSource, "languageString");

                // lblCRC.Text = (sender as DataGridView)["RomCRC", e.RowIndex].Value.ToString();
                lblCRC.DataBindings.Clear();
                lblCRC.DataBindings.Add("Text", dgv.DataSource, "RomCRC");

                // lblGenre.Text = (sender as DataGridView)["Genre", e.RowIndex].Value.ToString();
                lblGenre.DataBindings.Clear();
                lblGenre.DataBindings.Add("Text", dgv.DataSource, "Genre");

                // lblPublisher.Text = (sender as DataGridView)["Publisher", e.RowIndex].Value.ToString();
                lblPublisher.DataBindings.Clear();
                lblPublisher.DataBindings.Add("Text", dgv.DataSource, "Publisher");

                // lblSaveType.Text = (sender as DataGridView)["SaveType", e.RowIndex].Value.ToString();
                lblSaveType.DataBindings.Clear();
                lblSaveType.DataBindings.Add("Text", dgv.DataSource, "SaveType");

                // lblSize.Text = (sender as DataGridView)["RomSize", e.RowIndex].Value.ToString();
                lblSize.DataBindings.Clear();
                lblSize.DataBindings.Add("Text", dgv.DataSource, "RomSize");

                // lblSource.Text = (sender as DataGridView)["SourceRom", e.RowIndex].Value.ToString();
                lblSource.DataBindings.Clear();
                lblSource.DataBindings.Add("Text", dgv.DataSource, "SourceRom");

                /*
                //if ((sender as DataGridView)["duplicateid", e.RowIndex].Value.ToString() != "None")
                //{
                //    lblDuplicateID.Text = (sender as DataGridView)["duplicateid", e.RowIndex].Value.ToString();
                //    btnFilterDuplicate.Enabled = true;
                //}
                //else
                //{
                //    lblDuplicateID.Text = "None";
                //    btnFilterDuplicate.Enabled = false;
                //} 
                 */
                lblDuplicateID.DataBindings.Clear();
                lblDuplicateID.DataBindings.Add("Text", dgv.DataSource, "duplicateid");
                if (lblDuplicateID.Text == "None")
                {
                    btnFilterDuplicate.Enabled = true;
                }
                else
                {
                    btnFilterDuplicate.Enabled = false;
                }

                // lblReleaseNumber.Text = (sender as DataGridView)["ReleaseNumber", e.RowIndex].Value.ToString();
                lblReleaseNumber.DataBindings.Clear();
                lblReleaseNumber.DataBindings.Add("Text", dgv.DataSource, "ReleaseNumber");

                // ImgCover.ImageLocation = NDSDirectories.PathImg + (sender as DataGridView)["ImageNumber", e.RowIndex].Value + "a.png";
                ImgCover.DataBindings.Clear();
                ImgCover.DataBindings.Add("ImageLocation", dgv.DataSource, "ImgCoverPath");

                // ImgInGame.ImageLocation = NDSDirectories.PathImg + (sender as DataGridView)["ImageNumber", e.RowIndex].Value + "b.png";
                ImgInGame.DataBindings.Clear();
                ImgInGame.DataBindings.Add("ImageLocation", dgv.DataSource, "ImgInGamePath");

                // imgLocation.Image = Flags.Images[(sender as DataGridView)["Location", e.RowIndex].Value.ToString() + ".png"];
                imgLocation.DataBindings.Clear();
                imgLocation.DataBindings.Add("ImageLocation", dgv.DataSource, "FlagPath");

                // ImgIcon.DataBindings.Add("ImageLocation", dgv.DataSource, "ImgIconPath");
                ImgIcon.DataBindings.Clear();
                ImgIcon.DataBindings.Add("Image", dgv.DataSource, "Icon");

                Encoding encoding = Encoding.GetEncoding(437);
                /*
                //richTextBox1.DataBindings.Clear();
                //richTextBox1.DataBindings.Add("Text", dgv.DataSource, "NfoPath");
                //StreamReader file = new StreamReader(richTextBox1.Text, encoding);
                //richTextBox1.LoadFile(file.BaseStream, RichTextBoxStreamType.PlainText);

                //if (File.Exists(NDSDirectories.PathNfo + (sender as DataGridView)["ReleaseNumber", e.RowIndex].Value + ".nfo"))
                //{
                 * */
                var nfopath = dgv["NfoPath", dgv.SelectedRows[0].Index].Value;
                if (nfopath != null)
                {
                    StreamReader file = new StreamReader(nfopath.ToString(), encoding);
                    richTextBox1.LoadFile(file.BaseStream, RichTextBoxStreamType.PlainText);
                }
                else
                {
                    richTextBox1.Clear();
                }

                // bool RomExist = bool.Parse((sender as DataGridView)["RomExist", (sender as DataGridView).SelectedRows[0].Index].Value.ToString());
                this.currentPathSelectedRom = dgv["RomPath", dgv.SelectedRows[0].Index].Value.ToString();
                if (dgv["ReleaseNumber", dgv.SelectedRows[0].Index].Value != null)
                {
                    this.currentSelectedRom = _controler.GetRomByReleaseNumber(dgv["ReleaseNumber", dgv.SelectedRows[0].Index].Value.ToString());
                }

                // bool RomExist = File.Exists(dgv["RomPath", dgv.SelectedRows[0].Index].Value.ToString());
                if (File.Exists(currentPathSelectedRom))
                {
                    btnUnzip.Enabled = true;
                    btnUnzip.Text = "Copy on Linker";
                }
                else
                {
                    btnUnzip.Enabled = false;
                    btnUnzip.Text = "File is missing";
                }

                if (currentSelectedRom != null)
                {
                    if (currentSelectedRom.IsAllImagePresent())
                    {
                        btnDownloadImgNfoOneRom.Enabled = false;
                    }
                    else
                    {
                        btnDownloadImgNfoOneRom.Enabled = true;
                    }
                }
                else
                {
                    btnDownloadImgNfoOneRom.Enabled = false;
                }
            }
            else
            {
                ImgCover.ImageLocation = null;
                ImgInGame.ImageLocation = null;
                lblLanguage.Text = null;
                lblCRC.Text = null;
                lblGenre.Text = null;
                lblPublisher.Text = null;
                lblSaveType.Text = null;
                lblSize.Text = null;
                lblSource.Text = null;
                lblDuplicateID.Text = "None";
                btnFilterDuplicate.Enabled = false;
                imgLocation.Image = null;
                richTextBox1.Clear();
                lblReleaseNumber.Text = null;
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
            downloadXml.Show(_controler.datURL, _controler.datFileName, "Downloading Database ...");
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
            downloadXml.ShowHidden(_controler.datVersionURL, string.Format("{0}\\ADVANsCEne_NDScrc_Version.txt", Application.StartupPath), "Downloading Version ...");
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
                    MessageBox.Show("DataBase is up to date", "Database version " + _controler.DatVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BW_Diff bw = new BW_Diff(Directory.GetParent(_controler.PathXmlDB) + "\\ADVANsCEne_NDScrc.xml.old", _controler.PathXmlDB);
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
            File.Delete(Directory.GetParent(_controler.PathXmlDB) + "\\ADVANsCEne_NDScrc.xml.old");
            File.Delete(string.Format("{0}\\ADVANsCEne_NDScrc_Version.txt", Application.StartupPath));

            this.Text = string.Format("NdsCRC III v{0} - AdvanceSceneDat v{1} ({2})", ProductVersion, _controler.DatVersion, _controler.DatCreationDate);

            _controler.ReloadAdvanSceneDataBase();

            MAJ_Img_Nfo maj = new MAJ_Img_Nfo();
            maj.Show();
            maj.StartDownloadAllMissingFiles();

            MessageBox.Show("Update Complete.", "DataBase Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                File.AppendAllText(NDSDirectories.PathUpdateDataBaseLogFile, string.Format("{0}{1}", split[0], Environment.NewLine));

                // ListboxDataBaseUpdate.Items.Add(split[1]);
                // File.AppendAllText(NDSDirectories.PathUpdateDataBaseLogFile, split[1]);
            }
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
        private void Button4_Click(object sender, EventArgs e)
        {
            _controler.RepairCollection();
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
            if (File.Exists(currentPathSelectedRom))
            {
                folderBrowserDialogExtract.ShowDialog();
                if (Directory.Exists(folderBrowserDialogExtract.SelectedPath) && currentPathSelectedRom != string.Empty)
                {
                    BW_Extract bw = new BW_Extract(currentPathSelectedRom, folderBrowserDialogExtract.SelectedPath);
                    bw.ProgressChanged += new ProgressChangedEventHandler(Bw_Extract_ProgressChanged);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_Extract_RunWorkerCompleted);
                    btnUnzip.Enabled = false;
                    bw.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Fichier non présent", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bw_Extract_RunWorkerCompleted
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        private void Bw_Extract_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Copie Fini", "Copie Rom", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }

            SetLblNbRom();
        }

        /// <summary>
        /// Update the number of rom to display on the tabs
        /// </summary>
        private void SetLblNbRom()
        {
            tabCollection.Text = string.Format("Collection ({0} roms)", _controler.GetCollection().Count);
            tabDataBase.Text = string.Format("DataBase ({0} roms)", _controler.GetDataBase().Count);
            tabMissing.Text = string.Format("Missing ({0} roms)", _controler.GetCollectionMissing().Count);
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

        /// <summary>
        /// Update image nfo of the selected rom
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            MAJ_Img_Nfo maj = new MAJ_Img_Nfo();

            int releaseNumber = int.Parse(currentSelectedRom.ReleaseNumber);
            string filePath = string.Format("{0}{1}.png", NDSDirectories.PathImg, releaseNumber.ToString("0000"));
            Queue<MajUrl> liste = new Queue<MajUrl>();
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl()
                {
                    uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlIco),
                    filepath = filePath
                });
            }

            filePath = string.Format("{0}{1}a.png", NDSDirectories.PathImg, releaseNumber.ToString("0000"));
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl() { uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlCover), filepath = filePath });
            }

            filePath = string.Format("{0}{1}b.png", NDSDirectories.PathImg, releaseNumber.ToString("0000"));
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl() { uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlInGame), filepath = filePath });
            }

            filePath = string.Format("{0}{1}.nfo", NDSDirectories.PathNfo, releaseNumber.ToString("0000"));
            if (!File.Exists(filePath))
            {
                liste.Enqueue(new MajUrl() { uri = NDSDirectories.GetUriFor(releaseNumber, NDSDirectoriesEnum.UrlNfo), filepath = filePath });
            }

            maj.Bw_RunWorkerCompleted(null, new RunWorkerCompletedEventArgs(liste, null, false));

            // TabControl2_SelectedIndexChanged(null, new EventArgs());
            maj.Show();
        }

        /// <summary>
        /// AdvansceneLink_LinkClicked
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void AdvansceneLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = string.Format("http://www.advanscene.com/html/Releases/dbrelds.php?id={0}", currentSelectedRom.ReleaseNumber);
            System.Diagnostics.Process.Start(link);
        }
    }
}
