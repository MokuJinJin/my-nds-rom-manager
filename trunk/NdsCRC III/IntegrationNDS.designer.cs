namespace NdsCRC_III
{
    partial class IntegrationNDS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntegrationNDS));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblNbRom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRom = new System.Windows.Forms.Label();
            this.lblNbFound = new System.Windows.Forms.Label();
            this.lblRomNotFound = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblInfos = new System.Windows.Forms.Label();
            this.pb_Zip = new System.Windows.Forms.ProgressBar();
            this.LblAlreadyHave = new System.Windows.Forms.Label();
            this.LblIntegrated = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridResultat = new System.Windows.Forms.DataGridView();
            this.chkAlreadyHave = new System.Windows.Forms.CheckBox();
            this.chkNotFound = new System.Windows.Forms.CheckBox();
            this.chkIntegrated = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkBadDump = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResultat)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 66);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(720, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 155);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(732, 69);
            this.listBox1.TabIndex = 1;
            // 
            // lblNbRom
            // 
            this.lblNbRom.AutoSize = true;
            this.lblNbRom.Location = new System.Drawing.Point(21, 27);
            this.lblNbRom.Name = "lblNbRom";
            this.lblNbRom.Size = new System.Drawing.Size(13, 13);
            this.lblNbRom.TabIndex = 2;
            this.lblNbRom.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "/";
            // 
            // lblTotalRom
            // 
            this.lblTotalRom.AutoSize = true;
            this.lblTotalRom.Location = new System.Drawing.Point(58, 27);
            this.lblTotalRom.Name = "lblTotalRom";
            this.lblTotalRom.Size = new System.Drawing.Size(13, 13);
            this.lblTotalRom.TabIndex = 2;
            this.lblTotalRom.Text = "0";
            // 
            // lblNbFound
            // 
            this.lblNbFound.AutoSize = true;
            this.lblNbFound.Location = new System.Drawing.Point(131, 27);
            this.lblNbFound.Name = "lblNbFound";
            this.lblNbFound.Size = new System.Drawing.Size(111, 13);
            this.lblNbFound.TabIndex = 3;
            this.lblNbFound.Text = "0 Rom(s) Found in DB";
            // 
            // lblRomNotFound
            // 
            this.lblRomNotFound.AutoSize = true;
            this.lblRomNotFound.Location = new System.Drawing.Point(578, 27);
            this.lblRomNotFound.Name = "lblRomNotFound";
            this.lblRomNotFound.Size = new System.Drawing.Size(129, 13);
            this.lblRomNotFound.TabIndex = 3;
            this.lblRomNotFound.Text = "0 Rom(s) not Found in DB";
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(341, 410);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 4;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.BtnAbort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblInfos);
            this.groupBox1.Controls.Add(this.pb_Zip);
            this.groupBox1.Location = new System.Drawing.Point(12, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 73);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "7z Compression information";
            // 
            // LblInfos
            // 
            this.LblInfos.AutoSize = true;
            this.LblInfos.Location = new System.Drawing.Point(20, 20);
            this.LblInfos.Name = "LblInfos";
            this.LblInfos.Size = new System.Drawing.Size(81, 13);
            this.LblInfos.TabIndex = 1;
            this.LblInfos.Text = "nothing to do ...";
            // 
            // pb_Zip
            // 
            this.pb_Zip.Location = new System.Drawing.Point(6, 40);
            this.pb_Zip.Name = "pb_Zip";
            this.pb_Zip.Size = new System.Drawing.Size(720, 23);
            this.pb_Zip.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_Zip.TabIndex = 0;
            // 
            // LblAlreadyHave
            // 
            this.LblAlreadyHave.AutoSize = true;
            this.LblAlreadyHave.Location = new System.Drawing.Point(268, 27);
            this.LblAlreadyHave.Name = "LblAlreadyHave";
            this.LblAlreadyHave.Size = new System.Drawing.Size(116, 13);
            this.LblAlreadyHave.TabIndex = 6;
            this.LblAlreadyHave.Text = "0 Rom(s) Already Have";
            // 
            // LblIntegrated
            // 
            this.LblIntegrated.AutoSize = true;
            this.LblIntegrated.Location = new System.Drawing.Point(407, 27);
            this.LblIntegrated.Name = "LblIntegrated";
            this.LblIntegrated.Size = new System.Drawing.Size(100, 13);
            this.LblIntegrated.TabIndex = 6;
            this.LblIntegrated.Text = "0 Rom(s) Integrated";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.LblIntegrated);
            this.groupBox2.Controls.Add(this.lblNbRom);
            this.groupBox2.Controls.Add(this.LblAlreadyHave);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblTotalRom);
            this.groupBox2.Controls.Add(this.lblNbFound);
            this.groupBox2.Controls.Add(this.lblRomNotFound);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(732, 95);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informations";
            // 
            // GridResultat
            // 
            this.GridResultat.AllowUserToAddRows = false;
            this.GridResultat.AllowUserToDeleteRows = false;
            this.GridResultat.AllowUserToOrderColumns = true;
            this.GridResultat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.GridResultat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridResultat.Location = new System.Drawing.Point(12, 2);
            this.GridResultat.MultiSelect = false;
            this.GridResultat.Name = "GridResultat";
            this.GridResultat.ReadOnly = true;
            this.GridResultat.RowHeadersVisible = false;
            this.GridResultat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridResultat.Size = new System.Drawing.Size(631, 150);
            this.GridResultat.TabIndex = 8;
            // 
            // chkAlreadyHave
            // 
            this.chkAlreadyHave.AutoSize = true;
            this.chkAlreadyHave.Checked = true;
            this.chkAlreadyHave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlreadyHave.Enabled = false;
            this.chkAlreadyHave.Location = new System.Drawing.Point(7, 42);
            this.chkAlreadyHave.Name = "chkAlreadyHave";
            this.chkAlreadyHave.Size = new System.Drawing.Size(90, 17);
            this.chkAlreadyHave.TabIndex = 9;
            this.chkAlreadyHave.Text = "Already Have";
            this.chkAlreadyHave.UseVisualStyleBackColor = true;
            this.chkAlreadyHave.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // chkNotFound
            // 
            this.chkNotFound.AutoSize = true;
            this.chkNotFound.Checked = true;
            this.chkNotFound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotFound.Enabled = false;
            this.chkNotFound.Location = new System.Drawing.Point(6, 65);
            this.chkNotFound.Name = "chkNotFound";
            this.chkNotFound.Size = new System.Drawing.Size(76, 17);
            this.chkNotFound.TabIndex = 9;
            this.chkNotFound.Text = "Not Found";
            this.chkNotFound.UseVisualStyleBackColor = true;
            this.chkNotFound.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // chkIntegrated
            // 
            this.chkIntegrated.AutoSize = true;
            this.chkIntegrated.Checked = true;
            this.chkIntegrated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntegrated.Enabled = false;
            this.chkIntegrated.Location = new System.Drawing.Point(6, 88);
            this.chkIntegrated.Name = "chkIntegrated";
            this.chkIntegrated.Size = new System.Drawing.Size(74, 17);
            this.chkIntegrated.TabIndex = 9;
            this.chkIntegrated.Text = "Integrated";
            this.chkIntegrated.UseVisualStyleBackColor = true;
            this.chkIntegrated.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkNotFound);
            this.groupBox3.Controls.Add(this.chkBadDump);
            this.groupBox3.Controls.Add(this.chkIntegrated);
            this.groupBox3.Controls.Add(this.chkAlreadyHave);
            this.groupBox3.Location = new System.Drawing.Point(654, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(103, 147);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
            // chkBadDump
            // 
            this.chkBadDump.AutoSize = true;
            this.chkBadDump.Checked = true;
            this.chkBadDump.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBadDump.Enabled = false;
            this.chkBadDump.Location = new System.Drawing.Point(6, 111);
            this.chkBadDump.Name = "chkBadDump";
            this.chkBadDump.Size = new System.Drawing.Size(74, 17);
            this.chkBadDump.TabIndex = 9;
            this.chkBadDump.Text = "Bad dump";
            this.chkBadDump.UseVisualStyleBackColor = true;
            this.chkBadDump.CheckedChanged += new System.EventHandler(this.Chk_CheckedChanged);
            // 
            // IntegrationNDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 445);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GridResultat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IntegrationNDS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntegrationNDS";
            this.Shown += new System.EventHandler(this.IntegrationNDS_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntegrationNDS_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridResultat)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblNbRom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRom;
        private System.Windows.Forms.Label lblNbFound;
        private System.Windows.Forms.Label lblRomNotFound;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar pb_Zip;
        private System.Windows.Forms.Label LblInfos;
        private System.Windows.Forms.Label LblAlreadyHave;
        private System.Windows.Forms.Label LblIntegrated;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridResultat;
        private System.Windows.Forms.CheckBox chkAlreadyHave;
        private System.Windows.Forms.CheckBox chkNotFound;
        private System.Windows.Forms.CheckBox chkIntegrated;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkBadDump;
    }
}