using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    class Sort
    {
        private static void swapValues(List<Image> images, int indexA, int indexB)
        {
            Image temp = images[indexA];
            images[indexA] = images[indexB];
            images[indexB] = temp;
        }

        private static int partitionList(List<Image> images, int left, int right, Image pivot)
        {
            int leftPointer = left - 1;
            int rightPointer = right;

            while(true)
            {
                while (images[++leftPointer].getAdaptability(1) < pivot.getAdaptability(1)) ;

                while (rightPointer > 0 && images[--rightPointer].getAdaptability(1) > pivot.getAdaptability(1)) ;

                if(leftPointer >= rightPointer)
                {
                    break;
                }
                else
                {
                    swapValues(images, leftPointer, rightPointer);
                }
            }

            swapValues(images, leftPointer, rightPointer);
            return leftPointer;
        }

        public static void quickSort(List<Image> images, int left, int right)
        {
            if (right - left <= 0)
            {
                return; //Base Case
            }
            else
            {
                Image pivot = images[right];
                int pivotLocation = partitionList(images, left, right, pivot);

                quickSort(images, left, pivotLocation - 1);

                quickSort(images, pivotLocation + 1, right);
            }
        }

        public static List<Image> mergeSort(List<Image> images)
        {
            if(images.Count <= 1)
            {
                return images;
            }

            int center = images.Count / 2;
            List<Image> leftImages = new List<Image>(center);
            List<Image> rightImages;

            if(images.Count % 2 == 0)
            {
                rightImages = new List<Image>(center);
            }
            else
            {
                rightImages = new List<Image>(center + 1);
            }

            List<Image> result = new List<Image>();

            for(int i = 0; i < center; i++)
            {
                leftImages[i] = images[i];
            }
        }
    }
}
