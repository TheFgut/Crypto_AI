using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.AI_Perceptron;
using CryptoAnalizerAI.AI_training.TrainingStatistics;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem.Generator
{
    class AI_Generator
    {
        private Operations operation;
        public newPerc onPerceptronUpdated;
        public AI_Generator()
        {
            operation = new Operations();
        }
        private Phase currentPhase = Phase.build_up;
        private int currentLayer = 1;

        private AI_LearningRecord etalonDataset;
        public Perceptron UpdatePerceptron(AI_LearningRecord currendRun, AI_LearningRecord previousRun)
        {

            //to do check neural update made better
            bool newIsBetter;
            Perceptron updated;
            switch (currentPhase)
            {
                case Phase.build_up:
                    newIsBetter = (previousRun.finalError / currendRun.finalError) - 1 > 0.0005f;//if better than previous more than 0.5 percent
                    updated = Build_Up(currendRun, previousRun, newIsBetter);
                    onPerceptronUpdated?.Invoke(updated);

                    etalonDataset = currendRun;

                    return updated;

                case Phase.optimization:
                    newIsBetter = (etalonDataset.finalError / currendRun.finalError) < 1.00025f;//if not worse than previous more than 0.25 percent
                    updated = Optimization(currendRun, previousRun, newIsBetter);
                    onPerceptronUpdated?.Invoke(updated);
                    return updated;

            }

            throw new Exception("Generator. UpdatePerceptron phase did't choosed");

        }

        private Perceptron Build_Up(AI_LearningRecord currendRun, AI_LearningRecord previousRun, bool newIsBetter)
        {
            Perceptron perceptron;
            if (newIsBetter)
            {
                perceptron = (Perceptron)currendRun.perceptron.Clone();
                perceptron = operation.addNeurons(currentLayer, perceptron);
                return perceptron;
            }
            else
            {
                perceptron = (Perceptron)previousRun.perceptron.Clone();
                currentLayer++;
                if (currentLayer < perceptron.hiddenLayersCount + 1)
                {
                    perceptron = operation.addNeurons(currentLayer, perceptron);
                    return perceptron;
                }
                else
                {
                    //to do stupor checkings

                    //switching to optimization
                    ChangePhase(Phase.optimization);
                    return Optimization(currendRun, previousRun, true);
                }
            }

        }

        private void ChangePhase(Phase newPhase)
        {
            currentPhase = newPhase;
            currentLayer = 1;
        }

        private Perceptron Optimization(AI_LearningRecord currendRun, AI_LearningRecord previousRun, bool newIsBetter)
        {
            Perceptron perceptron;
            if (newIsBetter)
            {
                perceptron = (Perceptron)currendRun.perceptron.Clone();
                if (currendRun.perceptron.settings.layers[currentLayer] <= 1)
                {
                    ChangePhase(Phase.build_up);
                    perceptron = operation.addLayer(perceptron);
                    return Build_Up(currendRun, previousRun, newIsBetter);
                }
     
                perceptron = operation.removeNeurons(currentLayer, perceptron);
                return perceptron;
            }
            else
            {
                perceptron = (Perceptron)previousRun.perceptron.Clone();
                currentLayer++;
                if (currentLayer < perceptron.hiddenLayersCount + 1)
                {
                    perceptron = operation.removeNeurons(currentLayer, perceptron);
                    return perceptron;
                }
                else
                {
                    //to do stupor checkings

                    //switching to optimization
                    ChangePhase(Phase.build_up);
                    perceptron = operation.addLayer(perceptron);
                    return Build_Up(currendRun, previousRun, newIsBetter);
                }
            }


        }


        private enum Phase
        {
            build_up,
            optimization
        }

        public delegate void newPerc(Perceptron newP);
    }
}
