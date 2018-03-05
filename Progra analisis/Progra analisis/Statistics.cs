using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using CsvHelper;

namespace Progra_analisis
{
    class Statistics
    {
        public static ArrayList statisticsRegister = new ArrayList();
        public static ArrayList topStatisticsRegister = new ArrayList();
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
        private int highestAdaptabilityReached;
        private string statisticsRegisterPath = Environment.CurrentDirectory + "\\statistics.txt";
        private string topStatisticsRegisterPath = Environment.CurrentDirectory + "\\topStatistics.txt";

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

        private void serializeList(ArrayList list, string path)
        {
            var serializer = new XmlSerializer(typeof(ArrayList));
            using (var stream = File.OpenWrite(path))
            {
                serializer.Serialize(stream, list);
            }
        }

        private void deserialize(ArrayList list, string path)
        {
            var serializer = new XmlSerializer(typeof(ArrayList));
            using (var stream = File.OpenRead(path))
            {
                var other = (ArrayList)(serializer.Deserialize(stream));
                list.Clear();
                list.AddRange(other);
            }
        }

        private void addToTopStatistics(Statistics statistic)
        {
            for (int i = 0; i < topStatisticsRegister.Count; i++)
            {
                Statistics element = (Statistics)topStatisticsRegister[i];
                if (element.getHighestAdaptabilityReached() < statistic.getHighestAdaptabilityReached())
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
            highestAdaptabilityReached = naturalSelection.getHighestAdaptability();
            try
            {
                deserialize(statisticsRegister, statisticsRegisterPath);
                deserialize(topStatisticsRegister, topStatisticsRegisterPath);
            }
            catch(Exception)
            {
                Console.WriteLine("The file could not be read.");
            }
        }

        public void addStatistic(Statistics statistic)
        {
            statisticsRegister.Add(statistic);
            addToTopStatistics(statistic);
        }

        public void downloadStatisticsCSV(int typeOfStatistics) //1 for all, or 2 for top 10
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true})
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        var writer = new CsvWriter(sw);
                        writer.WriteHeader(typeof(Statistics));
                        if (typeOfStatistics == 1)
                        {
                            foreach (Statistics s in statisticsRegister)
                            {
                                writer.WriteRecord(s);
                            }
                        }
                        if(typeOfStatistics == 2)
                        {
                            foreach (Statistics s in topStatisticsRegister)
                            {
                                writer.WriteRecord(s);
                            }
                        }
                    }
                    MessageBox.Show("Se han descargado las estadísticas de los distintos procesos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public int getHighestAdaptabilityReached()
        {
            return highestAdaptabilityReached;
        }


    }
}
