using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training;
using System.IO;
using CryptoAnalizerAI.AI_training.CustomDatasets;

namespace CryptoAnalizerAI.AI_training.dataset_loading
{
    public partial class DatasetsManagerWindow : Form
    {

        public List<int> choosedDatasets
        {
            get
            {
                if (checkM) return testDatasetsConfigureManager.choosedDatasets;
                return learnDatasetsConfigureManager.choosedDatasets;
            }
        }
        private bool checkM = false;
        public bool checkMode {
            get
            {
                return checkM;
            }
            set
            {
                //datasetConfigurationChanged?.Invoke("mode changed");
                checkM = value;
            }
        }

        public event DatasetManagerHandler? datasetLoaded;
        public event DatasetManagerHandler? datasetConfigurationChanged;

        private DatasetManager manager;
        private DatasetsConfigureManager learnDatasetsConfigureManager;
        private DatasetsConfigureManager testDatasetsConfigureManager;
        public DatasetsManagerWindow(DatasetManager manager)
        {
            this.manager = manager;

            InitializeComponent();
            learnDatasetsConfigureManager = new DatasetsConfigureManager(LearnDatasetRemoveButton, LearnDatasetSetupButton,
                ChooseLearnDatasetGrid, ChooseCheckDatasetGrid, ChoosedLearnDatasetGrid, dataChoosed);

            testDatasetsConfigureManager = new DatasetsConfigureManager(TestDatasetRemoveButton, testDatasetSetupButton,
                ChooseCheckDatasetGrid, ChooseLearnDatasetGrid, ChoosedCheckDatasetGrid, dataChoosed);

        }

        private void dataChoosed(string data)
        {
            datasetConfigurationChanged?.Invoke("");
            manager.SetChoosedDatasetsInts(learnDatasetsConfigureManager.choosedDatasets.ToArray(), 
                testDatasetsConfigureManager.choosedDatasets.ToArray());
        }

        //loadingDefault path datasets
        public void LoadDatasetsFromDefaultPath()
        {
            LoadDatasetsFromPath(Path.Combine(Directory.GetCurrentDirectory(), "Datasets\\"));
        }

        //choosing and checking directory
        private void chooseDatasetsDirectory_Click(object sender, EventArgs e)
        {
            
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                string path = fbd.SelectedPath;

                if (result == DialogResult.OK)
                {
                    LoadDatasetsFromPath(path);
                } 
            }
        }

        private void LoadDatasetsFromPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return;

            string[] settingsFiles = GetDatasetsInfoFilesDirectories(path);
            if (settingsFiles.Length == 0) return;
            List<Dataset> loadedDatasets = new List<Dataset>();


            choosedDirectoryDispPath.Text = path;

            int incorrectSum = 0;
            int brokenSum = 0;
            foreach (string settingFilesPath in settingsFiles)
            {
                int incorrect;
                int broken;

                Dataset loaded = DatasetsLoader.LoadDataset(settingFilesPath, out incorrect, out broken);
                if (loaded != null)
                {
                    loadedDatasets.Add(loaded);
                }


                incorrectSum += incorrect;
                brokenSum += broken;
            }

            int errors = (incorrectSum + brokenSum);
            if (errors != 0)
            {
                MessageBox.Show("Datasets found: " + settingsFiles.Length.ToString() + '\n' +
                    "Datasets loaded: " + loadedDatasets.Count + '\n' + "Errors: " + errors.ToString(), "Message");
            }

            manager.SetChoosedDatasetsInts(new int[0], new int[0]);
            manager.SetDatasets(loadedDatasets.ToArray());


            ShowLoadedDatasets();


            datasetLoaded?.Invoke("ok");

        }

        private void ShowLoadedDatasets()
        {
            Dataset[] datasets = manager.datasets;
            learnDatasetsConfigureManager.ShowLoadedDatasets(datasets);
            testDatasetsConfigureManager.ShowLoadedDatasets(datasets);
        }

        private string[] GetDatasetsInfoFilesDirectories(string path)
        {
            List<string> settingFilesList = new List<string>();
            string[] allFiles = Directory.GetFiles(path,"*",SearchOption.AllDirectories);
            foreach (string currentFileP in allFiles)
            {
                string[] splittedPath = currentFileP.Split("\\");
                if (splittedPath[splittedPath.Length - 1] == "packInfo.txt")
                {
                    settingFilesList.Add(currentFileP);
                }
            }

            return settingFilesList.ToArray();
        }


        //configuration Changed


    }
    //events
    public delegate void DatasetManagerHandler(string details);

}
