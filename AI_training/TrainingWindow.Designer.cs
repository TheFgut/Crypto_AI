
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
            this.WeightCorrectIterLAbel = new System.Windows.Forms.Label();
            this.WeigthSignCorrectionTextBox = new System.Windows.Forms.TextBox();
            this.CheckRunCheckBox = new System.Windows.Forms.CheckBox();
            this.learningRunsLabel = new System.Windows.Forms.Label();
            this.learningRunsTextBox = new System.Windows.Forms.TextBox();
            this.delayBetweenLearnsLabel = new System.Windows.Forms.Label();
            this.DelayBetweenLearnsBox = new System.Windows.Forms.TextBox();
            this.learningStepLabel = new System.Windows.Forms.Label();
            this.learningStepText = new System.Windows.Forms.TextBox();
            this.learningSpdLabel = new System.Windows.Forms.Label();
            this.learningSpeedText = new System.Windows.Forms.TextBox();
            this.currentDatasetNumLabel = new System.Windows.Forms.Label();
            this.datasetNumText = new System.Windows.Forms.TextBox();
            this.learningStatsGroupBox = new System.Windows.Forms.GroupBox();
            this.WalkNumDisplay = new System.Windows.Forms.TextBox();
            this.IterationNumLabel = new System.Windows.Forms.Label();
            this.PropagationNum = new System.Windows.Forms.Label();
            this.DatasetNumDiaplay = new System.Windows.Forms.TextBox();
            this.StartLearningButton = new System.Windows.Forms.Button();
            this.StopLearningButton = new System.Windows.Forms.Button();
            this.AI_learning_stopsGroup = new System.Windows.Forms.GroupBox();
            this.errorDontChangeCounterTextBox = new System.Windows.Forms.TextBox();
            this.countToStopTresholdTextBox = new System.Windows.Forms.TextBox();
            this.errorDontChangeTresholdTextBox = new System.Windows.Forms.TextBox();
            this.PerceptronConfigure = new System.Windows.Forms.Button();
            this.perceptronDetailsText = new System.Windows.Forms.RichTextBox();
            this.UpdateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PredictionGraphic = new System.Windows.Forms.PictureBox();
            this.averageErrorDisp = new System.Windows.Forms.TextBox();
            this.highestError = new System.Windows.Forms.TextBox();
            this.AutomaticTrainingBut = new System.Windows.Forms.Button();
            this.datasetParamsGroupBox = new System.Windows.Forms.GroupBox();
            this.ApplyCompressionBut = new System.Windows.Forms.Button();
            this.compressionLabel = new System.Windows.Forms.Label();
            this.compressionValueTextBox = new System.Windows.Forms.TextBox();
            this.learningSpeedSetupBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.learnPosGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AIprediction)).BeginInit();
            this.learningParamsGroupBox.SuspendLayout();
            this.learningStatsGroupBox.SuspendLayout();
            this.AI_learning_stopsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PredictionGraphic)).BeginInit();
            this.datasetParamsGroupBox.SuspendLayout();
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
            this.learningParamsGroupBox.Controls.Add(this.learningSpeedSetupBut);
            this.learningParamsGroupBox.Controls.Add(this.WeightCorrectIterLAbel);
            this.learningParamsGroupBox.Controls.Add(this.WeigthSignCorrectionTextBox);
            this.learningParamsGroupBox.Controls.Add(this.CheckRunCheckBox);
            this.learningParamsGroupBox.Controls.Add(this.learningRunsLabel);
            this.learningParamsGroupBox.Controls.Add(this.learningRunsTextBox);
            this.learningParamsGroupBox.Controls.Add(this.delayBetweenLearnsLabel);
            this.learningParamsGroupBox.Controls.Add(this.DelayBetweenLearnsBox);
            this.learningParamsGroupBox.Controls.Add(this.learningStepLabel);
            this.learningParamsGroupBox.Controls.Add(this.learningStepText);
            this.learningParamsGroupBox.Controls.Add(this.learningSpdLabel);
            this.learningParamsGroupBox.Controls.Add(this.learningSpeedText);
            this.learningParamsGroupBox.Location = new System.Drawing.Point(12, 247);
            this.learningParamsGroupBox.Name = "learningParamsGroupBox";
            this.learningParamsGroupBox.Size = new System.Drawing.Size(188, 210);
            this.learningParamsGroupBox.TabIndex = 5;
            this.learningParamsGroupBox.TabStop = false;
            this.learningParamsGroupBox.Text = "learning settings";
            // 
            // WeightCorrectIterLAbel
            // 
            this.WeightCorrectIterLAbel.AutoSize = true;
            this.WeightCorrectIterLAbel.Location = new System.Drawing.Point(8, 156);
            this.WeightCorrectIterLAbel.Name = "WeightCorrectIterLAbel";
            this.WeightCorrectIterLAbel.Size = new System.Drawing.Size(91, 15);
            this.WeightCorrectIterLAbel.TabIndex = 10;
            this.WeightCorrectIterLAbel.Text = "weigth sign cor.";
            // 
            // WeigthSignCorrectionTextBox
            // 
            this.WeigthSignCorrectionTextBox.Location = new System.Drawing.Point(105, 152);
            this.WeigthSignCorrectionTextBox.Name = "WeigthSignCorrectionTextBox";
            this.WeigthSignCorrectionTextBox.Size = new System.Drawing.Size(77, 23);
            this.WeigthSignCorrectionTextBox.TabIndex = 9;
            // 
            // CheckRunCheckBox
            // 
            this.CheckRunCheckBox.AutoSize = true;
            this.CheckRunCheckBox.Location = new System.Drawing.Point(47, 185);
            this.CheckRunCheckBox.Name = "CheckRunCheckBox";
            this.CheckRunCheckBox.Size = new System.Drawing.Size(100, 19);
            this.CheckRunCheckBox.TabIndex = 8;
            this.CheckRunCheckBox.Text = "only checking";
            this.CheckRunCheckBox.UseVisualStyleBackColor = true;
            // 
            // learningRunsLabel
            // 
            this.learningRunsLabel.AutoSize = true;
            this.learningRunsLabel.Location = new System.Drawing.Point(8, 126);
            this.learningRunsLabel.Name = "learningRunsLabel";
            this.learningRunsLabel.Size = new System.Drawing.Size(76, 15);
            this.learningRunsLabel.TabIndex = 7;
            this.learningRunsLabel.Text = "learning runs";
            // 
            // learningRunsTextBox
            // 
            this.learningRunsTextBox.Location = new System.Drawing.Point(105, 123);
            this.learningRunsTextBox.Name = "learningRunsTextBox";
            this.learningRunsTextBox.Size = new System.Drawing.Size(77, 23);
            this.learningRunsTextBox.TabIndex = 6;
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
            this.DelayBetweenLearnsBox.Location = new System.Drawing.Point(105, 94);
            this.DelayBetweenLearnsBox.Name = "DelayBetweenLearnsBox";
            this.DelayBetweenLearnsBox.Size = new System.Drawing.Size(77, 23);
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
            this.learningStepText.Location = new System.Drawing.Point(105, 65);
            this.learningStepText.Name = "learningStepText";
            this.learningStepText.Size = new System.Drawing.Size(77, 23);
            this.learningStepText.TabIndex = 2;
            // 
            // learningSpdLabel
            // 
            this.learningSpdLabel.AutoSize = true;
            this.learningSpdLabel.Location = new System.Drawing.Point(8, 43);
            this.learningSpdLabel.Name = "learningSpdLabel";
            this.learningSpdLabel.Size = new System.Drawing.Size(84, 15);
            this.learningSpdLabel.TabIndex = 1;
            this.learningSpdLabel.Text = "learning speed";
            // 
            // learningSpeedText
            // 
            this.learningSpeedText.Location = new System.Drawing.Point(105, 35);
            this.learningSpeedText.MaxLength = 30;
            this.learningSpeedText.Name = "learningSpeedText";
            this.learningSpeedText.ReadOnly = true;
            this.learningSpeedText.Size = new System.Drawing.Size(53, 23);
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
            this.learningStatsGroupBox.Controls.Add(this.WalkNumDisplay);
            this.learningStatsGroupBox.Controls.Add(this.IterationNumLabel);
            this.learningStatsGroupBox.Controls.Add(this.PropagationNum);
            this.learningStatsGroupBox.Controls.Add(this.DatasetNumDiaplay);
            this.learningStatsGroupBox.Location = new System.Drawing.Point(206, 247);
            this.learningStatsGroupBox.Name = "learningStatsGroupBox";
            this.learningStatsGroupBox.Size = new System.Drawing.Size(157, 83);
            this.learningStatsGroupBox.TabIndex = 8;
            this.learningStatsGroupBox.TabStop = false;
            this.learningStatsGroupBox.Text = "learning stats";
            // 
            // WalkNumDisplay
            // 
            this.WalkNumDisplay.Location = new System.Drawing.Point(57, 53);
            this.WalkNumDisplay.Name = "WalkNumDisplay";
            this.WalkNumDisplay.ReadOnly = true;
            this.WalkNumDisplay.Size = new System.Drawing.Size(90, 23);
            this.WalkNumDisplay.TabIndex = 3;
            // 
            // IterationNumLabel
            // 
            this.IterationNumLabel.AutoSize = true;
            this.IterationNumLabel.Location = new System.Drawing.Point(7, 56);
            this.IterationNumLabel.Name = "IterationNumLabel";
            this.IterationNumLabel.Size = new System.Drawing.Size(26, 15);
            this.IterationNumLabel.TabIndex = 2;
            this.IterationNumLabel.Text = "Pos";
            // 
            // PropagationNum
            // 
            this.PropagationNum.AutoSize = true;
            this.PropagationNum.Location = new System.Drawing.Point(7, 29);
            this.PropagationNum.Name = "PropagationNum";
            this.PropagationNum.Size = new System.Drawing.Size(28, 15);
            this.PropagationNum.TabIndex = 1;
            this.PropagationNum.Text = "Run";
            // 
            // DatasetNumDiaplay
            // 
            this.DatasetNumDiaplay.Location = new System.Drawing.Point(57, 26);
            this.DatasetNumDiaplay.Name = "DatasetNumDiaplay";
            this.DatasetNumDiaplay.ReadOnly = true;
            this.DatasetNumDiaplay.Size = new System.Drawing.Size(90, 23);
            this.DatasetNumDiaplay.TabIndex = 0;
            // 
            // StartLearningButton
            // 
            this.StartLearningButton.BackColor = System.Drawing.Color.PaleGreen;
            this.StartLearningButton.Location = new System.Drawing.Point(12, 463);
            this.StartLearningButton.Name = "StartLearningButton";
            this.StartLearningButton.Size = new System.Drawing.Size(75, 23);
            this.StartLearningButton.TabIndex = 9;
            this.StartLearningButton.Text = "Start";
            this.StartLearningButton.UseVisualStyleBackColor = false;
            // 
            // StopLearningButton
            // 
            this.StopLearningButton.Location = new System.Drawing.Point(206, 463);
            this.StopLearningButton.Name = "StopLearningButton";
            this.StopLearningButton.Size = new System.Drawing.Size(75, 23);
            this.StopLearningButton.TabIndex = 10;
            this.StopLearningButton.Text = "Stop";
            this.StopLearningButton.UseVisualStyleBackColor = true;
            // 
            // AI_learning_stopsGroup
            // 
            this.AI_learning_stopsGroup.Controls.Add(this.errorDontChangeCounterTextBox);
            this.AI_learning_stopsGroup.Controls.Add(this.countToStopTresholdTextBox);
            this.AI_learning_stopsGroup.Controls.Add(this.errorDontChangeTresholdTextBox);
            this.AI_learning_stopsGroup.Location = new System.Drawing.Point(369, 247);
            this.AI_learning_stopsGroup.Name = "AI_learning_stopsGroup";
            this.AI_learning_stopsGroup.Size = new System.Drawing.Size(186, 190);
            this.AI_learning_stopsGroup.TabIndex = 11;
            this.AI_learning_stopsGroup.TabStop = false;
            this.AI_learning_stopsGroup.Text = "AI learning stops";
            // 
            // errorDontChangeCounterTextBox
            // 
            this.errorDontChangeCounterTextBox.Location = new System.Drawing.Point(80, 22);
            this.errorDontChangeCounterTextBox.Name = "errorDontChangeCounterTextBox";
            this.errorDontChangeCounterTextBox.ReadOnly = true;
            this.errorDontChangeCounterTextBox.Size = new System.Drawing.Size(100, 23);
            this.errorDontChangeCounterTextBox.TabIndex = 2;
            // 
            // countToStopTresholdTextBox
            // 
            this.countToStopTresholdTextBox.Location = new System.Drawing.Point(80, 89);
            this.countToStopTresholdTextBox.Name = "countToStopTresholdTextBox";
            this.countToStopTresholdTextBox.Size = new System.Drawing.Size(100, 23);
            this.countToStopTresholdTextBox.TabIndex = 1;
            // 
            // errorDontChangeTresholdTextBox
            // 
            this.errorDontChangeTresholdTextBox.Location = new System.Drawing.Point(80, 60);
            this.errorDontChangeTresholdTextBox.Name = "errorDontChangeTresholdTextBox";
            this.errorDontChangeTresholdTextBox.Size = new System.Drawing.Size(100, 23);
            this.errorDontChangeTresholdTextBox.TabIndex = 0;
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
            // AutomaticTrainingBut
            // 
            this.AutomaticTrainingBut.Location = new System.Drawing.Point(469, 463);
            this.AutomaticTrainingBut.Name = "AutomaticTrainingBut";
            this.AutomaticTrainingBut.Size = new System.Drawing.Size(137, 23);
            this.AutomaticTrainingBut.TabIndex = 17;
            this.AutomaticTrainingBut.Text = "automatic training";
            this.AutomaticTrainingBut.UseVisualStyleBackColor = true;
            this.AutomaticTrainingBut.Click += new System.EventHandler(this.AutomaticTrainingBut_Click);
            // 
            // datasetParamsGroupBox
            // 
            this.datasetParamsGroupBox.Controls.Add(this.ApplyCompressionBut);
            this.datasetParamsGroupBox.Controls.Add(this.compressionLabel);
            this.datasetParamsGroupBox.Controls.Add(this.compressionValueTextBox);
            this.datasetParamsGroupBox.Location = new System.Drawing.Point(206, 337);
            this.datasetParamsGroupBox.Name = "datasetParamsGroupBox";
            this.datasetParamsGroupBox.Size = new System.Drawing.Size(157, 100);
            this.datasetParamsGroupBox.TabIndex = 18;
            this.datasetParamsGroupBox.TabStop = false;
            this.datasetParamsGroupBox.Text = "dataset compression";
            // 
            // ApplyCompressionBut
            // 
            this.ApplyCompressionBut.Enabled = false;
            this.ApplyCompressionBut.Location = new System.Drawing.Point(7, 58);
            this.ApplyCompressionBut.Name = "ApplyCompressionBut";
            this.ApplyCompressionBut.Size = new System.Drawing.Size(140, 23);
            this.ApplyCompressionBut.TabIndex = 2;
            this.ApplyCompressionBut.Text = "Apply";
            this.ApplyCompressionBut.UseVisualStyleBackColor = true;
            // 
            // compressionLabel
            // 
            this.compressionLabel.AutoSize = true;
            this.compressionLabel.Location = new System.Drawing.Point(6, 30);
            this.compressionLabel.Name = "compressionLabel";
            this.compressionLabel.Size = new System.Drawing.Size(45, 15);
            this.compressionLabel.TabIndex = 1;
            this.compressionLabel.Text = "compr.";
            // 
            // compressionValueTextBox
            // 
            this.compressionValueTextBox.Location = new System.Drawing.Point(57, 22);
            this.compressionValueTextBox.Name = "compressionValueTextBox";
            this.compressionValueTextBox.Size = new System.Drawing.Size(90, 23);
            this.compressionValueTextBox.TabIndex = 0;
            // 
            // learningSpeedSetupBut
            // 
            this.learningSpeedSetupBut.Location = new System.Drawing.Point(163, 36);
            this.learningSpeedSetupBut.Name = "learningSpeedSetupBut";
            this.learningSpeedSetupBut.Size = new System.Drawing.Size(25, 23);
            this.learningSpeedSetupBut.TabIndex = 11;
            this.learningSpeedSetupBut.Text = "...";
            this.learningSpeedSetupBut.UseVisualStyleBackColor = true;
            this.learningSpeedSetupBut.Click += new System.EventHandler(this.learningSpeedSetupBut_Click);
            // 
            // TrainingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.datasetParamsGroupBox);
            this.Controls.Add(this.AutomaticTrainingBut);
            this.Controls.Add(this.highestError);
            this.Controls.Add(this.averageErrorDisp);
            this.Controls.Add(this.PredictionGraphic);
            this.Controls.Add(this.perceptronDetailsText);
            this.Controls.Add(this.PerceptronConfigure);
            this.Controls.Add(this.AI_learning_stopsGroup);
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
            this.AI_learning_stopsGroup.ResumeLayout(false);
            this.AI_learning_stopsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PredictionGraphic)).EndInit();
            this.datasetParamsGroupBox.ResumeLayout(false);
            this.datasetParamsGroupBox.PerformLayout();
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
        private System.Windows.Forms.TextBox DatasetNumDiaplay;
        private System.Windows.Forms.TextBox WalkNumDisplay;
        private System.Windows.Forms.GroupBox AI_learning_stopsGroup;
        private System.Windows.Forms.Button PerceptronConfigure;
        private System.Windows.Forms.RichTextBox perceptronDetailsText;
        private System.ComponentModel.BackgroundWorker UpdateBackgroundWorker;
        private System.Windows.Forms.Label delayBetweenLearnsLabel;
        private System.Windows.Forms.TextBox DelayBetweenLearnsBox;
        private System.Windows.Forms.PictureBox PredictionGraphic;
        private System.Windows.Forms.TextBox averageErrorDisp;
        private System.Windows.Forms.TextBox highestError;
        private System.Windows.Forms.Button AutomaticTrainingBut;
        private System.Windows.Forms.CheckBox CheckRunCheckBox;
        private System.Windows.Forms.Label learningRunsLabel;
        private System.Windows.Forms.TextBox learningRunsTextBox;
        private System.Windows.Forms.GroupBox datasetParamsGroupBox;
        private System.Windows.Forms.Button ApplyCompressionBut;
        private System.Windows.Forms.Label compressionLabel;
        private System.Windows.Forms.TextBox compressionValueTextBox;
        private System.Windows.Forms.Label WeightCorrectIterLAbel;
        private System.Windows.Forms.TextBox WeigthSignCorrectionTextBox;
        private System.Windows.Forms.TextBox errorDontChangeCounterTextBox;
        private System.Windows.Forms.TextBox countToStopTresholdTextBox;
        private System.Windows.Forms.TextBox errorDontChangeTresholdTextBox;
        private System.Windows.Forms.Button learningSpeedSetupBut;
    }
}