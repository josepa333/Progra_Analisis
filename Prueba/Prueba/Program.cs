using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            int elementos = 51200;
            List<int> pixelPerSection = new List<int>(elementos);

            Random rnd = new Random();

            for (int section = 0; section < elementos; section++)
            {
                int rojo = rnd.Next(0, 256);
                pixelPerSection.Add(rojo);
            }



            Stopwatch timer = new Stopwatch();
            timer.Start();
            List<int> sectionBinary = new List<int>(2);
            //add to elements to binary section
            sectionBinary.Add(0);
            sectionBinary.Add(0);
            for (int i = 0; i < pixelPerSection.Count; i++)
            {
                int clr = pixelPerSection[i];
                double value = Math.Sqrt(0.299 * Math.Pow(clr, 2) + 0.587 * Math.Pow(clr, 2) + 0.114 * Math.Pow(clr, 2));
                if (value < 127)
                {
                    sectionBinary[0]++;
                }
                else
                {
                    sectionBinary[1]++;
                }
            }
            timer.Stop();
            Console.WriteLine(timer.Elapsed.ToString());
            Console.ReadKey();

        }
    }
}


/*         
 *                 string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Progra_Analisis\ima.JPG";
        Bitmap ima = new Bitmap(path,true);
        Color nc;

        for (int zone = 0; zone < 4 ; zone++)
        {
            for(int y = (ima.Height / 4) * (zone) ; y < (ima.Height/4) * (zone + 1) ; y++)
            {
                int x = 0;
                while (x < (ima.Width ))
                {
                    nc = Color.FromArgb(10 + ( x/250 * 30 ) , 10 +(30 * zone), 100 + (50 * zone));
                    ima.SetPixel(x, y, nc);
                    x++;
                }
                Console.WriteLine("Y");
            }
            Console.WriteLine("Zona");
        }

        Console.WriteLine("Listo");
        ima.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Progra_Analisis\newima.JPG");
        Console.ReadKey();    
 *         
 *         
 *         
 *         
 *         int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    nc = Color.FromArgb(oc.A, grayScale, grayScale, grayScale);
                }


                ima.SetPixel(i, x, nc);*/

