﻿using System;
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
        private Phase currentPhase = Phase.build_up;
        private int currentLayer = 1;
        public Perceptron UpdatePerceptron(AI_LearningRecord currendRun, AI_LearningRecord previousRun)
        {
            //to do check neural update made better
            bool newIsBetter;

            switch (currentPhase)
            {
                case Phase.build_up:
                    newIsBetter = (previousRun.finalError / currendRun.finalError) - 1 > 0.0005f;//if better than previous more than 0.5 percent
                    return Build_Up(currendRun, previousRun, newIsBetter);

                case Phase.optimization:
                    newIsBetter = (previousRun.finalError / currendRun.finalError) - 1 > -0.0005f;//if not worse than previous more than 0.5 percent
                    return Optimization(currendRun, previousRun, newIsBetter);

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
    }
}
