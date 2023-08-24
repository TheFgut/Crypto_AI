using CryptoAnalizerAI.AI_geneticTrainingSystem;
using CryptoAnalizerAI.AI_training.TrainingStatistics;
using System;
using System.Data;
using System.Windows.Forms;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_loading
{
    public partial class PerceptronLoadingWindow : Form
    {
        private LoadedStatMoveDelegate percTransfer;
        private TrainingIterationsSaverAndLoader loader;

        private DataTable table;
        public PerceptronLoadingWindow(LoadedStatMoveDelegate percTransfer)
        {
            this.percTransfer = percTransfer;
            InitializeComponent();

            table = makeDefaultDatasetDataTable();
            FieInspectorGrid.DataSource = table;

            loader = new TrainingIterationsSaverAndLoader();
            loadBut.Enabled = false;
            SwitchToChoosingDirectory();


        }


        private DataTable makeDefaultDatasetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("type", typeof(string));

            return dt;
        }

        private void AddRowToTable(int id, string name,string type, DataTable table)
        {
            table.Rows.Add(id,name,type);
        }


        public delegate void LoadedStatMoveDelegate(Perceptron perceptron);

        private void loadBut_Click(object sender, EventArgs e)
        {
            if(choosedPerceptron != null)
            {
                percTransfer?.Invoke(choosedPerceptron);
                Close();
            }
        }



        private bool choosingDirectory = true;
        private void FieInspectorGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int clickedIndex = e.RowIndex;
            if (choosingDirectory)
            {
                SwitchToChoosingStat(clickedIndex);
            }
            else
            {
                AI_LearningRecord record = loader.loadStat(clickedIndex);
                choosedRecording = record;
                LearnStatChoosed(record);
            }
        }

        private void SwitchToChoosingStat(int directoryID)
        {
            choosingDirectory = false;
            backBut.Enabled = true;

            string[] paths = loader.getChoosedDirStatsPaths(directoryID);

            table.Rows.Clear();
            for (int i = 0; i < paths.Length; i++)
            {
                string[] splitted = paths[i].Split("\\");
                string name = splitted[splitted.Length - 1];
                AddRowToTable(i, name.Split(".")[0], "stat file", table);
            }
        }

        private AI_LearningRecord choosedRecording;
        private Perceptron choosedPerceptron;
        private void LearnStatChoosed(AI_LearningRecord stat)
        {
            statsDisp.Text = "final error: " + stat.finalError + "\n";
            statsDisp.Text += "guess percent: " + (int)(stat.finalGuessValue * 100) + "%\n";
            choosedPerceptron = new Perceptron(stat.perceptronSaveFile);
            statsDisp.Text += choosedPerceptron.ToString();

            loadBut.Enabled = true;
        }

        private void SwitchToChoosingDirectory()
        {
            choosingDirectory = true;
            backBut.Enabled = false;
            loadBut.Enabled = false;

            string[] paths = loader.getAwailableStatsPacksPaths();

            table.Rows.Clear();
            for (int i = 0; i < paths.Length; i++)
            {
                string[] splitted = paths[i].Split("\\");
                string name = splitted[splitted.Length - 1];
                AddRowToTable(i, name, "directory", table);
            }
        }

        private void backBut_Click(object sender, EventArgs e)
        {
            SwitchToChoosingDirectory();
        }
    }
}
