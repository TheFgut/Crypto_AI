using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.AI_Perceptron;

namespace CryptoAnalizerAI.AI_training
{
    public class WeightsSignCorrection
    {
        public int correctIterationNum { get; private set; } = -1;

        public void setCorrectIterationNum(int num)
        {
            correctIterationNum = num;
        }

        public void Correct(Perceptron target)
        {
            float minValue;
            float maxValue;
            float averageValue;
            GetWeigthBorders(target, out maxValue,out averageValue, out minValue);
            float fromMinToAverage = Math.Abs(averageValue - minValue);
            float fromMaxToAverage = Math.Abs(maxValue - averageValue);

            float minDifCoef = fromMinToAverage / fromMaxToAverage;

            float correctStep = 0.05f * minDifCoef;
            if (correctStep > 60) correctStep = 60f;
            float correctStepValue = minValue + (correctStep * fromMinToAverage);


            Neuron[][] neurons = target.neurons;
            for (int l = 0; l < neurons.Length;l++)
            {
                for (int n = 0; n < neurons[l].Length;n++)
                {
                    Neuron.link[] links = neurons[l][n].links;
                    if (links == null) continue;
                    for (int LNum = 0; LNum < links.Length; LNum++)
                    {
                        float weigth = links[LNum].weigth;
                        if(weigth < correctStepValue)
                        {
                            links[LNum].setWeigth(-weigth);
                        }
                    }
                }
            }
        }

        private void GetWeigthBorders(Perceptron target, out float max, out float average, out float min)
        {
            max = float.MinValue;
            min = float.MaxValue;
            average = 0;
        }
    }
}
