﻿
namespace CryptoAnalizerAI
{
    partial class ControlPanel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChronometerSwitchBut = new System.Windows.Forms.Button();
            this.chronometerNameBox = new System.Windows.Forms.TextBox();
            this.FixedUpdate = new System.Windows.Forms.Timer(this.components);
            this.textDisplay = new System.Windows.Forms.TextBox();
            this.openChronometrSettingsBut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartBut = new System.Windows.Forms.Button();
            this.AI_TrainingBut = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChronometerSwitchBut
            // 
            this.ChronometerSwitchBut.AccessibleDescription = "";
            this.ChronometerSwitchBut.BackColor = System.Drawing.SystemColors.Control;
            this.ChronometerSwitchBut.Location = new System.Drawing.Point(142, 27);
            this.ChronometerSwitchBut.Name = "ChronometerSwitchBut";
            this.ChronometerSwitchBut.Size = new System.Drawing.Size(75, 23);
            this.ChronometerSwitchBut.TabIndex = 0;
            this.ChronometerSwitchBut.Text = "ON";
            this.ChronometerSwitchBut.UseVisualStyleBackColor = false;
            this.ChronometerSwitchBut.Click += new System.EventHandler(this.ChronometerSwitchBut_Click);
            // 
            // chronometerNameBox
            // 
            this.chronometerNameBox.Location = new System.Drawing.Point(12, 27);
            this.chronometerNameBox.Name = "chronometerNameBox";
            this.chronometerNameBox.ReadOnly = true;
            this.chronometerNameBox.Size = new System.Drawing.Size(124, 23);
            this.chronometerNameBox.TabIndex = 1;
            this.chronometerNameBox.Text = "Course chronometer";
            // 
            // FixedUpdate
            // 
            this.FixedUpdate.Enabled = true;
            this.FixedUpdate.Tick += new System.EventHandler(this.FixedUpdate_Tick);
            // 
            // textDisplay
            // 
            this.textDisplay.Location = new System.Drawing.Point(12, 56);
            this.textDisplay.Name = "textDisplay";
            this.textDisplay.Size = new System.Drawing.Size(124, 23);
            this.textDisplay.TabIndex = 2;
            // 
            // openChronometrSettingsBut
            // 
            this.openChronometrSettingsBut.Enabled = false;
            this.openChronometrSettingsBut.Location = new System.Drawing.Point(223, 27);
            this.openChronometrSettingsBut.Name = "openChronometrSettingsBut";
            this.openChronometrSettingsBut.Size = new System.Drawing.Size(35, 23);
            this.openChronometrSettingsBut.TabIndex = 3;
            this.openChronometrSettingsBut.Text = "...";
            this.openChronometrSettingsBut.UseVisualStyleBackColor = true;
            this.openChronometrSettingsBut.Click += new System.EventHandler(this.openChronometrSettingsBut_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuToolStripItem
            // 
            this.MenuToolStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.MenuToolStripItem.Name = "MenuToolStripItem";
            this.MenuToolStripItem.Size = new System.Drawing.Size(50, 20);
            this.MenuToolStripItem.Text = "Menu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.settingsToolStripMenuItem.Text = "settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // restartBut
            // 
            this.restartBut.Location = new System.Drawing.Point(713, 415);
            this.restartBut.Name = "restartBut";
            this.restartBut.Size = new System.Drawing.Size(75, 23);
            this.restartBut.TabIndex = 5;
            this.restartBut.Text = "restart";
            this.restartBut.UseVisualStyleBackColor = true;
            this.restartBut.Click += new System.EventHandler(this.restartBut_Click);
            // 
            // AI_TrainingBut
            // 
            this.AI_TrainingBut.Location = new System.Drawing.Point(687, 27);
            this.AI_TrainingBut.Name = "AI_TrainingBut";
            this.AI_TrainingBut.Size = new System.Drawing.Size(101, 23);
            this.AI_TrainingBut.TabIndex = 6;
            this.AI_TrainingBut.Text = "AI training";
            this.AI_TrainingBut.UseVisualStyleBackColor = true;
            this.AI_TrainingBut.Click += new System.EventHandler(this.AI_TrainingBut_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AI_TrainingBut);
            this.Controls.Add(this.restartBut);
            this.Controls.Add(this.openChronometrSettingsBut);
            this.Controls.Add(this.textDisplay);
            this.Controls.Add(this.chronometerNameBox);
            this.Controls.Add(this.ChronometerSwitchBut);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ControlPanel";
            this.Text = "Control panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlPanel_FormClosing);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChronometerSwitchBut;
        private System.Windows.Forms.TextBox chronometerNameBox;
        private System.Windows.Forms.Timer FixedUpdate;
        private System.Windows.Forms.TextBox textDisplay;
        private System.Windows.Forms.Button openChronometrSettingsBut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button restartBut;
        private System.Windows.Forms.Button AI_TrainingBut;
    }
}

