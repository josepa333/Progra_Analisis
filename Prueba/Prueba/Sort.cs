﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    class Sort
    {
        //Private Methods for Merge Sort
        private static List<Individual> merge(List<Individual> leftImages, List<Individual> rightImages)
        {
            List<Individual> result = new List<Individual>(leftImages.Count + rightImages.Count);
            int indexLeftImages = 0;
            int indexRightImages = 0;
            int indexResult = 0;

            while (indexLeftImages < leftImages.Count || indexRightImages < rightImages.Count)
            {
                if (indexLeftImages < leftImages.Count && indexRightImages < rightImages.Count)
                {
                    if (leftImages[indexLeftImages].getAdaptability(1) <= rightImages[indexRightImages].getAdaptability(1)) //Comparison Ascendent or Descendent
                    {
                        result[indexResult] = leftImages[indexLeftImages];
                        indexLeftImages++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = rightImages[indexRightImages];
                        indexRightImages++;
                        indexResult++;
                    }
                }
                else
                {
                    if (indexLeftImages < leftImages.Count)
                    {
                        result[indexResult] = leftImages[indexLeftImages];
                        indexLeftImages++;
                        indexResult++;
                    }
                    else
                    {
                        if (indexRightImages < rightImages.Count)
                        {
                            result[indexResult] = rightImages[indexRightImages];
                            indexRightImages++;
                            indexResult++;
                        }
                    }
                }
            }
            return result;
        }

        //Private Methods for Quick Sort
        private static void swapValues(Individual[] list, int indexA, int indexB)
        {
            Individual temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        private static int partitionList(Individual[] list, int left, int right, Individual pivot)
        {
            int leftPointer = left - 1;
            int rightPointer = right;

            while (true)
            {
                while (list[++leftPointer].getAdaptability(1) < pivot.getAdaptability(1)) ; //Comparison Ascendent or Descendent

                while (rightPointer > 0 && list[--rightPointer].getAdaptability(1) > pivot.getAdaptability(1)) ; //Comparison Ascendent or Descendent

                if (leftPointer >= rightPointer)
                {
                    break;
                }
                else
                {
                    swapValues(list, leftPointer, rightPointer);
                }
            }

            swapValues(list, leftPointer, right);
            return leftPointer;
        }

        public static void quickSort(Individual[] list, int left, int right)
        {
            if (right - left <= 0)
            {
                return; //Base Case
            }
            else
            {
                Individual pivot = list[right];
                int pivotLocation = partitionList(list, left, right, pivot);

                quickSort(list, left, pivotLocation - 1);

                quickSort(list, pivotLocation + 1, right);
            }
        }

        public static List<Individual> mergeSort(List<Individual> images)
        {
            if (images.Count <= 1)
            {
                return images; //Base Case
            }

            int center = images.Count / 2;
            List<Individual> leftImages = new List<Individual>(center);
            List<Individual> rightImages;

            if (images.Count % 2 == 0)
            {
                rightImages = new List<Individual>(center);
            }
            else
            {
                rightImages = new List<Individual>(center + 1);
            }

            List<Individual> result = new List<Individual>(images.Count);

            for (int i = 0; i < center; i++)
            {
                leftImages[i] = images[i];
            }

            int c = 0;
            for (int j = center; j < images.Count; j++)
            {
                if (c != images.Count)
                {
                    rightImages[c] = images[j];
                    c++;
                }
            }

            leftImages = mergeSort(leftImages);
            rightImages = mergeSort(rightImages);

            result = merge(leftImages, rightImages);

            return result;
        }
    }
}
