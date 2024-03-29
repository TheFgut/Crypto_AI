﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.dataset_loading;
using CryptoAnalizerAI.AI_training.learning_settings;
using CryptoAnalizerAI.AI_training.AI_Perceptron;
using System.Threading;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using CryptoAnalizerAI.AI_geneticTrainingSystem;
using CryptoAnalizerAI.AI_training.TrainingStatistics;
using CryptoAnalizerAI.AI_training.UI;

namespace CryptoAnalizerAI.AI_training
{
    public partial class TrainingWindow : Form
    {
        private BasicLearningSettings learningSettings;
        private TrainerControllingButtons trainerControls;
        private manual_AI_Trainer trainer;
        private DatasetManager datasetsManager;
        private TrainingVisualizer visualizer;
        private DataCompressionParamsController dataComprController;
        private WeightSignCorrectionController signCorrectionControls;
        private LearningEarlyStops learningEarlyStops;

        private StatisticChronometer statisticsChronometer;
        public TrainingWindow()
        {
            InitializeComponent();

            learningSettings = new BasicLearningSettings(learningSpeedText, learningStepText, DelayBetweenLearnsBox, learningRunsTextBox, CheckRunCheckBox, this, learningSpeedSetupBut);
            datasetsManager = new DatasetManager(learningSettings);
            trainer = new manual_AI_Trainer(learningSettings, datasetsManager);
            trainerControls = new TrainerControllingButtons(StartLearningButton, StopLearningButton, trainer, this);

            visualizer = new TrainingVisualizer(PredictionGraphic, averageErrorDisp, highestError, learnPosGraphic, trainer,
                 DatasetNumDiaplay, WalkNumDisplay, datasetsManager, this, averageAI_outputTextBox, averagerealCourseChangeTextBox);

            trainerControls.DeactivateControls();
            ChackDatasetConfiguration();

            datasetManager = new DatasetsManagerWindow(datasetsManager);
            datasetManager.datasetLoaded += datasetsLoaded;
            datasetManager.datasetConfigurationChanged += datasetsConfigured;
            datasetManager.FormClosing += DatasetManagerClosing;

            dataComprController = new DataCompressionParamsController(compressionValueTextBox, ApplyCompressionBut, datasetsManager, trainer);

            datasetManager.LoadDatasetsFromDefaultPath();

            statisticsChronometer = new StatisticChronometer(datasetsManager, trainer);
            signCorrectionControls = new WeightSignCorrectionController(trainer.signCorrection, WeigthSignCorrectionTextBox);
            learningEarlyStops = new LearningEarlyStops(statisticsChronometer, trainer, this, countToStopTresholdTextBox, errorDontChangeTresholdTextBox, errorDontChangeCounterTextBox);

            trainer.connectEarlyStopsModule(learningEarlyStops);
        }

        private void TrainingWindow_Load(object sender, EventArgs e)
        {

        }

        //datasets loading
        private DatasetsManagerWindow datasetManager;
        private void loadDataBut_Click(object sender, EventArgs e)
        {
            datasetManager.Show();

        }

        private void DatasetManagerClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            datasetManager.Hide();
        }

        public void datasetsLoaded(string details)
        {
            ChackDatasetConfiguration();
        }

        public void datasetsConfigured(string details)
        {
            ChackDatasetConfiguration();
        }

        private void ChackDatasetConfiguration()
        {
            if (datasetsManager.datasets == null || datasetsManager.datasets.Length == 0)
            {
                loadedDataDetailsText.Text = "no datasets loaded";

            }
            else
            {
                loadedDataDetailsText.Text = "Loaded " + datasetsManager.datasets.Length + "datasets" + "\n"
                 + "Choosed " + datasetManager.choosedDatasets.Count + "datasets";
            }

        }

        //perceptron loading and configuration
        private PerceptronConfigurationWindow perceptronConfiguration;
        private Perceptron perceptron;
        private void PerceptronConfigure_Click(object sender, EventArgs e)
        {
            if(perceptronConfiguration == null)
            {
                perceptronConfiguration = new PerceptronConfigurationWindow(perceptron,trainer, PerceptronLoaded);
                perceptronConfiguration.FormClosed += perceptronConfigurationClosed;
                perceptronConfiguration.Show();
            }
        }

        private void PerceptronLoaded(Perceptron perceptron)
        {
            trainer.ConnectPerceptron(perceptron);
            perceptronDetailsText.Text = "perceptronLoaded";
            this.perceptron = perceptron;
        }

        private void perceptronConfigurationClosed(object sender, EventArgs e)
        {
            perceptronConfiguration.FormClosed -= perceptronConfigurationClosed;
            perceptronConfiguration = null;
        }

        //update
        private void UpdateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            Thread.Sleep(100);
        }

        private GeneticTrainerSettingUpWindow automaticTrainingWindow;
        private void AutomaticTrainingBut_Click(object sender, EventArgs e)
        {
            if(automaticTrainingWindow == null)
            {
                automaticTrainingWindow = new GeneticTrainerSettingUpWindow(datasetsManager,trainer, statisticsChronometer);
                automaticTrainingWindow.FormClosed += AutomaticTrainingWindowClosed;
                automaticTrainingWindow.Show();
            }
        }

        private void AutomaticTrainingWindowClosed(object sender, EventArgs e)
        {
            automaticTrainingWindow.FormClosed -= AutomaticTrainingWindowClosed;
            automaticTrainingWindow = null;
        }

        private LearningSpeedSetupWindow lSpeedSetup;
        private void learningSpeedSetupBut_Click(object sender, EventArgs e)
        {
            if(lSpeedSetup == null)
            {
                lSpeedSetup = new LearningSpeedSetupWindow(learningSettings.speed);
                lSpeedSetup.FormClosed += lSpeedSetupWindowClosed;
                learningSettings.onEnableChange += lSpeedSetup.EnableChange;
                lSpeedSetup.Show();
            }
        }

        private void lSpeedSetupWindowClosed(object sender, EventArgs e)
        {
            lSpeedSetup.FormClosed -= lSpeedSetupWindowClosed;
            learningSettings.onEnableChange -= lSpeedSetup.EnableChange;
            lSpeedSetup = null;
        }
    }
}
