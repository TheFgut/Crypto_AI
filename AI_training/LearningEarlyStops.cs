using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.TrainingStatistics;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training;


namespace CryptoAnalizerAI.AI_training
{
    public class LearningEarlyStops
    {
        private StatisticChronometer chronometer;

        private TrainingWindow window;
        private TextBox counterTextBox;
        public LearningEarlyStops(StatisticChronometer chronometer,manual_AI_Trainer trainer, TrainingWindow window,
            TextBox countToStopBox, TextBox TresholdToStopBox,TextBox counterTextBox)
        {
            this.counterTextBox = counterTextBox;
            this.window = window;
            this.chronometer = chronometer;
            chronometer.onRunsDataPacked += dataRecorded;
            trainer.onTrainingEnd += Reset;

            countToStopBox.TextChanged += countToStopChanged;
            countToStopBox.Validating += countToStopValidating;
            countToStopValidating(countToStopBox, null);

            TresholdToStopBox.TextChanged += errorTresholdChanged;
            TresholdToStopBox.Validating += errorTresholdValidating;
            errorTresholdValidating(TresholdToStopBox, null);
        }

        private int countToStop = 10;

        public bool doStop { get { return counter >= countToStop; } }

        private int counter;

        private float treshold = 0.01f;

        private DatasetLearningStats prev;
        private void dataRecorded(DatasetLearningStats fullDataRun)
        {
            if (prev != null)
            {
                float dif = Math.Abs(1 - (prev.averageError / fullDataRun.averageError));
                if (dif < treshold)
                {
                    counter++;
                    window.BeginInvoke(new writeData(WriteText), counterTextBox, counter.ToString());
                }
                else
                {
                    Reset();
                }
            }
            prev = fullDataRun;
        }


        private void Reset()
        {
            counter = 0;
            window.BeginInvoke(new writeData(WriteText), counterTextBox, counter.ToString());
        }

        public delegate void writeData(TextBox box, string text);

        private void WriteText(TextBox box, string text)
        {
            box.Text = text;
        }

        private void countToStopChanged(object sender, EventArgs args)
        {
            TextBox box = (TextBox)sender;
            int newValue;
            if(int.TryParse(box.Text, out newValue))
            {
                if(newValue != countToStop)
                {
                    countToStop = newValue;
                }
            }
        }

        private void countToStopValidating(object sender, EventArgs args)
        {
            TextBox box = (TextBox)sender;
            box.Text = countToStop.ToString();
        }


        private void errorTresholdChanged(object sender, EventArgs args)
        {
            TextBox box = (TextBox)sender;
            float newValue;

            string text = box.Text;
            if (text.EndsWith("%"))
            {
                text = text.Remove(text.Length - 1);
            }
            if (float.TryParse(text, out newValue))
            {
                if (newValue != countToStop)
                {
                    treshold = newValue/100;
                }
            }
        }

        private void errorTresholdValidating(object sender, EventArgs args)
        {
            TextBox box = (TextBox)sender;
            box.Text = (treshold * 100).ToString() + "%";
        }
    }
}
