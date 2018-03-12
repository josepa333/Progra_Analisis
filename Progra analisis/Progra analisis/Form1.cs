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
using System.Threading;

namespace Progra_analisis
{
    public partial class Form1 : Form
    {
        private NaturalSelection naturalSelection;
        private Bitmap bitImage;
        private Object locker = new Object();

        public Form1()
        {
            InitializeComponent();
            Statistics.saveStatistics();
            Statistics.loadStatistics();

            
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
            this.output11.SizeMode = PictureBoxSizeMode.StretchImage;

            this.goBack.Visible = false;
            this.distance1.Visible = false;
            this.distance2.Visible = false;
            this.distance3.Visible = false;
            this.distance4.Visible = false;
            this.distance5.Visible = false;
            this.distance6.Visible = false;
            this.distance7.Visible = false;
            this.distance8.Visible = false;
            this.distance9.Visible = false;
            this.distance10.Visible = false;
            this.distance11.Visible = false;

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
            this.output11.Visible = false;
            this.saveResults.Visible = false;

            this.bestDistance.Visible = false;
            this.worstDistance.Visible = false;
            this.mediumDistance.Visible = false;
            
        }

        struct DataParameter
        {
            public int Process;
            public int Delay;
        }

        private DataParameter _inputparameter;


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

        private void hideWidgets()
        {
            this.Q_generations.Visible = !this.Q_generations.Visible;
            this.Q_population.Visible = !this.Q_population.Visible;
            this.mutationsPerGeneration.Visible = !this.mutationsPerGeneration.Visible;
            this.pAwNa.Visible = !this.pAwNa.Visible;
            this.pNAwNa.Visible = !this.pNAwNa.Visible;
            this.pAwA.Visible = !this.pAwA.Visible;
            this.pAdaptableImagesPercentage.Visible = !this.pAdaptableImagesPercentage.Visible;
            this.adapatblesPercentageToCopy.Visible = !this.adapatblesPercentageToCopy.Visible;
            this.childsPerGenerations.Visible = !this.childsPerGenerations.Visible;
            this.goBack.Visible = !this.goBack.Visible;


            this.label2.Visible = !this.label2.Visible;
            this.label3.Visible = !this.label3.Visible;
            this.label4.Visible = !this.label4.Visible;
            this.label6.Visible = !this.label6.Visible;
            this.label7.Visible = !this.label7.Visible;
            this.label8.Visible = !this.label8.Visible;
            this.label9.Visible = !this.label9.Visible;
            this.label10.Visible = !this.label10.Visible;
            this.label11.Visible = !this.label11.Visible;

            this.selected_picture.Visible = !this.selected_picture.Visible;
            this.BT_selectImage.Visible = !this.BT_selectImage.Visible;
            this.button1.Visible = !this.button1.Visible;

            this.groupBox2.Visible = !this.groupBox2.Visible;
            this.groupBox1.Visible = !this.groupBox1.Visible;

            this.distance1.Visible = !this.distance1.Visible;
            this.distance2.Visible = !this.distance2.Visible;
            this.distance3.Visible = !this.distance3.Visible;
            this.distance4.Visible = !this.distance4.Visible;
            this.distance5.Visible = !this.distance5.Visible;
            this.distance6.Visible = !this.distance6.Visible;
            this.distance7.Visible = !this.distance7.Visible;
            this.distance8.Visible = !this.distance8.Visible;
            this.distance9.Visible = !this.distance9.Visible;
            this.distance10.Visible = !this.distance10.Visible;
            this.distance11.Visible = !this.distance11.Visible;


            this.output1.Visible = !this.output1.Visible;
            this.output2.Visible = !this.output2.Visible;
            this.output3.Visible = !this.output3.Visible;
            this.output4.Visible = !this.output4.Visible;
            this.output5.Visible = !this.output5.Visible;
            this.output6.Visible = !this.output6.Visible;
            this.output7.Visible = !this.output7.Visible;
            this.output8.Visible = !this.output8.Visible;
            this.output9.Visible = !this.output9.Visible;
            this.output10.Visible = !this.output10.Visible;
            this.output11.Visible = !this.output11.Visible;
            this.saveResults.Visible = !this.saveResults.Visible;

            this.bestDistance.Visible = !this.bestDistance.Visible;
            this.worstDistance.Visible = !this.worstDistance.Visible;
            this.mediumDistance.Visible = !this.mediumDistance.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (!backgroundWorker.IsBusy)
            {
                _inputparameter.Delay = 100;
                _inputparameter.Process = 1200;
                backgroundWorker.RunWorkerAsync(_inputparameter);
            }*/
            

            int numberOfAaptables = Convert.ToInt32(((this.pAdaptableImagesPercentage.Value) / 100) * this.Q_population.Value);
            int mutationValidation = Convert.ToInt32((this.Q_population.Value - this.childsPerGenerations.Value - ((this.adapatblesPercentageToCopy.Value / 100) * numberOfAaptables)));
            
            if (bitImage != null &&
                this.Q_generations.Value > 1 &&
                this.Q_population.Value > 1 &&
                this.childsPerGenerations.Value > 1 &&
                ((this.pAwNa.Value + this.pNAwNa.Value + this.pAwA.Value) == 100) &&
                this.childsPerGenerations.Value <= this.Q_population.Value &&
                this.mutationsPerGeneration.Value <= mutationValidation)
            {
                if ( numberOfAaptables >= 2)
                {
                    hideWidgets();

                    if (this.RGBSelected.Checked == true)
                    {
                        Individual.histrogramSelected = 0;
                    }
                    else
                    {
                        Individual.histrogramSelected = 1;
                    }

                    if (this.manhattan.Checked == true)
                    {
                        Individual.distanceSelected = 0;
                    }
                    else
                    {
                        Individual.distanceSelected = 1;
                    }

                    naturalSelection = new NaturalSelection(bitImage,
                        Decimal.ToInt32(this.Q_generations.Value),
                        Decimal.ToInt32(this.Q_population.Value),
                        Decimal.ToInt32(this.childsPerGenerations.Value),
                        Decimal.ToInt32(this.mutationsPerGeneration.Value),
                        Decimal.ToDouble(this.pAwNa.Value) / 100,
                        Decimal.ToDouble(this.pNAwNa.Value) / 100,
                        Decimal.ToDouble(this.pAwA.Value) / 100,
                        Decimal.ToDouble(this.pAdaptableImagesPercentage.Value) / 100,
                        Decimal.ToInt32(this.adapatblesPercentageToCopy.Value) / 100,
                        3);

                    Individual[] imagesToDisplay = naturalSelection.genericAlgorithm();
                    double[] bestDistances = naturalSelection.getBestDistances();

                    this.bestDistance.Text = bestDistances[0].ToString();
                    this.mediumDistance.Text = bestDistances[1].ToString();
                    this.worstDistance.Text = bestDistances[2].ToString();

                    this.output1.Image = imagesToDisplay[0].getBitmap();
                    this.distance1.Text = imagesToDisplay[0].getGeneration().ToString();   ; //imagesToDisplay[0].getDistance().ToString();

                    this.output2.Image = imagesToDisplay[1].getBitmap();
                    this.distance2.Text = imagesToDisplay[1].getGeneration().ToString();

                    this.output3.Image = imagesToDisplay[2].getBitmap();
                    this.distance3.Text = imagesToDisplay[2].getGeneration().ToString();

                    this.output4.Image = imagesToDisplay[3].getBitmap();
                    this.distance4.Text = imagesToDisplay[3].getGeneration().ToString();

                    this.output5.Image = imagesToDisplay[4].getBitmap();
                    this.distance5.Text = imagesToDisplay[4].getGeneration().ToString();

                    this.output6.Image = imagesToDisplay[5].getBitmap();
                    this.distance6.Text = imagesToDisplay[5].getGeneration().ToString();

                    this.output7.Image = imagesToDisplay[6].getBitmap();
                    this.distance7.Text = imagesToDisplay[6].getGeneration().ToString();

                    this.output8.Image = imagesToDisplay[7].getBitmap();
                    this.distance8.Text = imagesToDisplay[7].getGeneration().ToString();

                    this.output9.Image = imagesToDisplay[8].getBitmap();
                    this.distance9.Text = imagesToDisplay[8].getGeneration().ToString();

                    this.output10.Image = imagesToDisplay[9].getBitmap();
                    this.distance10.Text = imagesToDisplay[9].getGeneration().ToString();

                    this.output11.Image = imagesToDisplay[10].getBitmap();
                    this.distance11.Text = imagesToDisplay[10].getGeneration().ToString();


                    //threadLoading thread = new threadLoading(naturalSelection);
                    //Thread thr = new Thread(new ThreadStart(run));
                    //thr.Start();

                    Statistics statistic = new Statistics(naturalSelection);
                    Statistics.addStatistic(statistic);
                }
                else
                {
                    MessageBox.Show("Verify there has to be at least two adaptables individuals to be able to cross");
                }

            }
            else
            {
                MessageBox.Show("Verify the given data");
            }
            
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

        private void RGBSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (this.darknessSelected.Checked == true)
            {
                this.darknessSelected.Checked = false;
                this.RGBSelected.Checked = true;
            }
        }

        private void darknessSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RGBSelected.Checked == true)
            {
                this.RGBSelected.Checked = false;
                this.darknessSelected.Checked = true;
            }
        }

        private void manhattan_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Surprise.Checked == true)
            {
                this.Surprise.Checked = false;
                this.manhattan.Checked = true;
            }
        }

        private void Surprise_CheckedChanged(object sender, EventArgs e)
        {
            if (this.manhattan.Checked == true)
            {
                this.manhattan.Checked = false;
                this.Surprise.Checked = true;
            }
        }

        private void saveResults_Click(object sender, EventArgs e)
        {
            Statistics.saveStatistics();
            MessageBox.Show("The progress has been saved.");
        }

        private void goBack_Click(object sender, EventArgs e)
        {
            hideWidgets();
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.output6.Image = naturalSelection.getPositionCero();
            lblProgress.Text = string.Format("Limpando...{0}%", e.ProgressPercentage);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int process = ((DataParameter)e.Argument).Process;
            int delay = ((DataParameter)e.Argument).Delay;
            int index = 1;
            try
            {
                for (int i = 1; i < process; i++)
                {
                    if (!backgroundWorker.CancellationPending)
                    {
                        backgroundWorker.ReportProgress(index++ * 100 / (1 + process));
                        Thread.Sleep(1000);
                    }
                    if (naturalSelection.getGenerations()- 2 < naturalSelection.getGenerationCounter())
                    {
                        if (backgroundWorker.IsBusy)
                            backgroundWorker.CancelAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                backgroundWorker.CancelAsync();
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Limpeza Terminada.");
        }
    }
}
