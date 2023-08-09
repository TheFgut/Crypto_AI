using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.CustomDatasets;
using System.Data;
using CryptoAnalizerAI.AI_training.dataset_loading;


namespace CryptoAnalizerAI.AI_training.dataset_loading
{
    internal class DatasetsConfigureManager
    {
        private DataGridView loadedGrid;
        private DataGridView choosedGrid;

        private DataGridController[] loadedDataGrids;
        private DataGridController choosedDataGrid;

        private Button removeBUt;
        private Button setupBut;

        private DatasetManagerHandler datasetChanged;
        public DatasetsConfigureManager(Button removeBut, Button setupBut, DataGridView loadedGrid1,
            DataGridView loadedGrid2, DataGridView choosedGrid, DatasetManagerHandler datasetChanged)
        {
            this.loadedGrid = loadedGrid1;
            this.choosedGrid = choosedGrid;
            this.removeBUt = removeBut;
            this.setupBut = setupBut;
            this.datasetChanged = datasetChanged;

            loadedDataGrids = new DataGridController[2];


            if (loadedGrid1.DataSource == null)
            {
                DataTable dt = makeDefaultDatasetDataTable();
                loadedDataGrids[0] = new DataGridController(loadedGrid1, dt);
            }
            else
            {
                loadedDataGrids[0] = new DataGridController(loadedGrid1, (DataTable)loadedGrid1.DataSource);
            }

            if (loadedGrid2.DataSource == null)
            {
                DataTable dt1 = makeDefaultDatasetDataTable();
                loadedDataGrids[1] = new DataGridController(loadedGrid2, dt1);
            }
            else
            {
                loadedDataGrids[1] = new DataGridController(loadedGrid2, (DataTable)loadedGrid2.DataSource);
            }


            loadedGrid1.CellClick += ChooseDatasetGrid_CellClick;


            DataTable dt2 = makeDefaultDatasetDataTable();
            choosedDataGrid = new DataGridController(choosedGrid, dt2);

            choosedGrid.CellClick += ChoosedDatasetGrid_CellClick;

            removeBut.Click += DatasetRemoveButton_Click;
        }

        public void ShowLoadedDatasets(Dataset[] datasets)
        {
            loadedDataGrids[0].table.Clear();
            choosedDataGrid.table.Clear();
            choosedDatasets.Clear();

            DataTable loadedTable = loadedDataGrids[0].table;

            for (int i = 0; i < datasets.Length; i++)
            {
                loadedTable.Rows.Add(new object[] { DateTime.Parse("1/1/2016"), datasets[i].average, 0, 0, i });
            }

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

        public List<int> choosedDatasets { get; private set; } = new List<int>();
        private void ChooseDatasetGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int clickedIndex = e.RowIndex;
            if (clickedIndex < 0) return;
            int transferedDatasetID = loadedDataGrids[0].TransferRowTo(clickedIndex, choosedDataGrid);
            loadedDataGrids[1].RemoveRow(clickedIndex);
            choosedDatasets.Add(transferedDatasetID);
            //manager.SetChoosedDatasetsInts(choosedDatasets.ToArray());
            //datasetConfigurationChanged?.Invoke("+");

            datasetChanged?.Invoke("data choosed");
        }


        //choosed Dataset Editiong
        private int choosedID = -1;
        private int choosedRealID = 0;
        private void ChoosedDatasetGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            choosedID = e.RowIndex;
            setupBut.Enabled = true;
            removeBUt.Enabled = true;


            //choosedDatasetInfo.Text = "";
        }

        private void DatasetRemoveButton_Click(object sender, EventArgs e)
        {
            if (choosedID == -1) return;
            setupBut.Enabled = false;
            removeBUt.Enabled = false;

            int transferedDatasetID = choosedDataGrid.TransferRowTo(choosedID, loadedDataGrids[0]);
            loadedDataGrids[1].AddRow(choosedID, loadedDataGrids[0]);
            choosedDatasets.Remove(transferedDatasetID);
            //manager.SetChoosedDatasetsInts(choosedDatasets.ToArray());

            //choosedDatasetInfo.Text = "";
            choosedID = -1;
            datasetChanged?.Invoke("data choosed");
            //datasetConfigurationChanged?.Invoke("-");
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

            public void RemoveRow(int rowID)
            {
                DataRow row = table.Rows[rowID];
                table.Rows.Remove(row);
            }

            public void AddRow(int rowID, DataGridController resourse)
            {
                DataRow row = resourse.table.Rows[rowID];
                table.Rows.Add(row.ItemArray);

            }
        }
    }
}
