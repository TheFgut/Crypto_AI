using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.learning_settings;

namespace CryptoAnalizerAI.AI_training.UI
{
    public partial class LearningSpeedSetupWindow : Form
    {
        private LearningSpeedSettings settings;
        public LearningSpeedSetupWindow(LearningSpeedSettings spdSett)
        {
            this.settings = spdSett;
            InitializeComponent();
            startSpeedTextBox.Text = settings.startSpeed.ToString();
            endSpeedTextBox.Text = settings.endSpeed.ToString();
            errorDecreaseStartTresholdBox.Text = settings.speedDecreasErrorTreshold.ToString();
            errorDecreaseFullTresholdBox.Text = settings.maxSpeedDecreaseErrorTreshold.ToString();
            maxErrorSpeedDecreaseBox.Text = settings.errorDecreasedSpeed.ToString();
        }



        private void startSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            float newValue;
            if(float.TryParse(textBox.Text, out newValue))
            {
                settings.startSpeed = newValue;
                settings.Reset();
            }
        }

        private void startSpeedTextBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = settings.startSpeed.ToString();
        }


        private void endSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            float newValue;
            if (float.TryParse(textBox.Text, out newValue))
            {
                settings.endSpeed = newValue;
            }
        }

        private void endSpeedTextBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = settings.endSpeed.ToString();
        }

        private void errorDecreaseStartTresholdBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            float newValue;
            if (float.TryParse(textBox.Text, out newValue))
            {
                settings.speedDecreasErrorTreshold = newValue;
            }
        }

        private void errorDecreaseStartTresholdBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = settings.speedDecreasErrorTreshold.ToString();
        }

        private void errorDecreaseFullTresholdBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            float newValue;
            if (float.TryParse(textBox.Text, out newValue))
            {
                settings.maxSpeedDecreaseErrorTreshold = newValue;
            }
        }

        private void errorDecreaseFullTresholdBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = settings.maxSpeedDecreaseErrorTreshold.ToString();
        }

        private void maxErrorSpeedDecreaseBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            float newValue;
            if (float.TryParse(textBox.Text, out newValue))
            {
                settings.errorDecreasedSpeed = newValue;
            }
        }

        private void maxErrorSpeedDecreaseBox_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = settings.errorDecreasedSpeed.ToString();
        }

        public void EnableChange(bool change)
        {
            if (!change) Close();
        }
    }
}
