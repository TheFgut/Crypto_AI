﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.AI_training.dataset_loading
{
    public class DatasetManager
    {

        public DatasetManager()
        {
            dataWalker = new DataWalker(this);
        }
        public Dataset[] datasets { get; private set; } = new Dataset[0];


        public event datasetsLoaded dataLoaded;

        public int[] choosedDatasets { get; private set; } = new int[0];
        public event datasetsLoaded dataChoosed;

        public void SetChoosedDatasetsInts(int[] choosedDatasets)
        {
            this.choosedDatasets = choosedDatasets;
            dataChoosed?.Invoke();
            dataWalker.Reset();
        }

        public void SetDatasets(Dataset[] datasets)
        {
            this.datasets = datasets;
            dataLoaded?.Invoke();
            dataWalker.Reset();
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


            public int currentDataset { get; private set; } = 0;

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
            public int currentDatasetLength { get { return manager.datasets[currentDataset].data.Length; } }


            public event DataWalkerEvent datasetChanged;

            public event NumChanged DatasetPositionChanged;

            private int loopPreventionCounter;

            public Interval[] Walk(int needInputDataElements, int needOutputDataElements, out Interval[] outputDataElements, int step = 1)
            {
                Dataset choosed = manager.datasets[manager.choosedDatasets[currentDataset]];
                if (posInDataset + needInputDataElements + needOutputDataElements >= choosed.data.Length)
                {
                    loopPreventionCounter++;
                    if(loopPreventionCounter > 10)
                    {
                        loopPreventionCounter = 0;
                        
                        outputDataElements = new Interval[0];
                        return new Interval[0];
                    }

                    MoveToNextDataset(step);
                    return Walk(needInputDataElements, needOutputDataElements, out outputDataElements);
                }

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
                loopPreventionCounter = 0;

                outputDataElements = output;
                return input;
            }

            private int stepDrag;
            private void MoveToNextDataset(int dataMovingStep)
            {
                posInDataset = 0;
                currentDataset++;
                if(currentDataset >= manager.choosedDatasets.Length)
                {
                    currentDataset = 0;
                }

                stepDrag++;
                if(stepDrag < dataMovingStep)
                {
                    stepDrag = 0;
                }

                datasetChanged?.Invoke();

            }

            public delegate void DataWalkerEvent();

            public delegate void NumChanged(int newNum);

            public void Reset()
            {
                posInDataset = 0;
                datasetPos = 0;
                datasetChanged?.Invoke();
            }
        }
    }
}
