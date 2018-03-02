using System;
using System.Drawing;
using System.Collections;

namespace Prueba
{
    class Image
    {
        public static Image finalImage;
        public static int mutations = 0;


        private int geneticMutability = 20; //Mutability in the genes of each Image, if there is a mutation
        private ArrayList histogramGradient;
        private ArrayList histogramRGB;
        private Adaptability adaptability;
        private Bitmap bitmap;


        public Image()
        {
            histogramRGB = new ArrayList();
            histogramGradient = new ArrayList();
            bitmap = generateBitmap();
            fillHistograms();
            adaptability = new Adaptability(histogramRGB, histogramGradient);
        }

        public Image(Bitmap p_kid)
        {
            histogramRGB = new ArrayList();
            histogramGradient = new ArrayList();
            bitmap = p_kid;
            fillHistograms();
            adaptability = new Adaptability(histogramRGB, histogramGradient);
        }

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

        private void fillHistograms()//Fills the histograms with the total appearances of each tone of the color
        {
            ArrayList redHistogram = new ArrayList();
            ArrayList greenHistogram = new ArrayList();
            ArrayList blueHistogram = new ArrayList();

            for (int i = 0; i < 256; i++)
            {
                redHistogram.Add(0);
                greenHistogram.Add(0);
                blueHistogram.Add(0);
            }

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color clr = bitmap.GetPixel(i, j);
                    redHistogram[clr.R] = (int)redHistogram[clr.R] + 1;
                    greenHistogram[clr.G] = (int)greenHistogram[clr.G] + 1;
                    blueHistogram[clr.B] = (int)blueHistogram[clr.B] + 1;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                histogramRGB.Add(redHistogram[i]);
            }
            for (int i = 0; i < 256; i++)
            {
                histogramRGB.Add(greenHistogram[i]);
            }
            for (int i = 0; i < 256; i++)
            {
                histogramRGB.Add(blueHistogram[i]);
            }
        }

        public Image crossOver(Image soulmate)
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
            return new Image(bitmap_kid);
        }

        public Image mutation(Image soulmate)
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
            return new Image(bitmap_kid);
        }

        public Bitmap getBitmap()
        {
            return bitmap;
        }

        public ArrayList getHistogramRGB()
        {
            return histogramRGB;
        }

        public int getAdaptability(int adaptabilityOperation)
        {
            return adaptability.getAdaptability(adaptabilityOperation);
        }

    }
}
