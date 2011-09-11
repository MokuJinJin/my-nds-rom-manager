namespace NdsCRC_III
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnGetNewRom = new System.Windows.Forms.Button();
            this.GridCollection = new System.Windows.Forms.DataGridView();
            this.labelExtractPercent = new System.Windows.Forms.Label();
            this.btnUnzip = new System.Windows.Forms.Button();
            this.progressBarExtract = new System.Windows.Forms.ProgressBar();
            this.btnFilterDuplicate = new System.Windows.Forms.Button();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblCRC = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSaveType = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabImages = new System.Windows.Forms.TabPage();
            this.ImgInGame = new System.Windows.Forms.PictureBox();
            this.ImgCover = new System.Windows.Forms.PictureBox();
            this.tabNFO = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabInformations = new System.Windows.Forms.TabPage();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtDirName = new System.Windows.Forms.TextBox();
            this.AdvansceneLink = new System.Windows.Forms.LinkLabel();
            this.ImgIcon = new System.Windows.Forms.PictureBox();
            this.btnDownloadImgNfoOneRom = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ImgLocation = new System.Windows.Forms.PictureBox();
            this.tabDataBaseUpdateInfo = new System.Windows.Forms.TabPage();
            this.ListboxDataBaseUpdate = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMAJ_Img_NFO = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRepair = new System.Windows.Forms.Button();
            this.labelUpdatePercent = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.folderBrowserDialogExtract = new System.Windows.Forms.FolderBrowserDialog();
            this.cbxLanguages = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabCollection = new System.Windows.Forms.TabPage();
            this.tabDataBase = new System.Windows.Forms.TabPage();
            this.GridDataBase = new System.Windows.Forms.DataGridView();
            this.tabMissing = new System.Windows.Forms.TabPage();
            this.GridMissing = new System.Windows.Forms.DataGridView();
            this.chk_DemoRomVisibility = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridCollection)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgInGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCover)).BeginInit();
            this.tabNFO.SuspendLayout();
            this.tabInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLocation)).BeginInit();
            this.tabDataBaseUpdateInfo.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabCollection.SuspendLayout();
            this.tabDataBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridDataBase)).BeginInit();
            this.tabMissing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridMissing)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetNewRom
            // 
            this.btnGetNewRom.Location = new System.Drawing.Point(621, 12);
            this.btnGetNewRom.Name = "btnGetNewRom";
            this.btnGetNewRom.Size = new System.Drawing.Size(78, 23);
            this.btnGetNewRom.TabIndex = 0;
            this.btnGetNewRom.Text = "GetNewRom";
            this.btnGetNewRom.UseVisualStyleBackColor = true;
            this.btnGetNewRom.Click += new System.EventHandler(this.BtnGetNewRom_Click);
            // 
            // GridCollection
            // 
            this.GridCollection.AllowUserToAddRows = false;
            this.GridCollection.AllowUserToDeleteRows = false;
            this.GridCollection.AllowUserToOrderColumns = true;
            this.GridCollection.AllowUserToResizeRows = false;
            this.GridCollection.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.GridCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridCollection.Location = new System.Drawing.Point(3, 3);
            this.GridCollection.MultiSelect = false;
            this.GridCollection.Name = "GridCollection";
            this.GridCollection.ReadOnly = true;
            this.GridCollection.RowHeadersVisible = false;
            this.GridCollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridCollection.Size = new System.Drawing.Size(504, 406);
            this.GridCollection.TabIndex = 1;
            this.GridCollection.SelectionChanged += new System.EventHandler(this.Grid_CurrentCellChanged);
            // 
            // labelExtractPercent
            // 
            this.labelExtractPercent.AutoSize = true;
            this.labelExtractPercent.BackColor = System.Drawing.Color.Transparent;
            this.labelExtractPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExtractPercent.ForeColor = System.Drawing.Color.White;
            this.labelExtractPercent.Location = new System.Drawing.Point(63, 385);
            this.labelExtractPercent.Name = "labelExtractPercent";
            this.labelExtractPercent.Size = new System.Drawing.Size(30, 13);
            this.labelExtractPercent.TabIndex = 26;
            this.labelExtractPercent.Text = "00%";
            // 
            // btnUnzip
            // 
            this.btnUnzip.Location = new System.Drawing.Point(9, 351);
            this.btnUnzip.Name = "btnUnzip";
            this.btnUnzip.Size = new System.Drawing.Size(144, 23);
            this.btnUnzip.TabIndex = 7;
            this.btnUnzip.Text = "Copier sur Carte";
            this.btnUnzip.UseVisualStyleBackColor = true;
            this.btnUnzip.Click += new System.EventHandler(this.BtnUnzip_Click);
            // 
            // progressBarExtract
            // 
            this.progressBarExtract.ForeColor = System.Drawing.Color.PaleGreen;
            this.progressBarExtract.Location = new System.Drawing.Point(9, 380);
            this.progressBarExtract.Name = "progressBarExtract";
            this.progressBarExtract.Size = new System.Drawing.Size(142, 23);
            this.progressBarExtract.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarExtract.TabIndex = 24;
            // 
            // btnFilterDuplicate
            // 
            this.btnFilterDuplicate.Enabled = false;
            this.btnFilterDuplicate.Location = new System.Drawing.Point(96, 6);
            this.btnFilterDuplicate.Name = "btnFilterDuplicate";
            this.btnFilterDuplicate.Size = new System.Drawing.Size(141, 23);
            this.btnFilterDuplicate.TabIndex = 3;
            this.btnFilterDuplicate.Text = "Filter Location Duplicate";
            this.btnFilterDuplicate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterDuplicate.UseVisualStyleBackColor = true;
            this.btnFilterDuplicate.Click += new System.EventHandler(this.BtnFilterDuplicate_Click);
            // 
            // lblGenre
            // 
            this.lblGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(67, 197);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(46, 13);
            this.lblGenre.TabIndex = 1;
            this.lblGenre.Text = "lblGenre";
            // 
            // lblCRC
            // 
            this.lblCRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCRC.AutoSize = true;
            this.lblCRC.Location = new System.Drawing.Point(67, 171);
            this.lblCRC.Name = "lblCRC";
            this.lblCRC.Size = new System.Drawing.Size(39, 13);
            this.lblCRC.TabIndex = 1;
            this.lblCRC.Text = "lblCRC";
            // 
            // lblSource
            // 
            this.lblSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(67, 145);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(51, 13);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "lblSource";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(67, 119);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(37, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "lblSize";
            // 
            // lblSaveType
            // 
            this.lblSaveType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaveType.AutoSize = true;
            this.lblSaveType.Location = new System.Drawing.Point(67, 93);
            this.lblSaveType.Name = "lblSaveType";
            this.lblSaveType.Size = new System.Drawing.Size(66, 13);
            this.lblSaveType.TabIndex = 1;
            this.lblSaveType.Text = "lblSaveType";
            // 
            // lblPublisher
            // 
            this.lblPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(67, 67);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(60, 13);
            this.lblPublisher.TabIndex = 1;
            this.lblPublisher.Text = "lblPublisher";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Genre :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "CRC32 :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Source :";
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(6, 47);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(65, 13);
            this.lblLanguage.TabIndex = 1;
            this.lblLanguage.Text = "lblLanguage";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Size :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Save type :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Publisher :";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabImages);
            this.tabControl1.Controls.Add(this.tabNFO);
            this.tabControl1.Controls.Add(this.tabInformations);
            this.tabControl1.Controls.Add(this.tabDataBaseUpdateInfo);
            this.tabControl1.Location = new System.Drawing.Point(521, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(487, 438);
            this.tabControl1.TabIndex = 19;
            // 
            // tabImages
            // 
            this.tabImages.Controls.Add(this.ImgInGame);
            this.tabImages.Controls.Add(this.ImgCover);
            this.tabImages.Location = new System.Drawing.Point(4, 22);
            this.tabImages.Name = "tabImages";
            this.tabImages.Padding = new System.Windows.Forms.Padding(3);
            this.tabImages.Size = new System.Drawing.Size(479, 412);
            this.tabImages.TabIndex = 0;
            this.tabImages.Text = "Image";
            this.tabImages.UseVisualStyleBackColor = true;
            // 
            // ImgInGame
            // 
            this.ImgInGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImgInGame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgInGame.InitialImage = global::NdsCRC_III.Properties.Resources.ImgInGame;
            this.ImgInGame.Location = new System.Drawing.Point(223, 15);
            this.ImgInGame.Name = "ImgInGame";
            this.ImgInGame.Size = new System.Drawing.Size(256, 384);
            this.ImgInGame.TabIndex = 18;
            this.ImgInGame.TabStop = false;
            // 
            // ImgCover
            // 
            this.ImgCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImgCover.BackColor = System.Drawing.SystemColors.Control;
            this.ImgCover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgCover.InitialImage = global::NdsCRC_III.Properties.Resources.ImgCover;
            this.ImgCover.Location = new System.Drawing.Point(6, 15);
            this.ImgCover.Name = "ImgCover";
            this.ImgCover.Size = new System.Drawing.Size(214, 384);
            this.ImgCover.TabIndex = 17;
            this.ImgCover.TabStop = false;
            // 
            // tabNFO
            // 
            this.tabNFO.Controls.Add(this.richTextBox1);
            this.tabNFO.Location = new System.Drawing.Point(4, 22);
            this.tabNFO.Name = "tabNFO";
            this.tabNFO.Padding = new System.Windows.Forms.Padding(3);
            this.tabNFO.Size = new System.Drawing.Size(479, 412);
            this.tabNFO.TabIndex = 2;
            this.tabNFO.Text = "NFO";
            this.tabNFO.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Lucida Console", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(473, 406);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // tabInformations
            // 
            this.tabInformations.Controls.Add(this.txtFileName);
            this.tabInformations.Controls.Add(this.txtDirName);
            this.tabInformations.Controls.Add(this.AdvansceneLink);
            this.tabInformations.Controls.Add(this.ImgIcon);
            this.tabInformations.Controls.Add(this.btnDownloadImgNfoOneRom);
            this.tabInformations.Controls.Add(this.labelExtractPercent);
            this.tabInformations.Controls.Add(this.btnUnzip);
            this.tabInformations.Controls.Add(this.label3);
            this.tabInformations.Controls.Add(this.label5);
            this.tabInformations.Controls.Add(this.progressBarExtract);
            this.tabInformations.Controls.Add(this.label7);
            this.tabInformations.Controls.Add(this.btnFilterDuplicate);
            this.tabInformations.Controls.Add(this.lblLanguage);
            this.tabInformations.Controls.Add(this.label4);
            this.tabInformations.Controls.Add(this.lblGenre);
            this.tabInformations.Controls.Add(this.label9);
            this.tabInformations.Controls.Add(this.label6);
            this.tabInformations.Controls.Add(this.label2);
            this.tabInformations.Controls.Add(this.lblCRC);
            this.tabInformations.Controls.Add(this.label8);
            this.tabInformations.Controls.Add(this.lblSource);
            this.tabInformations.Controls.Add(this.lblPublisher);
            this.tabInformations.Controls.Add(this.lblSize);
            this.tabInformations.Controls.Add(this.lblSaveType);
            this.tabInformations.Controls.Add(this.ImgLocation);
            this.tabInformations.Location = new System.Drawing.Point(4, 22);
            this.tabInformations.Name = "tabInformations";
            this.tabInformations.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformations.Size = new System.Drawing.Size(479, 412);
            this.tabInformations.TabIndex = 4;
            this.tabInformations.Text = "Informations";
            this.tabInformations.UseVisualStyleBackColor = true;
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.SystemColors.Control;
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileName.Location = new System.Drawing.Point(71, 250);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(402, 13);
            this.txtFileName.TabIndex = 35;
            this.txtFileName.Text = "txtFileName";
            // 
            // txtDirName
            // 
            this.txtDirName.BackColor = System.Drawing.SystemColors.Control;
            this.txtDirName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDirName.Location = new System.Drawing.Point(70, 223);
            this.txtDirName.Name = "txtDirName";
            this.txtDirName.ReadOnly = true;
            this.txtDirName.Size = new System.Drawing.Size(402, 13);
            this.txtDirName.TabIndex = 35;
            this.txtDirName.Text = "txtDirName";
            // 
            // AdvansceneLink
            // 
            this.AdvansceneLink.AutoSize = true;
            this.AdvansceneLink.Location = new System.Drawing.Point(25, 299);
            this.AdvansceneLink.Name = "AdvansceneLink";
            this.AdvansceneLink.Size = new System.Drawing.Size(104, 13);
            this.AdvansceneLink.TabIndex = 34;
            this.AdvansceneLink.TabStop = true;
            this.AdvansceneLink.Text = "Link to AdvanScene";
            this.AdvansceneLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AdvansceneLink_LinkClicked);
            // 
            // ImgIcon
            // 
            this.ImgIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgIcon.InitialImage = global::NdsCRC_III.Properties.Resources.Icon;
            this.ImgIcon.Location = new System.Drawing.Point(8, 6);
            this.ImgIcon.Name = "ImgIcon";
            this.ImgIcon.Size = new System.Drawing.Size(36, 36);
            this.ImgIcon.TabIndex = 27;
            this.ImgIcon.TabStop = false;
            // 
            // btnDownloadImgNfoOneRom
            // 
            this.btnDownloadImgNfoOneRom.Location = new System.Drawing.Point(9, 322);
            this.btnDownloadImgNfoOneRom.Name = "btnDownloadImgNfoOneRom";
            this.btnDownloadImgNfoOneRom.Size = new System.Drawing.Size(142, 23);
            this.btnDownloadImgNfoOneRom.TabIndex = 33;
            this.btnDownloadImgNfoOneRom.Text = "Download Img/Nfo";
            this.btnDownloadImgNfoOneRom.UseVisualStyleBackColor = true;
            this.btnDownloadImgNfoOneRom.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "FileName :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DirName :";
            // 
            // ImgLocation
            // 
            this.ImgLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImgLocation.Location = new System.Drawing.Point(50, 6);
            this.ImgLocation.Name = "ImgLocation";
            this.ImgLocation.Size = new System.Drawing.Size(16, 16);
            this.ImgLocation.TabIndex = 2;
            this.ImgLocation.TabStop = false;
            this.ImgLocation.DoubleClick += new System.EventHandler(this.ImgLocation_DoubleClick);
            // 
            // tabDataBaseUpdateInfo
            // 
            this.tabDataBaseUpdateInfo.Controls.Add(this.ListboxDataBaseUpdate);
            this.tabDataBaseUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDataBaseUpdateInfo.Location = new System.Drawing.Point(4, 22);
            this.tabDataBaseUpdateInfo.Name = "tabDataBaseUpdateInfo";
            this.tabDataBaseUpdateInfo.Size = new System.Drawing.Size(479, 412);
            this.tabDataBaseUpdateInfo.TabIndex = 3;
            this.tabDataBaseUpdateInfo.Text = "Database Update Infos";
            this.tabDataBaseUpdateInfo.UseVisualStyleBackColor = true;
            // 
            // ListboxDataBaseUpdate
            // 
            this.ListboxDataBaseUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListboxDataBaseUpdate.FormattingEnabled = true;
            this.ListboxDataBaseUpdate.Location = new System.Drawing.Point(3, 3);
            this.ListboxDataBaseUpdate.Name = "ListboxDataBaseUpdate";
            this.ListboxDataBaseUpdate.Size = new System.Drawing.Size(473, 407);
            this.ListboxDataBaseUpdate.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(705, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Update DataBase";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CheckDatVersion);
            // 
            // btnMAJ_Img_NFO
            // 
            this.btnMAJ_Img_NFO.Location = new System.Drawing.Point(917, 12);
            this.btnMAJ_Img_NFO.Name = "btnMAJ_Img_NFO";
            this.btnMAJ_Img_NFO.Size = new System.Drawing.Size(91, 23);
            this.btnMAJ_Img_NFO.TabIndex = 23;
            this.btnMAJ_Img_NFO.Text = "Update Nfo Img";
            this.btnMAJ_Img_NFO.UseVisualStyleBackColor = true;
            this.btnMAJ_Img_NFO.Click += new System.EventHandler(this.BtnMAJ_Img_NFO_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.PaleGreen;
            this.progressBar1.Location = new System.Drawing.Point(811, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 24;
            // 
            // btnRepair
            // 
            this.btnRepair.Location = new System.Drawing.Point(913, 32);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(95, 23);
            this.btnRepair.TabIndex = 25;
            this.btnRepair.Text = "RepairCollection";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Visible = false;
            this.btnRepair.Click += new System.EventHandler(this.Button4_Click);
            // 
            // labelUpdatePercent
            // 
            this.labelUpdatePercent.AutoSize = true;
            this.labelUpdatePercent.BackColor = System.Drawing.Color.Transparent;
            this.labelUpdatePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdatePercent.ForeColor = System.Drawing.Color.White;
            this.labelUpdatePercent.Location = new System.Drawing.Point(841, 17);
            this.labelUpdatePercent.Name = "labelUpdatePercent";
            this.labelUpdatePercent.Size = new System.Drawing.Size(30, 13);
            this.labelUpdatePercent.TabIndex = 26;
            this.labelUpdatePercent.Text = "00%";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(12, 14);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(171, 20);
            this.txtRecherche.TabIndex = 27;
            this.txtRecherche.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtRecherche_KeyUp);
            // 
            // btnRecherche
            // 
            this.btnRecherche.Location = new System.Drawing.Point(189, 12);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(75, 23);
            this.btnRecherche.TabIndex = 28;
            this.btnRecherche.Text = "Title Filter";
            this.btnRecherche.UseVisualStyleBackColor = true;
            this.btnRecherche.Click += new System.EventHandler(this.BtnRecherche_Click);
            // 
            // cbxLanguages
            // 
            this.cbxLanguages.FormattingEnabled = true;
            this.cbxLanguages.Location = new System.Drawing.Point(331, 14);
            this.cbxLanguages.Name = "cbxLanguages";
            this.cbxLanguages.Size = new System.Drawing.Size(159, 21);
            this.cbxLanguages.TabIndex = 29;
            this.cbxLanguages.SelectedIndexChanged += new System.EventHandler(this.CbxLanguages_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Language";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl2.Controls.Add(this.tabCollection);
            this.tabControl2.Controls.Add(this.tabDataBase);
            this.tabControl2.Controls.Add(this.tabMissing);
            this.tabControl2.Location = new System.Drawing.Point(1, 48);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(518, 438);
            this.tabControl2.TabIndex = 31;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.TabControl2_SelectedIndexChanged);
            // 
            // tabCollection
            // 
            this.tabCollection.Controls.Add(this.GridCollection);
            this.tabCollection.Location = new System.Drawing.Point(4, 22);
            this.tabCollection.Name = "tabCollection";
            this.tabCollection.Padding = new System.Windows.Forms.Padding(3);
            this.tabCollection.Size = new System.Drawing.Size(510, 412);
            this.tabCollection.TabIndex = 0;
            this.tabCollection.Text = "Collection";
            this.tabCollection.UseVisualStyleBackColor = true;
            // 
            // tabDataBase
            // 
            this.tabDataBase.Controls.Add(this.GridDataBase);
            this.tabDataBase.Location = new System.Drawing.Point(4, 22);
            this.tabDataBase.Name = "tabDataBase";
            this.tabDataBase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataBase.Size = new System.Drawing.Size(510, 412);
            this.tabDataBase.TabIndex = 1;
            this.tabDataBase.Text = "DataBase";
            this.tabDataBase.UseVisualStyleBackColor = true;
            // 
            // GridDataBase
            // 
            this.GridDataBase.AllowUserToAddRows = false;
            this.GridDataBase.AllowUserToDeleteRows = false;
            this.GridDataBase.AllowUserToOrderColumns = true;
            this.GridDataBase.AllowUserToResizeRows = false;
            this.GridDataBase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.GridDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridDataBase.Location = new System.Drawing.Point(3, 3);
            this.GridDataBase.MultiSelect = false;
            this.GridDataBase.Name = "GridDataBase";
            this.GridDataBase.ReadOnly = true;
            this.GridDataBase.RowHeadersVisible = false;
            this.GridDataBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridDataBase.Size = new System.Drawing.Size(504, 406);
            this.GridDataBase.TabIndex = 2;
            this.GridDataBase.SelectionChanged += new System.EventHandler(this.Grid_CurrentCellChanged);
            // 
            // tabMissing
            // 
            this.tabMissing.Controls.Add(this.GridMissing);
            this.tabMissing.Location = new System.Drawing.Point(4, 22);
            this.tabMissing.Name = "tabMissing";
            this.tabMissing.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissing.Size = new System.Drawing.Size(510, 412);
            this.tabMissing.TabIndex = 2;
            this.tabMissing.Text = "Missing";
            this.tabMissing.UseVisualStyleBackColor = true;
            // 
            // GridMissing
            // 
            this.GridMissing.AllowUserToAddRows = false;
            this.GridMissing.AllowUserToDeleteRows = false;
            this.GridMissing.AllowUserToOrderColumns = true;
            this.GridMissing.AllowUserToResizeRows = false;
            this.GridMissing.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.GridMissing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridMissing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridMissing.Location = new System.Drawing.Point(3, 3);
            this.GridMissing.MultiSelect = false;
            this.GridMissing.Name = "GridMissing";
            this.GridMissing.ReadOnly = true;
            this.GridMissing.RowHeadersVisible = false;
            this.GridMissing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridMissing.Size = new System.Drawing.Size(504, 406);
            this.GridMissing.TabIndex = 3;
            this.GridMissing.SelectionChanged += new System.EventHandler(this.Grid_CurrentCellChanged);
            // 
            // chk_DemoRomVisibility
            // 
            this.chk_DemoRomVisibility.AutoSize = true;
            this.chk_DemoRomVisibility.Checked = true;
            this.chk_DemoRomVisibility.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_DemoRomVisibility.Location = new System.Drawing.Point(496, 16);
            this.chk_DemoRomVisibility.Name = "chk_DemoRomVisibility";
            this.chk_DemoRomVisibility.Size = new System.Drawing.Size(117, 17);
            this.chk_DemoRomVisibility.TabIndex = 32;
            this.chk_DemoRomVisibility.Text = "Demo Rom visibility";
            this.chk_DemoRomVisibility.UseVisualStyleBackColor = true;
            this.chk_DemoRomVisibility.CheckedChanged += new System.EventHandler(this.Chk_DemoRomVisibility_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 486);
            this.Controls.Add(this.chk_DemoRomVisibility);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxLanguages);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.labelUpdatePercent);
            this.Controls.Add(this.btnRepair);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnMAJ_Img_NFO);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGetNewRom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "NdsCRC III";
            ((System.ComponentModel.ISupportInitialize)(this.GridCollection)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgInGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCover)).EndInit();
            this.tabNFO.ResumeLayout(false);
            this.tabInformations.ResumeLayout(false);
            this.tabInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLocation)).EndInit();
            this.tabDataBaseUpdateInfo.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabCollection.ResumeLayout(false);
            this.tabDataBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridDataBase)).EndInit();
            this.tabMissing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridMissing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetNewRom;
        private System.Windows.Forms.DataGridView GridCollection;
        private System.Windows.Forms.PictureBox ImgInGame;
        private System.Windows.Forms.PictureBox ImgCover;
        private System.Windows.Forms.Button btnFilterDuplicate;
        private System.Windows.Forms.PictureBox ImgLocation;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblCRC;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSaveType;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabImages;
        private System.Windows.Forms.TabPage tabNFO;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMAJ_Img_NFO;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.TabPage tabDataBaseUpdateInfo;
        private System.Windows.Forms.ListBox ListboxDataBaseUpdate;
        private System.Windows.Forms.Label labelUpdatePercent;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnRecherche;
        private System.Windows.Forms.Button btnUnzip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogExtract;
        private System.Windows.Forms.Label labelExtractPercent;
        private System.Windows.Forms.ProgressBar progressBarExtract;
        private System.Windows.Forms.ComboBox cbxLanguages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabCollection;
        private System.Windows.Forms.TabPage tabDataBase;
        private System.Windows.Forms.TabPage tabInformations;
        private System.Windows.Forms.DataGridView GridDataBase;
        private System.Windows.Forms.TabPage tabMissing;
        private System.Windows.Forms.DataGridView GridMissing;
        private System.Windows.Forms.PictureBox ImgIcon;
        private System.Windows.Forms.CheckBox chk_DemoRomVisibility;
        private System.Windows.Forms.Button btnDownloadImgNfoOneRom;
        private System.Windows.Forms.LinkLabel AdvansceneLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDirName;
        private System.Windows.Forms.TextBox txtFileName;
    }
}

