using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CryptoAnalizerAI.AI_training;

namespace CryptoAnalizerAI.Chonometer
{
    class CourseDataRecorder
    {
        private ChronometerSettings settings;
        public CourseDataRecorder(ChronometerSettings settings)
        {
            this.settings = settings;
            InitFolderName();
            buyOrdersSum = new float[settings.buyOrdersRecordDepth];
            sellOrdersSum = new float[settings.sellOrdersRecordDepth];
        }

        private DateTime datasetRecordDate;
        private float recordFullTime;
        private float courseSum;
        private float[] buyOrdersSum;
        private float[] sellOrdersSum;
        public void record(float currentCourse, float[] buyOrders, float[] sellOrders)
        {
            float millisecDifFromLastRecord = CheckMillisecDif();
            float dif = recordFullTime + millisecDifFromLastRecord - settings.smoothInteval;

            if (dif >= 0)
            {
                float coef = millisecDifFromLastRecord - dif;
                courseSum += currentCourse * coef;
                for (int i = 0; i < buyOrdersSum.Length; i++)
                {
                    buyOrdersSum[i] += buyOrders[i] * coef;
                }
                for (int i = 0; i < sellOrdersSum.Length; i++)
                {
                    sellOrdersSum[i] += sellOrders[i] * coef;
                }
                smoothAndSave(courseSum, buyOrdersSum, sellOrdersSum);

                coef = dif;
                courseSum = currentCourse * coef;
                for (int i = 0; i < buyOrdersSum.Length; i++)
                {
                    buyOrdersSum[i] = buyOrders[i] * coef;
                }
                for (int i = 0; i < sellOrdersSum.Length; i++)
                { 
                    sellOrdersSum[i] = sellOrders[i] * coef;
                }
                recordFullTime = dif;
            }
            else
            {
                courseSum += currentCourse * millisecDifFromLastRecord;
                for (int i = 0; i < buyOrdersSum.Length; i++)
                {
                    buyOrdersSum[i] += buyOrders[i] * millisecDifFromLastRecord;
                }
                for (int i = 0; i < sellOrdersSum.Length; i++)
                {
                    sellOrdersSum[i] += sellOrders[i] * millisecDifFromLastRecord;
                }
                recordFullTime += millisecDifFromLastRecord;
            }

        }
        private List<Interval> recorded = new List<Interval>();
        public void smoothAndSave(float courseSum, float[] buyOrdersSum, float[] sellOrdersSum)
        {
            float averageCourse = courseSum / settings.smoothInteval;
            for (int i = 0; i < buyOrdersSum.Length; i++)
            {
                buyOrdersSum[i] = buyOrdersSum[i] / settings.smoothInteval;
            }
            for (int i = 0; i < sellOrdersSum.Length; i++)
            {
                sellOrdersSum[i] = sellOrdersSum[i] / settings.smoothInteval;
            }
            Interval interval = new Interval(averageCourse, buyOrdersSum, sellOrdersSum);
            recorded.Add(interval);
            if (recorded.Count * settings.smoothInteval >= settings.saveInteval)
            {
                saveData();
            }
        }


        private float previousMillisec;
        private float CheckMillisecDif()//улучшение точности таймера
        {
            int now = DateTime.Now.Millisecond;
            float value = 0;
            if (previousMillisec > now)
            {
                value = ((1000 - previousMillisec) + now);
            }
            else
            {
                value = now - previousMillisec;
            }
            previousMillisec = DateTime.Now.Millisecond;
            return value / 1000;
        }

        private string folderName;

        private void InitFolderName()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), settings.dataSaveWay);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            datasetRecordDate = DateTime.Today;
            folderName = DateTime.Today.Day  + "." + DateTime.Today.Month + "." + DateTime.Today.Year + " " + DateTime.Now.Hour + "h" + DateTime.Now.Minute + "m";
            string newFolderPath = filePath + "\\" + folderName;
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }
        }
        private int recordingsInPack = 0;
        private List<float> averageCourses = new List<float>();
        public void saveData(bool final = false)
        {
            string packPath = Path.Combine(Directory.GetCurrentDirectory(), settings.dataSaveWay) + "\\" + folderName;

            string fullPath = Path.Combine(packPath, "M" + DateTime.Today.Month + "D" + DateTime.Today.Day + "H" + DateTime.Now.Hour
                + "M" + DateTime.Now.Minute + "per-" + (int)settings.saveInteval + ".txt");
            StreamWriter sw = File.CreateText(fullPath);
            //stats
            float average = getAverageCourse(recorded);
            averageCourses.Add(average);

            string recordStats = average.ToString();
            sw.WriteLine(recordStats);
            //intervals
            for (int i = 0; i < recorded.Count;i++)
            {
                Interval interval = recorded[i];
                string buyOrders = "";
                foreach (float order in interval.averageBuyOrders)
                {
                    buyOrders += " " + order;
                }

                string sellOrders = "";
                foreach (float order in interval.averageSellOrders)
                {
                    sellOrders += " " + order;
                }
                sw.WriteLine(interval.averageCourse + " B" + buyOrders + " S" + sellOrders);
            }
            sw.Close();
            recorded.Clear();

            if (final)
            {
                MakePackStatsFile(packPath);
            }
            else
            {
                recordingsInPack++;
            }
        }

        private void MakePackStatsFile(string packPath)
        {
            string fullPath = Path.Combine(packPath,  "packInfo.txt");
            StreamWriter sw = File.CreateText(fullPath);

            float min = float.MaxValue;
            float max = float.MinValue;
            float avg = 0;
            foreach(float crs in averageCourses)
            {
                if (crs < min) min = crs;
                if (crs > max) max = crs;
                avg += crs;
            }
            avg /= averageCourses.Count;

            sw.WriteLine(min + " " + max + " " + avg.ToString());
            sw.WriteLine(datasetRecordDate.ToString());
            sw.Close();
        }

        private float getAverageCourse(List<Interval> intervals)
        {
            float avg = 0;
            for (int i = 0; i < intervals.Count; i++)
            {
                avg += intervals[i].averageCourse;
            }
            avg /= intervals.Count;
            return avg;
        }

    }
}
