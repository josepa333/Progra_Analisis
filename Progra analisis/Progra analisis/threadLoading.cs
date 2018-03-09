using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Progra_analisis
{
    class threadLoading
    {
        public NaturalSelection naturalPointer;
        public loadingScreen view;

        public threadLoading(NaturalSelection pNaturalPointer)
        {
            naturalPointer = pNaturalPointer;
            view = new loadingScreen();
            Thread updater = new Thread(checker);
            updater.Start();
        }

        public void checker()
        {
            while (true)
            {
                int generationCounter = naturalPointer.getGenerationCounter();
                if (generationCounter  > 1 && generationCounter%10 == 0)
                {
                    view.setPicture(naturalPointer.getPositionCero());
                }
                Thread.Sleep(10000);
            }
        }



        /*view.setPicture(naturalPointer.getPositionCero());*/


    }
}
