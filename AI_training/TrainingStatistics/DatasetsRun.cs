using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    class DatasetsRun
    {
        public DatasetLearningStats[] stats { get; set; }

        public float averageError { get; set; }
        public DatasetsRun(DatasetLearningStats[] stats)
        {
            this.stats = stats;
            averageError = calculateAverageError(stats);
        }


        public DatasetsRun()
        {

        }        //for json saving

        private float calculateAverageError(DatasetLearningStats[] stats)
        {
            float errorsSum = 0;
            foreach (DatasetLearningStats lStat in stats)
            {
                errorsSum += lStat.averageError;
            }
            return errorsSum / stats.Length;
        }
    }
}
