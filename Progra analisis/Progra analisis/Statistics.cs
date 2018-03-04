using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_analisis
{
    class Statistics
    {
        public static ArrayList statisticsRegister = new ArrayList();
        private double adapatblesPercentageToCopy; //The adaptables that will continue next generation
        private double adaptableImagesPercentage; //Defines the percentage of each population that will be defined as the most adaptables.
        private double cross_A_A_percentage; //Cross percentage of childs from two parents with high adaptability.
        private double cross_NA_NA_percentage; //Cross percentage of childs from two parents with low adaptability.
        private double cross_A_NA_percentage; //Cross percentage of chlds from a high adaptability parent with a lowone.
        private double mutationProbability;//from 0 to a 100 real quick
        private int finalMutationsPerGeneration; //The number of mutations per generation.
        private int childsPerGeneration;
        private int childsPerCross; //The amount of childs in each cross
        private int generations;
        private int population;

        public Statistics (NaturalSelection naturalSelection)
        {
            childsPerGeneration = naturalSelection.getChildsPerGeneration();
            childsPerCross = naturalSelection.getChildsPerCross();
            generations = naturalSelection.getGenerations();
            population = naturalSelection.getPopulation();
            adapatblesPercentageToCopy = naturalSelection.getAdaptablesPercentageToCopy();
            adaptableImagesPercentage = (double)(naturalSelection.getAdaptableImagesPercentage() * 100) / population;
            cross_A_A_percentage = (double)(naturalSelection.getCross_A_A_percentage() * 100) / childsPerGeneration;
            cross_A_NA_percentage = (double)(naturalSelection.getCross_A_NA_percentage() * 100) / childsPerGeneration;
            cross_NA_NA_percentage = (double)(naturalSelection.getCross_NA_NA_percentage() * 100) / childsPerGeneration;
            mutationProbability = (double)naturalSelection.getMutationProbability() / 100;
            finalMutationsPerGeneration = naturalSelection.getFinalMutationsPerGeneration();
        }
    }
}
