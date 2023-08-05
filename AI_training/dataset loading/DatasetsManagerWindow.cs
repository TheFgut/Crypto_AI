using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training;
using System.IO;

namespace CryptoAnalizerAI.AI_training.dataset_loading
{
    public partial class DatasetsManagerWindow : Form
    {
        private DataGridController loadedDataGrid;
        private DataGridController choosedDataGrid;
        public static List<int> choosedDatasets { get; private set; } = new List<int>();

        public event DatasetManagerHandler? datasetLoaded;
        public event DatasetManagerHandler? datasetConfigurationChanged;

        private DatasetManager manager;
        public DatasetsManagerWindow(DatasetManager manager)
        {
            this.manager = manager;

            InitializeComponent();
            DataTable dt = makeDefaultDatasetDataTable();
            loadedDataGrid = new DataGridController(ChooseDatasetGrid, dt);

            DataTable dt1 = makeDefaultDatasetDataTable();
            choosedDataGrid = new DataGridController(ChoosedDatasetGrid, dt1);



        }
        //loadingDefault path datasets
        public void LoadDatasetsFromDefaultPath()
        {
            LoadDatasetsFromPath(Path.Combine(Directory.GetCurrentDirectory(), "Datasets\\"));
        }

        private DataTable makeDefaultDatasetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Average", typeof(float));
            dt.Columns.Add("Min", typeof(float));
            dt.Columns.Add("Max", typeof(float));
            dt.Columns.Add("ID", typeof(int));

            return dt;
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

            manager.SetChoosedDatasetsInts(new int[0]);
            manager.SetDatasets(loadedDatasets.ToArray());


            choosedDatasets.Clear();
            ShowLoadedDatasets();


            datasetLoaded?.Invoke("ok");

        }

        private void ShowLoadedDatasets()
        {
            loadedDataGrid.table.Clear();
            choosedDataGrid.table.Clear();

            DataTable loadedTable = loadedDataGrid.table;

            for(int i = 0; i < manager.datasets.Length; i++)
            {
                loadedTable.Rows.Add(new object[] {DateTime.Parse("1/1/2016"), manager.datasets[i].average, 0,0, i});
            }

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

        private void ChooseDatasetGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int clickedIndex = e.RowIndex;
            if (clickedIndex < 0) return;
            int transferedDatasetID = loadedDataGrid.TransferRowTo(clickedIndex, choosedDataGrid);
            choosedDatasets.Add(transferedDatasetID);
            manager.SetChoosedDatasetsInts(choosedDatasets.ToArray());
            datasetConfigurationChanged?.Invoke("+");
        }



        //choosed Dataset Editiong
        private int choosedID = -1;
        private int choosedRealID = 0;
        private void ChoosedDatasetGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            choosedID = e.RowIndex;
            DatasetSetupButton.Enabled = true;
            DatasetRemoveButton.Enabled = true;


            choosedDatasetInfo.Text = "";
        }

        private List<DatasetSettingUp> setUpWindows = new List<DatasetSettingUp>();

        private void DatasetSetupButton_Click(object sender, EventArgs e)
        {
            if (choosedID == -1) return;
            


        }

        private void DatasetRemoveButton_Click(object sender, EventArgs e)
        {
            if (choosedID == -1) return;
            DatasetSetupButton.Enabled = false;
            DatasetRemoveButton.Enabled = false;

            int transferedDatasetID = choosedDataGrid.TransferRowTo(choosedID, loadedDataGrid);
            choosedDatasets.Remove(transferedDatasetID);
            manager.SetChoosedDatasetsInts(choosedDatasets.ToArray());

            choosedDatasetInfo.Text = "";
            choosedID = -1;
            datasetConfigurationChanged?.Invoke("-");
        }



        private class DataGridController
        {
            public DataTable table { get; private set; }
            public DataGridController(DataGridView view, DataTable table)
            {
                this.table = table;
                view.DataSource = table;
            }

            public int TransferRowTo(int rowID, DataGridController targetDataController)
            {

                DataRow row = table.Rows[rowID];
                int dataRealId = (int)row.ItemArray[row.ItemArray.Length - 1];


                DataTable table1 = targetDataController.table;
                table1.Rows.Add(row.ItemArray);
                table.Rows.Remove(row);
                return dataRealId;
            }
        }


    }
    //events
    public delegate void DatasetManagerHandler(string details);

}
