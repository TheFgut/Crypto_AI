using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CryptoAnalizerAI.Main;

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

        public LearningSpeedSettings speed { get; private set; }

        private Button spdSetupBut;
        public BasicLearningSettings(TextBox learningSpdBox, TextBox learningStepBox, TextBox learningDelayBox, TextBox runsCountBox, CheckBox checkRunBox, TrainingWindow window, Button spdSetupBut)
        {
            this.spdSetupBut = spdSetupBut;
            this.window = window;
            this.learningSpdBox = learningSpdBox;
            this.learningStepBox = learningStepBox;
            learningStepBox.Validating += learningStepUpdate;
            this.learningDelayBox = learningDelayBox;
            learningDelayBox.Validating += learningDelayUpdate;
            this.runsCountBox = runsCountBox;
            runsCountBox.Validating += RunsCountUpdate;
            this.checkRunBox = checkRunBox;
            checkRunBox.Validated += ChecRunBoxChecked;

            learningStepBox.Text = learningStep.ToString();
            learningDelayBox.Text = learningDelay.ToString();
            runsCountBox.Text = runsCount.ToString();
            checkRunBox.Checked = checkRun;

            speed = new LearningSpeedSettings(learningSpdBox, window);
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

        public event enableCallBack onEnableChange;
        public void DeactivateButtons(bool inNormalThread = false)
        {

            if (inNormalThread)
            {
                spdSetupBut.Enabled = false;
                learningStepBox.ReadOnly = true;
                learningDelayBox.ReadOnly = true;
                runsCountBox.ReadOnly = true;
                checkRunBox.Enabled = false;
                onEnableChange?.Invoke(false);
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
                spdSetupBut.Enabled = true;
                learningStepBox.ReadOnly = false;
                learningDelayBox.ReadOnly = false;
                runsCountBox.ReadOnly = false;
                checkRunBox.Enabled = true;
                onEnableChange?.Invoke(true);
            }
            else
            {
                window.BeginInvoke(new multiThreadCall(ActivateButtons), true);
            }

        }

        public delegate void multiThreadCall(bool mult);

        public int learningStep { get; private set; } = 50;
        public int learningDelay { get; private set; } = 1;

        public int runsCount { get; private set; } = 100;

        public bool checkRun { get; private set; }


        public delegate void enableCallBack(bool change);
    }

    public class LearningSpeedSettings
    {
        private TextBox currentSpeedDisp;
        private TrainingWindow window;
        public LearningSpeedSettings(TextBox currentSpeedDisp, TrainingWindow window)
        {
            this.currentSpeedDisp = currentSpeedDisp;
            this.window = window;
            currentSpeedDisp.Text = startSpeed.ToString();
        }

        public float startSpeed = 0.0001f;
        public float endSpeed = 0.00001f;

        public float speedDecreasErrorTreshold = 5;
        public float maxSpeedDecreaseErrorTreshold = 10;
        public float errorDecreasedSpeed = 0.0000001f;

        private float prevSpd = 0;
        public float getSpeed(float learnProgress, float error)
        {
            float progressedLSpeed = Mathf.Lerp(startSpeed, endSpeed, learnProgress);
            float errorCorrectedLSpeed = Mathf.Lerp(progressedLSpeed, errorDecreasedSpeed, getErrorLerpCoef(error));

            if(prevSpd != errorCorrectedLSpeed) showCurrentSpd(errorCorrectedLSpeed);
            prevSpd = errorCorrectedLSpeed;

            return errorCorrectedLSpeed;
        }

        public void Reset()
        {
            showCurrentSpd(startSpeed);
        }


        private float getErrorLerpCoef(float error)
        {
            if (error < speedDecreasErrorTreshold) return 0;
            if (error > maxSpeedDecreaseErrorTreshold) return 1;
            if (float.IsNaN(error) || float.IsInfinity(error)) return 1;
            return (error - speedDecreasErrorTreshold) / (maxSpeedDecreaseErrorTreshold - speedDecreasErrorTreshold);
        }

        private void showCurrentSpd(float value)
        {
            string text = value.ToString();
            if (float.IsNaN(value)) text = "zero";
            if (float.IsPositiveInfinity(value)) text = "+infinity";
            if (float.IsNegativeInfinity(value)) text = "-infinity";



            window.BeginInvoke(new setText(setTextFunc), currentSpeedDisp, text);
        }

        private void setTextFunc(TextBox box, string text)
        {
            box.Text = text;
        }

        private delegate void setText(TextBox box, string text);
    }
}

    



