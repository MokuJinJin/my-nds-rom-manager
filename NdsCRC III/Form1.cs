using System;
using System.Drawing;
using System.Windows.Forms;
using NdsCRC_III.BusinessService;

namespace NdsCRC_III
{
    public partial class Form1 : Form
    {
        private BindingSource bsCollection = new BindingSource();
        private BindingSource bsAdvanScene = new BindingSource();
        private BindingSource bsMissing = new BindingSource();
        private MFControler _controler;
        public Form1()
        {
            InitializeComponent();
            _controler = new MFControler(Application.StartupPath);

            bsCollection.DataSource = _controler.GetCollection();
            dataGridView1.DataSource = bsCollection;

            bsAdvanScene.DataSource = _controler.GetDataBase();
            dataGridView2.DataSource = bsAdvanScene;

            bsMissing.DataSource = _controler.GetCollectionMissing();
            dataGridView3.DataSource = bsMissing;

            label1.DataBindings.Add("Text", bsAdvanScene, "Title");
            
            
            init(dataGridView1);
            init(dataGridView2);
            init(dataGridView3);
        }
        private void init(DataGridView dataGridView1)
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.DataBindings.Clear();
            label1.DataBindings.Add("Text", bsAdvanScene, "Title");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.DataBindings.Clear();
            label1.DataBindings.Add("Text", bsCollection, "Title");
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            label1.DataBindings.Clear();
            label1.DataBindings.Add("Text", dgv.DataSource, "Title");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controler.RepairCollection();
        }
    }
}
