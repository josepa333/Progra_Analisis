﻿using System;
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
            Bitmap ima = new Bitmap(path, true);

            int contadorX = 0;
            int contadorY = 0;
            int fatherWidht = ima.Width / 3;
            int fatherHight = ima.Height / 3;
            int xNuevo = 0;
            int yNuevo = 0;
            Bitmap imaT = new Bitmap(fatherWidht, fatherHight);

            while (contadorX != 3 && contadorY != 3)
            {
                imaT = new Bitmap(fatherWidht, fatherHight);
                for (int j = (ima.Height / 3) * contadorY; j < (ima.Height / 3) * (contadorY + 1); j++)
                {
                    for (int i = (ima.Width / 3) * contadorX; i < (ima.Width / 3) * (contadorX + 1); i++)
                    {
                        imaT.SetPixel(xNuevo,yNuevo,ima.GetPixel(i, j));
                        xNuevo++;
                        if (xNuevo == fatherWidht - 1)
                        {
                            xNuevo = 0;
                        }
                    }
                    yNuevo++;
                }
                xNuevo = yNuevo = 0;

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
            Console.WriteLine("Listo");
            imaT.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Progra_Analisis\newima.JPG");
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

