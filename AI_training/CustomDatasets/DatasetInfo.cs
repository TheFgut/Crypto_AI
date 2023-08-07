using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CryptoAnalizerAI;

namespace CryptoAnalizerAI.AI_training.CustomDatasets
{
    class DatasetInfo
    {
        public TimeSpan timeInterval { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public float averageCourse { get; set; }
        public float minValue { get; set; }
        public float maxValue { get; set; }
        public CryptoPair cryptoPair { get; set; }

        public DatasetInfo()
        {

        }

        public DatasetInfo(TimeSpan timeInterval, DateTime startDate, DateTime endDate,
            float averageCourse, float minValue, float maxValue, CryptoPair cryptoPair)
        {
            this.timeInterval = timeInterval;
            this.startDate = startDate;
            this.endDate = endDate;
            this.averageCourse = averageCourse;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.cryptoPair = cryptoPair;
        }
    }
}
