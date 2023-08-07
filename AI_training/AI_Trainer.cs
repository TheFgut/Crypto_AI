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
    public class AI_Trainer
    {
        private Perceptron perceptron;
        public bool trainingPending { get; private set; }
        private BasicLearningSettings basicSettings;
        private TrainerControllingButtons controllingButtons;
        public DatasetManager datasetManager { get; private set; }


        public AI_Trainer(BasicLearningSettings basicSettings, DatasetManager datasetManager)
        {
 
            this.basicSettings = basicSettings;
            this.datasetManager = datasetManager;
            datasetManager.dataLoaded += DataasetsUpdated;
            datasetManager.dataChoosed += DataasetsUpdated;
        }

        public void ConnectControllingButtons(TrainerControllingButtons controllingButtons)
        {
            this.controllingButtons = controllingButtons;
        }

        public void ConnectPerceptron(Perceptron perceptron)
        {
            this.perceptron = perceptron;
            perceptron.settings.setBasicLEarnSettings(basicSettings);
            if (isGoodConditionsForLearnong()) controllingButtons.ActivateControls();
        }

        //enabling controls
        public void DataasetsUpdated()
        {
            if (isGoodConditionsForLearnong()) controllingButtons.ActivateControls();
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
                Interval[] input = datasetManager.dataWalker.Walk(perceptron.inputLength + 1, perceptron.outputLength, out output, basicSettings.learningStep + 1);


                float[] inputAverages = getAverages(input);
                float startCourse = inputAverages[0];
                float[] inputDifs = convertToDif(inputAverages, startCourse, true);

                float[] perceptronPrediction = perceptron.Calculate(inputDifs);
                float[] outputAverages = getAverages(output);
                float outpStartCourse = inputAverages[inputAverages.Length - 1];
                float[] outputDifs = convertToDif(outputAverages, outpStartCourse, false);
                perceptron.Learn(outputDifs);

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
        public void StopTraning()
        {
            if (threadToWork != null)
            {
                threadToWork.Dispose();
            }
            onTrainingEnd?.Invoke();
            trainingPending = false;
            basicSettings.ActivateButtons();
        }

        public delegate void predictionDelegate(float[] prediction , float[] realCourse);
        public delegate void stateChangeEvent();
    }
}
