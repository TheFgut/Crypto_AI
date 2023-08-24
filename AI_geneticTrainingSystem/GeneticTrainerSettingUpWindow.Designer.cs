
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
            this.perceptronInfo = new System.Windows.Forms.GroupBox();
            this.updateNLabel = new System.Windows.Forms.Label();
            this.updateNumDisp = new System.Windows.Forms.TextBox();
            this.neuralInfoText = new System.Windows.Forms.RichTextBox();
            this.changeStructureCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TrainedAIDataGridView)).BeginInit();
            this.perceptronInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrainedAIDataGridView
            // 
            this.TrainedAIDataGridView.AllowUserToAddRows = false;
            this.TrainedAIDataGridView.AllowUserToDeleteRows = false;
            this.TrainedAIDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TrainedAIDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.TrainedAIDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrainedAIDataGridView.Location = new System.Drawing.Point(12, 12);
            this.TrainedAIDataGridView.Name = "TrainedAIDataGridView";
            this.TrainedAIDataGridView.RowHeadersWidth = 51;
            this.TrainedAIDataGridView.RowTemplate.Height = 25;
            this.TrainedAIDataGridView.Size = new System.Drawing.Size(898, 426);
            this.TrainedAIDataGridView.TabIndex = 0;
            // 
            // ChoosedTrainedAIViewInfoBox
            // 
            this.ChoosedTrainedAIViewInfoBox.Location = new System.Drawing.Point(916, 12);
            this.ChoosedTrainedAIViewInfoBox.Name = "ChoosedTrainedAIViewInfoBox";
            this.ChoosedTrainedAIViewInfoBox.Size = new System.Drawing.Size(198, 131);
            this.ChoosedTrainedAIViewInfoBox.TabIndex = 1;
            this.ChoosedTrainedAIViewInfoBox.TabStop = false;
            this.ChoosedTrainedAIViewInfoBox.Text = "trained AI info";
            // 
            // TrainingStartBut
            // 
            this.TrainingStartBut.Location = new System.Drawing.Point(916, 414);
            this.TrainingStartBut.Name = "TrainingStartBut";
            this.TrainingStartBut.Size = new System.Drawing.Size(75, 23);
            this.TrainingStartBut.TabIndex = 2;
            this.TrainingStartBut.Text = "Start";
            this.TrainingStartBut.UseVisualStyleBackColor = true;
            // 
            // TrainingStopBut
            // 
            this.TrainingStopBut.Location = new System.Drawing.Point(1039, 414);
            this.TrainingStopBut.Name = "TrainingStopBut";
            this.TrainingStopBut.Size = new System.Drawing.Size(75, 23);
            this.TrainingStopBut.TabIndex = 3;
            this.TrainingStopBut.Text = "Stop";
            this.TrainingStopBut.UseVisualStyleBackColor = true;
            // 
            // perceptronInfo
            // 
            this.perceptronInfo.Controls.Add(this.updateNLabel);
            this.perceptronInfo.Controls.Add(this.updateNumDisp);
            this.perceptronInfo.Controls.Add(this.neuralInfoText);
            this.perceptronInfo.Location = new System.Drawing.Point(916, 156);
            this.perceptronInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.perceptronInfo.Name = "perceptronInfo";
            this.perceptronInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.perceptronInfo.Size = new System.Drawing.Size(208, 205);
            this.perceptronInfo.TabIndex = 4;
            this.perceptronInfo.TabStop = false;
            this.perceptronInfo.Text = "neural info";
            // 
            // updateNLabel
            // 
            this.updateNLabel.AutoSize = true;
            this.updateNLabel.Location = new System.Drawing.Point(6, 22);
            this.updateNLabel.Name = "updateNLabel";
            this.updateNLabel.Size = new System.Drawing.Size(72, 15);
            this.updateNLabel.TabIndex = 2;
            this.updateNLabel.Text = "update num";
            // 
            // updateNumDisp
            // 
            this.updateNumDisp.Location = new System.Drawing.Point(88, 20);
            this.updateNumDisp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateNumDisp.Name = "updateNumDisp";
            this.updateNumDisp.ReadOnly = true;
            this.updateNumDisp.Size = new System.Drawing.Size(110, 23);
            this.updateNumDisp.TabIndex = 1;
            // 
            // neuralInfoText
            // 
            this.neuralInfoText.Location = new System.Drawing.Point(6, 53);
            this.neuralInfoText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.neuralInfoText.Name = "neuralInfoText";
            this.neuralInfoText.ReadOnly = true;
            this.neuralInfoText.Size = new System.Drawing.Size(192, 148);
            this.neuralInfoText.TabIndex = 0;
            this.neuralInfoText.Text = "";
            // 
            // changeStructureCheckBox
            // 
            this.changeStructureCheckBox.AutoSize = true;
            this.changeStructureCheckBox.Checked = true;
            this.changeStructureCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeStructureCheckBox.Location = new System.Drawing.Point(962, 366);
            this.changeStructureCheckBox.Name = "changeStructureCheckBox";
            this.changeStructureCheckBox.Size = new System.Drawing.Size(115, 19);
            this.changeStructureCheckBox.TabIndex = 5;
            this.changeStructureCheckBox.Text = "change structure";
            this.changeStructureCheckBox.UseVisualStyleBackColor = true;
            // 
            // GeneticTrainerSettingUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 450);
            this.Controls.Add(this.changeStructureCheckBox);
            this.Controls.Add(this.perceptronInfo);
            this.Controls.Add(this.TrainingStopBut);
            this.Controls.Add(this.TrainingStartBut);
            this.Controls.Add(this.ChoosedTrainedAIViewInfoBox);
            this.Controls.Add(this.TrainedAIDataGridView);
            this.Name = "GeneticTrainerSettingUpWindow";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.TrainedAIDataGridView)).EndInit();
            this.perceptronInfo.ResumeLayout(false);
            this.perceptronInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TrainedAIDataGridView;
        private System.Windows.Forms.GroupBox ChoosedTrainedAIViewInfoBox;
        private System.Windows.Forms.Button TrainingStartBut;
        private System.Windows.Forms.Button TrainingStopBut;
        private System.Windows.Forms.GroupBox perceptronInfo;
        private System.Windows.Forms.RichTextBox neuralInfoText;
        private System.Windows.Forms.Label updateNLabel;
        private System.Windows.Forms.TextBox updateNumDisp;
        private System.Windows.Forms.CheckBox changeStructureCheckBox;
    }
}