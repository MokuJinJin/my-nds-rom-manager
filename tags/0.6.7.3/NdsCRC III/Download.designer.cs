namespace NdsCRC_III
{
    partial class Download
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Download));
            this.lblDownload = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnAction = new System.Windows.Forms.Button();
            this.chkAutoQuit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(99, 9);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(101, 13);
            this.lblDownload.TabIndex = 0;
            this.lblDownload.Text = "No URI Available ...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(275, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(196, 61);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "Cancel";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Visible = false;
            this.btnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // chkAutoQuit
            // 
            this.chkAutoQuit.AutoSize = true;
            this.chkAutoQuit.Location = new System.Drawing.Point(12, 61);
            this.chkAutoQuit.Name = "chkAutoQuit";
            this.chkAutoQuit.Size = new System.Drawing.Size(162, 17);
            this.chkAutoQuit.TabIndex = 3;
            this.chkAutoQuit.Text = "Close this form when finished";
            this.chkAutoQuit.UseVisualStyleBackColor = true;
            this.chkAutoQuit.CheckedChanged += new System.EventHandler(this.ChkAutoQuit_CheckedChanged);
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 88);
            this.Controls.Add(this.chkAutoQuit);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Download";
            this.Text = "Download";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.CheckBox chkAutoQuit;
    }
}