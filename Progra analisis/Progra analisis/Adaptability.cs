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
        private int distanceRGBHistogram;
        private int distanceGradientHistogram;
        private int distanceAverage;

        private int manhattan(ArrayList individual)
        {
            int distanceValue = 0;

            for (int i = 0; i < Image.finalImage.getHistogramRGB().Count; i++)
            {
                distanceValue += Math.Abs((int)Image.finalImage.getHistogramRGB()[i] - (int)individual[i]);
            }
            return distanceValue;
        }

        private void setDistanceRGBHistogram(ArrayList RGBHistogram)
        {
            distanceRGBHistogram = manhattan(RGBHistogram);
        }

        private void setDistanceGradientHistogram(ArrayList gradientHistogram)
        {
            distanceGradientHistogram = 0; //Function for gradient distance
        }

        private void setDistanceAverage()
        {
            distanceAverage = (distanceRGBHistogram + distanceGradientHistogram) / 2;
        }

        public Adaptability(ArrayList RGBHistogram, ArrayList gradientHistogram)
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
    }
}
