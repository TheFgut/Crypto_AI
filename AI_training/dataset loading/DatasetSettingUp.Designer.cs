
namespace CryptoAnalizerAI.AI_training.dataset_loading
{
    partial class DatasetSettingUp
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
            this.graphic = new System.Windows.Forms.PictureBox();
            this.dataSelection = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.ApplyStartBut = new System.Windows.Forms.Button();
            this.ApplyEndBut = new System.Windows.Forms.Button();
            this.SaveBut = new System.Windows.Forms.Button();
            this.CloseBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // graphic
            // 
            this.graphic.Location = new System.Drawing.Point(316, 12);
            this.graphic.Name = "graphic";
            this.graphic.Size = new System.Drawing.Size(472, 165);
            this.graphic.TabIndex = 0;
            this.graphic.TabStop = false;
            // 
            // dataSelection
            // 
            this.dataSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSelection.Location = new System.Drawing.Point(12, 12);
            this.dataSelection.Name = "dataSelection";
            this.dataSelection.RowTemplate.Height = 25;
            this.dataSelection.Size = new System.Drawing.Size(286, 426);
            this.dataSelection.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(386, 183);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(402, 88);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(386, 277);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(402, 96);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // ApplyStartBut
            // 
            this.ApplyStartBut.Location = new System.Drawing.Point(304, 248);
            this.ApplyStartBut.Name = "ApplyStartBut";
            this.ApplyStartBut.Size = new System.Drawing.Size(75, 23);
            this.ApplyStartBut.TabIndex = 4;
            this.ApplyStartBut.Text = "Choose";
            this.ApplyStartBut.UseVisualStyleBackColor = true;
            this.ApplyStartBut.Click += new System.EventHandler(this.ApplyStart_Click);
            // 
            // ApplyEndBut
            // 
            this.ApplyEndBut.Location = new System.Drawing.Point(305, 350);
            this.ApplyEndBut.Name = "ApplyEndBut";
            this.ApplyEndBut.Size = new System.Drawing.Size(75, 23);
            this.ApplyEndBut.TabIndex = 5;
            this.ApplyEndBut.Text = "Choose";
            this.ApplyEndBut.UseVisualStyleBackColor = true;
            this.ApplyEndBut.Click += new System.EventHandler(this.ApplyEnd_Click);
            // 
            // SaveBut
            // 
            this.SaveBut.Location = new System.Drawing.Point(305, 415);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(329, 23);
            this.SaveBut.TabIndex = 6;
            this.SaveBut.Text = "Save";
            this.SaveBut.UseVisualStyleBackColor = true;
            // 
            // CloseBut
            // 
            this.CloseBut.Location = new System.Drawing.Point(640, 415);
            this.CloseBut.Name = "CloseBut";
            this.CloseBut.Size = new System.Drawing.Size(148, 23);
            this.CloseBut.TabIndex = 7;
            this.CloseBut.Text = "Close";
            this.CloseBut.UseVisualStyleBackColor = true;
            // 
            // DatasetLoadingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseBut);
            this.Controls.Add(this.SaveBut);
            this.Controls.Add(this.ApplyEndBut);
            this.Controls.Add(this.ApplyStartBut);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataSelection);
            this.Controls.Add(this.graphic);
            this.Name = "DatasetLoadingWindow";
            this.Text = "DatasetLoadingWindow";
            ((System.ComponentModel.ISupportInitialize)(this.graphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox graphic;
        private System.Windows.Forms.DataGridView dataSelection;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button ApplyStartBut;
        private System.Windows.Forms.Button ApplyEndBut;
        private System.Windows.Forms.Button SaveBut;
        private System.Windows.Forms.Button CloseBut;
    }
}