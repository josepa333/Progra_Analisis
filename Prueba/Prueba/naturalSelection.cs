using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prueba
{
    class naturalSelection
    {
        List<Image> images;

        public naturalSelection(Bitmap desireImage,int p_mutation, int quantityGenerations, int quantityImages, int population)
        {
            images = new List<Image>();
            createImages(quantityImages);
            Image.finalImage = new Image(desireImage);
            Image.mutability = p_mutation;

            images = Sort.mergeSort(images);   
            
        }

        private void createImages(int quantityImages)
        {
            for(int i = 0; i < quantityImages; i++)
            {
                images.Add(new Image());
            }
        }
    }
}
