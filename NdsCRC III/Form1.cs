//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Zed Byt Corp">
//     Copyright Zed Byt Corp 2010
// </copyright>
//-----------------------------------------------------------------------

namespace NdsCRC_III
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    using NdsCRC_III.BusinessService;

    /// <summary>
    /// Test form
    /// </summary>
    public partial class Form1 : Form
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
        /// Constructor of Form1 : used for test
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _controler = new MFControler(Application.StartupPath);

            sourceCollection.DataSource = _controler.GetCollection();
            dataGridView1.DataSource = sourceCollection;

            sourceAdvanScene.DataSource = _controler.GetDataBase();
            dataGridView2.DataSource = sourceAdvanScene;

            sourceMissing.DataSource = _controler.GetCollectionMissing();
            dataGridView3.DataSource = sourceMissing;

            label1.DataBindings.Add("Text", sourceAdvanScene, "Title");
            
            Init(dataGridView1);
            Init(dataGridView2);
            Init(dataGridView3);
        }
        
        /// <summary>
        /// whatever
        /// </summary>
        /// <param name="dataGridView1">dataGridView1</param>
        private void Init(DataGridView dataGridView1)
        {
            dataGridView1.Columns["ImageNumber"].Visible = false;
            dataGridView1.Columns["ReleaseNumber"].Visible = false;
            dataGridView1.Columns["Title"].Visible = true;
            dataGridView1.Columns["SaveType"].Visible = false;
            dataGridView1.Columns["RomSize"].Visible = false;
            dataGridView1.Columns["Publisher"].Visible = false;
            dataGridView1.Columns["Location"].Visible = false;
            dataGridView1.Columns["SourceRom"].Visible = false;
            dataGridView1.Columns["languageString"].Visible = false;
            dataGridView1.Columns["RomCRC"].Visible = false;
            dataGridView1.Columns["ImgCoverCRC"].Visible = false;
            dataGridView1.Columns["ImgInGameCRC"].Visible = false;
            dataGridView1.Columns["IcoCRC"].Visible = false;
            dataGridView1.Columns["NFOCRC"].Visible = false;
            dataGridView1.Columns["Genre"].Visible = false;
            dataGridView1.Columns["DumpDate"].Visible = false;
            dataGridView1.Columns["InternalName"].Visible = false;
            dataGridView1.Columns["Serial"].Visible = false;
            dataGridView1.Columns["Version"].Visible = false;
            dataGridView1.Columns["Wifi"].Visible = false;
            dataGridView1.Columns["duplicateid"].Visible = false;

            // dataGridView1.Columns["Have"].Visible = false;
            dataGridView1.Columns["RomNumber"].Visible = true;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Columns["RomNumber"].DisplayIndex = 0;
            dataGridView1.Columns["RomNumber"].HeaderText = "#";
            dataGridView1.Columns["RomNumber"].Width = 40;
            dataGridView1.Columns["Title"].Width = 390;
        }

        /// <summary>
        /// DataGridView2_CellClick
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.DataBindings.Clear();
            label1.DataBindings.Add("Text", sourceAdvanScene, "Title");
        }

        /// <summary>
        /// DataGridView1_CellClick
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.DataBindings.Clear();
            label1.DataBindings.Add("Text", sourceCollection, "Title");
        }

        /// <summary>
        /// DataGridView3_CellClick
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        private void DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            label1.DataBindings.Clear();
            label1.DataBindings.Add("Text", dgv.DataSource, "Title");
        }

        /// <summary>
        /// Button1_Click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            _controler.RepairCollection();
        }
    }
}
