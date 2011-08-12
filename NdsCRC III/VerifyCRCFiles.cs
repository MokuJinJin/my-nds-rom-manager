using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using NdsCRC_III.BusinessService.BW;

namespace NdsCRC_III
{
    public partial class VerifyCRCFiles : Form
    {
        
        public VerifyCRCFiles()
        {
            InitializeComponent();
            
        }
        public void Start()
        {
            label1.Text = "Counting files ...";
            
            BW_VerifyCRCFiles bw = new BW_VerifyCRCFiles(Application.StartupPath);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerAsync();
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                listBox1.Items.Add((string)e.UserState);
            }
            if (e.ProgressPercentage == -1)
            {
                label1.Text = "Checking ...";
            }
            else
            {
                label1.Text = e.ProgressPercentage.ToString("00") + "%";
                progressBar1.Value = e.ProgressPercentage;
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("The End");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
