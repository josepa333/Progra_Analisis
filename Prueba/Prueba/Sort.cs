using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_analisis
{
    class Sort
    {
        //Private Methods for Merge Sort
        private static List<int> merge(List<int> lefList, List<int> rightList)
        {
            List<int> result = new List<int>(lefList.Count + rightList.Count);
            int indexLeftImages = 0;
            int indexRightImages = 0;
            int indexResult = 0;

            while (indexLeftImages < lefList.Count || indexRightImages < rightList.Count)
            {
                if (indexLeftImages < lefList.Count && indexRightImages < rightList.Count)
                {
                    if (lefList[indexLeftImages] <= rightList[indexRightImages]) //Comparison Ascendent or Descendent
                    {
                        result[indexResult] = lefList[indexLeftImages];
                        indexLeftImages++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = rightList[indexRightImages];
                        indexRightImages++;
                        indexResult++;
                    }
                }
                else
                {
                    if (indexLeftImages < lefList.Count)
                    {
                        result[indexResult] = lefList[indexLeftImages];
                        indexLeftImages++;
                        indexResult++;
                    }
                    else
                    {
                        if (indexRightImages < rightList.Count)
                        {
                            result[indexResult] = rightList[indexRightImages];
                            indexRightImages++;
                            indexResult++;
                        }
                    }
                }
            }
            return result;
        }

        //Private Methods for Quick Sort
        private static void swapValues(List<int> list, int indexA, int indexB)
        {
            int temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        private static int partitionList(List<int> list, int left, int right, int pivot)
        {
            int leftPointer = left - 1;
            int rightPointer = right;

            while (true)
            {
                while (list[++leftPointer] < pivot) ; //Comparison Ascendent or Descendent

                while (rightPointer > 0 && list[--rightPointer] > pivot) ; //Comparison Ascendent or Descendent

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

        public static void quickSort(List<int> list, int left, int right)
        {
            if (right - left <= 0)
            {
                return; //Base Case
            }
            else
            {
                int pivot = list[right];
                int pivotLocation = partitionList(list, left, right, pivot);

                quickSort(list, left, pivotLocation - 1);

                quickSort(list, pivotLocation + 1, right);
            }
        }

        public static List<int> mergeSort(List<int> images)
        {
            if (images.Count <= 1)
            {
                return images; //Base Case
            }

            int center = images.Count / 2;
            List<int> leftList = new List<int>(center);
            List<int> rightList;

            if (images.Count % 2 == 0)
            {
                rightList = new List<int>(center);
            }
            else
            {
                rightList = new List<int>(center + 1);
            }

            List<int> result = new List<int>(images.Count);

            for (int i = 0; i < center; i++)
            {
                leftList[i] = images[i];
            }

            int c = 0;
            for (int j = center; j < images.Count; j++)
            {
                if (c != images.Count)
                {
                    rightList[c] = images[j];
                    c++;
                }
            }

            leftList = mergeSort(leftList);
            rightList = mergeSort(rightList);

            result = merge(leftList, rightList);

            return result;
        }
    }
}
