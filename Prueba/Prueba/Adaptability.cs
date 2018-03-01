using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Prueba
{
    class Adaptability
    {
        private int distanceRHistogram;
        private int distanceGHistogram;
        private int distanceBHistogram;
        private int distanceAverage;

        private void setDistanceRHistogram()
        {
            
        }

        private void setDistanceGHistogram()
        {

        }

        private void setDistanceBHistogram()
        {

        }

        private void setDistanceAverage()
        {
            distanceAverage = (distanceRHistogram + distanceGHistogram + distanceBHistogram) / 3;
        }

        public Adaptability(ArrayList p_Histogram)
        {
            setDistanceRHistogram();
            setDistanceGHistogram();
            setDistanceBHistogram();
            setDistanceAverage();
        }

        //adaptabilityOperation is how the adaptability is calculated.
        //1 for the avarege between the different distances.
        public int getAdaptability(int adaptabilityOperation)
        {
            switch(adaptabilityOperation)
            {
                case 1:
                    return distanceAverage;
                default:
                    return 0;
            }
        }

        public int manhattan(Image objective, Image individual)
        {
            int distanceValue = 0;

            for(int i = 0; i < objective.getHistogramRGB().Count ; i++)
            {
                distanceValue += Math.Abs( (int)objective.getHistogramRGB()[i] - (int)individual.getHistogramRGB()[i] );
            }
            return distanceValue;
        }
    }
}
