using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CryptoAnalizerAI.AI_training.learning_settings
{
    public class BasicLearningSettings
    {
        private TextBox learningSpdBox;
        private TextBox learningStepBox;
        private TextBox learningDelayBox;
        public BasicLearningSettings(TextBox learningSpdBox, TextBox learningStepBox, TextBox learningDelayBox)
        {
            this.learningSpdBox = learningSpdBox;
            learningSpdBox.Validating += learningSpdUpdate;
            this.learningStepBox = learningStepBox;
            learningStepBox.Validating += learningStepUpdate;
            this.learningDelayBox = learningDelayBox;
            learningDelayBox.Validating += learningDelayUpdate;

            learningSpdBox.Text = learningSpeed.ToString();
            learningStepBox.Text = learningStep.ToString();
            learningDelayBox.Text = learningDelay.ToString();

        }

        public void learningSpdUpdate(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            float value;
            if (float.TryParse(textBox.Text, out value))
            {
                learningSpeed = value;
            }
            else
            {
                textBox.Text = learningSpeed.ToString();
            }
        }

        public void learningStepUpdate(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                learningStep = value;
            }
            else
            {
                textBox.Text = learningStep.ToString();
            }
        }

        public void learningDelayUpdate(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                learningDelay = value;
            }
            else
            {
                textBox.Text = learningStep.ToString();
            }
        }

        public void DeactivateButtons()
        {
            learningSpdBox.ReadOnly = true;
            learningStepBox.ReadOnly = true;
            learningDelayBox.ReadOnly = true;
        }

        public void ActivateButtons()
        {
            learningSpdBox.ReadOnly = false;
            learningStepBox.ReadOnly = false;
            learningDelayBox.ReadOnly = false;
        }

        public float learningSpeed { get; private set; } = 0.01f;
        public int learningStep { get; private set; } = 0;
        public int learningDelay { get; private set; } = 200;
    }
}

    



