using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections;

namespace Progra_analisis
{
    class threadLoading
    {
        public NaturalSelection naturalPointer;
        public loadingScreen view;
        public List<Bitmap> bitmapsTest = new List<Bitmap>(5);

        public threadLoading(List<Bitmap> p_bitmapsTest)//NaturalSelection pNaturalPointer
        {
            //naturalPointer = pNaturalPointer;
            bitmapsTest = p_bitmapsTest;
            view = new loadingScreen();
            view.Show();
            Thread updater = new Thread(checker);
            updater.Start();
        }

        public void checker()
        {
            int contador = 0;
            while (contador <5)
            {
                view.setPicture(bitmapsTest[contador]);
                Thread.Sleep(1000);
                contador++;
            }
        }

        /*
         *                 int generationCounter = naturalPointer.getGenerationCounter();
                if (generationCounter  > 1 && generationCounter%10 == 0)
                {
                    ;
                }*/



        /*view.setPicture(naturalPointer.getPositionCero());*/


    }
}
