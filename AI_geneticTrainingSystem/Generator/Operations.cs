using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.AI_Perceptron;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem.Generator
{
    class Operations
    {
        //to do save old weigts and full settings 
        public Perceptron addNeurons(int layer, Perceptron perceptron)
        {
            Perceptron_settings settings = (Perceptron_settings)perceptron.settings;
            int[] layers = settings.layers;

            int neuronsIncrease = (int)(layers[layer] * 0.15f);
            if (neuronsIncrease <= 0) neuronsIncrease = 1;
            layers[layer] += neuronsIncrease;//adding 15 percent to size
            //Perceptron_settings updatedSett = new Perceptron_settings(layers, settings.activationFunc);
            Perceptron updated = new Perceptron(layers, perceptron.bias);

            return updated;
        }

        public Perceptron removeNeurons(int layer, Perceptron perceptron)
        {
            Perceptron_settings settings = (Perceptron_settings)perceptron.settings;
            int[] layers = settings.layers;

            int neuronsDecrease = (int)(layers[layer] * 0.075f);//removing 7.5 percent from size
            if (neuronsDecrease <= 0) neuronsDecrease = 1;
            layers[layer] -= neuronsDecrease;
            //Perceptron_settings updatedSett = new Perceptron_settings(layers, settings.activationFunc);
            Perceptron updated = new Perceptron(layers, perceptron.bias);

            return updated;
        }

        public Perceptron addLayer(Perceptron perceptron)
        {
            Perceptron_settings settings = (Perceptron_settings)perceptron.settings;
            int[] layers = settings.layers;
            int[] newLayers = new int[layers.Length + 1];
            for (int i = 0; i < layers.Length - 1; i++)
            {
                newLayers[i] = layers[i];
            }
            newLayers[newLayers.Length - 1] = layers[layers.Length - 1];
            newLayers[newLayers.Length - 2] = layers[layers.Length - 2];


            //Perceptron_settings updatedSett = new Perceptron_settings(layers, settings.activationFunc);
            Perceptron updated = new Perceptron(newLayers, perceptron.bias);

            return updated;
        }

        //backup
        private Perceptron backup;
        public void Remember(Perceptron perceptron)
        {
            backup = (Perceptron)perceptron.Clone();
        }

        public Perceptron restore()
        {
            return (Perceptron)backup.Clone();
        }

        public Perceptron peekPrevious()
        {
            return backup;
        }
    }
}
