using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using CryptoAnalizerAI.AI_training.TrainingStatistics;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    public partial class GeneticTrainerSettingUpWindow : Form
    {
        public GeneticTrainerSettingUpWindow(DatasetManager datasetManager, AI_Trainer trainer)
        {
            InitializeComponent();
            
        }
    }
}
