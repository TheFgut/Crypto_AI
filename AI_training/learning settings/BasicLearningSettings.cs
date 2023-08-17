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

        private TextBox runsCountBox;
        private CheckBox checkRunBox;
        private TrainingWindow window;
        public BasicLearningSettings(TextBox learningSpdBox, TextBox learningStepBox, TextBox learningDelayBox, TextBox runsCountBox, CheckBox checkRunBox, TrainingWindow window)
        {
            this.window = window;
            this.learningSpdBox = learningSpdBox;
            learningSpdBox.Validating += learningSpdUpdate;
            this.learningStepBox = learningStepBox;
            learningStepBox.Validating += learningStepUpdate;
            this.learningDelayBox = learningDelayBox;
            learningDelayBox.Validating += learningDelayUpdate;
            this.runsCountBox = runsCountBox;
            runsCountBox.Validating += RunsCountUpdate;
            this.checkRunBox = checkRunBox;
            checkRunBox.Validated += ChecRunBoxChecked;

            learningSpdBox.Text = learningSpeed.ToString();
            learningStepBox.Text = learningStep.ToString();
            learningDelayBox.Text = learningDelay.ToString();
            runsCountBox.Text = runsCount.ToString();
            checkRunBox.Checked = checkRun;

        }

        private void learningSpdUpdate(object sender, EventArgs e)
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

        private void learningStepUpdate(object sender, EventArgs e)
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

        private void learningDelayUpdate(object sender, EventArgs e)
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

        private void RunsCountUpdate(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                runsCount = value;
            }
            else
            {
                textBox.Text = runsCount.ToString();
            }
        }

        private void ChecRunBoxChecked(object sender, EventArgs e)
        {
            CheckBox textBox = sender as CheckBox;
            setCheckRun(textBox.Checked);
        }

        public void setCheckRun(bool checkRun)
        {
            this.checkRun = checkRun;
        }

        public void DeactivateButtons(bool inNormalThread = false)
        {

            if (inNormalThread)
            {
                learningSpdBox.ReadOnly = true;
                learningStepBox.ReadOnly = true;
                learningDelayBox.ReadOnly = true;
                runsCountBox.ReadOnly = true;
                checkRunBox.Enabled = false;
            }
            else
            {
                window.BeginInvoke(new multiThreadCall(DeactivateButtons), true);
            }
        }

        public void ActivateButtons(bool inNormalThread = false)
        {

            if (inNormalThread)
            {
                learningSpdBox.ReadOnly = false;
                learningStepBox.ReadOnly = false;
                learningDelayBox.ReadOnly = false;
                runsCountBox.ReadOnly = false;
                checkRunBox.Enabled = true;
            }
            else
            {
                window.BeginInvoke(new multiThreadCall(ActivateButtons), true);
            }

        }

        public delegate void multiThreadCall(bool mult);

        public float learningSpeed { get; private set; } = 0.001f;
        public int learningStep { get; private set; } = 6;
        public int learningDelay { get; private set; } = 1;

        public int runsCount { get; private set; } = 2;

        public bool checkRun { get; private set; }
    }
}

    



