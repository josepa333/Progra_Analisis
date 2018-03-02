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
        private Bitmap bitImage;
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

            bitImage = new Bitmap(filename, true);

            this.selected_picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.selected_picture.Image = Image.FromFile(filename);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal generations = Decimal.ToInt32(this.Q_generations.Value); 
            NaturalSelection naturalSelection = new NaturalSelection(bitImage,
                Decimal.ToInt32(this.Q_generations.Value),
                Decimal.ToInt32(this.Q_population.Value),
                Decimal.ToInt32(this.childsPerGeneration.Value),
                Decimal.ToDouble(this.mutabilityPercentage.Value),
                Decimal.ToDouble(this.pAwNa.Value),
                Decimal.ToDouble(this.pNAwNa.Value),
                Decimal.ToDouble(this.pAwA.Value),
                Decimal.ToDouble(this.pAdaptableImages.Value));
        }
    }
}
