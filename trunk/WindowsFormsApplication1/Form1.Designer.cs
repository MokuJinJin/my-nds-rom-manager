namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.dockContainer1 = new Crom.Controls.Docking.DockContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectForm3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockContainer1
            // 
            this.dockContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.dockContainer1.CanMoveByMouseFilledForms = true;
            this.dockContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockContainer1.Location = new System.Drawing.Point(0, 24);
            this.dockContainer1.Name = "dockContainer1";
            this.dockContainer1.Size = new System.Drawing.Size(415, 411);
            this.dockContainer1.TabIndex = 0;
            this.dockContainer1.TitleBarGradientColor1 = System.Drawing.SystemColors.Control;
            this.dockContainer1.TitleBarGradientColor2 = System.Drawing.Color.White;
            this.dockContainer1.TitleBarGradientSelectedColor1 = System.Drawing.Color.DarkGray;
            this.dockContainer1.TitleBarGradientSelectedColor2 = System.Drawing.Color.White;
            this.dockContainer1.TitleBarTextColor = System.Drawing.Color.Black;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(415, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.foToolStripMenuItem,
            this.selectForm3ToolStripMenuItem,
            this.changeImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.fileToolStripMenuItem.Text = "Affichage";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.CheckOnClick = true;
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.insertToolStripMenuItem.Text = "Form2";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.ViewForm2_Click);
            // 
            // foToolStripMenuItem
            // 
            this.foToolStripMenuItem.CheckOnClick = true;
            this.foToolStripMenuItem.Name = "foToolStripMenuItem";
            this.foToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.foToolStripMenuItem.Text = "Form3";
            this.foToolStripMenuItem.Click += new System.EventHandler(this.ViewForm3_Click);
            // 
            // selectForm3ToolStripMenuItem
            // 
            this.selectForm3ToolStripMenuItem.Name = "selectForm3ToolStripMenuItem";
            this.selectForm3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.selectForm3ToolStripMenuItem.Text = "SelectForm3";
            this.selectForm3ToolStripMenuItem.Click += new System.EventHandler(this.selectForm3ToolStripMenuItem_Click);
            // 
            // changeImageToolStripMenuItem
            // 
            this.changeImageToolStripMenuItem.Name = "changeImageToolStripMenuItem";
            this.changeImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeImageToolStripMenuItem.Text = "ChangeImage";
            this.changeImageToolStripMenuItem.Click += new System.EventHandler(this.changeImageToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 435);
            this.Controls.Add(this.dockContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Crom.Controls.Docking.DockContainer dockContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectForm3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeImageToolStripMenuItem;

    }
}

