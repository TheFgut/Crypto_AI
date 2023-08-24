using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.DataSavingAndLoading;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{
    public class Perceptron_SaveFile
    {
        public float[][][] weigths { get; set; }


        //settings
        public int[] layersConfiguration { get; set; }
        public bool[] bias { get; set; }
        public Perceptron_SaveFile(Neuron[][] neurons, Perceptron_settings settings)
        {
            //saving weigths
            weigths = new float[neurons.Length][][];
            for (int layer = 0; layer < neurons.Length; layer++)
            {
                weigths[layer] = new float[neurons[layer].Length][];
                for(int neuron = 0; neuron < neurons[layer].Length; neuron++)
                {
                    Neuron.link[] links = neurons[layer][neuron].links;
                    if (links == null)
                    {
                        weigths[layer][neuron] = new float[0];
                        continue;
                    }

                    weigths[layer][neuron] = new float[links.Length];
                    for (int link = 0; link < links.Length; link++)
                    {
                        weigths[layer][neuron][link] = JsonChecks.clearInfinities(links[link].weigth);
                    }
                }
            }
            //saving settings
            layersConfiguration = settings.layers;
            bias = settings.bias;
        }

        public Perceptron_SaveFile()
        {

        }//for json saving
    }
}
