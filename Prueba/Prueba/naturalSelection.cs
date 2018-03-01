using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prueba
{
    class NaturalSelection
    {
        private List<Image> images;
        private int adaptableImagesPercentage = 0; //Defines the percentage of each population that will be defined as the most adaptables.
        private int cross_A_A_percentage = 0; //Cross percentage of childs from two parents with high adaptability.
        private int cross_NA_NA_percentage = 0; //Cross percentage of childs from two parents with low adaptability.
        private int cross_A_NA_percentage = 0; //Cross percentage of chlds from a high adaptability parent with a lowone.
        private int childMutationPercentage = 0; //Percentage of the total of childs that will have a mutation.
        private int childsPerGeneration = 0;
        private int generations = 0;
        private int population = 0;

        private void createImages(int quantityImages)
        {
            for (int i = 0; i < quantityImages; i++)
            {
                images.Add(new Image());
            }
        }

        //Selects the adaptable individuals of the population
        private List<Image> selection_A()
        {
            List<Image> adaptables = new List<Image>(adaptableImagesPercentage);
            if(adaptableImagesPercentage == images.Count)
            {
                return images;
            }
            for(int i = 0; i < adaptableImagesPercentage; i++)
            {
                adaptables[i] = images[i];
            }
            return adaptables;
        }

        //Selects the not adaptable individuals of the population
        private List<Image> selection_NA()
        {
            List<Image> notAdaptables = new List<Image>(images.Count - adaptableImagesPercentage);
            if (adaptableImagesPercentage == images.Count)
            {
                return notAdaptables;
            }
            for (int i = adaptableImagesPercentage; i < images.Count; i++)
            {
                notAdaptables[i] = images[i];
            }
            return notAdaptables;
        }

        //Replace the least not adaptable individuals with the new childs
        private void replace_NA(List<Image> childs)
        {
            int childsIndex = 0;
            int imagesIndex = (images.Count - childs.Count) - 1;
            for(int i = imagesIndex; i < images.Count; i++)
            {
                images[i] = childs[childsIndex];
                childsIndex++;
            }
        }

        public NaturalSelection(Bitmap desireImage, int pGenerations, int pPopulation, int pChildsPerGeneration, double pChildMutationPercentage, double pCross_A_NA_percentage,
            double pCross_NA_NA_percentage, double pCross_A_A_percentage, double pAdaptableImagesPercentage)
        {
            Image.finalImage = new Image(desireImage);
            childsPerGeneration = pChildsPerGeneration;
            generations = pGenerations;
            population = pPopulation;
            adaptableImagesPercentage = (int)pAdaptableImagesPercentage * population;
            cross_A_A_percentage = (int)pCross_A_A_percentage * childsPerGeneration;
            cross_NA_NA_percentage = (int)pCross_NA_NA_percentage * childsPerGeneration;
            cross_A_NA_percentage = (int)pCross_A_NA_percentage * childsPerGeneration;
            childMutationPercentage = (int)pChildMutationPercentage * childsPerGeneration;

            images = new List<Image>(population);
            createImages(population);
            images = Sort.mergeSort(images);   
            
        }

        public double getAdaptableImagesPercentage()
        {
            return adaptableImagesPercentage;
        }

        public double getCross_A_A_percentage()
        {
            return cross_A_A_percentage;
        }

        public double getCross_NA_NA_percentage()
        {
            return cross_NA_NA_percentage;
        }

        public double getCross_A_NA_percentage()
        {
            return cross_A_NA_percentage;
        }

        public double getChildMutationPercentage()
        {
            return childMutationPercentage;
        }

        public int getChildsPerGeneration()
        {
            return childsPerGeneration;
        }

        public int getGenerations()
        {
            return generations;
        }

        public int getPopulation()
        {
            return population;
        }

        public List<Image> genericAlgorithm()
        {
            return images;
        }
    }
}
