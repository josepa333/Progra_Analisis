using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Progra_analisis
{
    class Adaptability
    {
        private int distanceRGBHistogram;
        private int distanceGradientHistogram;
        private int distanceAverage;

        private int manhattan(List<List<int>> individual)
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

        private void setDistanceRGBHistogram(List<List<int>> RGBHistogram)
        {
            distanceRGBHistogram = manhattan(RGBHistogram);
        }

        private void setDistanceGradientHistogram(List<List<int>> gradientHistogram)
        {
            distanceGradientHistogram = darknessDistance(gradientHistogram); //Function for gradient distance
        }

        private void setDistanceAverage()
        {
            distanceAverage = (distanceRGBHistogram + distanceGradientHistogram) / 2;
        }

        public Adaptability(List<List<int>> RGBHistogram, List<List<int>> gradientHistogram)
        {
            setDistanceRGBHistogram(RGBHistogram);
            setDistanceGradientHistogram(gradientHistogram);
            setDistanceAverage();
        }

        //adaptabilityOperation is how the adaptability is calculated.
        //1 for the avarege between the different distances.
        public int getAdaptability(int adaptabilityOperation)
        {
            switch (adaptabilityOperation)
            {
                case 1:
                    return distanceAverage;
                default:
                    return 0;
            }
        }

        private int darknessDistance(List<List<int>> individual)
        {
            int distanceValue = 0;

            List<List<int>> histogramFromFinalImage = Individual.finalImage.getHistogramGradient();

            for (int section = 0; section < individual.Count; section++)
            {
                distanceValue += Math.Abs(histogramFromFinalImage[section][0] - individual[section][0]);
                distanceValue += Math.Abs(histogramFromFinalImage[section][1] - individual[section][1]);
            }
            return distanceValue;
        }
    }
}
