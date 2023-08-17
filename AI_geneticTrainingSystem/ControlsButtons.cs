using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    internal class ControlsButtons
    {
        private Button startBut;
        private Button stopBut;

        private GeneticTrainer geneticTrainer;
        private TrainerControllingButtons manual_trainer_controls;
        public ControlsButtons(Button startBut, Button stopBut, manual_AI_Trainer trainer, GeneticTrainer geneticTrainer)
        {
            this.startBut = startBut;
            this.stopBut = stopBut;
            this.geneticTrainer = geneticTrainer;

            SetEnable(trainer.isGoodConditionsForLearnong());
            trainer.trainingAwailbaleChange += SetEnable;
            startBut.BackColor = Color.Gray;

            startBut.Click += StartButtonClicked;
            stopBut.Click += StopButtonClicked;

            manual_trainer_controls = trainer.controllingButtons;

 
        }

        private bool enabled;
        public void SetEnable(bool enabled)
        {
            if (trainPending) return;
            this.enabled = enabled;

            startBut.Enabled = enabled;
            stopBut.Enabled = enabled;

            ResetStartBut();
        }

        private bool trainPending;
        public void StartButtonClicked(object sender, EventArgs e)
        {
            manual_trainer_controls.DeactivateControls();
            trainPending = !trainPending;
            if (trainPending)
            {
                geneticTrainer.StartLerning();
                startBut.Text = "Pause";
                startBut.BackColor = Color.Yellow;
            }
            else
            {
                geneticTrainer.PauseLearning();
                ResetStartBut();
            }
        }

        public void StopButtonClicked(object sender, EventArgs e)
        {
            manual_trainer_controls.ActivateControls();
            geneticTrainer.StopLearning();
            ResetStartBut();
        }

        private void ResetStartBut()
        {
            startBut.Text = "Start";
            startBut.BackColor = Color.Gray;
        }


        public delegate void multiThreadCall(bool mult);
    }
}
