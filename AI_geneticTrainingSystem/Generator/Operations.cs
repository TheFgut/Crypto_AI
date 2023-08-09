using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.AI_Perceptron;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem.Generator
{
    class Operations
    {

        public Perceptron addNeurons(int layer, Perceptron perceptron)
        {
            throw new NotImplementedException();
        }

        public Perceptron removeNeurons(int layer, Perceptron perceptron)
        {
            throw new NotImplementedException();
        }

        public Perceptron addLayer(Perceptron perceptron)
        {
            throw new NotImplementedException();
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
