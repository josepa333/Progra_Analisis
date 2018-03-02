using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Progra_analisis
{
    class NaturalSelection
    {
        private List<Image> images;
        private int adaptableImagesPercentage; //Defines the percentage of each population that will be defined as the most adaptables.
        private int cross_A_A_percentage; //Cross percentage of childs from two parents with high adaptability.
        private int cross_NA_NA_percentage; //Cross percentage of childs from two parents with low adaptability.
        private int cross_A_NA_percentage; //Cross percentage of chlds from a high adaptability parent with a lowone.
        private int mutationPercentage; //Percentage of mutation when there is a cross.
        private int finalMutationPercentage; //The percentage of mutations per generation.
        private int mutationProbability;//from 0 to a 100 real quick
        private int childsPerGeneration;
        private int generations;
        private int population;

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
            if (adaptableImagesPercentage == images.Count)
            {
                return images;
            }
            for (int i = 0; i < adaptableImagesPercentage; i++)
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
            for (int i = imagesIndex; i < images.Count; i++)
            {
                images[i] = childs[childsIndex];
                childsIndex++;
            }
            Sort.mergeSort(images);
        }

        //Returns the new childs.
        private List<Image> crossOver(List<Image> adaptables, List<Image> notAdaptables)
        {
            int childAmount = childsPerGeneration;
            int cross_A_A = cross_A_A_percentage;
            int cross_A_NA = cross_A_NA_percentage;
            int cross_NA_NA = cross_NA_NA_percentage;
            int rand_A_index;
            int rand_NA_index;
            int childsIndex = 0;
            int index = 0;
            int rand_mutation;
            Random rnd = new Random();
            List<Image> childs = new List<Image>(childAmount);

            while (childAmount != 0)
            {
                while (cross_A_A != 0)
                {
                    if (adaptables.Count >= 2)
                    {
                        rand_A_index = rnd.Next(0, adaptables.Count);
                        Image parent1 = images[rand_A_index];
                        index = rand_A_index;
                        rand_A_index = rnd.Next(0, adaptables.Count);
                        while (rand_A_index != index)
                        {
                            rand_A_index = rnd.Next(0, adaptables.Count);
                        }
                        Image parent2 = images[rand_A_index];
                        rand_mutation = rnd.Next(0, 101);
                        if (rand_mutation <= mutationProbability)
                        {
                            Image child = parent1.mutation(parent2);
                            childs[childsIndex] = child;
                        }
                        else
                        {
                            Image child = parent1.crossOver(parent2);
                            childs[childsIndex] = child;
                        }
                        childsIndex++;
                    }
                    cross_A_A--;
                }
                while (cross_A_NA != 0)
                {
                    if (adaptables.Count >= 1 && notAdaptables.Count >= 1)
                    {
                        rand_A_index = rnd.Next(0, adaptables.Count);
                        rand_NA_index = rnd.Next(0, notAdaptables.Count);
                        Image parent1 = images[rand_A_index];
                        Image parent2 = images[rand_NA_index];
                        rand_mutation = rnd.Next(0, 101);
                        if (rand_mutation <= mutationProbability)
                        {
                            Image child = parent1.mutation(parent2);
                            childs[childsIndex] = child;
                        }
                        else
                        {
                            Image child = parent1.crossOver(parent2);
                            childs[childsIndex] = child;
                        }
                        childsIndex++;
                    }
                    cross_A_NA--;
                }
                while (cross_NA_NA != 0)
                {
                    if (notAdaptables.Count >= 2)
                    {
                        rand_NA_index = rnd.Next(0, notAdaptables.Count);
                        Image parent1 = images[rand_NA_index];
                        index = rand_NA_index;
                        rand_NA_index = rnd.Next(0, notAdaptables.Count);
                        while (rand_NA_index != index)
                        {
                            rand_NA_index = rnd.Next(0, notAdaptables.Count);
                        }
                        Image parent2 = images[rand_NA_index];
                        rand_mutation = rnd.Next(0, 101);
                        if (rand_mutation <= mutationProbability)
                        {
                            Image child = parent1.mutation(parent2);
                            childs[childsIndex] = child;
                        }
                        else
                        {
                            Image child = parent1.crossOver(parent2);
                            childs[childsIndex] = child;
                        }
                        childsIndex++;
                    }
                    cross_NA_NA--;
                }
                childAmount--;
            }
            return childs;
        }

        public NaturalSelection(Bitmap desireImage, int pGenerations, int pPopulation, int pChildsPerGeneration, double pMutabilityPercentage, double pCross_A_NA_percentage,
            double pCross_NA_NA_percentage, double pCross_A_A_percentage, double pAdaptableImagesPercentage)
        {
            Image.finalImage = new Image(desireImage);
            childsPerGeneration = pChildsPerGeneration;
            generations = pGenerations;
            population = pPopulation;
            Image.mutations = 0;
            adaptableImagesPercentage = (int)pAdaptableImagesPercentage * population;
            cross_A_A_percentage = (int)pCross_A_A_percentage * childsPerGeneration;
            cross_NA_NA_percentage = (int)pCross_NA_NA_percentage * childsPerGeneration;
            cross_A_NA_percentage = (int)pCross_A_NA_percentage * childsPerGeneration;
            mutationPercentage = (int)pMutabilityPercentage * 100;
            mutationProbability = mutationPercentage;
            images = new List<Image>(population);
            createImages(population);
            images = Sort.mergeSort(images);

        }

        public int getAdaptableImagesPercentage()
        {
            return adaptableImagesPercentage;
        }

        public int getCross_A_A_percentage()
        {
            return cross_A_A_percentage;
        }

        public int getCross_NA_NA_percentage()
        {
            return cross_NA_NA_percentage;
        }

        public int getCross_A_NA_percentage()
        {
            return cross_A_NA_percentage;
        }

        public int getMutationPercentage()
        {
            return mutationPercentage;
        }

        public int getFinalMutationPercentage()
        {
            return Image.mutations / generations;
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
