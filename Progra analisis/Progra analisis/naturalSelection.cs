using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

namespace Progra_analisis
{
    class NaturalSelection
    {
        private Individual[] images;
        private double adapatblesPercentageToCopy; //The adaptables that will continue next generation
        private int adaptableImagesPercentage; //Defines the percentage of each population that will be defined as the most adaptables.
        private int cross_A_A_percentage; //Cross percentage of childs from two parents with high adaptability.
        private int cross_NA_NA_percentage; //Cross percentage of childs from two parents with low adaptability.
        private int cross_A_NA_percentage; //Cross percentage of chlds from a high adaptability parent with a lowone.
        private int childsPerGeneration;
        private int mutationsPerGeneration;
        private int generations;
        private int population;
        private int generationCounter;
        


        public NaturalSelection(
            Bitmap desireImage, 
            int pGenerations, /**/
            int pPopulation,/**/
            int pChildsPerGeneration,/*no mayor a population*/
            double pCross_A_NA_percentage,
            double pCross_NA_NA_percentage, 
            double pCross_A_A_percentage,
            double pAdaptableImagesPercentage,/*  */
            double pAdapatblesPercentageToCopy,/*menor o igual que adaptable image percentaje*/ 
            int sectionsPerImage
            )
        {

            Individual.finalImage = new Individual(desireImage,0);
            Individual.finalImage.dataForFinalImage();
            MessageBox.Show("FinalImage");
            Individual.sectionsPerImage = sectionsPerImage;

            childsPerGeneration = pChildsPerGeneration;

            generations = pGenerations;

            population = pPopulation;

            Individual.mutations = 0;

            adaptableImagesPercentage = Convert.ToInt32(pAdaptableImagesPercentage * population);
            adapatblesPercentageToCopy = pAdapatblesPercentageToCopy;
            cross_A_A_percentage = Convert.ToInt32(pCross_A_A_percentage * childsPerGeneration);
            cross_NA_NA_percentage = Convert.ToInt32(pCross_NA_NA_percentage * childsPerGeneration);
            cross_A_NA_percentage = Convert.ToInt32(pCross_A_NA_percentage * childsPerGeneration);
            images = new Individual[population];
            MessageBox.Show("Population");
            createImages(population);
            MessageBox.Show("Imagenes creadas");
            Sort.quickSort(images, 0, images.Length - 1);
            MessageBox.Show("Listo");
            generationCounter = 0;
        }

        private void createImages(int quantityImages)
        {
            for (int i = 0; i < quantityImages; i++)
            {
                images[i] = new Individual();
            }
            MessageBox.Show("Listas imagenes");
        }

        //Selects the adaptable individuals of the population
        private Individual[] selection_A()
        {
            Individual[] adaptables = new Individual[adaptableImagesPercentage];
            if (adaptableImagesPercentage == images.Length)
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
        private Individual[] selection_NA()
        {
            int notAdaptablesIndex = 0;
            Individual[] notAdaptables = new Individual[images.Length - adaptableImagesPercentage];
            if (adaptableImagesPercentage == images.Length)
            {
                return notAdaptables;
            }
            for (int i = adaptableImagesPercentage; i < images.Length; i++)
            {
                notAdaptables[notAdaptablesIndex] = images[i];
                notAdaptablesIndex++;
            }
            return notAdaptables;
        }

        private Individual[] getOtherIndividualsToCopy(int otherIndividualsToCopyAmount, int adaptablesCopied)
        {
            Random rnd = new Random();
            int mutations = mutationsPerGeneration;
            int counter = 0;
            int notCopiedAdaptablesIndex = 0; //The random index of any individual that wasnt copied.
            int otherIndividualsToCopyIndex = 0;
            ArrayList OtherIndividualsIndex = new ArrayList();
            Individual[] otherIndividualsToCopy = new Individual[otherIndividualsToCopyAmount];
            Individual individual;
            while (counter < otherIndividualsToCopyAmount)
            {
                notCopiedAdaptablesIndex = rnd.Next(adaptablesCopied, images.Length);
                while (OtherIndividualsIndex.Contains(notCopiedAdaptablesIndex))
                {
                    notCopiedAdaptablesIndex = rnd.Next(adaptablesCopied, images.Length);
                }
                OtherIndividualsIndex.Add(notCopiedAdaptablesIndex);
                individual = images[notCopiedAdaptablesIndex];
                if (mutations != 0)
                {
                    //mutation
                    mutations--;
                }
                otherIndividualsToCopy[otherIndividualsToCopyIndex] = individual;
                otherIndividualsToCopyIndex++;
                counter++;
            }
            return otherIndividualsToCopy;
        }

        //Replace the not chosen individuals with the new childs and sorts the population
        private void evolution(Individual[] childs, Individual[] adaptables)
        {
            int adaptablesToCopy = (int)adapatblesPercentageToCopy * adaptables.Length;
            int otherIndividualsToCopyAmount = images.Length - adaptablesToCopy - childs.Length;
            int childsIndex = 0;
            int copiedAdaptablesIndex = 0;
            int imagesIndex = 0;
            int otherIndividualToCopyIndex = 0;
            Individual[] otherIndividualsToCopy = getOtherIndividualsToCopy(otherIndividualsToCopyAmount, adaptablesToCopy);

            if (adaptablesToCopy <= population - childsPerGeneration) //There must be space for adding the new childs
            {
                while (copiedAdaptablesIndex < adaptablesToCopy)
                {
                    images[imagesIndex] = adaptables[copiedAdaptablesIndex];
                    copiedAdaptablesIndex++;
                    imagesIndex++;
                }
                while (childsIndex < childs.Length)
                {
                    images[imagesIndex] = childs[childsIndex];
                    childsIndex++;
                    imagesIndex++;
                }
                for (int i = imagesIndex; i < otherIndividualsToCopyAmount; i++)
                {
                    Individual element = otherIndividualsToCopy[otherIndividualToCopyIndex];
                    images[i] = element;
                    otherIndividualToCopyIndex++;
                }
                Sort.quickSort(images, 0, images.Length - 1);
            }
        }

        private Individual[] parentsToCross(Individual[] adaptables, Individual[] notAdaptables, int typeOfParents)
        {
            Individual[] parents = new Individual[2];
            int rand_A_index;
            int rand_NA_index;
            int index = 0;
            Random rnd = new Random();
            switch (typeOfParents)
            {
                case 1:
                    rand_A_index = rnd.Next(0, adaptables.Length);
                    parents[0] = adaptables[rand_A_index];
                    index = rand_A_index;
                    rand_A_index = rnd.Next(0, adaptables.Length);
                    while (rand_A_index != index)
                    {
                        rand_A_index = rnd.Next(0, adaptables.Length);
                    }
                    parents[1] = adaptables[rand_A_index];
                    break;
                case 2:
                    rand_A_index = rnd.Next(0, adaptables.Length);
                    rand_NA_index = rnd.Next(0, notAdaptables.Length);
                    parents[0] = adaptables[rand_A_index];
                    parents[1] = notAdaptables[rand_NA_index];
                    break;
                case 3:
                    rand_NA_index = rnd.Next(0, notAdaptables.Length);
                    parents[0] = notAdaptables[rand_NA_index];
                    index = rand_NA_index;
                    rand_NA_index = rnd.Next(0, notAdaptables.Length);
                    while (rand_NA_index != index)
                    {
                        rand_NA_index = rnd.Next(0, notAdaptables.Length);
                    }
                    parents[1] = notAdaptables[rand_NA_index];
                    break;
                default:
                    break;
            }
            return parents;
        }

<<<<<<< HEAD
=======
        //Returns the child when two parents cross
        private Individual crossParents(Individual[] parents)
        {
            Individual child;
            Random rnd = new Random();
            int rand_mutation = rnd.Next(0, 101);
            if (rand_mutation <= mutationProbability)
            {
                //child = parents[0].mutation(parents[1]); RICHI cambie esto para poder correrlo pero lo deje por si usted lo queria
                //manejar difernte
                child = parents[0].crossOver(parents[1]);
            }
            else
            {
                child = parents[0].crossOver(parents[1]);
            }
            return child;
        }

>>>>>>> 63a4b43f62d71f56e4c150394ac56237f4967c5c
        //Returns the new sorted childs.
        private Individual[] crossOver(Individual[] adaptables, Individual[] notAdaptables)
        {
            int childAmount = childsPerGeneration;
            int cross_A_A = cross_A_A_percentage;
            int cross_A_NA = cross_A_NA_percentage;
            int cross_NA_NA = cross_NA_NA_percentage;
            int childsIndex = 0;
            Individual[] parents = new Individual[2];
            Individual[] childs = new Individual[childAmount];
            if (cross_A_A + cross_A_NA + cross_NA_NA > childAmount) //Validate in API.
            {
                Individual[] nulo = new Individual[0];
                return nulo;
            }
            
            while (cross_A_A != 0)
            {
                if (adaptables.Length >= 2)
                {
                    parents = parentsToCross(adaptables, notAdaptables, 1);
                    childs[childsIndex] = parents[0].crossOver(parents[1]);
                    childsIndex++;
                }
                cross_A_A--;
                childAmount--;
            }
            while (cross_A_NA != 0)
            {
                if (adaptables.Length >= 1 && notAdaptables.Length >= 1)
                {
                    parents = parentsToCross(adaptables, notAdaptables, 2);
                    childs[childsIndex] = parents[0].crossOver(parents[1]);
                    childsIndex++;
                }
                cross_A_NA--;
                childAmount--;
            }
            while (cross_NA_NA != 0)
            {
                if (notAdaptables.Length >= 2)
                {
                    parents = parentsToCross(adaptables, notAdaptables, 3);
                    childs[childsIndex] = parents[0].crossOver(parents[1]);
                    childsIndex++;
                }
                cross_NA_NA--;
                childAmount--;
            }
            //Not always it will be exactly so:
            while (childAmount != 0)
            {
                parents = parentsToCross(adaptables, notAdaptables, 3);
                childs[childsIndex] = parents[0].crossOver(parents[1]);
                childsIndex++;
                childAmount--;
            }
            Sort.quickSort(childs, 0, childs.Length - 1); //Se pueden hacer experimentos, porque el meter los hijos ya ordenados, puede que al utilizar x algoritmo de ordenamiento despues, sea más eficiente.
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

        public int getMutationsPerGeneration()
        {
            return mutationsPerGeneration;
        }

        public int getFinalMutationsPerGeneration()
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

        public double getAdaptablesPercentageToCopy()
        {
            return adapatblesPercentageToCopy;
        }

        public int getGenerationCounter()
        {
            return generationCounter;
        }

        public int getHighestAdaptability()
        {
            return images[0].getAdaptability(1);   
        }

        public Individual[] genericAlgorithm()
        {
            int finalResultIndex = 0;
            int generation = 0;
            int generationPercentage = Convert.ToInt32((0.10) * (generations));
            Individual[] finalResult = new Individual[10];

            while (generation != generations)
            {
                MessageBox.Show("Inicia generacion");
                //Selection
                Individual[] adaptables = selection_A();
                Individual[] notAdaptables = selection_NA();
                //Crossing
                Individual[] newChilds = crossOver(adaptables, notAdaptables);
                //Evolution
                evolution(newChilds, adaptables);

                if(generation % 10 == 0)
                {
                    //seteo de la imagen
                }

                if(generation % generationPercentage == 0)
                {
                    finalResult[finalResultIndex] = images[0];
                    finalResultIndex++;
                }
                generationCounter++;
                generation++;
                MessageBox.Show("Finaliza gen");
            }
            Sort.quickSort(finalResult, 0, finalResult.Length - 1);
            return finalResult;
        }

        public Bitmap getPositionCero()
        {
            return images[0].getBitmap();
        }
    }
}
