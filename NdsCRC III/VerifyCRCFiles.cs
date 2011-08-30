//-----------------------------------------------------------------------
// <copyright file="VerifyCRCFiles.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------
namespace NdsCRC_III
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using NdsCRC_III.BusinessService.BW;

    /// <summary>
    /// Form for verify CRC of the collection files
    /// </summary>
    public partial class VerifyCRCFiles : Form
    {
        /// <summary>
        /// Constructor for VerifyCRCFiles
        /// </summary>
        public VerifyCRCFiles()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Launch the work
        /// </summary>
        public void Start()
        {
            label1.Text = "Counting files ...";
            
            BW_VerifyCRCFiles bw = new BW_VerifyCRCFiles(Application.StartupPath);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bw_RunWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(Bw_ProgressChanged);
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Bw_ProgressChanged
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ProgressChangedEventArgs</param>
        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

        /// <summary>
        /// Bw_RunWorkerCompleted
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">RunWorkerCompletedEventArgs</param>
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("The End");
        }

        /// <summary>
        /// Button1_Click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
