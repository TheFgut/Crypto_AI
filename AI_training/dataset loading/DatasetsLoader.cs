using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_training;
using System.IO;
using System.Linq;
using CryptoAnalizerAI.AI_training.CustomDatasets;

namespace CryptoAnalizerAI.AI_training.dataset_loading
{
    static class DatasetsLoader
    {


        public static Dataset LoadDataset(string infoFileDPath, out int incorrectFiles, out int brokenFiles)
        {
            incorrectFiles = 0;
            brokenFiles = 0;

            //reading dataset info file
            DatasetInfo datasetInfo;

            getDatasetSettings(infoFileDPath, out datasetInfo);
            float average = datasetInfo.averageCourse;
            //getting all probably data files
            string directory = getDirectory(infoFileDPath);
            var filesPaths = Directory.GetFiles(directory).Where(file => !file.EndsWith("packInfo.txt"));

            List<string> rawData = new List<string>();

            List<Interval> contantIntervals = new List<Interval>();
            foreach (string filePath in filesPaths)
            {

                StreamReader reader = new StreamReader(filePath);

                string content = reader.ReadLine();
                //reading average data

                //reading all data
                while (!reader.EndOfStream) 
                {
                    
                    content = reader.ReadLine();
                    if (content == null)
                    {
                        break;
                    }
                    int errrorCode;
                    //6 6 is incorect. to do: normal dinamic choose
                    Interval interval = tryReadDataLine(content,6,6, out errrorCode);
                    if(errrorCode != 0)
                    {
                        brokenFiles++;
                        break;
                    }
                    contantIntervals.Add(interval);
                } 
            }

            return new Dataset(contantIntervals.ToArray(), average);
        }

        private static string getDirectory(string infoFileDPath)
        {
            string[] splitted = infoFileDPath.Split("\\");
            return infoFileDPath.Substring(0, infoFileDPath.Length - (splitted[splitted.Length - 1].Length + 1));
        }

        private static bool getDatasetSettings(string infoFilePath, out DatasetInfo datasetInfo)
        {
            string[] splitted = infoFilePath.Split('\\');
            string infoFileName = splitted[splitted.Length - 1];
            string infoFileDirectory = infoFilePath.Substring(0, infoFilePath.Length - (infoFileName.Length + 1));

            LoaderAndSaver<DatasetInfo> datasetInfoLoader = new LoaderAndSaver<DatasetInfo>(infoFileDirectory, infoFileName);

            try
            {
                datasetInfo = datasetInfoLoader.loadObject();
                return true;
            }
            catch
            {
                datasetInfo = null;

                return false;
            }

        }

        private static Interval tryReadDataLine(string data,int buyOrdersCount, int sellOrdersCount,out int errorCode)
        {
            float average = 0;
            float[] buyOrders = new float[buyOrdersCount];
            int bCOunter = 0;
            float[] sellOrders = new float[sellOrdersCount];
            int sCounter = 0;

            errorCode = 0;
            string[] splitted = data.Split(' ');
            int stage = 0;
            for (int i = 0; i < splitted.Length; i++)
            {
                try
                {
                    switch (stage)
                    {
                        //loocking for average
                        case 0:
                            average = Single.Parse(splitted[i]);
                            stage = 1;
                            i++;
                            break;
                        //loocking for buy orders
                        case 1:
                            if (splitted[i] == "S")
                            {
                                stage = 2;
                                continue;
                            }
                            buyOrders[bCOunter] = Single.Parse(splitted[i]);
                            bCOunter++;
                            break;
                        //loocking for sell orders
                        case 2:
                            sellOrders[sCounter] = Single.Parse(splitted[i]);
                            sCounter++;
                            break;
                    }
                }
                catch
                {
                    errorCode = 1; // incorrect value
                    return null;
                }
            }
   

            return new Interval(average, buyOrders, sellOrders);
        }


    }
}
