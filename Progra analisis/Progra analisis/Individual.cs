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
        public static int mutations = 0;
        public static int sectionsPerImage = 3;

        private int geneticMutability = 20; //Mutability in the genes of each Image, if there is a mutation
        private List<List<int>> histogramDarkness;
        private List<List<int>> histogramRGB;
        private Adaptability adaptability;
        private Bitmap bitmap;


        private Bitmap generateBitmap()
        {
            Bitmap newImage = new Bitmap(finalImage.getBitmap().Width, finalImage.getBitmap().Height);
            Random rnd = new Random();

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
            return newImage;
        }

        private void dissectImage()
        {
            int contadorX = 0;
            int contadorY = 0;
            int fatherWidht = bitmap.Width / 3;
            int fatherHight = bitmap.Height / 3;
            ArrayList pixelPerSection = new ArrayList();

            while (contadorX != 3 && contadorY != 3)
            {
                for (int j = (bitmap.Height / 3) * contadorY; j < (bitmap.Height / 3) * (contadorY + 1); j++)
                {
                    for (int i = (bitmap.Width / 3) * contadorX; i < (bitmap.Width / 3) * (contadorX + 1); i++)
                    {
                        pixelPerSection.Add(bitmap.GetPixel(i, j));
                    }
                }

                fillRGBHistogram(pixelPerSection);
                fillDarknessHistogram(pixelPerSection);
                pixelPerSection = new ArrayList();

                if (contadorX == 1 && contadorY == 2)
                {
                    break;
                }
                else
                {
                    if (contadorX == 2)
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

        private void fillRGBHistogram(ArrayList pixelPerSection)//Fills the histograms with the total appearances of each tone of the color
        {
            ArrayList redHistogram = new ArrayList();
            ArrayList greenHistogram = new ArrayList();
            ArrayList blueHistogram = new ArrayList();
            List<int> sectionRGB = new List<int>(768);

            for (int i = 0; i < 256; i++)
            {
                redHistogram.Add(0);
                greenHistogram.Add(0);
                blueHistogram.Add(0);
            }

            for (int i = 0; i < pixelPerSection.Count; i++)
            {
                Color clr = (Color)pixelPerSection[i];
                redHistogram[clr.R] = (int)redHistogram[clr.R] + 1;
                greenHistogram[clr.G] = (int)greenHistogram[clr.G] + 1;
                blueHistogram[clr.B] = (int)blueHistogram[clr.B] + 1;
            }

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

        private void fillDarknessHistogram(ArrayList pixelPerSection)
        {
            List<int> sectionBinary = new List<int>(2);
            sectionBinary.Add(0);
            sectionBinary.Add(0);

            for (int i = 0; i < pixelPerSection.Count; i++)
            {
                int colorAverage = (((Color)pixelPerSection[i]).R + ((Color)pixelPerSection[i]).G + ((Color)pixelPerSection[i]).B) / 3;
                if (colorAverage < 127)
                {
                    sectionBinary[0]++;
                }
                else
                {
                    sectionBinary[1]++;
                }
            }
            histogramDarkness.Add(sectionBinary);
        }

        public Individual()
        {
            histogramRGB = new List<List<int>>(sectionsPerImage * sectionsPerImage);
            histogramDarkness = new List<List<int>>(sectionsPerImage * sectionsPerImage);
            bitmap = generateBitmap();
            dissectImage();
            adaptability = new Adaptability(histogramRGB, histogramDarkness);
            histogramRGB.Clear();
            histogramDarkness.Clear();
        }

        public Individual(Bitmap p_kid, int cero)
        {
            histogramRGB = new List<List<int>>();
            histogramDarkness = new List<List<int>>();
            bitmap = p_kid;
        }

        public Individual(Bitmap p_kid)
        {
            histogramRGB = new List<List<int>>();
            histogramDarkness = new List<List<int>>();
            bitmap = p_kid;
            dissectImage();
            adaptability = new Adaptability(histogramRGB, histogramDarkness);
        }

        public Individual crossOver(Individual soulmate)
        {
            Bitmap bitmap_kid = new Bitmap(bitmap.Width, bitmap.Height);
            Random rnd = new Random();
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    if (rnd.Next(0, 1) == 2)
                    {
                        bitmap_kid.SetPixel(i, j, bitmap.GetPixel(i, j));
                    }
                    else
                    {
                        bitmap_kid.SetPixel(i, j, soulmate.getBitmap().GetPixel(i, j));
                    }
                }
            }
            return new Individual(bitmap_kid);
        }

        public Individual mutation(Individual soulmate)
        {
            mutations++;
            Bitmap bitmap_kid = new Bitmap(bitmap.Width, bitmap.Height);
            Random rnd = new Random();

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int selector = rnd.Next(0, 100);

                    if (selector < geneticMutability)
                    {
                        int rojo = rnd.Next(0, 256);
                        int verde = rnd.Next(0, 256);
                        int azul = rnd.Next(0, 256);
                        //ALPHAAAA

                        Color newco = Color.FromArgb(rojo, verde, azul);
                        bitmap_kid.SetPixel(i, j, newco);
                    }
                    else
                    {
                        if (rnd.Next(0, 1) == 2)
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

        public Bitmap getBitmap()
        {
            return bitmap;
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
            adaptability = new Adaptability(histogramRGB, histogramDarkness);
        }

        public int getAdaptability(int adaptabilityOperation)
        {
            return adaptability.getAdaptability(adaptabilityOperation);
        }
    }
}
