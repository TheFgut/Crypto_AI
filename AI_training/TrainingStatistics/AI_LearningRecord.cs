using CryptoAnalizerAI.AI_training.AI_Perceptron;
using System.Text.Json.Serialization;

namespace CryptoAnalizerAI.AI_training.TrainingStatistics
{
    public class AI_LearningRecord
    {
        public DatasetsRun[] learningRuns { get; set; }
        public DatasetsRun testRun { get; set; }

        public int datasetCompression { get; set; }

        public int learningRunsCount { get; set; }
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

        public float finalGuessValue
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

        [JsonIgnore] public Perceptron perceptron { get; private set; }// dont use this, may change during trayning to another

        public void setPerceptron(Perceptron perceptron)
        {
            this.perceptron = perceptron;
        }

        public Perceptron_SaveFile perceptronSaveFile { get; set; }
        public AI_LearningRecord(DatasetsRun[] learningRuns, DatasetsRun testRun, Perceptron perceptron, int datasetCompression, int learningRunsCount)
        {
            this.learningRuns = learningRuns;
            this.testRun = testRun;
            this.perceptron = perceptron;
            this.datasetCompression = datasetCompression;
            this.learningRunsCount = learningRunsCount;
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
