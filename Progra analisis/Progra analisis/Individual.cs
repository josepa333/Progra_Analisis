using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Progra_analisis
{
    class Individual
    {
        public static Individual finalImage;
        public static int sectionsPerImage = 3;
        public static int histrogramSelected = 0; //0 = RGB and 1 = darkness
        public static int distanceSelected = 0; // 0 = Manhattan and 1 = Surprise
        public static double[,] probabilityDistributionRGB = new double[sectionsPerImage*sectionsPerImage,768];
        public static double[,] probabilityDistributionDarkness = new double[sectionsPerImage * sectionsPerImage, 768];
        public static int numberOfPixels;

        private List<List<int>> histogramDarkness;
        private List<List<int>> histogramRGB;
        private Adaptability adaptability;
        private Bitmap bitmap;
        private object lockObject = new object();
        private object locker = new object();

        private Bitmap generateBitmap()
        {
            Bitmap newImage = new Bitmap(finalImage.getBitmap().Width, finalImage.getBitmap().Height);
            Random rnd = new Random();

            for (int i = 0; i < newImage.Width; i++)
            {
                for (int j = 0; j < newImage.Height; j++)
                {
                    int rojo = rnd.Next(0, 256);
                    int verde = rnd.Next(0, 256);
                    int azul = rnd.Next(0, 256);

                    Color newco = Color.FromArgb(255, rojo, verde, azul);
                    newImage.SetPixel(i, j, newco);
                }
            }
            return newImage;
        }

        private void dissectImage()
        {
            int contadorX = 0;
            int contadorY = 0;
            int fatherWidht = bitmap.Width / sectionsPerImage;
            int fatherHight = bitmap.Height / sectionsPerImage;
            ArrayList pixelPerSection = new ArrayList();

            while (contadorX != sectionsPerImage && contadorY != sectionsPerImage)
            {
                for (int j = (bitmap.Height / sectionsPerImage) * contadorY; j < (bitmap.Height / sectionsPerImage) * (contadorY + 1); j++)
                {
                    for (int i = (bitmap.Width / sectionsPerImage) * contadorX; i < (bitmap.Width / sectionsPerImage) * (contadorX + 1); i++)
                    {
                        pixelPerSection.Add(bitmap.GetPixel(i, j));
                    }
                }

                fillHistogram(pixelPerSection);
                pixelPerSection = new ArrayList();

                if (contadorX == sectionsPerImage-1 && contadorY == sectionsPerImage-1)
                {
                    break;
                }
                else
                {
                    if (contadorX == sectionsPerImage-1)
                    {
                        contadorX = 0;
                        contadorY++;
                    }
                    else
                    {
                        contadorX++;
                    }
                }
            }
        }

        private void fillHistogram(ArrayList pixelPerSection)//Fills the histograms with the total appearances of each tone of the color
        {
            ArrayList redHistogram = new ArrayList();
            ArrayList greenHistogram = new ArrayList();
            ArrayList blueHistogram = new ArrayList();

            List<int> sectionBinary = new List<int>(2);
            List<int> sectionRGB = new List<int>(768);


            //add to elements to binary section
            sectionBinary.Add(0);
            sectionBinary.Add(0);

            //add the 255 elements to the RBG arrays
            for (int i = 0; i < 256; i++)
            {
                redHistogram.Add(0);
                greenHistogram.Add(0);
                blueHistogram.Add(0);
            }

            for (int i = 0; i < pixelPerSection.Count; i++)
            {
                Color clr = (Color)pixelPerSection[i];

                if (histrogramSelected == 0)
                {
                    redHistogram[clr.R] = (int)redHistogram[clr.R] + 1;
                    greenHistogram[clr.G] = (int)greenHistogram[clr.G] + 1;
                    blueHistogram[clr.B] = (int)blueHistogram[clr.B] + 1;
                }
                else
                {
                    if (clr.A < 127)
                    {
                        sectionBinary[0]++;
                    }
                    else
                    {
                        sectionBinary[1]++;
                    }
                }
            }
            if (histrogramSelected == 0)
            {
                for (int i = 0; i < 256; i++)
                {
                    sectionRGB.Add((int)redHistogram[i]);
                }
                for (int i = 0; i < 256; i++)
                {
                    sectionRGB.Add((int)greenHistogram[i]);
                }
                for (int i = 0; i < 256; i++)
                {
                    sectionRGB.Add((int)blueHistogram[i]);
                }
                histogramRGB.Add(sectionRGB);
            }
            else
            {
                histogramDarkness.Add(sectionBinary);
            }   
        }

        public Individual()
        {
            histogramRGB = new List<List<int>>(sectionsPerImage * sectionsPerImage);
            histogramDarkness = new List<List<int>>(sectionsPerImage * sectionsPerImage);
            bitmap = generateBitmap();
            dissectImage();
            if (Individual.histrogramSelected == 0)
            {
                adaptability = new Adaptability(histogramRGB);
            }
            if (Individual.histrogramSelected == 1)
            {
                adaptability = new Adaptability(histogramDarkness);
            }
            histogramRGB.Clear();
            histogramDarkness.Clear();
        }

        public Individual(Bitmap p_kid, int cero)
        {
            histogramRGB = new List<List<int>>();
            histogramDarkness = new List<List<int>>();
            bitmap = p_kid;
            Individual.numberOfPixels = (p_kid.Height / 3) * (p_kid.Width / 3);
        }

        public Individual(Bitmap p_kid)
        {
            histogramRGB = new List<List<int>>(sectionsPerImage * sectionsPerImage);
            histogramDarkness = new List<List<int>>(sectionsPerImage * sectionsPerImage);
            bitmap = p_kid;
            dissectImage();
            if (Individual.histrogramSelected == 0)
            {
                adaptability = new Adaptability(histogramRGB);
            }
            if (Individual.histrogramSelected == 1)
            {
                adaptability = new Adaptability(histogramDarkness);
            }
            histogramRGB.Clear();
            histogramDarkness.Clear();
        }

        public Individual crossOver(Individual soulmate)
        {
            Bitmap bitmap_kid = new Bitmap(bitmap.Width, bitmap.Height);
            lock (lockObject)
            {
                Random rnd = new Random();
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color clr = bitmap.GetPixel(i, j);
                        if (rnd.Next(0, 1) == 2)
                        {
                            bitmap_kid.SetPixel(i, j, Color.FromArgb(255, clr.R, clr.G, clr.B));
                        }
                        else
                        {
                            clr = soulmate.getBitmap().GetPixel(i, j);
                            bitmap_kid.SetPixel(i, j, Color.FromArgb(255, clr.R, clr.G, clr.B));
                        }
                    }
                }
            }
            return new Individual(bitmap_kid);
        }


        private int checkPixel(int i, int j, Color father, Color mother)
        {
            Color clr = finalImage.getBitmap().GetPixel(i, j);
            int distanceFather = Math.Abs(father.R - clr.R) + Math.Abs(father.G - clr.G) + Math.Abs(father.B - clr.B);
            int distanceMother = Math.Abs(mother.R - clr.R) + Math.Abs(mother.G - clr.G) + Math.Abs(mother.B - clr.B);

            if (distanceFather < distanceMother)
            {
                return 1;
            }
            return 0;
        }

        public Individual crossOverLookingOver(Individual soulmate)
        {
            Bitmap bitmap_kid = new Bitmap(bitmap.Width, bitmap.Height);
            Random rnd = new Random();

            lock (lockObject)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        int which = checkPixel(i, j, bitmap.GetPixel(i, j), soulmate.getBitmap().GetPixel(i, j));
                        if (which == 1)
                        {
                            bitmap_kid.SetPixel(i, j, bitmap.GetPixel(i, j));
                        }
                        else
                        {
                            bitmap_kid.SetPixel(i, j, soulmate.getBitmap().GetPixel(i, j));
                        }
                    }
                }
            }
            return new Individual(bitmap_kid);
        }

        public void mutation()
        {
            Random rnd = new Random();
            int mutationsApplied = 0;
            int dimentions = (bitmap.Height * bitmap.Width) / 4;
            while (mutationsApplied < dimentions)
            {
                int red = rnd.Next(0, 256);
                int green = rnd.Next(0, 256);
                int blue = rnd.Next(0, 256);

                int x = rnd.Next(0, bitmap.Width - 1);
                int y = rnd.Next(0, bitmap.Height - 1);

                Color newco = Color.FromArgb(red, green, blue);
                bitmap.SetPixel(x , y , newco);
                mutationsApplied++;
            }
        }

        public Bitmap getBitmap()
        {
            Bitmap b;
            lock (lockObject)
            {
               b  = new Bitmap(bitmap);
            }
            return b;
        }

        public List<List<int>> getHistogramRGB()
        {
            return histogramRGB;
        }

        public List<List<int>> getHistogramDarkness()
        {
            return histogramDarkness;
        }

        public void dataForFinalImage()
        {
            dissectImage();
            Individual.probDistributionRGB(Individual.finalImage.getHistogramRGB());
            Individual.probDistributionDarkness(Individual.finalImage.getHistogramDarkness());
        }

        public double getDistance()
        {
            return adaptability.getDistance();
        }

        public static void probDistributionRGB(List<List<int>> histogramRGB)
        { 
            double[] probablityPerSection = new double[768];

            for (int section = 0; section < histogramRGB.Count; section++)
            {
                for (int i = 0; i < histogramRGB[section].Count; i++)
                {
                    Individual.probabilityDistributionRGB[section,i] = (histogramRGB[section][i] / Individual.numberOfPixels);
                }
            }
        }

        public static void probDistributionDarkness(List<List<int>> histogramDarkness)
        {

            List<double> probablityPerSection = new List<double>(768);

            for (int section = 0; section < histogramDarkness.Count; section++)
            {
                for (int i = 0; i < histogramDarkness[section].Count; i++)
                {
                    Individual.probabilityDistributionRGB[section, i] = (histogramDarkness[section][i] / Individual.numberOfPixels);
                }
            }
        }
    }
}
