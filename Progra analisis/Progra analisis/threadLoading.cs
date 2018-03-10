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

        //Borrar
        public List<Bitmap> bitmapsTest = new List<Bitmap>(5);

        public threadLoading(NaturalSelection pNaturalPointer)//NaturalSelection pNaturalPointer
        {
            naturalPointer = pNaturalPointer;
            view = new loadingScreen();
            view.Show();
            Thread updater = new Thread(checker);
            updater.Start();
        }

        public void checker()
        {
            int contador = 0;
            while (true)
            {
                view.actualPicture.Image = naturalPointer.getPositionCero();
                //view.label2.Text = naturalPointer.getGenerationCounter().ToString();
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
