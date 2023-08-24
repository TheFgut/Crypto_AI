using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CryptoAnalizerAI.AI_training.CustomDatasets
{
    public class Dataset
    {
        public DateTime date { get; private set; }
        public Interval[] data { get; private set; }
        public float average { get; private set; }

        public float durationInHours { get; private set; }
        //to do систему настроект интервала(чтобы можно было бегать нейронкой не по полному датасету а только его части)
        public Dataset(Interval[] data, float average, float durationInHours)
        {
            this.data = data;
            this.average = average;
            this.durationInHours = durationInHours;
        }


        public Dataset pack(int packing)
        {
            if (packing <= 1) return this;

            DatasetPacker packer = new DatasetPacker(packing, this);

            return packer.getPacked();
        }


        private class DatasetPacker
        {
            private int packing;
            private Interval[] Intervals;
            private float average;
            private float duration;
            public DatasetPacker(int packing, Dataset dataset)
            {
                this.packing = packing;
                this.Intervals = dataset.data;
                duration = dataset.durationInHours;
                average = dataset.average;
            }

            //to do sell and buy orders calculation
            public Dataset getPacked()
            {
                int outcome = Intervals.Length / packing;
                Interval[] packedIntervals = new Interval[outcome];

                int step = 0;
                int outcomeNum = 0;
                do
                {
                    float averagesSum = 0;
                    for (int i = 0; i < packing; i++)
                    {
                        averagesSum += Intervals[i + step].averageCourse;
                    }
                    averagesSum /= packing;
                    packedIntervals[outcomeNum] = new Interval(averagesSum, null, null);

                    outcomeNum++;
                    step += packing;
                } while (outcomeNum < outcome);

                return new Dataset(packedIntervals, average, duration);
            }


        }
    }

    public class Interval
    {
        public float averageCourse { get; protected set; }
        public float[] averageBuyOrders { get; protected set; }
        public float[] averageSellOrders { get; protected set; }
        public Interval(float averageCourse, float[] averageBuyOrders, float[] averageSellOrders)
        {
            this.averageCourse = averageCourse;
            this.averageBuyOrders = averageBuyOrders;
            this.averageSellOrders = averageSellOrders;
        }
    }

    public class DynamicDataset
    {


        public int maximumIntervalsCount { get; set; }
        public DynamicDataset(int maximumIntervalsCount)
        {
            this.maximumIntervalsCount = maximumIntervalsCount;
        }
    }
}
