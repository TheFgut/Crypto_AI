using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using CryptoAnalizerAI.AI_training;
using CryptoAnalizerAI.DataSavingAndLoading;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    public class StatisticChronometer
    {
        private DatasetManager datasetManager;
        private manual_AI_Trainer trainer;

        public StatisticChronometer(DatasetManager datasetManager, manual_AI_Trainer trainer)
        {
            this.datasetManager = datasetManager;
            this.trainer = trainer;

            datasetManager.dataWalker.onProceedToNextDataset += DatasetChanged;
            trainer.predictionEvent_retDif += recordNeuralOutput;
            trainer.onTrainingStart += InitiateNewStatisticsRecording;
            trainer.onTrainingEnd += LearningFinished;

            InitiateNewStatisticsRecording();
        }

        private void DatasetChanged()
        {
            PackStatisticRecording();

        }

        private void InitiateNewStatisticsRecording()
        {
            ClearRecordingCache();
            neuralNetworkStats.Clear();
        }

        private List<DatasetLearningStats> neuralNetworkStats = new List<DatasetLearningStats>();

        public DatasetLearningStats[] getAllRecordingsAndClear()
        {
            PackStatisticRecording();

            DatasetLearningStats[] stats = neuralNetworkStats.ToArray();
            InitiateNewStatisticsRecording();
            return stats;
 
        }

        public dataRunTransfer onRunsDataPacked;
        private void PackStatisticRecording()
        {
            if (errorValues.Count <= 1) return;
            float guessFrequence = JsonChecks.clearInfinities((float)guessCount / errorValues.Count);
            DatasetLearningStats learningStats = new DatasetLearningStats(errorValues.ToArray(), courseValues.ToArray(), guessFrequence);
            onRunsDataPacked?.Invoke(learningStats);

            neuralNetworkStats.Add(learningStats);
            ClearRecordingCache();
        }

        private void ClearRecordingCache()
        {
            errorValues.Clear();
            courseValues.Clear();
            guessCount = 0;
        }
        private const string localStatsSaveDestination = "AutomatedLearning";
        private void LearningFinished()
        {
            //PackStatisticRecording();
        }

        private List<float> errorValues = new List<float>();
        private List<float> courseValues = new List<float>();
        private int guessCount;
        private void recordNeuralOutput(float[] neural, float[] real)
        {
            courseValues.Add(real[0]);

            float summedError = calculateErrorSum(neural, real);
            errorValues.Add(JsonChecks.clearInfinities(summedError));
            if (GuessConditions.isThisGuess(neural, real))
            {
                guessCount++;
            }
        }

        private float calculateErrorSum(float[] neural, float[] real)
        {
            float sum = 0;
            for (int i = 0; i < neural.Length;i++)
            {
                sum += Math.Abs(neural[i] - real[i]);
            }
            return sum;
        }

        public delegate void dataRunTransfer(DatasetLearningStats pack);
    }
}
