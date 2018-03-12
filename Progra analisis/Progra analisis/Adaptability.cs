using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Progra_analisis
{
    class Adaptability
    {
        private int manhattanDistanceRGBHistogram;
        private int manhattanDistanceDarknessHistogram;
        private double klDistanceRGBHistogram;
        private double klDisatanceDarknessHistogram;
        private double distance;

        private int manhattanRGB(List<List<int>> individual)
        {
            int distanceValue = 0;

            List<List<int>> histogramFromFinalImage = Individual.finalImage.getHistogramRGB();

            for (int section = 0; section < individual.Count; section++)
            {
                for (int i = 0; i < individual[section].Count; i++)
                {
                    distanceValue += Math.Abs( histogramFromFinalImage[section][i] - individual[section][i]);
                }
            }
            return distanceValue;
        }

        private int manhattanDarkness(List<List<int>> individual)
        {
            int distanceValue = 0;

            List<List<int>> histogramFromFinalImage = Individual.finalImage.getHistogramDarkness();

            for (int section = 0; section < individual.Count; section++)
            {
                distanceValue += Math.Abs(histogramFromFinalImage[section][0] - individual[section][0]);
                distanceValue += Math.Abs(histogramFromFinalImage[section][1] - individual[section][1]);
            }
            return distanceValue;
        }

        private void setManhattanRGBHistogram(List<List<int>> RGBHistogram)
        {
            manhattanDistanceRGBHistogram = manhattanRGB(RGBHistogram);
            distance = manhattanDistanceRGBHistogram;
        }

        private void setManhattanDarknessHistogram(List<List<int>> darknessHistogram)
        {
            manhattanDistanceDarknessHistogram = manhattanDarkness(darknessHistogram); //Function for gradient distance
            distance = manhattanDistanceDarknessHistogram;
        }

        private void setSurpriseRGBHistogram(List<List<int>> RGBHistogram)
        {
            klDistanceRGBHistogram = klRGB(RGBHistogram);
            distance = klDistanceRGBHistogram;
        }

        private void setSurpriseDarknessHistogram(List<List<int>> darknessHistogram)
        {
            klDisatanceDarknessHistogram = klDarkness(darknessHistogram);
            distance = klDisatanceDarknessHistogram;
        }

        public Adaptability(List<List<int>> histogram)
        {
            if (Individual.histrogramSelected == 0)
            {
                if (Individual.distanceSelected == 0)
                {
                    setManhattanRGBHistogram(histogram);
                }
                if (Individual.distanceSelected == 1)
                {
                    setSurpriseRGBHistogram(histogram);
                }
            }
            if (Individual.histrogramSelected == 1)
            {
                if (Individual.distanceSelected == 0)
                {
                    setManhattanDarknessHistogram(histogram);
                }
                if (Individual.distanceSelected == 1)
                {
                    setSurpriseDarknessHistogram(histogram);
                }
            }
        }

        public double getDistance()
        {
            return distance;
        }


        private double klRGB(List<List<int>> individual)
        {
            double[,] probabilityDistributionRGB = Individual.probabilityDistributionRGB;
            double pX = 0;
            double qX = 0;
            double distanceValue = 0;

            for (int section = 0; section < individual.Count; section++)
            {
                for (int i = 0; i < individual[section].Count; i++)
                {
                    qX = probabilityDistributionRGB[section,i];
                    pX = individual[section][i] / Individual.numberOfPixels;

                    distanceValue +=  (pX * Math.Log10(pX) - pX * Math.Log10(qX)) * 10;
                }
            }
            return distanceValue;
        }

        private double klDarkness(List<List<int>> individual)
        {
            double[,] probabilityDistributionDarkness = Individual.probabilityDistributionDarkness;
            double pX = 0;
            double qX = 0;
            double distanceValue = 0;

            for (int section = 0; section < individual.Count; section++)
            {
                for (int i = 0; i < individual[section].Count; i++)
                {
                    qX = probabilityDistributionDarkness[section, i];
                    pX = individual[section][i] / Individual.numberOfPixels;

                    distanceValue += (pX * Math.Log10(pX) - pX * Math.Log10(qX)) * 10;
                }
            }
            return distanceValue;
        }


    }
}
