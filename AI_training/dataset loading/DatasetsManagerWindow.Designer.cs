
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
            this.ChooseDatasetGrid = new System.Windows.Forms.DataGridView();
            this.ChoosedDatasetGrid = new System.Windows.Forms.DataGridView();
            this.choosedDatasetInfo = new System.Windows.Forms.RichTextBox();
            this.choosedLabelText = new System.Windows.Forms.Label();
            this.DatasetSetupButton = new System.Windows.Forms.Button();
            this.DatasetRemoveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChooseDatasetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosedDatasetGrid)).BeginInit();
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
            // ChooseDatasetGrid
            // 
            this.ChooseDatasetGrid.AllowUserToAddRows = false;
            this.ChooseDatasetGrid.AllowUserToDeleteRows = false;
            this.ChooseDatasetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChooseDatasetGrid.Location = new System.Drawing.Point(12, 42);
            this.ChooseDatasetGrid.Name = "ChooseDatasetGrid";
            this.ChooseDatasetGrid.ReadOnly = true;
            this.ChooseDatasetGrid.RowTemplate.Height = 25;
            this.ChooseDatasetGrid.Size = new System.Drawing.Size(292, 150);
            this.ChooseDatasetGrid.TabIndex = 2;
            this.ChooseDatasetGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChooseDatasetGrid_CellClick);
            // 
            // ChoosedDatasetGrid
            // 
            this.ChoosedDatasetGrid.AllowUserToAddRows = false;
            this.ChoosedDatasetGrid.AllowUserToDeleteRows = false;
            this.ChoosedDatasetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChoosedDatasetGrid.Location = new System.Drawing.Point(310, 42);
            this.ChoosedDatasetGrid.Name = "ChoosedDatasetGrid";
            this.ChoosedDatasetGrid.ReadOnly = true;
            this.ChoosedDatasetGrid.RowTemplate.Height = 25;
            this.ChoosedDatasetGrid.Size = new System.Drawing.Size(295, 150);
            this.ChoosedDatasetGrid.TabIndex = 3;
            this.ChoosedDatasetGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChoosedDatasetGrid_CellClick);
            // 
            // choosedDatasetInfo
            // 
            this.choosedDatasetInfo.Location = new System.Drawing.Point(611, 42);
            this.choosedDatasetInfo.Name = "choosedDatasetInfo";
            this.choosedDatasetInfo.ReadOnly = true;
            this.choosedDatasetInfo.Size = new System.Drawing.Size(177, 121);
            this.choosedDatasetInfo.TabIndex = 4;
            this.choosedDatasetInfo.Text = "";
            // 
            // choosedLabelText
            // 
            this.choosedLabelText.AutoSize = true;
            this.choosedLabelText.Location = new System.Drawing.Point(656, 16);
            this.choosedLabelText.Name = "choosedLabelText";
            this.choosedLabelText.Size = new System.Drawing.Size(95, 15);
            this.choosedLabelText.TabIndex = 5;
            this.choosedLabelText.Text = "Choosed dataset";
            // 
            // DatasetSetupButton
            // 
            this.DatasetSetupButton.Enabled = false;
            this.DatasetSetupButton.Location = new System.Drawing.Point(611, 169);
            this.DatasetSetupButton.Name = "DatasetSetupButton";
            this.DatasetSetupButton.Size = new System.Drawing.Size(80, 23);
            this.DatasetSetupButton.TabIndex = 6;
            this.DatasetSetupButton.Text = "Setup";
            this.DatasetSetupButton.UseVisualStyleBackColor = true;
            this.DatasetSetupButton.Click += new System.EventHandler(this.DatasetSetupButton_Click);
            // 
            // DatasetRemoveButton
            // 
            this.DatasetRemoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DatasetRemoveButton.Enabled = false;
            this.DatasetRemoveButton.Location = new System.Drawing.Point(713, 169);
            this.DatasetRemoveButton.Name = "DatasetRemoveButton";
            this.DatasetRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.DatasetRemoveButton.TabIndex = 7;
            this.DatasetRemoveButton.Text = "Remove";
            this.DatasetRemoveButton.UseVisualStyleBackColor = false;
            this.DatasetRemoveButton.Click += new System.EventHandler(this.DatasetRemoveButton_Click);
            // 
            // DatasetsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DatasetRemoveButton);
            this.Controls.Add(this.DatasetSetupButton);
            this.Controls.Add(this.choosedLabelText);
            this.Controls.Add(this.choosedDatasetInfo);
            this.Controls.Add(this.ChoosedDatasetGrid);
            this.Controls.Add(this.ChooseDatasetGrid);
            this.Controls.Add(this.choosedDirectoryDispPath);
            this.Controls.Add(this.chooseDatasetsDirectory);
            this.Name = "DatasetsManager";
            this.Text = "DatasetsManager";
            ((System.ComponentModel.ISupportInitialize)(this.ChooseDatasetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChoosedDatasetGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseDatasetsDirectory;
        private System.Windows.Forms.TextBox choosedDirectoryDispPath;
        private System.Windows.Forms.DataGridView ChooseDatasetGrid;
        private System.Windows.Forms.DataGridView ChoosedDatasetGrid;
        private System.Windows.Forms.RichTextBox choosedDatasetInfo;
        private System.Windows.Forms.Label choosedLabelText;
        private System.Windows.Forms.Button DatasetSetupButton;
        private System.Windows.Forms.Button DatasetRemoveButton;
    }
}