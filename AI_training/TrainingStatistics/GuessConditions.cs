using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    public static class GuessConditions
    {
        private const float coincidenceTreshold = 0.7f;
        private const float difTreshold = 0.015f;
        public static bool isThisGuess(float[] neural, float[] real)
        {
            float neuralDif = neural[neural.Length - 1] - neural[0];
            float realDif = real[real.Length - 1] - real[0];


            return (neuralDif / realDif) > coincidenceTreshold || (neuralDif - realDif) < difTreshold;
        }
    }
}
