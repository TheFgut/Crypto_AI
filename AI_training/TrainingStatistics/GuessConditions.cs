using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    public static class GuessConditions
    {
        private const float coincidenceTreshold = 0.3f;
        private const float difTreshold = 0.0005f;
        public static bool isThisGuess(float[] neural, float[] real)
        {
            float neuralFinalPoint = getSum(neural);
            float realFinalPoint = getSum(real);
            if(realFinalPoint == 0)
            {
                if (neuralFinalPoint < difTreshold) return true;
                return false;
            }

            bool loverThanTresholdDif = Math.Abs(neuralFinalPoint - realFinalPoint) < difTreshold;
            if (Math.Sign(neuralFinalPoint) != Math.Sign(realFinalPoint) && !loverThanTresholdDif) return false;

            return Math.Abs((neuralFinalPoint / realFinalPoint) - 1) < coincidenceTreshold || loverThanTresholdDif;
        }

        private static float getSum(float[] values)
        {
            float sum = 0;
            foreach (float val in values)
            {
                sum += val;
            }
            return sum;
        }
    }
}
