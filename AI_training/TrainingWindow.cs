using System;
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

namespace CryptoAnalizerAI.AI_training
{
    public partial class TrainingWindow : Form
    {
        private BasicLearningSettings learningSettings;
        private TrainerControllingButtons trainerControls;
        private AI_Trainer trainer;
        private DatasetManager datasetsManager;
        private TrainingVisualizer visualizer;
        public TrainingWindow()
        {
            InitializeComponent();
            datasetsManager = new DatasetManager();
            learningSettings = new BasicLearningSettings(learningSpeedText, learningStepText, DelayBetweenLearnsBox);
            trainer = new AI_Trainer(learningSettings, datasetsManager);
            trainerControls = new TrainerControllingButtons(StartLearningButton, StopLearningButton, trainer);

            visualizer = new TrainingVisualizer(PredictionGraphic, averageErrorDisp, highestError, learnPosGraphic, trainer);

            trainerControls.DeactivateControls();
            ChackDatasetConfiguration();

            datasetManager = new DatasetsManagerWindow(datasetsManager);
            datasetManager.datasetLoaded += datasetsLoaded;
            datasetManager.datasetConfigurationChanged += datasetsConfigured;
            datasetManager.FormClosing += DatasetManagerClosing;


            datasetManager.LoadDatasetsFromDefaultPath();
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
                 + "Choosed " + DatasetsManagerWindow.choosedDatasets.Count + "datasets";
            }

        }

        //perceptron loading and configuration
        private PerceptronConfigurationWindow perceptronConfiguration;
        private Perceptron perceptron;
        private void PerceptronConfigure_Click(object sender, EventArgs e)
        {
            if(perceptronConfiguration == null)
            {
                perceptronConfiguration = new PerceptronConfigurationWindow(perceptron, PerceptronLoaded);
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
    }
}
