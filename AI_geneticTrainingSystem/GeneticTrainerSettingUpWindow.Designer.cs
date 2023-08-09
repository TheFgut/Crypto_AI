
namespace CryptoAnalizerAI.AI_geneticTrainingSystem
{
    partial class GeneticTrainerSettingUpWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TrainedAIDataGridView = new System.Windows.Forms.DataGridView();
            this.ChoosedTrainedAIViewInfoBox = new System.Windows.Forms.GroupBox();
            this.TrainingStartBut = new System.Windows.Forms.Button();
            this.TrainingStopBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrainedAIDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TrainedAIDataGridView
            // 
            this.TrainedAIDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrainedAIDataGridView.Location = new System.Drawing.Point(12, 12);
            this.TrainedAIDataGridView.Name = "TrainedAIDataGridView";
            this.TrainedAIDataGridView.RowTemplate.Height = 25;
            this.TrainedAIDataGridView.Size = new System.Drawing.Size(220, 426);
            this.TrainedAIDataGridView.TabIndex = 0;
            // 
            // ChoosedTrainedAIViewInfoBox
            // 
            this.ChoosedTrainedAIViewInfoBox.Location = new System.Drawing.Point(238, 12);
            this.ChoosedTrainedAIViewInfoBox.Name = "ChoosedTrainedAIViewInfoBox";
            this.ChoosedTrainedAIViewInfoBox.Size = new System.Drawing.Size(198, 131);
            this.ChoosedTrainedAIViewInfoBox.TabIndex = 1;
            this.ChoosedTrainedAIViewInfoBox.TabStop = false;
            this.ChoosedTrainedAIViewInfoBox.Text = "trained AI info";
            // 
            // TrainingStartBut
            // 
            this.TrainingStartBut.Location = new System.Drawing.Point(238, 414);
            this.TrainingStartBut.Name = "TrainingStartBut";
            this.TrainingStartBut.Size = new System.Drawing.Size(75, 23);
            this.TrainingStartBut.TabIndex = 2;
            this.TrainingStartBut.Text = "Start";
            this.TrainingStartBut.UseVisualStyleBackColor = true;
            // 
            // TrainingStopBut
            // 
            this.TrainingStopBut.Location = new System.Drawing.Point(361, 414);
            this.TrainingStopBut.Name = "TrainingStopBut";
            this.TrainingStopBut.Size = new System.Drawing.Size(75, 23);
            this.TrainingStopBut.TabIndex = 3;
            this.TrainingStopBut.Text = "Stop";
            this.TrainingStopBut.UseVisualStyleBackColor = true;
            // 
            // GeneticTrainerSettingUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TrainingStopBut);
            this.Controls.Add(this.TrainingStartBut);
            this.Controls.Add(this.ChoosedTrainedAIViewInfoBox);
            this.Controls.Add(this.TrainedAIDataGridView);
            this.Name = "GeneticTrainerSettingUpWindow";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.TrainedAIDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TrainedAIDataGridView;
        private System.Windows.Forms.GroupBox ChoosedTrainedAIViewInfoBox;
        private System.Windows.Forms.Button TrainingStartBut;
        private System.Windows.Forms.Button TrainingStopBut;
    }
}