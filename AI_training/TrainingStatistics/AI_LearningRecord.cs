using System;
using System.Collections.Generic;
using System.Text;

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
                return -1;
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
                return -1;
            }
        }
        public AI_LearningRecord(DatasetsRun[] learningRuns, DatasetsRun testRun)
        {
            this.learningRuns = learningRuns;
            this.testRun = testRun;
        }


        public AI_LearningRecord()
        {

        }        //for json saving
    }
}
