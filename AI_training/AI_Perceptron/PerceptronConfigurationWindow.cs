using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_making;
using CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_loading;
using CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_setting_up;
using CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_analizing;
namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{
    public partial class PerceptronConfigurationWindow : Form
    {
        private Perceptron perceptron;

        private createdOrLoadedperceptronTransfer returnPerceptron;
        private InputAdapterSettingUp inpAdapterSetup;

        private PerceptronWeigtsStatsUI weightsAnalize;
        private manual_AI_Trainer trainer;
        public PerceptronConfigurationWindow(Perceptron perceptronToShow,manual_AI_Trainer trainer,createdOrLoadedperceptronTransfer returnPerceptron)
        {
            perceptron = perceptronToShow;

            this.trainer = trainer;
            this.returnPerceptron = returnPerceptron;
            InitializeComponent();
            ApplyPerceptron.Enabled = false;

            inpAdapterSetup = new InputAdapterSettingUp(IA_inputCountTextBox, IA_outputCountTextBox, inputAdapConnectBut, connectedInputAdapterDetails);
            inpAdapterSetup.ConnectPerceptron(perceptron);

            weightsAnalize = new PerceptronWeigtsStatsUI(avgWeigthDisp, maxWDisp,minWDisp, brokenWPercentDisp, this, updateWeightsDataCheckBox);

            if (perceptronToShow != null)
            {
                weightsAnalize.ConnectPerceptron(perceptronToShow);
                ShowPerceptronDetails(perceptronToShow);
            }
            trainer.learnIterationFinished += weightsAnalize.TryRecalculateData;
        }


        //creating perceptron
        private PerceptronMakerWindow perceptronMakerWindow;
        private void CreatePerceptronButton_Click(object sender, EventArgs e)
        {
            if(perceptronMakerWindow == null)
            {
                perceptronMakerWindow = new PerceptronMakerWindow(perceptronCreated, perceptron);
                perceptronMakerWindow.FormClosed += perceptronMakerClosed;
                perceptronMakerWindow.Show();
            }
            CreatePerceptronButton.Enabled = false;
        }

        private void perceptronMakerClosed(object sender, EventArgs e)
        {
            perceptronMakerWindow.FormClosed -= perceptronMakerClosed;
            perceptronMakerWindow = null;
            CreatePerceptronButton.Enabled = true;
        }

        private void perceptronCreated(Perceptron newPerceptron)
        {
            perceptron = newPerceptron;
            ApplyPerceptron.Enabled = true;
            inpAdapterSetup.ConnectPerceptron(perceptron);
            ShowPerceptronDetails(newPerceptron);
        }

        //showing perceptron details
        private void ShowPerceptronDetails(Perceptron perceptron)
        {
            int[] neuronsLayers = perceptron.settings.layers;
            string message = "perceptron loaded" + "\n" + "layers:";
            for (int i = 0; i < neuronsLayers.Length; i++)
            {
                message += "\nl"+ i + " " + neuronsLayers[i].ToString() + " neurons";
            }
            perceptronDetailsText.Text = message;
        }
        //loading perceptron
        private PerceptronLoadingWindow loaderWindow;
        private void LoadPerceptronButton_Click(object sender, EventArgs e)
        {
            if(loaderWindow == null)
            {
                loaderWindow = new PerceptronLoadingWindow(perceptronLoaded);
                loaderWindow.FormClosed += perceptronLoaderClosed;
                loaderWindow.Show();
            }
            LoadPerceptronButton.Enabled = false;
        }

        private void perceptronLoaderClosed(object sender, EventArgs e)
        {
            loaderWindow.FormClosed -= perceptronLoaderClosed;
            loaderWindow = null;
            LoadPerceptronButton.Enabled = true;
        }

        private void perceptronLoaded(Perceptron newPerceptron)
        {
            perceptron = newPerceptron;
            ApplyPerceptron.Enabled = true;
            inpAdapterSetup.ConnectPerceptron(perceptron);
            ShowPerceptronDetails(newPerceptron);
        }

        //applying
        private void ApplyPerceptron_Click(object sender, EventArgs e)
        {
            if(perceptron != null)
            {
                returnPerceptron?.Invoke(perceptron);
                Close();
            }

        }

        public delegate void createdOrLoadedperceptronTransfer(Perceptron perceptron);

        private void PerceptronConfigurationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (loaderWindow != null) loaderWindow.Close();
            if (perceptronMakerWindow != null) perceptronMakerWindow.Close();

        }

        private void PerceptronConfigurationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            trainer.learnIterationFinished -= weightsAnalize.TryRecalculateData;
        }
    }
}
