
namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{
    partial class PerceptronConfigurationWindow
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
            this.CreatePerceptronButton = new System.Windows.Forms.Button();
            this.LoadPerceptronButton = new System.Windows.Forms.Button();
            this.perceptronDetailsText = new System.Windows.Forms.RichTextBox();
            this.perceptronDrawing = new System.Windows.Forms.PictureBox();
            this.ApplyPerceptron = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.perceptronDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // CreatePerceptronButton
            // 
            this.CreatePerceptronButton.Location = new System.Drawing.Point(670, 12);
            this.CreatePerceptronButton.Name = "CreatePerceptronButton";
            this.CreatePerceptronButton.Size = new System.Drawing.Size(118, 23);
            this.CreatePerceptronButton.TabIndex = 0;
            this.CreatePerceptronButton.Text = "Create perceptron";
            this.CreatePerceptronButton.UseVisualStyleBackColor = true;
            this.CreatePerceptronButton.Click += new System.EventHandler(this.CreatePerceptronButton_Click);
            // 
            // LoadPerceptronButton
            // 
            this.LoadPerceptronButton.Location = new System.Drawing.Point(670, 41);
            this.LoadPerceptronButton.Name = "LoadPerceptronButton";
            this.LoadPerceptronButton.Size = new System.Drawing.Size(118, 23);
            this.LoadPerceptronButton.TabIndex = 1;
            this.LoadPerceptronButton.Text = "Load perceptron";
            this.LoadPerceptronButton.UseVisualStyleBackColor = true;
            this.LoadPerceptronButton.Click += new System.EventHandler(this.LoadPerceptronButton_Click);
            // 
            // perceptronDetailsText
            // 
            this.perceptronDetailsText.Location = new System.Drawing.Point(670, 70);
            this.perceptronDetailsText.Name = "perceptronDetailsText";
            this.perceptronDetailsText.Size = new System.Drawing.Size(118, 339);
            this.perceptronDetailsText.TabIndex = 2;
            this.perceptronDetailsText.Text = "no perceptron";
            // 
            // perceptronDrawing
            // 
            this.perceptronDrawing.Location = new System.Drawing.Point(12, 12);
            this.perceptronDrawing.Name = "perceptronDrawing";
            this.perceptronDrawing.Size = new System.Drawing.Size(652, 204);
            this.perceptronDrawing.TabIndex = 3;
            this.perceptronDrawing.TabStop = false;
            // 
            // ApplyPerceptron
            // 
            this.ApplyPerceptron.Location = new System.Drawing.Point(694, 415);
            this.ApplyPerceptron.Name = "ApplyPerceptron";
            this.ApplyPerceptron.Size = new System.Drawing.Size(75, 23);
            this.ApplyPerceptron.TabIndex = 4;
            this.ApplyPerceptron.Text = "Apply";
            this.ApplyPerceptron.UseVisualStyleBackColor = true;
            this.ApplyPerceptron.Click += new System.EventHandler(this.ApplyPerceptron_Click);
            // 
            // PerceptronConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ApplyPerceptron);
            this.Controls.Add(this.perceptronDrawing);
            this.Controls.Add(this.perceptronDetailsText);
            this.Controls.Add(this.LoadPerceptronButton);
            this.Controls.Add(this.CreatePerceptronButton);
            this.Name = "PerceptronConfigurationWindow";
            this.Text = "PerceptronConfigurationWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PerceptronConfigurationWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.perceptronDrawing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreatePerceptronButton;
        private System.Windows.Forms.Button LoadPerceptronButton;
        private System.Windows.Forms.RichTextBox perceptronDetailsText;
        private System.Windows.Forms.PictureBox perceptronDrawing;
        private System.Windows.Forms.Button ApplyPerceptron;
    }
}