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
using System.Diagnostics;

namespace Progra_analisis
{
    [XmlInclude(typeof(Statistics[]))]
    [Serializable]
    public class Statistics : ISerializable
    {
        public static ArrayList statisticsRegister = new ArrayList();
        public static ArrayList topStatisticsRegister = new ArrayList();
        public double adapatblesPercentageToCopy; //The adaptables that will continue next generation
        public double adaptableImagesPercentage; //Defines the percentage of each population that will be defined as the most adaptables.
        public double cross_A_A_percentage; //Cross percentage of childs from two parents with high adaptability.
        public double cross_NA_NA_percentage; //Cross percentage of childs from two parents with low adaptability.
        public double cross_A_NA_percentage; //Cross percentage of chlds from a high adaptability parent with a lowone.
        public int mutationsPerGeneration;
        public int childsPerGeneration;
        public int generations;
        public int population;
        public double bestDistance;
        public double normalDistance;
        public double worstDistance;
        public string typeOfHistogram;
        public string typeOfDistance;
        public string time;
        public static string statisticsRegisterPathXML = Environment.CurrentDirectory + "\\statistics.XML";
        public static string topStatisticsRegisterPathXML = Environment.CurrentDirectory + "\\topStatistics.XML";
        public static string statisticsRegisterPathCSV = Environment.CurrentDirectory + "\\statistics.csv";
        public static string topStatisticsRegisterPathCSV = Environment.CurrentDirectory + "\\topStatistics.csv";
      
        private static void serializeList(ArrayList list, string path)
        {
            using (Stream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Statistics[] listaStats = list.ToArray(typeof(Statistics)) as Statistics[];
                XmlSerializer serializer = new XmlSerializer(typeof(Statistics[]));
                serializer.Serialize(fs, listaStats);
            }
        }

        private static void deserialize(ArrayList list, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Statistics[]));
            using (FileStream fs = File.OpenRead(path))
            {
                Statistics[] array = (Statistics[])serializer.Deserialize(fs);
                list.AddRange(array);
            }
        }

        private static void addToTopStatistics(Statistics statistic)
        {
            for (int i = 0; i < topStatisticsRegister.Count; i++)
            {
                Statistics element = (Statistics)topStatisticsRegister[i];
                if (element.bestDistance > statistic.bestDistance)
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
            time = "";
            time = naturalSelection.getTime();
        }

        private Statistics() { }

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
            File.Delete(statisticsRegisterPathCSV);
            File.Delete(topStatisticsRegisterPathCSV);
            StringBuilder csvContent = new StringBuilder();
            for (int i = 0; i < statisticsRegister.Count; i++)
            {
                csvContent.AppendLine("Type of Histogram,,," + ((Statistics)statisticsRegister[i]).typeOfHistogram);
                csvContent.AppendLine("Type of Distance,,," + ((Statistics)statisticsRegister[i]).typeOfDistance);
                csvContent.AppendLine("Time,,," + ((Statistics)statisticsRegister[i]).time);
                csvContent.AppendLine("Generations,,," + ((Statistics)statisticsRegister[i]).generations);
                csvContent.AppendLine("Population,,," + ((Statistics)statisticsRegister[i]).population);
                csvContent.AppendLine("Childs per Generation,,," + ((Statistics)statisticsRegister[i]).childsPerGeneration);
                csvContent.AppendLine("Mutations per Generation,,," + ((Statistics)statisticsRegister[i]).mutationsPerGeneration);
                csvContent.AppendLine("Adaptables Percentage,,," + ((Statistics)statisticsRegister[i]).adaptableImagesPercentage);
                csvContent.AppendLine("Adaptables Percentage to Copy,,," + ((Statistics)statisticsRegister[i]).adapatblesPercentageToCopy);
                csvContent.AppendLine("A_A Cross Percentage,,," + ((Statistics)statisticsRegister[i]).cross_A_A_percentage);
                csvContent.AppendLine("A_NA Cross Percentage,,," + ((Statistics)statisticsRegister[i]).cross_A_NA_percentage);
                csvContent.AppendLine("NA_NA Cross Percentage,,," + ((Statistics)statisticsRegister[i]).cross_NA_NA_percentage);
                csvContent.AppendLine("Best Distance,,," + ((Statistics)statisticsRegister[i]).bestDistance);
                csvContent.AppendLine("Normal Distance,,," + ((Statistics)statisticsRegister[i]).normalDistance);
                csvContent.AppendLine("Worst Distance,,," + ((Statistics)statisticsRegister[i]).worstDistance);
            }
            File.AppendAllText(statisticsRegisterPathCSV, csvContent.ToString());
            for (int i = 0; i < topStatisticsRegister.Count; i++)
            {
                csvContent.AppendLine("Type of Histogram,,," + ((Statistics)topStatisticsRegister[i]).typeOfHistogram);
                csvContent.AppendLine("Type of Distance,,," + ((Statistics)topStatisticsRegister[i]).typeOfDistance);
                csvContent.AppendLine("Time,,," + ((Statistics)topStatisticsRegister[i]).time);
                csvContent.AppendLine("Generations,,," + ((Statistics)topStatisticsRegister[i]).generations);
                csvContent.AppendLine("Population,,," + ((Statistics)topStatisticsRegister[i]).population);
                csvContent.AppendLine("Childs per Generation,,," + ((Statistics)topStatisticsRegister[i]).childsPerGeneration);
                csvContent.AppendLine("Mutations per Generation,,," + ((Statistics)topStatisticsRegister[i]).mutationsPerGeneration);
                csvContent.AppendLine("Adaptables Percentage,,," + ((Statistics)topStatisticsRegister[i]).adaptableImagesPercentage);
                csvContent.AppendLine("Adaptables Percentage to Copy,,," + ((Statistics)topStatisticsRegister[i]).adapatblesPercentageToCopy);
                csvContent.AppendLine("A_A Cross Percentage,,," + ((Statistics)topStatisticsRegister[i]).cross_A_A_percentage);
                csvContent.AppendLine("A_NA Cross Percentage,,," + ((Statistics)topStatisticsRegister[i]).cross_A_NA_percentage);
                csvContent.AppendLine("NA_NA Cross Percentage,,," + ((Statistics)topStatisticsRegister[i]).cross_NA_NA_percentage);
                csvContent.AppendLine("Best Distance,,," + ((Statistics)topStatisticsRegister[i]).bestDistance);
                csvContent.AppendLine("Normal Distance,,," + ((Statistics)topStatisticsRegister[i]).normalDistance);
                csvContent.AppendLine("Worst Distance,,," + ((Statistics)topStatisticsRegister[i]).worstDistance);
            }
            File.AppendAllText(topStatisticsRegisterPathCSV, csvContent.ToString());
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
            info.AddValue("time", time);
        }
    }
}
