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

            Random rnd = new Random();
            for (int i = 0; i < ima.Width; i++)
                {
                for (int j = 0; j < ima.Height; j++)
                {
                    int rojo = rnd.Next(0, 254);
                    int verde = rnd.Next(0, 254);
                    int azul = rnd.Next(0, 254);

                    Color newco = Color.FromArgb(rojo, verde, azul);
                    ima.SetPixel(i, j, newco);
                }
            }
            ima.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Progra_Analisis\newima.JPG");
            Console.ReadKey();
        }
    }
}
