using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using CryptoAnalizerAI.AI_geneticTrainingSystem.UI;
using CryptoAnalizerAI.AI_training.TrainingStatistics;


namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    partial class GeneticTrainerSettingUpWindow : Form
    {

        private NeuralN_Info neuralInfoUI;
        private GeneticTrainer geneticTrainer;
        private ControlsButtons controlButtons;

        private LearnRecordingsTable recordTable;
        private ChangeModeCheckBox chengeModeChck;
        public GeneticTrainerSettingUpWindow(DatasetManager datasetManager, manual_AI_Trainer trainer, StatisticChronometer statsChronometer)
        {

            InitializeComponent();

            GeneticTrainerSettings trainerSettings = new GeneticTrainerSettings();
            geneticTrainer = new GeneticTrainer(datasetManager, trainer, trainerSettings, statsChronometer);
            controlButtons = new ControlsButtons(TrainingStartBut, TrainingStopBut, trainer, geneticTrainer);

            neuralInfoUI = new NeuralN_Info(neuralInfoText,updateNumDisp, geneticTrainer.generator, this);

            recordTable = new LearnRecordingsTable(TrainedAIDataGridView, geneticTrainer, this);

            chengeModeChck = new ChangeModeCheckBox(changeStructureCheckBox, geneticTrainer);
        }


 
    }
}
