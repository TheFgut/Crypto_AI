using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.AI_Perceptron;
using System.Windows;
using System.ComponentModel;
using CryptoAnalizerAI.AI_training.learning_settings;
using CryptoAnalizerAI.AI_training.dataset_loading;
using System.Threading;
using CryptoAnalizerAI.AI_training.CustomDatasets;

namespace CryptoAnalizerAI.AI_training
{
    public class manual_AI_Trainer
    {
        private Perceptron perceptron;

        public Perceptron getPerceptron()
        {
            return perceptron;
        }

        public Perceptron getPerceptronCopy()
        {
            if (perceptron == null) return null;
            return (Perceptron)perceptron.Clone();
        }

        public bool trainingPending { get; private set; }
        public BasicLearningSettings basicSettings { get; private set; }
        public TrainerControllingButtons controllingButtons { get; set; }
        public DatasetManager datasetManager { get; private set; }

        public WeightsSignCorrection signCorrection { get; private set; }
        public manual_AI_Trainer(BasicLearningSettings basicSettings, DatasetManager datasetManager)
        {
 
            this.basicSettings = basicSettings;
            this.datasetManager = datasetManager;
            datasetManager.dataLoaded += DatasetsUpdated;
            datasetManager.dataChoosed += DatasetsUpdated;
            datasetManager.dataWalker.onProceedToNextDataset += RunUpdated;
            signCorrection = new WeightsSignCorrection();
        }

        public void ConnectControllingButtons(TrainerControllingButtons controllingButtons)
        {
            this.controllingButtons = controllingButtons;
        }

        public event trainEnableChange trainingAwailbaleChange;
        public void ConnectPerceptron(Perceptron perceptron)
        {
            this.perceptron = perceptron;
            perceptron.settings.setBasicLearnSettings(basicSettings);

            bool trainEnabled = isGoodConditionsForLearnong();
            if (trainEnabled) controllingButtons.ActivateControls();
            trainingAwailbaleChange?.Invoke(trainEnabled);
        }

        //enabling controls
        public void DatasetsUpdated()
        {
            bool trainEnabled = isGoodConditionsForLearnong();
            if (trainEnabled) controllingButtons.ActivateControls();
            trainingAwailbaleChange?.Invoke(trainEnabled);
        }

        public bool isGoodConditionsForLearnong()
        {
            return controllingButtons != null && datasetManager.datasets.Length > 0 && datasetManager.choosedDatasets.Length != 0 && perceptron != null;
        }

        //training
        private BackgroundWorker threadToWork;
        public event stateChangeEvent onTrainingStart;
        public void StartTraining()
        {
            if(threadToWork == null)
            {
                threadToWork = new BackgroundWorker();
                threadToWork.DoWork += Training;
                threadToWork.RunWorkerAsync();
                onTrainingStart?.Invoke();
            }
            ResetRunsCounter();
            trainingPending = true;
            basicSettings.DeactivateButtons();
        }

        public event predictionDelegate predictionEvent_retCourses;
        public event predictionDelegate predictionEvent_retDif;
        public void Training(object sender, DoWorkEventArgs args)
        {
            do
            {

                while (!trainingPending)
                {
                    Thread.Sleep(250);
                }

                Interval[] output;
                Interval[] input = datasetManager.dataWalker.Walk(perceptron.inputLength + 1, perceptron.outputLength, out output,
                    basicSettings.checkRun ? 1 : basicSettings.learningStep + 1);


                float[] inputAverages = getAverages(input);
                float startCourse = inputAverages[0];
                float[] inputDifs = convertToDif(inputAverages, startCourse, true);

                float[] perceptronPrediction = perceptron.Calculate(inputDifs);
                float[] outputAverages = getAverages(output);
                float outpStartCourse = inputAverages[inputAverages.Length - 1];
                float[] outputDifs = convertToDif(outputAverages, outpStartCourse, false);

                if (!basicSettings.checkRun)
                {
                    float progress = runNum / (float)basicSettings.runsCount;

                    float error = 0;
                    for (int i = 0; i < outputDifs.Length;i++)
                    {
                        error += Math.Abs(outputDifs[i] - perceptronPrediction[i]);
                    }

                    float speed = basicSettings.speed.getSpeed(progress, error);
                    perceptron.Learn(outputDifs, speed);
                }


                //predictionEvent_retCourses(perceptronPrediction, outputAverages);
                predictionEvent_retDif(perceptronPrediction, outputDifs);

                Thread.Sleep(basicSettings.learningDelay);
            } while (true);
        }

        private float[] getAverages(Interval[] intervals)
        {
            float[] averages = new float[intervals.Length];
            for (int i = 0; i < averages.Length; i++)
            {
                averages[i] = intervals[i].averageCourse;
            }
            return averages;
        }

        private float[] convertToDif(float[] input, float startCourse, bool ignoreFirstInput)
        {
            float[] Difs = ignoreFirstInput ? new float[input.Length - 1] : new float[input.Length];

            int drag = ignoreFirstInput ? 1 : 0;
            Difs[0] = input[drag] - startCourse;
            for (int i = 1 + drag; i < input.Length; i++)
            {
                Difs[i - drag] = input[i] - input[i - 1];
            }
            return Difs;
        }

        public void PauseTraining()
        {
            trainingPending = false;

            basicSettings.ActivateButtons();
        }
        public event stateChangeEvent onTrainingEnd;
        public event stateChangeEvent onRunEnd;
        public void StopTraning()
        {
            if (threadToWork != null)
            {
                threadToWork.Dispose();
            }
            trainingPending = false;
            basicSettings.ActivateButtons();
            onTrainingEnd?.Invoke();
        }

        public delegate void predictionDelegate(float[] prediction , float[] realCourse);
        public delegate void stateChangeEvent();
        public delegate void trainEnableChange(bool enable);

        private LearningEarlyStops learningEarlyStops;

        public void connectEarlyStopsModule(LearningEarlyStops learningEarlyStops)
        {
            this.learningEarlyStops = learningEarlyStops;
        }

        public int runNum { get; private set; }
        private int datasetNum;
        private void RunUpdated()
        {
            if (!trainingPending) return;
            
            int datasetsCount = datasetManager.choosedDatasets.Length;
            datasetNum++;

            if (datasetNum >= datasetsCount)
            {
                datasetNum -= datasetsCount;
                runNum++;
  
                if (learningEarlyStops != null && learningEarlyStops.doStop)
                {
                    onRunEnd?.Invoke();
                    LerningEnd();
                    return;
                }

                if (signCorrection.correctIterationNum == runNum)
                {
                    signCorrection.Correct(perceptron);
                }
                onRunEnd?.Invoke();
                if (runNum >= basicSettings.runsCount || basicSettings.checkRun)
                {
                    LerningEnd();
                }
            }
            
        }

        private void ResetRunsCounter()
        {
            runNum = 0;
            datasetNum = 0;
        }

        private void LerningEnd()
        {
            controllingButtons.ResetButtons();
            StopTraning();
        }
    }
}
