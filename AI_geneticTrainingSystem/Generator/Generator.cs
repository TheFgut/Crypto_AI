using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.AI_Perceptron;
using CryptoAnalizerAI.AI_training.TrainingStatistics;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem.Generator
{
    class Generator
    {
        private Operations operation;
        public Generator()
        {
            operation = new Operations();
        }

        public Perceptron UpdatePerceptron(AI_LearningRecord currendRun, AI_LearningRecord previousRun)
        {
            //to do - сдеать поведение как в схеме
            throw new NotImplementedException();
        }
    }
}
