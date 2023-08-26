using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training.learning_settings;

namespace CryptoAnalizerAI.AI_training.CustomDatasets
{
    public class DatasetManager
    {
        private BasicLearningSettings settings;
        public DatasetManager(BasicLearningSettings settings)
        {
            this.settings = settings;
            dataWalker = new DataWalker(this);
        }
        public Dataset[] datasets { get; private set; } = new Dataset[0];


        public event datasetsLoaded dataLoaded;

        public int[] choosedDatasets
        {
            get
            {
                if (settings.checkRun) return checkDatasetsIds;
                return learningDatasetsIds;
            }
        }
        public event datasetsLoaded dataChoosed;

        private int[] learningDatasetsIds = new int[0];
        private int[] checkDatasetsIds = new int[0];
        public void SetChoosedDatasetsInts(int[] choosedDatasets, int[] checkDatasetsIds)
        {
            learningDatasetsIds = choosedDatasets;
            this.checkDatasetsIds = checkDatasetsIds;
            dataChoosed?.Invoke();
            dataWalker.Reset();
        }


        public int compression { get; private set; } = 8;

        public void setCompression(int newValue)
        {
            if(compression != newValue)
            {
                compression = newValue;
                packDatasets();
            }
        }

        private Dataset[] rawDatasets;
        public void SetDatasets(Dataset[] datasets)
        {
            rawDatasets = datasets;
            //packing
            packDatasets();

            dataLoaded?.Invoke();
            dataWalker.Reset();
        }

        private void packDatasets()
        {
            Dataset[] packed = new Dataset[rawDatasets.Length];
            for (int i = 0; i < packed.Length; i++)
            {
                packed[i] = rawDatasets[i].pack(compression);
            }

            this.datasets = packed;
        }

        public delegate void datasetsLoaded();


        public DataWalker dataWalker { get; private set; }
        public class DataWalker
        {
            private DatasetManager manager;

            public DataWalker(DatasetManager manager)
            {
                this.manager = manager;
            }


            public int currentDatasetNum { get; private set; } = 0;
            public int currentDatasetID { get {
                    if (manager.choosedDatasets.Length == 0)
                    {
                        return 0;
                    }
                    return manager.choosedDatasets[currentDatasetNum]; } }

            private int datasetPos = 0;

            public int posInDataset { 
                get 
                {
                    return datasetPos;
                }
                private set 
                {
                    datasetPos = value;
   
                    DatasetPositionChanged?.Invoke(datasetPos);
                } 
            }


            public event DataWalkerEvent datasetChanged;

            public event DataWalkerEvent onProceedToNextDataset;

            public event NumChanged DatasetPositionChanged;


            public bool randomizeData;


            private int antiLoopCounter = 0;
            public Interval[] Walk(int needInputDataElements, int needOutputDataElements, out Interval[] outputDataElements, int step = 1)
            {
                Dataset choosed = manager.datasets[manager.choosedDatasets[currentDatasetNum]];
                if (posInDataset + needInputDataElements + needOutputDataElements >= choosed.data.Length)
                {

                    MoveToNextDataset(step);
                    antiLoopCounter++;
                    if(antiLoopCounter > 10)
                    {
                        throw new Exception("loop");
                    }
                    return Walk(needInputDataElements, needOutputDataElements, out outputDataElements, step);
                }
                antiLoopCounter = 0;

                Interval[] input = new Interval[needInputDataElements];
                int num = posInDataset;
                for (int i = 0; i < needInputDataElements;i++)
                {
                    num = i + posInDataset;
                    input[i] = choosed.data[num];
                }
                num++;
                Interval[] output = new Interval[needOutputDataElements];
                for (int i = 0; i < needOutputDataElements; i++)
                {
                    int outputNum = i + num;
                    output[i] = choosed.data[outputNum];
                }

                posInDataset += step;

                outputDataElements = output;
                return input;
            }

            private int stepDrag;
            private int[] randomizedElements;
            private void MoveToNextDataset(int dataMovingStep)
            {

                currentDatasetNum++;
                if(currentDatasetNum >= manager.choosedDatasets.Length)
                {
                    currentDatasetNum = 0;
                }

                stepDrag++;
                if(stepDrag >= dataMovingStep)
                {
                    stepDrag = 0;
                }

                //if (randomizeData)
                //{
                //    randomizedElements = new int[];
                //}
                //else
                //{
                //    
                //}

                posInDataset = stepDrag;

                datasetChanged?.Invoke();
                onProceedToNextDataset?.Invoke();
            }


            public delegate void DataWalkerEvent();

            public delegate void NumChanged(int newNum);

            public void Reset()
            {
                posInDataset = 0;
                datasetPos = 0;
                stepDrag = 0;
                datasetChanged?.Invoke();
            }


            private class DataPacker
            {
                private const int packCount = 5;
            }
        }
    }
}
