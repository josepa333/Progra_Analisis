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
            
            this.output1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output4.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output5.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output6.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output7.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output8.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output9.SizeMode = PictureBoxSizeMode.StretchImage;
            this.output10.SizeMode = PictureBoxSizeMode.StretchImage;

            this.output1.Visible = false;
            this.output2.Visible = false;
            this.output3.Visible = false;
            this.output4.Visible = false;
            this.output5.Visible = false;
            this.output6.Visible = false;
            this.output7.Visible = false;
            this.output8.Visible = false;
            this.output9.Visible = false;
            this.output10.Visible = false;
            
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

            try
            {
                bitImage = new Bitmap(filename, true);
                this.selected_picture.SizeMode = PictureBoxSizeMode.StretchImage;
                this.selected_picture.Image = Image.FromFile(filename);
            }
            catch
            {
                MessageBox.Show("Choose an image");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Borrar todo dentro de esto despues de probar
            List<Bitmap> bitmapsTest = new List<Bitmap>(5);

            Bitmap newImage = new Bitmap(bitImage.Width, bitImage.Height);
            Random rnd = new Random();
            int contador = 0;

            while (contador < 5)
            {
                for (int i = 0; i < newImage.Width; i++)
                {
                    for (int j = 0; j < newImage.Height; j++)
                    {
                        int a = rnd.Next(0, 256);
                        int rojo = rnd.Next(0, 256);
                        int verde = rnd.Next(0, 256);
                        int azul = rnd.Next(0, 256);

                        Color newco = Color.FromArgb(a, rojo, verde, azul);
                        newImage.SetPixel(i, j, newco);
                    }
                }
                bitmapsTest.Add(newImage);
                contador++;
            }
            bitmapsTest.Add(bitImage);

            //Borrar

            //Cambiar a natural selection
            threadLoading thread = new threadLoading(bitmapsTest);
            /*
            if (bitImage != null &&
                this.Q_generations.Value > 1 &&
                this.Q_population.Value > 1 &&
                this.childsPerGenerations.Value > 1 &&
                ((this.pAwNa.Value + this.pNAwNa.Value + this.pAwA.Value) == 100) &&
                this.childsPerGenerations.Value <= this.Q_population.Value &&
                this.sectionsPerImage.Value > 2
                )
            {
                if (this.pAdaptableImages.Value > 0 && this.adapatblesPercentageToCopy.Value <= this.childsPerGenerations.Value 
                    || pAdaptableImages.Value == 0)
                {
                    this.Q_generations.Hide();
                    this.Q_population.Hide();
                    this.mutabilityPercentage.Hide();
                    this.pAwNa.Hide();
                    this.pNAwNa.Hide();
                    this.pAwA.Hide();
                    this.pAdaptableImages.Hide();
                    this.adapatblesPercentageToCopy.Hide();
                    this.childsPerGenerations.Hide();

                    this.label2.Hide();
                    this.label3.Hide();
                    this.label5.Hide();
                    this.label6.Hide();
                    this.label7.Hide();
                    this.label8.Hide();
                    this.label9.Hide();
                    this.label10.Hide();
                    this.label11.Hide();
                    this.label12.Hide();

                    this.selected_picture.Hide();
                    this.BT_selectImage.Hide();
                    this.button1.Hide();

                    this.output1.Visible = true;
                    this.output2.Visible = true;
                    this.output3.Visible = true;
                    this.output4.Visible = true;
                    this.output5.Visible = true;
                    this.output6.Visible = true;
                    this.output7.Visible = true;
                    this.output8.Visible = true;
                    this.output9.Visible = true;
                    this.output10.Visible = true;

                    
                    NaturalSelection naturalSelection = new NaturalSelection(bitImage,
                        Decimal.ToInt32(this.Q_generations.Value),
                        Decimal.ToInt32(this.Q_population.Value),
                        Decimal.ToInt32(this.childsPerGenerations.Value),
                        Decimal.ToDouble(this.mutabilityPercentage.Value) / 100,
                        Decimal.ToDouble(this.pAwNa.Value) / 100,
                        Decimal.ToDouble(this.pNAwNa.Value) / 100,
                        Decimal.ToDouble(this.pAwA.Value) / 100,
                        Decimal.ToDouble(this.pAdaptableImages.Value) / 100,
                        Decimal.ToInt32(this.adapatblesPercentageToCopy.Value) / 100,
                        Decimal.ToInt32(this.sectionsPerImage.Value));
                        

                    
                    Individual[] imagesToDisplay = naturalSelection.genericAlgorithm();

                    
                    this.output1.Image = imagesToDisplay[0].getBitmap();
                    this.output2.Image = imagesToDisplay[1].getBitmap();
                    this.output3.Image = imagesToDisplay[2].getBitmap();
                    
                    this.output4.Image = imagesToDisplay[3].getBitmap();
                    this.output5.Image = imagesToDisplay[4].getBitmap();
                    this.output6.Image = imagesToDisplay[5].getBitmap();
                    this.output7.Image = imagesToDisplay[6].getBitmap();
                    this.output8.Image = imagesToDisplay[7].getBitmap();
                    this.output9.Image = imagesToDisplay[8].getBitmap();
                    this.output10.Image = imagesToDisplay[9].getBitmap();
                    
                }
                else
                {
                    MessageBox.Show("Verify the percentages of adapatbles Percentage To Copy and childs per generation");
                }

            }
            else
            {
                MessageBox.Show("Verify the given data");
            }
            */
        }

        private void selected_picture_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
