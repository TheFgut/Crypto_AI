﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CryptoAnalizerAI.AI_training.learning_settings;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{
    public class Perceptron : ICloneable
    {


        public Neuron[][] neurons { get; private set; }//1 - number of layer, 2 - number of neuron in layer
        public Perceptron_settings settings { get; private set; }

        public int inputDataLength
        {
            get
            {
                return neurons.Length == 0 || neurons == null ? 0 : neurons[0].Length;
            }
        }

        public DataAdapter DataAdapter { get; private set; }

        public void setDataAdapter(DataAdapter adapter)
        {
            DataAdapter = adapter;
        }

        public int outputDataLength { get {
                if (DataAdapter != null) return DataAdapter.inputValuesCount;
                return neurons.Length == 0 || neurons == null ? 0 : neurons[neurons.Length - 1].Length; } }

        private perceptronOutput transferOutput;
        private backPropagete backTransfer;

        public int hiddenLayersCount { get
            {
                if (neurons == null) return 0;
                return neurons.Length - 2;
            } 
        }
        public Perceptron(Perceptron_settings settings,
            perceptronOutput output, backPropagete back)
        {
            //this.transferOutput = output;
            //this.backTransfer = back;
            //this.settings = settings;

            //neuronsGenerate(settings);
        }

        public Perceptron(Perceptron_SaveFile saveFile)
        {
            settings = new Perceptron_settings(saveFile.layersConfiguration, saveFile.bias, new hyperbolicTan());
            neuronsGenerate<Neuron>(settings, saveFile.bias);
            applyWeigths(saveFile.weigths);
        }

        private void applyWeigths(float[][][] weigths)
        {
            //to do weigth assign to neurons

            for (int layerNum = 0; layerNum < weigths.Length; layerNum++)
            {
                Neuron[] layer = neurons[layerNum]; ;
                for (int neuronNum = 0; neuronNum < weigths[layerNum].Length; neuronNum++)
                {
                    layer[neuronNum].setWeigths(weigths[layerNum][neuronNum]);
                }
            }
        }

        public Perceptron(int[] layers, bool[] bias)
        {
            settings = new Perceptron_settings(layers, bias, new hyperbolicTan());
            neuronsGenerate<Neuron>(settings, bias, false);
            
        }

        private Perceptron(Perceptron_settings settings)
        {
            this.settings = settings;
            neuronsGenerate<Neuron>(settings, settings.bias, false);
        }

        private void neuronsGenerate<N>(Perceptron_settings settings, bool[] biases, bool makeOutputFit1 = false) where N : Neuron, new() 
        {
            Random randomModule = new Random();

            neurons = new Neuron[settings.layers.Length][];
            //input
            bool bias = biases[0];
            int BCoef = (bias ? 1 : 0);
            int inputLCount = settings.layers[0] + BCoef;
            neurons[0] = new Neuron[inputLCount + (biases[0] ? 1 : 0)];
            for (int i = 0; i < neurons[0].Length - BCoef; i++)
            {
                neurons[0][i] = new N();
  
            }

            if (bias)
            {
                neurons[0][neurons[0].Length - 1] = new Bias();
            }
            //inner
            if (settings.layers.Length > 2)
            {
                for (int LayerN = 1; LayerN < neurons.Length - 1; LayerN++)
                {
                    bias = biases[LayerN];
                    BCoef = (bias ? 1 : 0);

                    int neuronsCount = settings.layers[LayerN];
                    neurons[LayerN] = new Neuron[neuronsCount + BCoef];
                    for (int NeuronN = 0; NeuronN < neuronsCount; NeuronN++)
                    {
                        neurons[LayerN][NeuronN] = new N();
                        neurons[LayerN][NeuronN].Init(neurons[LayerN - 1], randomModule, makeOutputFit1);
                    }
                    if (bias)
                    {
                        neurons[LayerN][neuronsCount] = new Bias();
                    }
                }
            }

            //output
            int outputLayerId = neurons.Length - 1;
            int lastPrev = outputLayerId - 1;
            neurons[outputLayerId] = new Neuron[settings.layers[outputLayerId]];
            for (int i = 0; i < neurons[outputLayerId].Length; i++)
            {
                neurons[outputLayerId][i] = new N();
                neurons[outputLayerId][i].Init(neurons[lastPrev], randomModule, makeOutputFit1);
            }
        }

        public float[] Calculate(float[] input)
        {
            if (input.Length != inputDataLength)
            {
                throw new Exception("perceptron calculation input bigger or smaller than expected");
            }
            //задает значения на входной слой
            setInput(input);
            //просчитывает значения на внутренних слоях
            for (int LayerN = 1; LayerN < neurons.Length - 1; LayerN++)
            {
                for (int NeuronN = 0; NeuronN < neurons[LayerN].Length; NeuronN++)
                {
                    
                    neurons[LayerN][NeuronN].Calculate(settings.activationFunc);

                }
            }
            //вывод данных 
            int lastLayerId = neurons.Length - 1;
            float[] outputData = new float[neurons[lastLayerId].Length];
            for (int NeuronN = 0; NeuronN < outputData.Length; NeuronN++)
            {
                outputData[NeuronN] = neurons[lastLayerId][NeuronN].Calculate(settings.activationFunc);
                outputData[NeuronN] = neurons[lastLayerId][NeuronN].getNum();

            }


            if (DataAdapter != null)
            {
                outputData = DataAdapter.Revert(outputData);
            }

            if (transferOutput != null) transferOutput(outputData);
            return outputData;
        }
        private void backPropagate(float learningSpeed)
        {
            for (int LayerN = neurons.Length - 2; LayerN > 1; LayerN--)//всё остальное вплоть до входных
            {
                for (int NeuronN = 0; NeuronN < neurons[LayerN].Length; NeuronN++)
                {
                    float proizvodnaya = settings.activationFunc.derivative(neurons[LayerN][NeuronN].getNum());
                    float weights_delta = neurons[LayerN][NeuronN].error * proizvodnaya;
                    neurons[LayerN][NeuronN].backPropagate(weights_delta, learningSpeed);
                }
            }
            //продолжение обратного распространения, если к перцептрону подключен/ы другой/ие
            if (backTransfer != null)
            {
                float[] errors = new float[neurons[0].Length];
                for(int i = 0; i < neurons[0].Length;i++)
                {
                    errors[i] = neurons[0][i].error;
                }
                backTransfer(errors);
            }

        }
        public void Learn(float[] expectedOutput, float learningSpeed)
        {
            if(DataAdapter != null)
            {
                expectedOutput = DataAdapter.Convert(expectedOutput);
            }
            ereaseLerningErrorData();
            //изменение весов(обратное распостранение)
            int L = neurons.Length - 1;
            for (int NeuronN = 0; NeuronN < neurons[L].Length; NeuronN++)//выходные веса
            {

                float error = neurons[L][NeuronN].getNum() - expectedOutput[NeuronN];
                float proizvodnaya = settings.activationFunc.derivative(neurons[L][NeuronN].getNum());
                float currentNeuronError = error * proizvodnaya;
                neurons[L][NeuronN].increaseError(currentNeuronError);
                neurons[L][NeuronN].backPropagate(currentNeuronError, learningSpeed);

            }
            backPropagate(learningSpeed);

        }

        private void ereaseLerningErrorData()
        {
            foreach (Neuron[] layer in neurons)
            {
                foreach (Neuron n in layer)
                {
                    n.clearError();
                }
            }
        }

        private void setInput(float[] input)
        {
            //задает значения на входной слой
            for (int Nn = 0; Nn < input.Length; Nn++)
            {
                neurons[0][Nn].setNum(input[Nn]);
            }
        }




        public object Clone()
        {
            //to do cloning weights values
            Perceptron perceptron = new Perceptron((Perceptron_settings)settings.Clone());
            perceptron.setDataAdapter(DataAdapter);
            return perceptron;
        }        //cloning only structure

        public Perceptron_SaveFile makeSaveFile()
        {
            //throw new NotImplementedException();
            return new Perceptron_SaveFile(neurons, settings);
        }

        public override string ToString()
        {
            string description = "";
            for (int i = 0; i < settings.layers.Length;i++)
            {
                description += "l" + i.ToString() + ":" + settings.layers[i].ToString() + " ";
            }
            return description;
        }

    }


    public class Perceptron_settings : ICloneable
    {
        public int[] layers { get; private set; }
        public bool[] bias { get; private set; }
        public activationFunction activationFunc { get; private set; }

        public BasicLearningSettings basicLearnSettings { get; private set; }

        public void setBasicLearnSettings(BasicLearningSettings basicLearnSettings)
        {
            this.basicLearnSettings = basicLearnSettings;
        }

        public object Clone()
        {
            Perceptron_settings newS = new Perceptron_settings((int[])layers.Clone(),(bool[])bias.Clone(), activationFunc);
            newS.setBasicLearnSettings(basicLearnSettings);
            return newS;
        }

        public Perceptron_settings(int[] layers, bool[] bias,
            activationFunction activationFunc)
        {

            this.layers = layers;
            this.bias = bias;
            this.activationFunc= activationFunc;
        }
    }

}
