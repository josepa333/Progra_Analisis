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

    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Progra_Analisis\ima.JPG";
            Bitmap ima = new Bitmap(path,true);

            for (int i = 0; i < ima.Width; i++)
            {
                for (int x = 0; x < ima.Height; x++)
                {
                    Color oc = ima.GetPixel(i, x);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                    ima.SetPixel(i, x, nc);
                }
            }



            ima.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Progra_Analisis\newima.JPG");
            Console.ReadKey();
        }
    }
}
