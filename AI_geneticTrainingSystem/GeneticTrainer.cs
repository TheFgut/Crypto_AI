using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using CryptoAnalizerAI.AI_training;
using CryptoAnalizerAI.AI_training.TrainingStatistics;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    class GeneticTrainer
    {
        private DatasetManager datasetManager;
        private manual_AI_Trainer defaultTrainer;
        private GeneticTrainerSettings settings;
        public GeneticTrainer(DatasetManager datasetManager, manual_AI_Trainer trainer, GeneticTrainerSettings settings)
        {
            this.datasetManager = datasetManager;
            this.defaultTrainer = trainer;
            this.settings = settings;
        }

        public void StartLerning()
        {
            StatisticChronometer statsChronometer = new StatisticChronometer(datasetManager, defaultTrainer);
            statsChronometer.runFinishedReturnError += RunFinished_retError;
            statsChronometer.runFinishedReturnGuessFrequency += RunFinished_retFreq;
        }

        public void PauseLearning()
        {

        }

        public void StopLearning()
        {

        }

        //learn pending

        private void RunFinished_retError(float runAverageError)
        {

        }

        private void RunFinished_retFreq(float guessFrequency)
        {

        }

        private void changeModeToFinalCheck()
        {
            //to do
        }
    }
}
