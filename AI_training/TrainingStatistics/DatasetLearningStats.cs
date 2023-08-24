using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.DataSavingAndLoading;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    public class DatasetLearningStats
    {
        //public int datasetID { get; set; }
        public float[] errors { get; set; }
        public float[] courseValues { get; set; }

        public float guessFrequency { get; set; } //0-1 (0 is never, 1 is all guessed)

        public float averageError { get; set; }
        public DatasetLearningStats(float[] errors, float[] courseValues, float guessFrequency)
        {
            this.errors = errors;
            this.courseValues = courseValues;
            this.guessFrequency = guessFrequency;


            averageError = JsonChecks.clearInfinities(calculateAverageError(errors));
        }

        private float calculateAverageError(float[] errors)
        {
            float errorsSum = 0;
            foreach (float error in errors)
            {
                errorsSum += error;
            }
            return errorsSum / errors.Length;
        }

        public DatasetLearningStats()
        {

        }
    }
}
