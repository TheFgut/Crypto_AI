
namespace CryptoAnalizerAI.AI_training.UI
{
    partial class LearningSpeedSetupWindow
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
            this.startSpeedTextBox = new System.Windows.Forms.TextBox();
            this.endSpeedTextBox = new System.Windows.Forms.TextBox();
            this.LProgressSpdChangeGroupSett = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorDecreaseStartTresholdBox = new System.Windows.Forms.TextBox();
            this.errorDecreaseFullTresholdBox = new System.Windows.Forms.TextBox();
            this.maxErrorSpeedDecreaseBox = new System.Windows.Forms.TextBox();
            this.startSpeedLabel = new System.Windows.Forms.Label();
            this.endSpeedLabel = new System.Windows.Forms.Label();
            this.startTresholdLabel = new System.Windows.Forms.Label();
            this.fullTresholdLabel = new System.Windows.Forms.Label();
            this.errorSpeedDecreaseLabel = new System.Windows.Forms.Label();
            this.LProgressSpdChangeGroupSett.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startSpeedTextBox
            // 
            this.startSpeedTextBox.Location = new System.Drawing.Point(89, 22);
            this.startSpeedTextBox.Name = "startSpeedTextBox";
            this.startSpeedTextBox.Size = new System.Drawing.Size(87, 23);
            this.startSpeedTextBox.TabIndex = 0;
            this.startSpeedTextBox.TextChanged += new System.EventHandler(this.startSpeedTextBox_TextChanged);
            this.startSpeedTextBox.Validated += new System.EventHandler(this.startSpeedTextBox_Validated);
            // 
            // endSpeedTextBox
            // 
            this.endSpeedTextBox.Location = new System.Drawing.Point(89, 51);
            this.endSpeedTextBox.Name = "endSpeedTextBox";
            this.endSpeedTextBox.Size = new System.Drawing.Size(87, 23);
            this.endSpeedTextBox.TabIndex = 1;
            this.endSpeedTextBox.TextChanged += new System.EventHandler(this.endSpeedTextBox_TextChanged);
            this.endSpeedTextBox.Validated += new System.EventHandler(this.endSpeedTextBox_Validated);
            // 
            // LProgressSpdChangeGroupSett
            // 
            this.LProgressSpdChangeGroupSett.Controls.Add(this.endSpeedLabel);
            this.LProgressSpdChangeGroupSett.Controls.Add(this.startSpeedLabel);
            this.LProgressSpdChangeGroupSett.Controls.Add(this.startSpeedTextBox);
            this.LProgressSpdChangeGroupSett.Controls.Add(this.endSpeedTextBox);
            this.LProgressSpdChangeGroupSett.Location = new System.Drawing.Point(12, 12);
            this.LProgressSpdChangeGroupSett.Name = "LProgressSpdChangeGroupSett";
            this.LProgressSpdChangeGroupSett.Size = new System.Drawing.Size(200, 100);
            this.LProgressSpdChangeGroupSett.TabIndex = 2;
            this.LProgressSpdChangeGroupSett.TabStop = false;
            this.LProgressSpdChangeGroupSett.Text = "progress speed changing";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorSpeedDecreaseLabel);
            this.groupBox1.Controls.Add(this.fullTresholdLabel);
            this.groupBox1.Controls.Add(this.startTresholdLabel);
            this.groupBox1.Controls.Add(this.maxErrorSpeedDecreaseBox);
            this.groupBox1.Controls.Add(this.errorDecreaseFullTresholdBox);
            this.groupBox1.Controls.Add(this.errorDecreaseStartTresholdBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 139);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "error speed correction";
            // 
            // errorDecreaseStartTresholdBox
            // 
            this.errorDecreaseStartTresholdBox.Location = new System.Drawing.Point(89, 37);
            this.errorDecreaseStartTresholdBox.Name = "errorDecreaseStartTresholdBox";
            this.errorDecreaseStartTresholdBox.Size = new System.Drawing.Size(87, 23);
            this.errorDecreaseStartTresholdBox.TabIndex = 0;
            this.errorDecreaseStartTresholdBox.TextChanged += new System.EventHandler(this.errorDecreaseStartTresholdBox_TextChanged);
            this.errorDecreaseStartTresholdBox.Validated += new System.EventHandler(this.errorDecreaseStartTresholdBox_Validated);
            // 
            // errorDecreaseFullTresholdBox
            // 
            this.errorDecreaseFullTresholdBox.Location = new System.Drawing.Point(89, 67);
            this.errorDecreaseFullTresholdBox.Name = "errorDecreaseFullTresholdBox";
            this.errorDecreaseFullTresholdBox.Size = new System.Drawing.Size(87, 23);
            this.errorDecreaseFullTresholdBox.TabIndex = 1;
            this.errorDecreaseFullTresholdBox.TextChanged += new System.EventHandler(this.errorDecreaseFullTresholdBox_TextChanged);
            this.errorDecreaseFullTresholdBox.Validated += new System.EventHandler(this.errorDecreaseFullTresholdBox_Validated);
            // 
            // maxErrorSpeedDecreaseBox
            // 
            this.maxErrorSpeedDecreaseBox.Location = new System.Drawing.Point(89, 110);
            this.maxErrorSpeedDecreaseBox.Name = "maxErrorSpeedDecreaseBox";
            this.maxErrorSpeedDecreaseBox.Size = new System.Drawing.Size(87, 23);
            this.maxErrorSpeedDecreaseBox.TabIndex = 2;
            this.maxErrorSpeedDecreaseBox.TextChanged += new System.EventHandler(this.maxErrorSpeedDecreaseBox_TextChanged);
            this.maxErrorSpeedDecreaseBox.Validated += new System.EventHandler(this.maxErrorSpeedDecreaseBox_Validated);
            // 
            // startSpeedLabel
            // 
            this.startSpeedLabel.AutoSize = true;
            this.startSpeedLabel.Location = new System.Drawing.Point(6, 30);
            this.startSpeedLabel.Name = "startSpeedLabel";
            this.startSpeedLabel.Size = new System.Drawing.Size(64, 15);
            this.startSpeedLabel.TabIndex = 2;
            this.startSpeedLabel.Text = "start speed";
            // 
            // endSpeedLabel
            // 
            this.endSpeedLabel.AutoSize = true;
            this.endSpeedLabel.Location = new System.Drawing.Point(6, 59);
            this.endSpeedLabel.Name = "endSpeedLabel";
            this.endSpeedLabel.Size = new System.Drawing.Size(61, 15);
            this.endSpeedLabel.TabIndex = 3;
            this.endSpeedLabel.Text = "end speed";
            // 
            // startTresholdLabel
            // 
            this.startTresholdLabel.AutoSize = true;
            this.startTresholdLabel.Location = new System.Drawing.Point(7, 45);
            this.startTresholdLabel.Name = "startTresholdLabel";
            this.startTresholdLabel.Size = new System.Drawing.Size(74, 15);
            this.startTresholdLabel.TabIndex = 3;
            this.startTresholdLabel.Text = "min treshold";
            // 
            // fullTresholdLabel
            // 
            this.fullTresholdLabel.AutoSize = true;
            this.fullTresholdLabel.Location = new System.Drawing.Point(7, 75);
            this.fullTresholdLabel.Name = "fullTresholdLabel";
            this.fullTresholdLabel.Size = new System.Drawing.Size(76, 15);
            this.fullTresholdLabel.TabIndex = 4;
            this.fullTresholdLabel.Text = "max treshold";
            // 
            // errorSpeedDecreaseLabel
            // 
            this.errorSpeedDecreaseLabel.AutoSize = true;
            this.errorSpeedDecreaseLabel.Location = new System.Drawing.Point(7, 117);
            this.errorSpeedDecreaseLabel.Name = "errorSpeedDecreaseLabel";
            this.errorSpeedDecreaseLabel.Size = new System.Drawing.Size(61, 15);
            this.errorSpeedDecreaseLabel.TabIndex = 5;
            this.errorSpeedDecreaseLabel.Text = "max value";
            // 
            // LearningSpeedSetupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 273);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LProgressSpdChangeGroupSett);
            this.Name = "LearningSpeedSetupWindow";
            this.Text = "LearningSpeedSetupWindow";
            this.LProgressSpdChangeGroupSett.ResumeLayout(false);
            this.LProgressSpdChangeGroupSett.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox startSpeedTextBox;
        private System.Windows.Forms.TextBox endSpeedTextBox;
        private System.Windows.Forms.GroupBox LProgressSpdChangeGroupSett;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox maxErrorSpeedDecreaseBox;
        private System.Windows.Forms.TextBox errorDecreaseFullTresholdBox;
        private System.Windows.Forms.TextBox errorDecreaseStartTresholdBox;
        private System.Windows.Forms.Label endSpeedLabel;
        private System.Windows.Forms.Label startSpeedLabel;
        private System.Windows.Forms.Label errorSpeedDecreaseLabel;
        private System.Windows.Forms.Label fullTresholdLabel;
        private System.Windows.Forms.Label startTresholdLabel;
    }
}