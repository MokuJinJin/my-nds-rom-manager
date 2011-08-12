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
            this.lblReleaseNumber = new System.Windows.Forms.Label();
            this.lblDuplicateID = new System.Windows.Forms.Label();
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
            this.ImgIcon = new System.Windows.Forms.PictureBox();
            this.imgLocation = new System.Windows.Forms.PictureBox();
            this.tabDataBaseUpdateInfo = new System.Windows.Forms.TabPage();
            this.ListboxDataBaseUpdate = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMAJ_Img_NFO = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button4 = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.GridCollection)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgInGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCover)).BeginInit();
            this.tabNFO.SuspendLayout();
            this.tabInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLocation)).BeginInit();
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
            this.btnGetNewRom.Click += new System.EventHandler(this.btnGetNewRom_Click);
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
            this.btnUnzip.Click += new System.EventHandler(this.btnUnzip_Click);
            // 
            // lblReleaseNumber
            // 
            this.lblReleaseNumber.AutoSize = true;
            this.lblReleaseNumber.Location = new System.Drawing.Point(325, 385);
            this.lblReleaseNumber.Name = "lblReleaseNumber";
            this.lblReleaseNumber.Size = new System.Drawing.Size(93, 13);
            this.lblReleaseNumber.TabIndex = 6;
            this.lblReleaseNumber.Text = "lblReleaseNumber";
            this.lblReleaseNumber.Visible = false;
            // 
            // lblDuplicateID
            // 
            this.lblDuplicateID.AutoSize = true;
            this.lblDuplicateID.Location = new System.Drawing.Point(197, 385);
            this.lblDuplicateID.Name = "lblDuplicateID";
            this.lblDuplicateID.Size = new System.Drawing.Size(73, 13);
            this.lblDuplicateID.TabIndex = 5;
            this.lblDuplicateID.Text = "lblDuplicateID";
            this.lblDuplicateID.Visible = false;
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
            this.btnFilterDuplicate.Location = new System.Drawing.Point(188, 351);
            this.btnFilterDuplicate.Name = "btnFilterDuplicate";
            this.btnFilterDuplicate.Size = new System.Drawing.Size(96, 23);
            this.btnFilterDuplicate.TabIndex = 3;
            this.btnFilterDuplicate.Text = "Filter Duplicate";
            this.btnFilterDuplicate.UseVisualStyleBackColor = true;
            this.btnFilterDuplicate.Visible = false;
            this.btnFilterDuplicate.Click += new System.EventHandler(this.btnFilterDuplicate_Click);
            // 
            // lblGenre
            // 
            this.lblGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(63, 191);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(46, 13);
            this.lblGenre.TabIndex = 1;
            this.lblGenre.Text = "lblGenre";
            // 
            // lblCRC
            // 
            this.lblCRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCRC.AutoSize = true;
            this.lblCRC.Location = new System.Drawing.Point(63, 165);
            this.lblCRC.Name = "lblCRC";
            this.lblCRC.Size = new System.Drawing.Size(39, 13);
            this.lblCRC.TabIndex = 1;
            this.lblCRC.Text = "lblCRC";
            // 
            // lblSource
            // 
            this.lblSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(63, 142);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(51, 13);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "lblSource";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(63, 116);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(37, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "lblSize";
            // 
            // lblSaveType
            // 
            this.lblSaveType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaveType.AutoSize = true;
            this.lblSaveType.Location = new System.Drawing.Point(63, 90);
            this.lblSaveType.Name = "lblSaveType";
            this.lblSaveType.Size = new System.Drawing.Size(66, 13);
            this.lblSaveType.TabIndex = 1;
            this.lblSaveType.Text = "lblSaveType";
            // 
            // lblPublisher
            // 
            this.lblPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(63, 67);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(60, 13);
            this.lblPublisher.TabIndex = 1;
            this.lblPublisher.Text = "lblPublisher";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Genre :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "CRC32 :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 142);
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
            this.label7.Location = new System.Drawing.Point(5, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Size :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 90);
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
            this.ImgInGame.InitialImage = global::NdsCRC_III.Properties.Resources.defaultb;
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
            this.ImgCover.InitialImage = global::NdsCRC_III.Properties.Resources.defaulta;
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
            this.tabInformations.Controls.Add(this.ImgIcon);
            this.tabInformations.Controls.Add(this.labelExtractPercent);
            this.tabInformations.Controls.Add(this.btnUnzip);
            this.tabInformations.Controls.Add(this.lblReleaseNumber);
            this.tabInformations.Controls.Add(this.label3);
            this.tabInformations.Controls.Add(this.lblDuplicateID);
            this.tabInformations.Controls.Add(this.label5);
            this.tabInformations.Controls.Add(this.progressBarExtract);
            this.tabInformations.Controls.Add(this.label7);
            this.tabInformations.Controls.Add(this.btnFilterDuplicate);
            this.tabInformations.Controls.Add(this.lblLanguage);
            this.tabInformations.Controls.Add(this.label4);
            this.tabInformations.Controls.Add(this.lblGenre);
            this.tabInformations.Controls.Add(this.label6);
            this.tabInformations.Controls.Add(this.lblCRC);
            this.tabInformations.Controls.Add(this.label8);
            this.tabInformations.Controls.Add(this.lblSource);
            this.tabInformations.Controls.Add(this.lblPublisher);
            this.tabInformations.Controls.Add(this.lblSize);
            this.tabInformations.Controls.Add(this.lblSaveType);
            this.tabInformations.Controls.Add(this.imgLocation);
            this.tabInformations.Location = new System.Drawing.Point(4, 22);
            this.tabInformations.Name = "tabInformations";
            this.tabInformations.Padding = new System.Windows.Forms.Padding(3);
            this.tabInformations.Size = new System.Drawing.Size(479, 412);
            this.tabInformations.TabIndex = 4;
            this.tabInformations.Text = "Informations";
            this.tabInformations.UseVisualStyleBackColor = true;
            // 
            // ImgIcon
            // 
            this.ImgIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgIcon.InitialImage = global::NdsCRC_III.Properties.Resources._default;
            this.ImgIcon.Location = new System.Drawing.Point(8, 6);
            this.ImgIcon.Name = "ImgIcon";
            this.ImgIcon.Size = new System.Drawing.Size(36, 36);
            this.ImgIcon.TabIndex = 27;
            this.ImgIcon.TabStop = false;
            // 
            // imgLocation
            // 
            this.imgLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLocation.Location = new System.Drawing.Point(50, 6);
            this.imgLocation.Name = "imgLocation";
            this.imgLocation.Size = new System.Drawing.Size(16, 16);
            this.imgLocation.TabIndex = 2;
            this.imgLocation.TabStop = false;
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
            this.btnMAJ_Img_NFO.Click += new System.EventHandler(this.btnMAJ_Img_NFO_Click);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(510, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "RepairCollection";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.txtRecherche.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRecherche_KeyUp);
            // 
            // btnRecherche
            // 
            this.btnRecherche.Location = new System.Drawing.Point(189, 12);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(75, 23);
            this.btnRecherche.TabIndex = 28;
            this.btnRecherche.Text = "recherche";
            this.btnRecherche.UseVisualStyleBackColor = true;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // cbxLanguages
            // 
            this.cbxLanguages.FormattingEnabled = true;
            this.cbxLanguages.Location = new System.Drawing.Point(331, 14);
            this.cbxLanguages.Name = "cbxLanguages";
            this.cbxLanguages.Size = new System.Drawing.Size(159, 21);
            this.cbxLanguages.TabIndex = 29;
            this.cbxLanguages.SelectedIndexChanged += new System.EventHandler(this.cbxLanguages_SelectedIndexChanged);
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
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
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
            this.GridDataBase.Size = new System.Drawing.Size(494, 406);
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
            this.GridMissing.Size = new System.Drawing.Size(494, 406);
            this.GridMissing.TabIndex = 3;
            this.GridMissing.SelectionChanged += new System.EventHandler(this.Grid_CurrentCellChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 486);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxLanguages);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.labelUpdatePercent);
            this.Controls.Add(this.button4);
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
            ((System.ComponentModel.ISupportInitialize)(this.imgLocation)).EndInit();
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
        private System.Windows.Forms.Label lblDuplicateID;
        private System.Windows.Forms.Button btnFilterDuplicate;
        private System.Windows.Forms.PictureBox imgLocation;
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
        private System.Windows.Forms.Label lblReleaseNumber;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMAJ_Img_NFO;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button4;
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
    }
}

