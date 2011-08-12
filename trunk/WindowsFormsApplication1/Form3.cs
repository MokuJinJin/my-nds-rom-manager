using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public void ChangeImage(string ImgPath)
        {
            pictureBox1.ImageLocation = ImgPath;
        }
        public string ImageLocation
        {
            get
            {
                return pictureBox1.ImageLocation;
            }
            set
            {
                pictureBox1.ImageLocation = value;
            }
        }
    }
}
