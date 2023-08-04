
namespace CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_making
{
    partial class PerceptronMakerWindow
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.structureInfo = new System.Windows.Forms.TextBox();
            this.neuronsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Enabled = false;
            this.CreateButton.Location = new System.Drawing.Point(52, 87);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // structureInfo
            // 
            this.structureInfo.Location = new System.Drawing.Point(12, 58);
            this.structureInfo.Name = "structureInfo";
            this.structureInfo.PlaceholderText = "input-hidden-output";
            this.structureInfo.Size = new System.Drawing.Size(166, 23);
            this.structureInfo.TabIndex = 1;
            this.structureInfo.TextChanged += new System.EventHandler(this.structureInfo_TextChanged);
            this.structureInfo.Validating += new System.ComponentModel.CancelEventHandler(this.structureInfo_Validating);
            // 
            // neuronsLabel
            // 
            this.neuronsLabel.AutoSize = true;
            this.neuronsLabel.Location = new System.Drawing.Point(39, 23);
            this.neuronsLabel.Name = "neuronsLabel";
            this.neuronsLabel.Size = new System.Drawing.Size(100, 15);
            this.neuronsLabel.TabIndex = 2;
            this.neuronsLabel.Text = "neurons structure";
            // 
            // PerceptronMakerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 127);
            this.Controls.Add(this.neuronsLabel);
            this.Controls.Add(this.structureInfo);
            this.Controls.Add(this.CreateButton);
            this.Name = "PerceptronMakerWindow";
            this.Text = "PerceptronMakerWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PerceptronMakerWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox structureInfo;
        private System.Windows.Forms.Label neuronsLabel;
    }
}