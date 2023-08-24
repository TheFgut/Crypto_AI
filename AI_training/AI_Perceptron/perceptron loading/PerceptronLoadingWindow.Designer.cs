
namespace CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_loading
{
    partial class PerceptronLoadingWindow
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
            this.FieInspectorGrid = new System.Windows.Forms.DataGridView();
            this.backBut = new System.Windows.Forms.Button();
            this.statsDisp = new System.Windows.Forms.RichTextBox();
            this.loadBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FieInspectorGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // FieInspectorGrid
            // 
            this.FieInspectorGrid.AllowUserToAddRows = false;
            this.FieInspectorGrid.AllowUserToDeleteRows = false;
            this.FieInspectorGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FieInspectorGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.FieInspectorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FieInspectorGrid.Location = new System.Drawing.Point(12, 12);
            this.FieInspectorGrid.Name = "FieInspectorGrid";
            this.FieInspectorGrid.RowTemplate.Height = 25;
            this.FieInspectorGrid.Size = new System.Drawing.Size(633, 350);
            this.FieInspectorGrid.TabIndex = 0;
            this.FieInspectorGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FieInspectorGrid_CellClick);
            // 
            // backBut
            // 
            this.backBut.Location = new System.Drawing.Point(12, 368);
            this.backBut.Name = "backBut";
            this.backBut.Size = new System.Drawing.Size(631, 41);
            this.backBut.TabIndex = 1;
            this.backBut.Text = "Back";
            this.backBut.UseVisualStyleBackColor = true;
            this.backBut.Click += new System.EventHandler(this.backBut_Click);
            // 
            // statsDisp
            // 
            this.statsDisp.Location = new System.Drawing.Point(652, 12);
            this.statsDisp.Name = "statsDisp";
            this.statsDisp.Size = new System.Drawing.Size(259, 350);
            this.statsDisp.TabIndex = 2;
            this.statsDisp.Text = "";
            // 
            // loadBut
            // 
            this.loadBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.loadBut.Location = new System.Drawing.Point(674, 368);
            this.loadBut.Name = "loadBut";
            this.loadBut.Size = new System.Drawing.Size(215, 41);
            this.loadBut.TabIndex = 3;
            this.loadBut.Text = "Load";
            this.loadBut.UseVisualStyleBackColor = false;
            this.loadBut.Click += new System.EventHandler(this.loadBut_Click);
            // 
            // PerceptronLoadingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 414);
            this.Controls.Add(this.loadBut);
            this.Controls.Add(this.statsDisp);
            this.Controls.Add(this.backBut);
            this.Controls.Add(this.FieInspectorGrid);
            this.Name = "PerceptronLoadingWindow";
            this.Text = "PerceptronLoadingWindow";
            ((System.ComponentModel.ISupportInitialize)(this.FieInspectorGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FieInspectorGrid;
        private System.Windows.Forms.Button backBut;
        private System.Windows.Forms.RichTextBox statsDisp;
        private System.Windows.Forms.Button loadBut;
    }
}