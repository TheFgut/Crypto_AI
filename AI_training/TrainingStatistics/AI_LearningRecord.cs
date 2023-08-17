using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.AI_Perceptron;
using System.Text.Json.Serialization;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    class AI_LearningRecord
    {
        public DatasetsRun[] learningRuns { get; set; }
        public DatasetsRun testRun { get; set; }

        public float finalLearn_RunError
        {
            get
            {
                if (learningRuns != null && learningRuns.Length > 0)
                {
                    return learningRuns[learningRuns.Length - 1].averageError;
                }
                return float.MaxValue;
            }
        }

        public float finalError
        {
            get
            {
                if (testRun != null)
                {
                    return testRun.averageError;
                }
                return float.MaxValue;
            }
        }

        public float finalGuessPercent
        {
            get
            {
                if (testRun != null)
                {
                    return testRun.averageGuessFrequency;
                }
                return float.MaxValue;
            }
        }

        [JsonIgnore] public Perceptron perceptron { get; private set; }

        public Perceptron_SaveFile perceptronSaveFile { get; set; }
        public AI_LearningRecord(DatasetsRun[] learningRuns, DatasetsRun testRun, Perceptron perceptron)
        {
            this.learningRuns = learningRuns;
            this.testRun = testRun;
            this.perceptron = perceptron;
            perceptronSaveFile = perceptron.makeSaveFile();
        }


        public AI_LearningRecord()
        {

        }        //for json saving


        public static AI_LearningRecord makeWorstStats()
        {
            return new AI_LearningRecord();
        }
    }
}
