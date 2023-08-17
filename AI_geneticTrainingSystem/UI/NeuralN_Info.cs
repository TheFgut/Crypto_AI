using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_geneticTrainingSystem.Generator;
using CryptoAnalizerAI.AI_training.AI_Perceptron;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem.UI
{
    class NeuralN_Info
    {
        private RichTextBox statsDisp;
        private TextBox updateNumDisp;
        private GeneticTrainerSettingUpWindow window;
        public NeuralN_Info(RichTextBox statsDisp,TextBox updateNumDisp, AI_Generator generator, GeneticTrainerSettingUpWindow window)
        {
            this.window = window;
            this.updateNumDisp = updateNumDisp;
            this.statsDisp = statsDisp;
            generator.onPerceptronUpdated += updateAiDescription;
        }
 
        private void updateAiDescription(Perceptron newP)
        {
            string statsStr = "Perceptron structure:";
            int[] aiLAyers = newP.settings.layers;
            statsStr += "\ninput:" + aiLAyers[0].ToString() + " neurons";
            for (int i = 1; i < aiLAyers.Length - 1;i++)
            {
                statsStr += "\nl" + (i - 1).ToString() + ": " + aiLAyers[i].ToString() + " neurons";
            }
            statsStr += "\noutput:" + aiLAyers[aiLAyers.Length - 1].ToString() + " neurons";

            newAiUpdateHappened();

            updateStatsDispText(statsStr);
        }

        private int updatesCount;
        private void newAiUpdateHappened()
        {
            updatesCount++;
            updateNumDispText(updatesCount.ToString());
        }

        private void updateStatsDispText(string text ,bool inNormalThread = false)
        {
   
            if (inNormalThread)
            {
                statsDisp.Text = text;
            }
            else
            {
                window.BeginInvoke(new multiThreadCall(updateStatsDispText), text, true);
            }
        }

        private void updateNumDispText(string text, bool inNormalThread = false)
        {
            if (inNormalThread)
            {
                updateNumDisp.Text = text;
            }
            else
            {
                window.BeginInvoke(new multiThreadCall(updateNumDispText), text, true);
            }

        }

        public void Reset()
        {
            updatesCount = 0;
            updateNumDisp.Text = updatesCount.ToString();
        }

        public delegate void multiThreadCall(string text, bool mult);
    }
}
