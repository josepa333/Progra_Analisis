using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CsvHelper;
using System.Xml.Serialization;

namespace Progra_analisis
{
    [Serializable()] class Statistics : ISerializable
    {
        public static ArrayList statisticsRegister = new ArrayList();
        public static ArrayList topStatisticsRegister = new ArrayList();
        private static double adapatblesPercentageToCopy; //The adaptables that will continue next generation
        private static double adaptableImagesPercentage; //Defines the percentage of each population that will be defined as the most adaptables.
        private static double cross_A_A_percentage; //Cross percentage of childs from two parents with high adaptability.
        private static double cross_NA_NA_percentage; //Cross percentage of childs from two parents with low adaptability.
        private static double cross_A_NA_percentage; //Cross percentage of chlds from a high adaptability parent with a lowone.
        private static int mutationsPerGeneration;
        private static int childsPerGeneration;
        private static int generations;
        private static int population;
        private static double bestDistance;
        private static double normalDistance;
        private static double worstDistance;
        private static string typeOfHistogram;
        private static string typeOfDistance;
        private static string statisticsRegisterPathXML = Environment.CurrentDirectory + "\\statistics.XML";
        private static string topStatisticsRegisterPathXML = Environment.CurrentDirectory + "\\topStatistics.XML";
        private static string statisticsRegisterPathCSV = Environment.CurrentDirectory + "\\statistics.csv";
        private static string topStatisticsRegisterPathCSV = Environment.CurrentDirectory + "\\topStatistics.csv";

        //private void writeToFile(string path, string text)
        //{
        //    System.IO.File.WriteAllText(path, text);
        //}

        //private string readFile(string path)
        //{
        //    String content = "";
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(path))
        //        {
        //            content = sr.ReadToEnd();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine("The file could not be read.");
        //    }
        //    return content;
        //}

        private static void serializeList(ArrayList list, string path)
        {
            using (Stream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ArrayList));
                serializer.Serialize(fs, list);
            }
        }

        private static void deserialize(ArrayList list, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayList));
            using (FileStream fs = File.OpenRead(path))
            {
                list = (ArrayList)serializer.Deserialize(fs);
            }
        }

        private static void addToTopStatistics(Statistics statistic)
        {
            for (int i = 0; i < topStatisticsRegister.Count; i++)
            {
                Statistics element = (Statistics)topStatisticsRegister[i];
                if (element.getBestDistance() > statistic.getBestDistance())
                {
                    topStatisticsRegister.Insert(i, statistic);
                    if (topStatisticsRegister.Count > 10)
                    {
                        topStatisticsRegister.RemoveAt(topStatisticsRegister.Count - 1);
                    }
                    break;
                }
            }
        }

        public Statistics (NaturalSelection naturalSelection)
        {
            childsPerGeneration = naturalSelection.getChildsPerGeneration();
            mutationsPerGeneration = naturalSelection.getMutationsPerGeneration();
            generations = naturalSelection.getGenerations();
            population = naturalSelection.getPopulation();
            adapatblesPercentageToCopy = naturalSelection.getAdaptablesPercentageToCopy();
            adaptableImagesPercentage = Convert.ToDouble((naturalSelection.getAdaptableImagesPercentage() * 100) / population);
            cross_A_A_percentage = Convert.ToDouble((naturalSelection.getCross_A_A_percentage() * 100) / childsPerGeneration);
            cross_A_NA_percentage = Convert.ToDouble((naturalSelection.getCross_A_NA_percentage() * 100) / childsPerGeneration);
            cross_NA_NA_percentage = Convert.ToDouble((naturalSelection.getCross_NA_NA_percentage() * 100) / childsPerGeneration);
            double[] distances = naturalSelection.getBestDistances();
            bestDistance = distances[0];
            normalDistance = distances[1];
            worstDistance = distances[2];
            typeOfHistogram = naturalSelection.getTypeOfHistogram();
            typeOfDistance = naturalSelection.getTypeOfDistance();
        }

        public Statistics(SerializationInfo info, StreamingContext ctxt)
        {
            childsPerGeneration = (int)info.GetValue("childsPerGeneration", typeof(int));
            mutationsPerGeneration = (int)info.GetValue("mutationsPerGeneration", typeof(int));
            generations = (int)info.GetValue("generations", typeof(int));
            population = (int)info.GetValue("population", typeof(int));
            adapatblesPercentageToCopy = (double)info.GetValue("adapatblesPercentageToCopy", typeof(double));
            adaptableImagesPercentage = (double)info.GetValue("adaptableImagesPercentage", typeof(double));
            cross_A_A_percentage = (double)info.GetValue("cross_A_A_percentage", typeof(double));
            cross_A_NA_percentage = (double)info.GetValue("cross_A_NA_percentage", typeof(double));
            cross_NA_NA_percentage = (double)info.GetValue("cross_NA_NA_percentage", typeof(double));
            bestDistance = (double)info.GetValue("bestDistance", typeof(double));
            normalDistance = (double)info.GetValue("normalDistance", typeof(double));
            worstDistance = (double)info.GetValue("worstDistance", typeof(double));
            typeOfHistogram = (string)info.GetValue("typeOfHistogram", typeof(string));
            typeOfDistance = (string)info.GetValue("typeOfDistance", typeof(string));
        }

        public static void addStatistic(Statistics statistic)
        {
            statisticsRegister.Add(statistic);
            addToTopStatistics(statistic);
        }

        public static void loadStatistics()
        {
            try
            {
                deserialize(statisticsRegister, statisticsRegisterPathXML);
                deserialize(topStatisticsRegister, topStatisticsRegisterPathXML);
            }
            catch (Exception)
            {
                Console.WriteLine("The file could not be read.");
            }
        }

        public static void saveStatistics()
        {
            serializeList(statisticsRegister, statisticsRegisterPathXML);
            serializeList(topStatisticsRegister, topStatisticsRegisterPathXML);
        }

        public static void downloadStatisticsCSV()
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("Type of Histogram," + typeOfHistogram);
            csvContent.AppendLine("Type of Distance," + typeOfDistance);
            csvContent.AppendLine("Time,");
            csvContent.AppendLine("Generations," + generations.ToString());
            csvContent.AppendLine("Population," + population.ToString());
            csvContent.AppendLine("Childs per Generation," + childsPerGeneration.ToString());
            csvContent.AppendLine("Mutations per Generation," + mutationsPerGeneration.ToString());
            csvContent.AppendLine("Adaptables Percentage," + adaptableImagesPercentage.ToString());
            csvContent.AppendLine("Adaptables Percentage to Copy," + adapatblesPercentageToCopy.ToString());
            csvContent.AppendLine("A_A Cross Percentage," + cross_A_A_percentage.ToString());
            csvContent.AppendLine("A_NA Cross Percentage," + cross_A_NA_percentage.ToString());
            csvContent.AppendLine("NA_NA Cross Percentage," + cross_NA_NA_percentage.ToString());
            csvContent.AppendLine("Best Distance," + bestDistance.ToString());
            csvContent.AppendLine("Normal Distance," + normalDistance.ToString());
            csvContent.AppendLine("Worst Distance," + worstDistance.ToString());
            File.AppendAllText(statisticsRegisterPathCSV, csvContent.ToString());
            File.AppendAllText(topStatisticsRegisterPathCSV, csvContent.ToString());
        }

        public double getAdaptablesPercentageToCopy()
        {
            return adapatblesPercentageToCopy;
        }

        public double getAdaptableImagesPercentage()
        {
            return adaptableImagesPercentage;
        }

        public double getCross_A_A_percentage()
        {
            return cross_A_A_percentage;
        }

        public double getCross_A_NA_percentage()
        {
            return cross_A_NA_percentage;
        }

        public double getCross_NA_NA_percentage()
        {
            return cross_NA_NA_percentage;
        }

        public int getMutationsPerGeneration()
        {
            return mutationsPerGeneration;
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

        public double getBestDistance()
        {
            return bestDistance;
        }

        public double getNormalDistance()
        {
            return normalDistance;
        }

        public double getWorstDistance()
        {
            return worstDistance;
        }

        public string getTypeOfHistogram()
        {
            return typeOfHistogram;
        }

        public string getTypeOfDistance()
        {
            return typeOfDistance;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("adaptableImagesPercentage", adaptableImagesPercentage);
            info.AddValue("adaptableImagesPercentage", adaptableImagesPercentage);
            info.AddValue("cross_A_A_percentage", cross_A_A_percentage);
            info.AddValue("cross_NA_NA_percentage", cross_NA_NA_percentage);
            info.AddValue("cross_A_NA_percentage", cross_A_NA_percentage);
            info.AddValue("mutationsPerGeneration", mutationsPerGeneration);
            info.AddValue("childsPerGeneration", childsPerGeneration);
            info.AddValue("generations", generations);
            info.AddValue("population", population);
            info.AddValue("bestDistance", bestDistance);
            info.AddValue("normalDistance", normalDistance);
            info.AddValue("worstDistance", worstDistance);
            info.AddValue("typeOfHistogram", typeOfHistogram);
            info.AddValue("typeOfDistance", typeOfDistance);
        }
    }
}
