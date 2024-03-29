﻿
namespace CryptoAnalizerAI
{
    partial class ChronometerWindow
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
            this.components = new System.ComponentModel.Container();
            this.FixedUpdate = new System.Windows.Forms.Timer(this.components);
            this.UpdateWhileVisible = new System.Windows.Forms.Timer(this.components);
            this.SvaeBut = new System.Windows.Forms.Button();
            this.timerText = new System.Windows.Forms.TextBox();
            this.FIxedUpdateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.recordedTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FixedUpdate
            // 
            this.FixedUpdate.Enabled = true;
            this.FixedUpdate.Interval = 200;
            this.FixedUpdate.Tick += new System.EventHandler(this.FixedUpdate_Tick);
            // 
            // UpdateWhileVisible
            // 
            this.UpdateWhileVisible.Tick += new System.EventHandler(this.UpdateWhileVisible_Tick);
            // 
            // SvaeBut
            // 
            this.SvaeBut.Location = new System.Drawing.Point(43, 58);
            this.SvaeBut.Name = "SvaeBut";
            this.SvaeBut.Size = new System.Drawing.Size(123, 23);
            this.SvaeBut.TabIndex = 0;
            this.SvaeBut.Text = "Save recordings";
            this.SvaeBut.UseVisualStyleBackColor = true;
            this.SvaeBut.Click += new System.EventHandler(this.saveRocordings);
            // 
            // timerText
            // 
            this.timerText.Location = new System.Drawing.Point(100, 12);
            this.timerText.Name = "timerText";
            this.timerText.ReadOnly = true;
            this.timerText.Size = new System.Drawing.Size(100, 23);
            this.timerText.TabIndex = 1;
            // 
            // FIxedUpdateBackgroundWorker
            // 
            this.FIxedUpdateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FIxedUpdateBackgroundWorker_DoWork);
            // 
            // recordedTimeLabel
            // 
            this.recordedTimeLabel.AutoSize = true;
            this.recordedTimeLabel.Location = new System.Drawing.Point(13, 15);
            this.recordedTimeLabel.Name = "recordedTimeLabel";
            this.recordedTimeLabel.Size = new System.Drawing.Size(81, 15);
            this.recordedTimeLabel.TabIndex = 2;
            this.recordedTimeLabel.Text = "recorded time";
            // 
            // ChronometerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 93);
            this.Controls.Add(this.recordedTimeLabel);
            this.Controls.Add(this.timerText);
            this.Controls.Add(this.SvaeBut);
            this.Name = "ChronometerWindow";
            this.Text = "Chronometer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chronometer_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.ChronometerWindow_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer FixedUpdate;
        private System.Windows.Forms.Timer UpdateWhileVisible;
        private System.Windows.Forms.Button SvaeBut;
        private System.Windows.Forms.TextBox timerText;
        private System.ComponentModel.BackgroundWorker FIxedUpdateBackgroundWorker;
        private System.Windows.Forms.Label recordedTimeLabel;
    }
}