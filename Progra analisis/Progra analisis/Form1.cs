using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Progra_analisis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BT_selectImage_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string filename = "";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                //MessageBox.Show(filename);
            }

            //Bitmap ima = new Bitmap(filename, true);

            this.selected_picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.selected_picture.Image = Image.FromFile(filename);


        }
    }
}
