using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace Prueba
{
    class Image
    {
        static Bitmap finalImage;
        static int mutability;


        private Bitmap bitmap;
        private ArrayList redHistogram = new ArrayList();
        private ArrayList greenHistogram = new ArrayList();
        private ArrayList blueHistogram = new ArrayList();


        public Image()
        {
            for (int i = 0; i < 256; i++)
            {
                redHistogram.Add(0);
                greenHistogram.Add(0);
                blueHistogram.Add(0);
            }
            bitmap = generateBitmap();
            fillHistograms();
        }

        private Image(Bitmap p_kid)
        {
            bitmap = p_kid;
            for (int i = 0; i < 256; i++)
            {
                redHistogram.Add(0);
                greenHistogram.Add(0);
                blueHistogram.Add(0);
            }
            fillHistograms();
        }

        private Bitmap generateBitmap()
        {
            Bitmap newImage = new Bitmap(finalImage.Width, finalImage.Height);
            Random rnd = new Random();

            for (int i = 0; i < newImage.Width; i++)
            {
                for (int j = 0; j < newImage.Height; j++)
                {
                    int rojo = rnd.Next(0, 256);
                    int verde = rnd.Next(0, 256);
                    int azul = rnd.Next(0, 256);

                    Color newco = Color.FromArgb(rojo, verde, azul);
                    newImage.SetPixel(i, j, newco);
                }
            }
            return newImage;
        }

        private void fillHistograms()//Fills the histograms with the total appearances of each tone of the color
        {
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
        }

        public Image crossOver(Image soulmate)
        {
            Bitmap bitmap_kid = new Bitmap(bitmap.Width, bitmap.Height);
            Random rnd = new Random();
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int selector = rnd.Next(0, 100);

                    if (selector < mutability)
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

    }
}
