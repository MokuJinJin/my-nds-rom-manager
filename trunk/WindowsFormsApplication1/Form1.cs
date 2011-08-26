using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crom.Controls.Docking;
using Crom.Controls.TabbedDocument;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private DockableFormInfo f2;
        private DockableFormInfo f3;
        private Form3 F3 = new Form3();
        public Form1()
        {
            InitializeComponent();
        }

        private void ViewForm2_Click(object sender, EventArgs e)
        {
            if (insertToolStripMenuItem.Checked)
            {
                f2 = dockContainer1.Add(new Form2(), zAllowedDock.Left, new Guid("00000000-0000-0000-0000-000000000002"));
            }
            else
            {
                dockContainer1.Remove(f2); 
            }
            
        }

        private void ViewForm3_Click(object sender, EventArgs e)
        {
            if (foToolStripMenuItem.Checked)
            {
                f3 = dockContainer1.Add(F3, zAllowedDock.Right, new Guid("00000000-0000-0000-0000-000000000003"));
                //dockContainer1.SetAutoHide(dockContainer1.GetFormInfo(f3.Id),true);
            }
            else
            {
                dockContainer1.Remove(f3);
            }
            
        }

        private void selectForm3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3.IsSelected = true;
            f3.ShowCloseButton = false;
        }

        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (F3.ImageLocation)
            {
                case @"E:\Games\-=Mes Documents=-\Visual Studio 2008\Projects\NdsCRC III\NdsCRC III\bin\Debug\data\img\0001a.png":
                    F3.ChangeImage(@"E:\Games\-=Mes Documents=-\Visual Studio 2008\Projects\NdsCRC III\NdsCRC III\bin\Debug\data\img\0001b.png");
                    break;
                case @"E:\Games\-=Mes Documents=-\Visual Studio 2008\Projects\NdsCRC III\NdsCRC III\bin\Debug\data\img\0001b.png":
                    F3.ChangeImage(@"E:\Games\-=Mes Documents=-\Visual Studio 2008\Projects\NdsCRC III\NdsCRC III\bin\Debug\data\img\0001a.png");
                    break;
                default:
                    F3.ChangeImage(@"E:\Games\-=Mes Documents=-\Visual Studio 2008\Projects\NdsCRC III\NdsCRC III\bin\Debug\data\img\0001b.png");
                    break;
            }
            f3.ShowFormAutoPanel();
        }
    }
}
