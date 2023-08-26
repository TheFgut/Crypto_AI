using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_analizing
{
    class PerceptronWeigtsStatsUI
    {
        private TextBox averageWDisp;
        private TextBox maxWDisp;
        private TextBox minWDisp;
        private TextBox brokenWPercentDisp;

        private PerceptronConfigurationWindow window;
        public PerceptronWeigtsStatsUI(TextBox averageWDisp, TextBox maxWDisp, TextBox minWDisp, TextBox brokenWPercentDisp, PerceptronConfigurationWindow window, CheckBox updtCheckBox)
        {
            this.averageWDisp = averageWDisp;
            this.maxWDisp = maxWDisp;
            this.minWDisp = minWDisp;
            this.brokenWPercentDisp = brokenWPercentDisp;
            this.window = window;
        }

        private Perceptron perceptron;
        public void ConnectPerceptron(Perceptron perceptron)
        {
            this.perceptron = perceptron;
            recalculateData();
        }

        private bool recalculateInRealTime = true;
        public void TryRecalculateData()
        {
            if (recalculateInRealTime)
            {
                recalculateData();
            }
        }

        private void recalculateData()
        {
            float min = float.MaxValue;
            float max = float.MinValue;

            double sum = 0;
            int brokenCount = 0;
            int linksCount = 0;

            Neuron[][] neurons = perceptron.neurons;
            for (int l = 0; l < neurons.Length;l++)
            {
                for (int n = 0; n < neurons[l].Length; n++)
                {
                    Neuron.link[] links = neurons[l][n].links;
                    if (links == null) continue;
                    linksCount += links.Length;

                    foreach (Neuron.link link in links)
                    {
                        if (float.IsNaN(link.weigth) || float.IsInfinity(link.weigth)) brokenCount++;
                        else
                        {
                            if (link.weigth < min) min = link.weigth;
                            if (link.weigth > max) max = link.weigth;
                            sum += link.weigth;
                        }     
                    }
                }
            }

            float average = (float)(sum / linksCount);
            float brokenPercent = (((float)brokenCount / linksCount) * 100);

            WriteTextSafe(average.ToString("N5"), averageWDisp);
            WriteTextSafe(max.ToString(), maxWDisp);
            WriteTextSafe(min.ToString(), minWDisp);
            WriteTextSafe(brokenPercent.ToString() + "%", brokenWPercentDisp);

        }

        public void WriteTextSafe(string text, TextBox textBox)
        {
            if (textBox.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { WriteTextSafe(text, textBox); };
                textBox.Invoke(safeWrite);
            }
            else
                textBox.Text = text;
        }
    }
}
