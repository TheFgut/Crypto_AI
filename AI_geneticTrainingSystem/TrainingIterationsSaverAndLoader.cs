using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CryptoAnalizerAI.AI_training.TrainingStatistics;
using CryptoAnalizerAI.Main;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    class TrainingIterationsSaverAndLoader
    {
        private string saveDirPath = null;
        private string mainDirectoryPath;

        private const string statFileExtension = ".LStat";
        public TrainingIterationsSaverAndLoader()
        {
            mainDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), Constatns.ConstantStrings.Destinations.TrainingStatsDirectory);


        }

        private void makeSaveDirPath()
        {
            DateTime now = DateTime.Now;
            saveDirPath = Path.Combine(mainDirectoryPath, "D" + now.Day + "M" + now.Month + "Y" + now.Year + "_H" + now.Hour + "M" + now.Minute + "S" + now.Second);
            Directory.CreateDirectory(saveDirPath);
        }

        public void Save(AI_LearningRecord record, int iterationNum)
        {
            if (saveDirPath == "" || saveDirPath == null) makeSaveDirPath();
            string filename = iterationNum.ToString() + " " + (int)(record.finalGuessValue * 100) + "% " + record.finalError + statFileExtension;
            LoaderAndSaver<AI_LearningRecord> recordingSaver = new LoaderAndSaver<AI_LearningRecord>(saveDirPath, filename);

            recordingSaver.Save(record);
        }

        //Loading
        //directories
        string[] directories;
        public string[] getAwailableStatsPacksPaths()
        {
            updateTrainingDirectoriesArr();
            return directories;
        }

        private void updateTrainingDirectoriesArr()
        {
            directories = Directory.GetDirectories(mainDirectoryPath, "D*", SearchOption.TopDirectoryOnly);
        }
        //stats
        private string[] stats;
        private string choosedDir;
        public string[] getChoosedDirStatsPaths(int num)
        {
            choosedDir = directories[num];
            stats = Directory.GetFiles(choosedDir, "*", SearchOption.TopDirectoryOnly);
            return stats;
        }

        public AI_LearningRecord loadStat(int num)
        {

            string[] splitted = stats[num].Split("\\");
            string name = splitted[splitted.Length - 1];

            LoaderAndSaver<AI_LearningRecord> recordingSaver = new LoaderAndSaver<AI_LearningRecord>(choosedDir, name);
            return recordingSaver.loadObject();
        }
    }
}
