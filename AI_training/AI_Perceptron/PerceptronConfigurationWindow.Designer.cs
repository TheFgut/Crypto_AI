
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
            this.inputAdapterGroupSet = new System.Windows.Forms.GroupBox();
            this.IA_OutputLabel = new System.Windows.Forms.Label();
            this.IA_inputLabel = new System.Windows.Forms.Label();
            this.IA_outputCountTextBox = new System.Windows.Forms.TextBox();
            this.IA_inputCountTextBox = new System.Windows.Forms.TextBox();
            this.connectedInputAdapterDetails = new System.Windows.Forms.RichTextBox();
            this.inputAdapConnectBut = new System.Windows.Forms.Button();
            this.AI_paramsGroupBox = new System.Windows.Forms.GroupBox();
            this.brokenWLabel = new System.Windows.Forms.Label();
            this.maxWLabel = new System.Windows.Forms.Label();
            this.minWLabel = new System.Windows.Forms.Label();
            this.avgWLabel = new System.Windows.Forms.Label();
            this.updateWeightsDataCheckBox = new System.Windows.Forms.CheckBox();
            this.brokenWPercentDisp = new System.Windows.Forms.TextBox();
            this.maxWDisp = new System.Windows.Forms.TextBox();
            this.minWDisp = new System.Windows.Forms.TextBox();
            this.avgWeigthDisp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.perceptronDrawing)).BeginInit();
            this.inputAdapterGroupSet.SuspendLayout();
            this.AI_paramsGroupBox.SuspendLayout();
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
            this.perceptronDrawing.Size = new System.Drawing.Size(440, 204);
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
            // inputAdapterGroupSet
            // 
            this.inputAdapterGroupSet.Controls.Add(this.IA_OutputLabel);
            this.inputAdapterGroupSet.Controls.Add(this.IA_inputLabel);
            this.inputAdapterGroupSet.Controls.Add(this.IA_outputCountTextBox);
            this.inputAdapterGroupSet.Controls.Add(this.IA_inputCountTextBox);
            this.inputAdapterGroupSet.Controls.Add(this.connectedInputAdapterDetails);
            this.inputAdapterGroupSet.Controls.Add(this.inputAdapConnectBut);
            this.inputAdapterGroupSet.Location = new System.Drawing.Point(464, 12);
            this.inputAdapterGroupSet.Name = "inputAdapterGroupSet";
            this.inputAdapterGroupSet.Size = new System.Drawing.Size(200, 204);
            this.inputAdapterGroupSet.TabIndex = 5;
            this.inputAdapterGroupSet.TabStop = false;
            this.inputAdapterGroupSet.Text = "input adapter";
            // 
            // IA_OutputLabel
            // 
            this.IA_OutputLabel.AutoSize = true;
            this.IA_OutputLabel.Location = new System.Drawing.Point(20, 66);
            this.IA_OutputLabel.Name = "IA_OutputLabel";
            this.IA_OutputLabel.Size = new System.Drawing.Size(45, 15);
            this.IA_OutputLabel.TabIndex = 5;
            this.IA_OutputLabel.Text = "Output";
            // 
            // IA_inputLabel
            // 
            this.IA_inputLabel.AutoSize = true;
            this.IA_inputLabel.Location = new System.Drawing.Point(20, 36);
            this.IA_inputLabel.Name = "IA_inputLabel";
            this.IA_inputLabel.Size = new System.Drawing.Size(35, 15);
            this.IA_inputLabel.TabIndex = 4;
            this.IA_inputLabel.Text = "Input";
            // 
            // IA_outputCountTextBox
            // 
            this.IA_outputCountTextBox.Location = new System.Drawing.Point(88, 58);
            this.IA_outputCountTextBox.Name = "IA_outputCountTextBox";
            this.IA_outputCountTextBox.ReadOnly = true;
            this.IA_outputCountTextBox.Size = new System.Drawing.Size(100, 23);
            this.IA_outputCountTextBox.TabIndex = 3;
            // 
            // IA_inputCountTextBox
            // 
            this.IA_inputCountTextBox.Location = new System.Drawing.Point(88, 28);
            this.IA_inputCountTextBox.Name = "IA_inputCountTextBox";
            this.IA_inputCountTextBox.Size = new System.Drawing.Size(100, 23);
            this.IA_inputCountTextBox.TabIndex = 2;
            // 
            // connectedInputAdapterDetails
            // 
            this.connectedInputAdapterDetails.Location = new System.Drawing.Point(6, 112);
            this.connectedInputAdapterDetails.Name = "connectedInputAdapterDetails";
            this.connectedInputAdapterDetails.ReadOnly = true;
            this.connectedInputAdapterDetails.Size = new System.Drawing.Size(187, 57);
            this.connectedInputAdapterDetails.TabIndex = 1;
            this.connectedInputAdapterDetails.Text = "";
            // 
            // inputAdapConnectBut
            // 
            this.inputAdapConnectBut.Location = new System.Drawing.Point(6, 175);
            this.inputAdapConnectBut.Name = "inputAdapConnectBut";
            this.inputAdapConnectBut.Size = new System.Drawing.Size(187, 23);
            this.inputAdapConnectBut.TabIndex = 0;
            this.inputAdapConnectBut.Text = "Connect";
            this.inputAdapConnectBut.UseVisualStyleBackColor = true;
            // 
            // AI_paramsGroupBox
            // 
            this.AI_paramsGroupBox.Controls.Add(this.brokenWLabel);
            this.AI_paramsGroupBox.Controls.Add(this.maxWLabel);
            this.AI_paramsGroupBox.Controls.Add(this.minWLabel);
            this.AI_paramsGroupBox.Controls.Add(this.avgWLabel);
            this.AI_paramsGroupBox.Controls.Add(this.updateWeightsDataCheckBox);
            this.AI_paramsGroupBox.Controls.Add(this.brokenWPercentDisp);
            this.AI_paramsGroupBox.Controls.Add(this.maxWDisp);
            this.AI_paramsGroupBox.Controls.Add(this.minWDisp);
            this.AI_paramsGroupBox.Controls.Add(this.avgWeigthDisp);
            this.AI_paramsGroupBox.Location = new System.Drawing.Point(464, 222);
            this.AI_paramsGroupBox.Name = "AI_paramsGroupBox";
            this.AI_paramsGroupBox.Size = new System.Drawing.Size(200, 216);
            this.AI_paramsGroupBox.TabIndex = 6;
            this.AI_paramsGroupBox.TabStop = false;
            this.AI_paramsGroupBox.Text = "parameters";
            // 
            // brokenWLabel
            // 
            this.brokenWLabel.AutoSize = true;
            this.brokenWLabel.Location = new System.Drawing.Point(7, 148);
            this.brokenWLabel.Name = "brokenWLabel";
            this.brokenWLabel.Size = new System.Drawing.Size(88, 15);
            this.brokenWLabel.TabIndex = 8;
            this.brokenWLabel.Text = "broken weigths";
            // 
            // maxWLabel
            // 
            this.maxWLabel.AutoSize = true;
            this.maxWLabel.Location = new System.Drawing.Point(5, 102);
            this.maxWLabel.Name = "maxWLabel";
            this.maxWLabel.Size = new System.Drawing.Size(87, 15);
            this.maxWLabel.TabIndex = 7;
            this.maxWLabel.Text = "max weigth val";
            // 
            // minWLabel
            // 
            this.minWLabel.AutoSize = true;
            this.minWLabel.Location = new System.Drawing.Point(7, 72);
            this.minWLabel.Name = "minWLabel";
            this.minWLabel.Size = new System.Drawing.Size(85, 15);
            this.minWLabel.TabIndex = 6;
            this.minWLabel.Text = "min weight val";
            // 
            // avgWLabel
            // 
            this.avgWLabel.AutoSize = true;
            this.avgWLabel.Location = new System.Drawing.Point(6, 25);
            this.avgWLabel.Name = "avgWLabel";
            this.avgWLabel.Size = new System.Drawing.Size(86, 15);
            this.avgWLabel.TabIndex = 5;
            this.avgWLabel.Text = "avg. weigth val";
            // 
            // updateWeightsDataCheckBox
            // 
            this.updateWeightsDataCheckBox.AutoSize = true;
            this.updateWeightsDataCheckBox.Location = new System.Drawing.Point(34, 191);
            this.updateWeightsDataCheckBox.Name = "updateWeightsDataCheckBox";
            this.updateWeightsDataCheckBox.Size = new System.Drawing.Size(125, 19);
            this.updateWeightsDataCheckBox.TabIndex = 4;
            this.updateWeightsDataCheckBox.Text = "update in real time";
            this.updateWeightsDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // brokenWPercentDisp
            // 
            this.brokenWPercentDisp.Location = new System.Drawing.Point(98, 145);
            this.brokenWPercentDisp.Name = "brokenWPercentDisp";
            this.brokenWPercentDisp.ReadOnly = true;
            this.brokenWPercentDisp.Size = new System.Drawing.Size(95, 23);
            this.brokenWPercentDisp.TabIndex = 3;
            // 
            // maxWDisp
            // 
            this.maxWDisp.Location = new System.Drawing.Point(98, 99);
            this.maxWDisp.Name = "maxWDisp";
            this.maxWDisp.ReadOnly = true;
            this.maxWDisp.Size = new System.Drawing.Size(95, 23);
            this.maxWDisp.TabIndex = 2;
            // 
            // minWDisp
            // 
            this.minWDisp.Location = new System.Drawing.Point(98, 69);
            this.minWDisp.Name = "minWDisp";
            this.minWDisp.ReadOnly = true;
            this.minWDisp.Size = new System.Drawing.Size(95, 23);
            this.minWDisp.TabIndex = 1;
            // 
            // avgWeigthDisp
            // 
            this.avgWeigthDisp.Location = new System.Drawing.Point(98, 22);
            this.avgWeigthDisp.Name = "avgWeigthDisp";
            this.avgWeigthDisp.ReadOnly = true;
            this.avgWeigthDisp.Size = new System.Drawing.Size(95, 23);
            this.avgWeigthDisp.TabIndex = 0;
            // 
            // PerceptronConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AI_paramsGroupBox);
            this.Controls.Add(this.inputAdapterGroupSet);
            this.Controls.Add(this.ApplyPerceptron);
            this.Controls.Add(this.perceptronDrawing);
            this.Controls.Add(this.perceptronDetailsText);
            this.Controls.Add(this.LoadPerceptronButton);
            this.Controls.Add(this.CreatePerceptronButton);
            this.Name = "PerceptronConfigurationWindow";
            this.Text = "PerceptronConfigurationWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PerceptronConfigurationWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PerceptronConfigurationWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.perceptronDrawing)).EndInit();
            this.inputAdapterGroupSet.ResumeLayout(false);
            this.inputAdapterGroupSet.PerformLayout();
            this.AI_paramsGroupBox.ResumeLayout(false);
            this.AI_paramsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreatePerceptronButton;
        private System.Windows.Forms.Button LoadPerceptronButton;
        private System.Windows.Forms.RichTextBox perceptronDetailsText;
        private System.Windows.Forms.PictureBox perceptronDrawing;
        private System.Windows.Forms.Button ApplyPerceptron;
        private System.Windows.Forms.GroupBox inputAdapterGroupSet;
        private System.Windows.Forms.Label IA_OutputLabel;
        private System.Windows.Forms.Label IA_inputLabel;
        private System.Windows.Forms.TextBox IA_outputCountTextBox;
        private System.Windows.Forms.TextBox IA_inputCountTextBox;
        private System.Windows.Forms.RichTextBox connectedInputAdapterDetails;
        private System.Windows.Forms.Button inputAdapConnectBut;
        private System.Windows.Forms.GroupBox AI_paramsGroupBox;
        private System.Windows.Forms.CheckBox updateWeightsDataCheckBox;
        private System.Windows.Forms.TextBox brokenWPercentDisp;
        private System.Windows.Forms.TextBox maxWDisp;
        private System.Windows.Forms.TextBox minWDisp;
        private System.Windows.Forms.TextBox avgWeigthDisp;
        private System.Windows.Forms.Label brokenWLabel;
        private System.Windows.Forms.Label maxWLabel;
        private System.Windows.Forms.Label minWLabel;
        private System.Windows.Forms.Label avgWLabel;
    }
}