using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training;
using CryptoAnalizerAI.AI_training.CustomDatasets;


namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    public partial class GeneticTrainerSettingUpWindow : Form
    {


        private GeneticTrainer geneticTrainer;
        private ControlsButtons controlButtons;
        public GeneticTrainerSettingUpWindow(DatasetManager datasetManager, manual_AI_Trainer trainer)
        {

            InitializeComponent();

            GeneticTrainerSettings trainerSettings = new GeneticTrainerSettings();
            geneticTrainer = new GeneticTrainer(datasetManager, trainer, trainerSettings);
            controlButtons = new ControlsButtons(TrainingStartBut, TrainingStopBut, trainer, geneticTrainer);


        }


 
    }
}
