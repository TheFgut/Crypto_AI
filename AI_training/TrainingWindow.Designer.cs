
namespace CryptoAnalizerAI.AI_training
{
    partial class TrainingWindow
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
            this.loadDataBut = new System.Windows.Forms.Button();
            this.loadedDataDetailsText = new System.Windows.Forms.RichTextBox();
            this.learnPosGraphic = new System.Windows.Forms.PictureBox();
            this.AIprediction = new System.Windows.Forms.PictureBox();
            this.learningParamsGroupBox = new System.Windows.Forms.GroupBox();
            this.delayBetweenLearnsLabel = new System.Windows.Forms.Label();
            this.DelayBetweenLearnsBox = new System.Windows.Forms.TextBox();
            this.learningStepLabel = new System.Windows.Forms.Label();
            this.learningStepText = new System.Windows.Forms.TextBox();
            this.learningSpdLabel = new System.Windows.Forms.Label();
            this.learningSpeedText = new System.Windows.Forms.TextBox();
            this.currentDatasetNumLabel = new System.Windows.Forms.Label();
            this.datasetNumText = new System.Windows.Forms.TextBox();
            this.learningStatsGroupBox = new System.Windows.Forms.GroupBox();
            this.IterationNumDisplay = new System.Windows.Forms.TextBox();
            this.IterationNumLabel = new System.Windows.Forms.Label();
            this.PropagationNum = new System.Windows.Forms.Label();
            this.PropagationNumDiaplay = new System.Windows.Forms.TextBox();
            this.StartLearningButton = new System.Windows.Forms.Button();
            this.StopLearningButton = new System.Windows.Forms.Button();
            this.AI_autosaveGroupBox = new System.Windows.Forms.GroupBox();
            this.PerceptronConfigure = new System.Windows.Forms.Button();
            this.perceptronDetailsText = new System.Windows.Forms.RichTextBox();
            this.UpdateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PredictionGraphic = new System.Windows.Forms.PictureBox();
            this.averageErrorDisp = new System.Windows.Forms.TextBox();
            this.highestError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.learnPosGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AIprediction)).BeginInit();
            this.learningParamsGroupBox.SuspendLayout();
            this.learningStatsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PredictionGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // loadDataBut
            // 
            this.loadDataBut.Location = new System.Drawing.Point(675, 21);
            this.loadDataBut.Name = "loadDataBut";
            this.loadDataBut.Size = new System.Drawing.Size(113, 23);
            this.loadDataBut.TabIndex = 0;
            this.loadDataBut.Text = "load data";
            this.loadDataBut.UseVisualStyleBackColor = true;
            this.loadDataBut.Click += new System.EventHandler(this.loadDataBut_Click);
            // 
            // loadedDataDetailsText
            // 
            this.loadedDataDetailsText.Location = new System.Drawing.Point(675, 50);
            this.loadedDataDetailsText.Name = "loadedDataDetailsText";
            this.loadedDataDetailsText.Size = new System.Drawing.Size(113, 159);
            this.loadedDataDetailsText.TabIndex = 1;
            this.loadedDataDetailsText.Text = "no dataset loaded";
            // 
            // learnPosGraphic
            // 
            this.learnPosGraphic.Location = new System.Drawing.Point(263, 12);
            this.learnPosGraphic.Name = "learnPosGraphic";
            this.learnPosGraphic.Size = new System.Drawing.Size(406, 149);
            this.learnPosGraphic.TabIndex = 2;
            this.learnPosGraphic.TabStop = false;
            // 
            // AIprediction
            // 
            this.AIprediction.Location = new System.Drawing.Point(263, 167);
            this.AIprediction.Name = "AIprediction";
            this.AIprediction.Size = new System.Drawing.Size(406, 42);
            this.AIprediction.TabIndex = 3;
            this.AIprediction.TabStop = false;
            // 
            // learningParamsGroupBox
            // 
            this.learningParamsGroupBox.Controls.Add(this.delayBetweenLearnsLabel);
            this.learningParamsGroupBox.Controls.Add(this.DelayBetweenLearnsBox);
            this.learningParamsGroupBox.Controls.Add(this.learningStepLabel);
            this.learningParamsGroupBox.Controls.Add(this.learningStepText);
            this.learningParamsGroupBox.Controls.Add(this.learningSpdLabel);
            this.learningParamsGroupBox.Controls.Add(this.learningSpeedText);
            this.learningParamsGroupBox.Location = new System.Drawing.Point(12, 247);
            this.learningParamsGroupBox.Name = "learningParamsGroupBox";
            this.learningParamsGroupBox.Size = new System.Drawing.Size(188, 142);
            this.learningParamsGroupBox.TabIndex = 5;
            this.learningParamsGroupBox.TabStop = false;
            this.learningParamsGroupBox.Text = "learning settings";
            // 
            // delayBetweenLearnsLabel
            // 
            this.delayBetweenLearnsLabel.AutoSize = true;
            this.delayBetweenLearnsLabel.Location = new System.Drawing.Point(8, 97);
            this.delayBetweenLearnsLabel.Name = "delayBetweenLearnsLabel";
            this.delayBetweenLearnsLabel.Size = new System.Drawing.Size(35, 15);
            this.delayBetweenLearnsLabel.TabIndex = 5;
            this.delayBetweenLearnsLabel.Text = "delay";
            // 
            // DelayBetweenLearnsBox
            // 
            this.DelayBetweenLearnsBox.Location = new System.Drawing.Point(98, 94);
            this.DelayBetweenLearnsBox.Name = "DelayBetweenLearnsBox";
            this.DelayBetweenLearnsBox.Size = new System.Drawing.Size(84, 23);
            this.DelayBetweenLearnsBox.TabIndex = 4;
            // 
            // learningStepLabel
            // 
            this.learningStepLabel.AutoSize = true;
            this.learningStepLabel.Location = new System.Drawing.Point(8, 68);
            this.learningStepLabel.Name = "learningStepLabel";
            this.learningStepLabel.Size = new System.Drawing.Size(75, 15);
            this.learningStepLabel.TabIndex = 3;
            this.learningStepLabel.Text = "learning step";
            // 
            // learningStepText
            // 
            this.learningStepText.Location = new System.Drawing.Point(98, 65);
            this.learningStepText.Name = "learningStepText";
            this.learningStepText.Size = new System.Drawing.Size(84, 23);
            this.learningStepText.TabIndex = 2;
            // 
            // learningSpdLabel
            // 
            this.learningSpdLabel.AutoSize = true;
            this.learningSpdLabel.Location = new System.Drawing.Point(8, 38);
            this.learningSpdLabel.Name = "learningSpdLabel";
            this.learningSpdLabel.Size = new System.Drawing.Size(84, 15);
            this.learningSpdLabel.TabIndex = 1;
            this.learningSpdLabel.Text = "learning speed";
            // 
            // learningSpeedText
            // 
            this.learningSpeedText.Location = new System.Drawing.Point(98, 35);
            this.learningSpeedText.MaxLength = 30;
            this.learningSpeedText.Name = "learningSpeedText";
            this.learningSpeedText.Size = new System.Drawing.Size(84, 23);
            this.learningSpeedText.TabIndex = 0;
            // 
            // currentDatasetNumLabel
            // 
            this.currentDatasetNumLabel.AutoSize = true;
            this.currentDatasetNumLabel.Location = new System.Drawing.Point(675, 219);
            this.currentDatasetNumLabel.Name = "currentDatasetNumLabel";
            this.currentDatasetNumLabel.Size = new System.Drawing.Size(73, 15);
            this.currentDatasetNumLabel.TabIndex = 6;
            this.currentDatasetNumLabel.Text = "dataset num";
            // 
            // datasetNumText
            // 
            this.datasetNumText.Location = new System.Drawing.Point(749, 216);
            this.datasetNumText.Name = "datasetNumText";
            this.datasetNumText.Size = new System.Drawing.Size(39, 23);
            this.datasetNumText.TabIndex = 7;
            // 
            // learningStatsGroupBox
            // 
            this.learningStatsGroupBox.Controls.Add(this.IterationNumDisplay);
            this.learningStatsGroupBox.Controls.Add(this.IterationNumLabel);
            this.learningStatsGroupBox.Controls.Add(this.PropagationNum);
            this.learningStatsGroupBox.Controls.Add(this.PropagationNumDiaplay);
            this.learningStatsGroupBox.Location = new System.Drawing.Point(206, 247);
            this.learningStatsGroupBox.Name = "learningStatsGroupBox";
            this.learningStatsGroupBox.Size = new System.Drawing.Size(247, 142);
            this.learningStatsGroupBox.TabIndex = 8;
            this.learningStatsGroupBox.TabStop = false;
            this.learningStatsGroupBox.Text = "learning stats";
            // 
            // IterationNumDisplay
            // 
            this.IterationNumDisplay.Location = new System.Drawing.Point(57, 53);
            this.IterationNumDisplay.Name = "IterationNumDisplay";
            this.IterationNumDisplay.ReadOnly = true;
            this.IterationNumDisplay.Size = new System.Drawing.Size(90, 23);
            this.IterationNumDisplay.TabIndex = 3;
            // 
            // IterationNumLabel
            // 
            this.IterationNumLabel.AutoSize = true;
            this.IterationNumLabel.Location = new System.Drawing.Point(7, 56);
            this.IterationNumLabel.Name = "IterationNumLabel";
            this.IterationNumLabel.Size = new System.Drawing.Size(40, 15);
            this.IterationNumLabel.TabIndex = 2;
            this.IterationNumLabel.Text = "I.Num";
            // 
            // PropagationNum
            // 
            this.PropagationNum.AutoSize = true;
            this.PropagationNum.Location = new System.Drawing.Point(7, 29);
            this.PropagationNum.Name = "PropagationNum";
            this.PropagationNum.Size = new System.Drawing.Size(44, 15);
            this.PropagationNum.TabIndex = 1;
            this.PropagationNum.Text = "P.Num";
            // 
            // PropagationNumDiaplay
            // 
            this.PropagationNumDiaplay.Location = new System.Drawing.Point(57, 26);
            this.PropagationNumDiaplay.Name = "PropagationNumDiaplay";
            this.PropagationNumDiaplay.ReadOnly = true;
            this.PropagationNumDiaplay.Size = new System.Drawing.Size(90, 23);
            this.PropagationNumDiaplay.TabIndex = 0;
            // 
            // StartLearningButton
            // 
            this.StartLearningButton.BackColor = System.Drawing.Color.PaleGreen;
            this.StartLearningButton.Location = new System.Drawing.Point(12, 415);
            this.StartLearningButton.Name = "StartLearningButton";
            this.StartLearningButton.Size = new System.Drawing.Size(75, 23);
            this.StartLearningButton.TabIndex = 9;
            this.StartLearningButton.Text = "Start";
            this.StartLearningButton.UseVisualStyleBackColor = false;
            // 
            // StopLearningButton
            // 
            this.StopLearningButton.Location = new System.Drawing.Point(206, 415);
            this.StopLearningButton.Name = "StopLearningButton";
            this.StopLearningButton.Size = new System.Drawing.Size(75, 23);
            this.StopLearningButton.TabIndex = 10;
            this.StopLearningButton.Text = "Stop";
            this.StopLearningButton.UseVisualStyleBackColor = true;
            // 
            // AI_autosaveGroupBox
            // 
            this.AI_autosaveGroupBox.Location = new System.Drawing.Point(469, 247);
            this.AI_autosaveGroupBox.Name = "AI_autosaveGroupBox";
            this.AI_autosaveGroupBox.Size = new System.Drawing.Size(137, 142);
            this.AI_autosaveGroupBox.TabIndex = 11;
            this.AI_autosaveGroupBox.TabStop = false;
            this.AI_autosaveGroupBox.Text = "AI autosave";
            // 
            // PerceptronConfigure
            // 
            this.PerceptronConfigure.Location = new System.Drawing.Point(675, 395);
            this.PerceptronConfigure.Name = "PerceptronConfigure";
            this.PerceptronConfigure.Size = new System.Drawing.Size(113, 23);
            this.PerceptronConfigure.TabIndex = 12;
            this.PerceptronConfigure.Text = "Configure";
            this.PerceptronConfigure.UseVisualStyleBackColor = true;
            this.PerceptronConfigure.Click += new System.EventHandler(this.PerceptronConfigure_Click);
            // 
            // perceptronDetailsText
            // 
            this.perceptronDetailsText.Location = new System.Drawing.Point(675, 257);
            this.perceptronDetailsText.Name = "perceptronDetailsText";
            this.perceptronDetailsText.Size = new System.Drawing.Size(113, 132);
            this.perceptronDetailsText.TabIndex = 13;
            this.perceptronDetailsText.Text = "no perceptron loaded";
            // 
            // UpdateBackgroundWorker
            // 
            this.UpdateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateBackgroundWorker_DoWork);
            // 
            // PredictionGraphic
            // 
            this.PredictionGraphic.Location = new System.Drawing.Point(12, 12);
            this.PredictionGraphic.Name = "PredictionGraphic";
            this.PredictionGraphic.Size = new System.Drawing.Size(241, 149);
            this.PredictionGraphic.TabIndex = 14;
            this.PredictionGraphic.TabStop = false;
            // 
            // averageErrorDisp
            // 
            this.averageErrorDisp.Location = new System.Drawing.Point(12, 167);
            this.averageErrorDisp.Name = "averageErrorDisp";
            this.averageErrorDisp.ReadOnly = true;
            this.averageErrorDisp.Size = new System.Drawing.Size(114, 23);
            this.averageErrorDisp.TabIndex = 15;
            // 
            // highestError
            // 
            this.highestError.Location = new System.Drawing.Point(132, 167);
            this.highestError.Name = "highestError";
            this.highestError.ReadOnly = true;
            this.highestError.Size = new System.Drawing.Size(121, 23);
            this.highestError.TabIndex = 16;
            // 
            // TrainingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.highestError);
            this.Controls.Add(this.averageErrorDisp);
            this.Controls.Add(this.PredictionGraphic);
            this.Controls.Add(this.perceptronDetailsText);
            this.Controls.Add(this.PerceptronConfigure);
            this.Controls.Add(this.AI_autosaveGroupBox);
            this.Controls.Add(this.StopLearningButton);
            this.Controls.Add(this.StartLearningButton);
            this.Controls.Add(this.learningStatsGroupBox);
            this.Controls.Add(this.datasetNumText);
            this.Controls.Add(this.currentDatasetNumLabel);
            this.Controls.Add(this.learningParamsGroupBox);
            this.Controls.Add(this.AIprediction);
            this.Controls.Add(this.learnPosGraphic);
            this.Controls.Add(this.loadedDataDetailsText);
            this.Controls.Add(this.loadDataBut);
            this.Name = "TrainingWindow";
            this.Text = "TrainingWindow";
            this.Load += new System.EventHandler(this.TrainingWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.learnPosGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AIprediction)).EndInit();
            this.learningParamsGroupBox.ResumeLayout(false);
            this.learningParamsGroupBox.PerformLayout();
            this.learningStatsGroupBox.ResumeLayout(false);
            this.learningStatsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PredictionGraphic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadDataBut;
        private System.Windows.Forms.RichTextBox loadedDataDetailsText;
        private System.Windows.Forms.PictureBox learnPosGraphic;
        private System.Windows.Forms.PictureBox AIprediction;
        private System.Windows.Forms.GroupBox learningParamsGroupBox;
        private System.Windows.Forms.Label learningStepLabel;
        private System.Windows.Forms.TextBox learningStepText;
        private System.Windows.Forms.Label learningSpdLabel;
        private System.Windows.Forms.TextBox learningSpeedText;
        private System.Windows.Forms.Label currentDatasetNumLabel;
        private System.Windows.Forms.TextBox datasetNumText;
        private System.Windows.Forms.GroupBox learningStatsGroupBox;
        private System.Windows.Forms.Button StartLearningButton;
        private System.Windows.Forms.Button StopLearningButton;
        private System.Windows.Forms.Label IterationNumLabel;
        private System.Windows.Forms.Label PropagationNum;
        private System.Windows.Forms.TextBox PropagationNumDiaplay;
        private System.Windows.Forms.TextBox IterationNumDisplay;
        private System.Windows.Forms.GroupBox AI_autosaveGroupBox;
        private System.Windows.Forms.Button PerceptronConfigure;
        private System.Windows.Forms.RichTextBox perceptronDetailsText;
        private System.ComponentModel.BackgroundWorker UpdateBackgroundWorker;
        private System.Windows.Forms.Label delayBetweenLearnsLabel;
        private System.Windows.Forms.TextBox DelayBetweenLearnsBox;
        private System.Windows.Forms.PictureBox PredictionGraphic;
        private System.Windows.Forms.TextBox averageErrorDisp;
        private System.Windows.Forms.TextBox highestError;
    }
}