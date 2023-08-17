using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using CryptoAnalizerAI.AI_training;
using CryptoAnalizerAI.AI_training.TrainingStatistics;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using CryptoAnalizerAI.AI_geneticTrainingSystem.Generator;
using CryptoAnalizerAI.AI_training.AI_Perceptron;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    class GeneticTrainer
    {
        private DatasetManager datasetManager;
        private manual_AI_Trainer defaultTrainer;
        private GeneticTrainerSettings settings;

        public AI_Generator generator { get; private set; }
        public GeneticTrainer(DatasetManager datasetManager, manual_AI_Trainer trainer, GeneticTrainerSettings settings)
        {
            generator = new AI_Generator();
            this.datasetManager = datasetManager;
            this.defaultTrainer = trainer;
            this.settings = settings;

            trainer.onTrainingEnd += TrainingFinished;
        }


        private bool working;
        StatisticChronometer statsChronometer;
        public void StartLerning()
        {
            if (working) return;
            statsChronometer = new StatisticChronometer(datasetManager, defaultTrainer);
            datasetManager.dataWalker.datasetChanged += RunFinished;
            defaultTrainer.StartTraining();
        }


        public void PauseLearning()
        {
            defaultTrainer.PauseTraining();
            datasetManager.dataWalker.datasetChanged -= RunFinished;


        }

        public void StopLearning()
        {
            if (!working) return;
            iteration = 0;
            defaultTrainer.StopTraning();
            datasetManager.dataWalker.datasetChanged -= RunFinished;

            working = false;
        }

        //learn pending
        private bool checking;
        private List<DatasetsRun> learningRuns = new List<DatasetsRun>();

        //on walker dataset changing
        private DatasetsRun testRun;
        private void RunFinished()
        {
            DatasetLearningStats[] runStats = statsChronometer.getAllRecordingsAndClear();
            if (checking)
            {
                testRun = new DatasetsRun(runStats);
            }
            else
            {
                learningRuns.Add(new DatasetsRun(runStats));
            }


        }

        //on manualTrainer stopping
        private void TrainingFinished()
        {


            if (checking)
            {
                LearnEnded();
                ChangeModeToLernChecking();
            }
            else
            {
                changeModeToFinalCheck();
  
            }


        }

        private void changeModeToFinalCheck()
        {
            checking = true;
            defaultTrainer.basicSettings.setCheckRun(true);
            datasetManager.dataWalker.Reset();
            defaultTrainer.StartTraining();
        }

        private void ChangeModeToLernChecking()
        {
            checking = false;
            defaultTrainer.basicSettings.setCheckRun(false);
            datasetManager.dataWalker.Reset();
            defaultTrainer.StartTraining();
        }
        private AI_LearningRecord currentRun;
        private AI_LearningRecord previousRun;

        public learnEndedCallback onLearnEnd;

        private int iteration;
        private void LearnEnded()
        {
            AI_LearningRecord learnRecord = new AI_LearningRecord(learningRuns.ToArray(), testRun, defaultTrainer.getPerceptronCopy());
            onLearnEnd?.Invoke(learnRecord, iteration);
            iteration++;

            if (previousRun == null) previousRun = AI_LearningRecord.makeWorstStats();

            Perceptron UpdatedAI = generator.UpdatePerceptron(learnRecord, previousRun);
            defaultTrainer.ConnectPerceptron(UpdatedAI);

            previousRun = currentRun;
            currentRun = learnRecord;
        }

        public delegate void learnEndedCallback(AI_LearningRecord record, int iteration);
    }
}
