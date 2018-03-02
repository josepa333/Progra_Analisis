﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Progra_analisis
{
    class NaturalSelection
    {
        private List<Individual> images;
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
        


        public NaturalSelection(Bitmap desireImage, int pGenerations, int pPopulation, int pChildsPerGeneration, double pMutabilityPercentage, double pCross_A_NA_percentage,
            double pCross_NA_NA_percentage, double pCross_A_A_percentage, double pAdaptableImagesPercentage)
        {
            Individual.finalImage = new Individual(desireImage);
            childsPerGeneration = pChildsPerGeneration;
            generations = pGenerations;
            population = pPopulation;
            Individual.mutations = 0;
            adaptableImagesPercentage = (int)pAdaptableImagesPercentage * population;
            cross_A_A_percentage = (int)pCross_A_A_percentage * childsPerGeneration;
            cross_NA_NA_percentage = (int)pCross_NA_NA_percentage * childsPerGeneration;
            cross_A_NA_percentage = (int)pCross_A_NA_percentage * childsPerGeneration;
            mutationPercentage = (int)pMutabilityPercentage * 100;
            mutationProbability = mutationPercentage;
            images = new List<Individual>(population);
            createImages(population);
            images = Sort.mergeSort(images);

        }

        private void createImages(int quantityImages)
        {
            for (int i = 0; i < quantityImages; i++)
            {
                images.Add(new Individual());
            }
        }

        //Selects the adaptable individuals of the population
        private List<Individual> selection_A()
        {
            List<Individual> adaptables = new List<Individual>(adaptableImagesPercentage);
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
        private List<Individual> selection_NA()
        {
            List<Individual> notAdaptables = new List<Individual>(images.Count - adaptableImagesPercentage);
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

        //Replace the least not adaptable individuals with the new childs and sorts the population
        private void replace_NA(List<Individual> childs)
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

        private List<Individual> parentsToCross(List<Individual> adaptables, List<Individual> notAdaptables, int typeOfParents)
        {
            List<Individual> parents = new List<Individual>(2);
            int rand_A_index;
            int rand_NA_index;
            int index = 0;
            Random rnd = new Random();
            switch (typeOfParents)
            {
                case 1:
                    rand_A_index = rnd.Next(0, adaptables.Count);
                    parents[0] = images[rand_A_index];
                    index = rand_A_index;
                    rand_A_index = rnd.Next(0, adaptables.Count);
                    while (rand_A_index != index)
                    {
                        rand_A_index = rnd.Next(0, adaptables.Count);
                    }
                    parents[1] = images[rand_A_index];
                    break;
                case 2:
                    rand_A_index = rnd.Next(0, adaptables.Count);
                    rand_NA_index = rnd.Next(0, notAdaptables.Count);
                    parents[0] = images[rand_A_index];
                    parents[1] = images[rand_NA_index];
                    break;
                case 3:
                    rand_NA_index = rnd.Next(0, notAdaptables.Count);
                    parents[0] = images[rand_NA_index];
                    index = rand_NA_index;
                    rand_NA_index = rnd.Next(0, notAdaptables.Count);
                    while (rand_NA_index != index)
                    {
                        rand_NA_index = rnd.Next(0, notAdaptables.Count);
                    }
                    parents[1] = images[rand_NA_index];
                    break;
                default:
                    break;
            }
            return parents;
        }

        //Returns the new childs.
        private List<Individual> crossOver(List<Individual> adaptables, List<Individual> notAdaptables)
        {
            int childAmount = childsPerGeneration;
            int cross_A_A = cross_A_A_percentage;
            int cross_A_NA = cross_A_NA_percentage;
            int cross_NA_NA = cross_NA_NA_percentage;
            int childsIndex = 0;
            int rand_mutation;
            Random rnd = new Random();
            List<Individual> parents = new List<Individual>(2);
            List<Individual> childs = new List<Individual>(childAmount);

            while (childAmount != 0)
            {
                while (cross_A_A != 0)
                {
                    if (adaptables.Count >= 2)
                    {
                        parents = parentsToCross(adaptables, notAdaptables, 1);
                        rand_mutation = rnd.Next(0, 101);
                        if (rand_mutation <= mutationProbability)
                        {
                            Individual child = parents[0].mutation(parents[1]);
                            childs[childsIndex] = child;
                        }
                        else
                        {
                            Individual child = parents[0].crossOver(parents[1]);
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
                        parents = parentsToCross(adaptables, notAdaptables, 2);
                        rand_mutation = rnd.Next(0, 101);
                        if (rand_mutation <= mutationProbability)
                        {
                            Individual child = parents[0].mutation(parents[1]);
                            childs[childsIndex] = child;
                        }
                        else
                        {
                            Individual child = parents[0].crossOver(parents[1]);
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
                        parents = parentsToCross(adaptables, notAdaptables, 3);
                        rand_mutation = rnd.Next(0, 101);
                        if (rand_mutation <= mutationProbability)
                        {
                            Individual child = parents[0].mutation(parents[1]);
                            childs[childsIndex] = child;
                        }
                        else
                        {
                            Individual child = parents[0].crossOver(parents[1]);
                            childs[childsIndex] = child;
                        }
                        childsIndex++;
                    }
                    cross_NA_NA--;
                }
                childAmount--;
            }
            Sort.mergeSort(childs); //Se pueden hacer experimentos, porque el meter los hijos ya ordenados, puede que al utilizar x algoritmo de ordenamiento despues, sea más eficiente.
            return childs;
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
            return Individual.mutations / generations;
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

        public List<Individual> genericAlgorithm()
        {
            int generation = 0;
            int generationPercentage = (int)(0.10) * (generations);
            List<Individual> finalResult = new List<Individual>();

            while (generation != generations)
            {
                //Selection
                List<Individual> adaptables = selection_A();
                List<Individual> notAdaptables = selection_NA();
                //Crossing
                List<Individual> newChilds = crossOver(adaptables, notAdaptables);
                //Evolution
                replace_NA(newChilds);

                if(generation % 10 == 0)
                {
                    //seteo de la imagen
                }

                if(generation % generationPercentage == 0)
                {
                    finalResult.Add(images[0]);
                }
                generation++;
            }
            return finalResult;
        }
    }
}
