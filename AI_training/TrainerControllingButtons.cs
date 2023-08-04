using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace CryptoAnalizerAI.AI_training
{
    public class TrainerControllingButtons
    {
        private Button startButton;
        private Button stopButton;

        private AI_Trainer trainer;
        public TrainerControllingButtons(Button startButton, Button stopButton, AI_Trainer trainer)
        {
            this.startButton = startButton;
            startButton.Click += StartLearningButton_Click;
            this.stopButton = stopButton;
            stopButton.Click += StopLearningButton_Click;
            this.trainer = trainer;
            trainer.ConnectControllingButtons(this);
        }

        private void StartLearningButton_Click(object sender, EventArgs e)
        {
            if(stopButton.Enabled == false)
            {
                stopButton.Enabled = true;
                stopButton.BackColor = Color.Red;
            }
            
            if (trainer.trainingPending)
            {
                startButton.BackColor = Color.PaleGreen;
                startButton.Text = "Start";
                trainer.PauseTraining();
            }
            else
            {
                startButton.BackColor = Color.Yellow;
                startButton.Text = "Pause";
                trainer.StartTraining();
            }

        }
        private void StopLearningButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            stopButton.BackColor = SystemColors.Control;

            startButton.Text = "Start";
            startButton.BackColor = SystemColors.Control;

            trainer.StopTraning();


        }

        private bool enabled = true;
        public void DeactivateControls()
        {
            if (!enabled) return;

            startButton.Enabled = false;
            startButton.Text = "Start";
            startButton.BackColor = SystemColors.Control;

            stopButton.Enabled = false;
            stopButton.BackColor = SystemColors.Control;

            enabled = false;
        }

        public void ActivateControls()
        {
            if (enabled) return;

            startButton.Enabled = true;
            startButton.Text = "Start";

            enabled = true;
        }
    }
}
