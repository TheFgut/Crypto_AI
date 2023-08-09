
namespace CryptoAnalizerAI.AI_training.dataset_loading
{
    partial class DatasetsManagerWindow
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
            this.chooseDatasetsDirectory = new System.Windows.Forms.Button();
            this.choosedDirectoryDispPath = new System.Windows.Forms.TextBox();
            this.ChooseLearnDatasetGrid = new System.Windows.Forms.DataGridView();
            this.ChoosedLearnDatasetGrid = new System.Windows.Forms.DataGridView();
            this.choosedDatasetInfo = new System.Windows.Forms.RichTextBox();
            this.choosedLabelText = new System.Windows.Forms.Label();
            this.LearnDatasetSetupButton = new System.Windows.Forms.Button();
            this.LearnDatasetRemoveButton = new System.Windows.Forms.Button();
            this.ChooseCheckDatasetGrid = new System.Windows.Forms.DataGridView();
            this.ChoosedCheckDatasetGrid = new System.Windows.Forms.DataGridView();
            this.TestDatasetsGroup = new System.Windows.Forms.GroupBox();
            this.TestDatasetRemoveButton = new System.Windows.Forms.Button();
            this.testDatasetSetupButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseLearnDatasetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosedLearnDatasetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseCheckDatasetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosedCheckDatasetGrid)).BeginInit();
            this.TestDatasetsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseDatasetsDirectory
            // 
            this.chooseDatasetsDirectory.Location = new System.Drawing.Point(172, 12);
            this.chooseDatasetsDirectory.Name = "chooseDatasetsDirectory";
            this.chooseDatasetsDirectory.Size = new System.Drawing.Size(40, 23);
            this.chooseDatasetsDirectory.TabIndex = 0;
            this.chooseDatasetsDirectory.Text = "...";
            this.chooseDatasetsDirectory.UseVisualStyleBackColor = true;
            this.chooseDatasetsDirectory.Click += new System.EventHandler(this.chooseDatasetsDirectory_Click);
            // 
            // choosedDirectoryDispPath
            // 
            this.choosedDirectoryDispPath.Location = new System.Drawing.Point(12, 13);
            this.choosedDirectoryDispPath.Name = "choosedDirectoryDispPath";
            this.choosedDirectoryDispPath.PlaceholderText = "set datasets directory";
            this.choosedDirectoryDispPath.ReadOnly = true;
            this.choosedDirectoryDispPath.Size = new System.Drawing.Size(154, 23);
            this.choosedDirectoryDispPath.TabIndex = 1;
            // 
            // ChooseLearnDatasetGrid
            // 
            this.ChooseLearnDatasetGrid.AllowUserToAddRows = false;
            this.ChooseLearnDatasetGrid.AllowUserToDeleteRows = false;
            this.ChooseLearnDatasetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChooseLearnDatasetGrid.Location = new System.Drawing.Point(29, 42);
            this.ChooseLearnDatasetGrid.Name = "ChooseLearnDatasetGrid";
            this.ChooseLearnDatasetGrid.ReadOnly = true;
            this.ChooseLearnDatasetGrid.RowTemplate.Height = 25;
            this.ChooseLearnDatasetGrid.Size = new System.Drawing.Size(411, 288);
            this.ChooseLearnDatasetGrid.TabIndex = 2;
            // 
            // ChoosedLearnDatasetGrid
            // 
            this.ChoosedLearnDatasetGrid.AllowUserToAddRows = false;
            this.ChoosedLearnDatasetGrid.AllowUserToDeleteRows = false;
            this.ChoosedLearnDatasetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChoosedLearnDatasetGrid.Location = new System.Drawing.Point(446, 42);
            this.ChoosedLearnDatasetGrid.Name = "ChoosedLearnDatasetGrid";
            this.ChoosedLearnDatasetGrid.ReadOnly = true;
            this.ChoosedLearnDatasetGrid.RowTemplate.Height = 25;
            this.ChoosedLearnDatasetGrid.Size = new System.Drawing.Size(423, 288);
            this.ChoosedLearnDatasetGrid.TabIndex = 3;
            // 
            // choosedDatasetInfo
            // 
            this.choosedDatasetInfo.Location = new System.Drawing.Point(875, 42);
            this.choosedDatasetInfo.Name = "choosedDatasetInfo";
            this.choosedDatasetInfo.ReadOnly = true;
            this.choosedDatasetInfo.Size = new System.Drawing.Size(177, 121);
            this.choosedDatasetInfo.TabIndex = 4;
            this.choosedDatasetInfo.Text = "";
            // 
            // choosedLabelText
            // 
            this.choosedLabelText.AutoSize = true;
            this.choosedLabelText.Location = new System.Drawing.Point(918, 16);
            this.choosedLabelText.Name = "choosedLabelText";
            this.choosedLabelText.Size = new System.Drawing.Size(95, 15);
            this.choosedLabelText.TabIndex = 5;
            this.choosedLabelText.Text = "Choosed dataset";
            // 
            // LearnDatasetSetupButton
            // 
            this.LearnDatasetSetupButton.Enabled = false;
            this.LearnDatasetSetupButton.Location = new System.Drawing.Point(875, 169);
            this.LearnDatasetSetupButton.Name = "LearnDatasetSetupButton";
            this.LearnDatasetSetupButton.Size = new System.Drawing.Size(80, 23);
            this.LearnDatasetSetupButton.TabIndex = 6;
            this.LearnDatasetSetupButton.Text = "Setup";
            this.LearnDatasetSetupButton.UseVisualStyleBackColor = true;
            // 
            // LearnDatasetRemoveButton
            // 
            this.LearnDatasetRemoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.LearnDatasetRemoveButton.Enabled = false;
            this.LearnDatasetRemoveButton.Location = new System.Drawing.Point(977, 169);
            this.LearnDatasetRemoveButton.Name = "LearnDatasetRemoveButton";
            this.LearnDatasetRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.LearnDatasetRemoveButton.TabIndex = 7;
            this.LearnDatasetRemoveButton.Text = "Remove";
            this.LearnDatasetRemoveButton.UseVisualStyleBackColor = false;
            // 
            // ChooseCheckDatasetGrid
            // 
            this.ChooseCheckDatasetGrid.AllowUserToAddRows = false;
            this.ChooseCheckDatasetGrid.AllowUserToDeleteRows = false;
            this.ChooseCheckDatasetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChooseCheckDatasetGrid.Location = new System.Drawing.Point(17, 22);
            this.ChooseCheckDatasetGrid.Name = "ChooseCheckDatasetGrid";
            this.ChooseCheckDatasetGrid.RowTemplate.Height = 25;
            this.ChooseCheckDatasetGrid.Size = new System.Drawing.Size(411, 266);
            this.ChooseCheckDatasetGrid.TabIndex = 8;
            // 
            // ChoosedCheckDatasetGrid
            // 
            this.ChoosedCheckDatasetGrid.AllowUserToAddRows = false;
            this.ChoosedCheckDatasetGrid.AllowUserToDeleteRows = false;
            this.ChoosedCheckDatasetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChoosedCheckDatasetGrid.Location = new System.Drawing.Point(434, 22);
            this.ChoosedCheckDatasetGrid.Name = "ChoosedCheckDatasetGrid";
            this.ChoosedCheckDatasetGrid.RowTemplate.Height = 25;
            this.ChoosedCheckDatasetGrid.Size = new System.Drawing.Size(423, 266);
            this.ChoosedCheckDatasetGrid.TabIndex = 9;
            // 
            // TestDatasetsGroup
            // 
            this.TestDatasetsGroup.Controls.Add(this.TestDatasetRemoveButton);
            this.TestDatasetsGroup.Controls.Add(this.testDatasetSetupButton);
            this.TestDatasetsGroup.Controls.Add(this.ChooseCheckDatasetGrid);
            this.TestDatasetsGroup.Controls.Add(this.ChoosedCheckDatasetGrid);
            this.TestDatasetsGroup.Location = new System.Drawing.Point(12, 336);
            this.TestDatasetsGroup.Name = "TestDatasetsGroup";
            this.TestDatasetsGroup.Size = new System.Drawing.Size(1058, 294);
            this.TestDatasetsGroup.TabIndex = 10;
            this.TestDatasetsGroup.TabStop = false;
            this.TestDatasetsGroup.Text = "test datasets";
            // 
            // TestDatasetRemoveButton
            // 
            this.TestDatasetRemoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TestDatasetRemoveButton.Enabled = false;
            this.TestDatasetRemoveButton.Location = new System.Drawing.Point(965, 200);
            this.TestDatasetRemoveButton.Name = "TestDatasetRemoveButton";
            this.TestDatasetRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.TestDatasetRemoveButton.TabIndex = 11;
            this.TestDatasetRemoveButton.Text = "Remove";
            this.TestDatasetRemoveButton.UseVisualStyleBackColor = false;
            // 
            // testDatasetSetupButton
            // 
            this.testDatasetSetupButton.Enabled = false;
            this.testDatasetSetupButton.Location = new System.Drawing.Point(868, 201);
            this.testDatasetSetupButton.Name = "testDatasetSetupButton";
            this.testDatasetSetupButton.Size = new System.Drawing.Size(75, 23);
            this.testDatasetSetupButton.TabIndex = 10;
            this.testDatasetSetupButton.Text = "Setup";
            this.testDatasetSetupButton.UseVisualStyleBackColor = true;
            // 
            // DatasetsManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 645);
            this.Controls.Add(this.TestDatasetsGroup);
            this.Controls.Add(this.LearnDatasetRemoveButton);
            this.Controls.Add(this.LearnDatasetSetupButton);
            this.Controls.Add(this.choosedLabelText);
            this.Controls.Add(this.choosedDatasetInfo);
            this.Controls.Add(this.ChoosedLearnDatasetGrid);
            this.Controls.Add(this.ChooseLearnDatasetGrid);
            this.Controls.Add(this.choosedDirectoryDispPath);
            this.Controls.Add(this.chooseDatasetsDirectory);
            this.Name = "DatasetsManagerWindow";
            this.Text = "DatasetsManager";
            ((System.ComponentModel.ISupportInitialize)(this.ChooseLearnDatasetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosedLearnDatasetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseCheckDatasetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosedCheckDatasetGrid)).EndInit();
            this.TestDatasetsGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseDatasetsDirectory;
        private System.Windows.Forms.TextBox choosedDirectoryDispPath;
        private System.Windows.Forms.DataGridView ChooseLearnDatasetGrid;
        private System.Windows.Forms.DataGridView ChoosedLearnDatasetGrid;
        private System.Windows.Forms.RichTextBox choosedDatasetInfo;
        private System.Windows.Forms.Label choosedLabelText;
        private System.Windows.Forms.Button LearnDatasetSetupButton;
        private System.Windows.Forms.Button LearnDatasetRemoveButton;
        private System.Windows.Forms.DataGridView ChooseCheckDatasetGrid;
        private System.Windows.Forms.DataGridView ChoosedCheckDatasetGrid;
        private System.Windows.Forms.GroupBox TestDatasetsGroup;
        private System.Windows.Forms.Button TestDatasetRemoveButton;
        private System.Windows.Forms.Button testDatasetSetupButton;
    }
}