using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using CryptoAnalizerAI.AI_training;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    class StatisticChronometer
    {
        private DatasetManager datasetManager;
        private AI_Trainer trainer;

        public StatisticChronometer(DatasetManager datasetManager, AI_Trainer trainer)
        {
            this.datasetManager = datasetManager;
            this.trainer = trainer;

            datasetManager.dataWalker.datasetChanged += DatasetChanged;
            trainer.predictionEvent_retDif += recordNeuralOutput;
            trainer.onTrainingStart += InitiateNewStatisticsRecording;
            trainer.onTrainingEnd += LearningFinished;
        }

        private void DatasetChanged()
        {
            if (!trainer.trainingPending) return;
            PackStatisticRecording();
            InitiateNewStatisticsRecording();
        }

        private void InitiateNewStatisticsRecording()
        {
            int currentDatasetID = datasetManager.dataWalker.currentDatasetID;
            Dataset currentDataset = datasetManager.datasets[currentDatasetID];

            ClearRecordingCache();
            neuralNetworkStats.Clear();
        }

        private List<DatasetLearningStats> neuralNetworkStats = new List<DatasetLearningStats>();

        public DatasetLearningStats[] getAllRecordingsAndFinish()
        {
            PackStatisticRecording();

            datasetManager.dataWalker.datasetChanged -= DatasetChanged;
            trainer.predictionEvent_retDif -= recordNeuralOutput;
            trainer.onTrainingStart -= InitiateNewStatisticsRecording;
            trainer.onTrainingEnd -= LearningFinished;

            return neuralNetworkStats.ToArray();
        }
        public event errorReturn runFinishedReturnError;
        public event errorReturn runFinishedReturnGuessFrequency;
        private void PackStatisticRecording()
        {
            float guessFrequence = (float)guessCount / errorValues.Count;
            DatasetLearningStats learningStats = new DatasetLearningStats(errorValues.ToArray(), courseValues.ToArray(), guessFrequence);
            
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
            PackStatisticRecording();
            DatasetsRun NetworkStats = new DatasetsRun(neuralNetworkStats.ToArray());
            //to do name generation
            LoaderAndSaver<DatasetsRun> statsSaver = new LoaderAndSaver<DatasetsRun>(localStatsSaveDestination, "stat");
            //to do - saving stats data with perceptron

        }

        private List<float> errorValues = new List<float>();
        private List<float> courseValues = new List<float>();
        private int guessCount;
        private void recordNeuralOutput(float[] neural, float[] real)
        {
            courseValues.Add(real[0]);
            errorValues.Add(calculateErrorSum(neural, real));
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

        public delegate void errorReturn(float error);
    }
}
