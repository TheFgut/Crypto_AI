using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.AI_Perceptron;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_making
{
    public partial class PerceptronMakerWindow : Form
    {
        private perceptronMakingCallback sendPerceptron;
        public PerceptronMakerWindow(perceptronMakingCallback returnPerceptronTo)
        {
            sendPerceptron = returnPerceptronTo;
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            sendPerceptron(new Perceptron(neuronsLayers, biases));
            Close();
        }
        private int[] neuronsLayers;
        private bool[] biases;
        private void structureInfo_Validating(object sender, CancelEventArgs e)
        {
            int[] layers;
            bool[] bias;
            if (Validate(structureInfo.Text, out layers, out bias))
            {
                neuronsLayers = layers;
                biases = bias;
                CreateButton.Enabled = true;
            }
            else
            {
                CreateButton.Enabled = false;
            }
        }

        private bool Validate(string input, out int[] neuronsSettings, out bool[] bias)
        {
            string[] splitted = input.Split('-');
            List<bool> biases = new List<bool>();
            List<int> layers = new List<int>();
            if (splitted.Length < 2)
            {
                neuronsSettings = null;
                bias = null;
                return false;
            }
            for (int i = 0; i < splitted.Length;i++)
            {
                string data = splitted[i];
                if (data.Contains('b') || data.Contains('B'))
                {
                    data = data.Remove(data.Length - 1);
                    biases.Add(true);
                }
                else
                {
                    biases.Add(false);
                }
               

                int num;
                if (int.TryParse(data, out num))
                {
                    layers.Add(num);
                }
                else
                {
                    neuronsSettings = null;
                    bias = null;
                    return false;
                }
            }
            neuronsSettings = layers.ToArray();
            bias = biases.ToArray();
            return true;
        }

        private void PerceptronMakerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                //sendPerceptron(null);
                return;
            }
        }

        private void structureInfo_TextChanged(object sender, EventArgs e)
        {
            bool[] bias;
            int[] layers;
            if (Validate(structureInfo.Text, out layers, out bias))
            {
                neuronsLayers = layers;
                biases = bias;
                CreateButton.Enabled = true;
            }
            else
            {
                CreateButton.Enabled = false;
            }
        }
    }

    public delegate void perceptronMakingCallback(Perceptron perceptron);
}
