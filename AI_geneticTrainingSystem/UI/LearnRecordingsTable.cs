using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.AI_geneticTrainingSystem;
using System.Data;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.TrainingStatistics;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem.UI
{
    class LearnRecordingsTable
    {
        private GeneticTrainerSettingUpWindow window;
        private DataGridView dataGrid;

        private DataTable table;
        public LearnRecordingsTable(DataGridView dataGrid,GeneticTrainer trainer, GeneticTrainerSettingUpWindow window)
        {
            this.window = window;
            this.dataGrid = dataGrid;

            table = makeDefaultDatasetDataTable();
            dataGrid.DataSource = table;

            trainer.onLearnEnd += IterationFinished;
        }

        private DataTable makeDefaultDatasetDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Iteration", typeof(int));
            dt.Columns.Add("Test error", typeof(float));
            dt.Columns.Add("Guess percent", typeof(float));
            dt.Columns.Add("AI_params", typeof(string));
            dt.Columns.Add("Learn erorror", typeof(float));

            return dt;
        }

        private void IterationFinished(AI_LearningRecord record, int iteration)
        {

            object[] row = new object[] { iteration, record.finalError, record.finalGuessValue * 100, record.perceptron.ToString(), record.finalLearn_RunError };
            table.Rows.Add(row);

            window.BeginInvoke(new tableVisualUpdate(dataGrid.Update));
        }

        private delegate void tableVisualUpdate();
    }
}
