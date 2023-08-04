using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CryptoAnalizerAI.AI_training
{
    public class Dataset
    {
        public DateTime date { get; private set; }
        public Interval[] data { get; private set; }
        public float average { get; private set; }
        //to do систему настроект интервала(чтобы можно было бегать нейронкой не по полному датасету а только его части)
        public Dataset(Interval[] data, float average)
        {
            this.data = data;
            this.average = average;
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
