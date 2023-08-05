
namespace CryptoAnalizerAI.settings
{
    partial class settingsWindow
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
            this.mainCryptoComboBox = new System.Windows.Forms.ComboBox();
            this.comparedToCryptoComboBox = new System.Windows.Forms.ComboBox();
            this.saveBut = new System.Windows.Forms.Button();
            this.closeBut = new System.Windows.Forms.Button();
            this.mainCriptoLabel = new System.Windows.Forms.Label();
            this.comparedCryptoLabel = new System.Windows.Forms.Label();
            this.cryptoChooseGroupBox = new System.Windows.Forms.GroupBox();
            this.cryptoChooseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainCryptoComboBox
            // 
            this.mainCryptoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainCryptoComboBox.FormattingEnabled = true;
            this.mainCryptoComboBox.Location = new System.Drawing.Point(16, 46);
            this.mainCryptoComboBox.Name = "mainCryptoComboBox";
            this.mainCryptoComboBox.Size = new System.Drawing.Size(121, 23);
            this.mainCryptoComboBox.TabIndex = 0;
            this.mainCryptoComboBox.SelectedIndexChanged += new System.EventHandler(this.mainCryptoComboBox_SelectedIndexChanged);
            // 
            // comparedToCryptoComboBox
            // 
            this.comparedToCryptoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comparedToCryptoComboBox.Enabled = false;
            this.comparedToCryptoComboBox.FormattingEnabled = true;
            this.comparedToCryptoComboBox.Location = new System.Drawing.Point(155, 46);
            this.comparedToCryptoComboBox.Name = "comparedToCryptoComboBox";
            this.comparedToCryptoComboBox.Size = new System.Drawing.Size(121, 23);
            this.comparedToCryptoComboBox.TabIndex = 1;
            this.comparedToCryptoComboBox.SelectedIndexChanged += new System.EventHandler(this.comparedToCryptoComboBox_SelectedIndexChanged);
            // 
            // saveBut
            // 
            this.saveBut.Enabled = false;
            this.saveBut.Location = new System.Drawing.Point(28, 138);
            this.saveBut.Name = "saveBut";
            this.saveBut.Size = new System.Drawing.Size(137, 23);
            this.saveBut.TabIndex = 2;
            this.saveBut.Text = "Save";
            this.saveBut.UseVisualStyleBackColor = true;
            this.saveBut.Click += new System.EventHandler(this.save_Click);
            // 
            // closeBut
            // 
            this.closeBut.Location = new System.Drawing.Point(221, 138);
            this.closeBut.Name = "closeBut";
            this.closeBut.Size = new System.Drawing.Size(85, 23);
            this.closeBut.TabIndex = 3;
            this.closeBut.Text = "Close";
            this.closeBut.UseVisualStyleBackColor = true;
            this.closeBut.Click += new System.EventHandler(this.closeBut_Click);
            // 
            // mainCriptoLabel
            // 
            this.mainCriptoLabel.AutoSize = true;
            this.mainCriptoLabel.Location = new System.Drawing.Point(48, 28);
            this.mainCriptoLabel.Name = "mainCriptoLabel";
            this.mainCriptoLabel.Size = new System.Drawing.Size(43, 15);
            this.mainCriptoLabel.TabIndex = 4;
            this.mainCriptoLabel.Text = "Crypto";
            // 
            // comparedCryptoLabel
            // 
            this.comparedCryptoLabel.AutoSize = true;
            this.comparedCryptoLabel.Location = new System.Drawing.Point(187, 28);
            this.comparedCryptoLabel.Name = "comparedCryptoLabel";
            this.comparedCryptoLabel.Size = new System.Drawing.Size(55, 15);
            this.comparedCryptoLabel.TabIndex = 5;
            this.comparedCryptoLabel.Text = "Currency";
            // 
            // cryptoChooseGroupBox
            // 
            this.cryptoChooseGroupBox.Controls.Add(this.mainCryptoComboBox);
            this.cryptoChooseGroupBox.Controls.Add(this.comparedCryptoLabel);
            this.cryptoChooseGroupBox.Controls.Add(this.mainCriptoLabel);
            this.cryptoChooseGroupBox.Controls.Add(this.comparedToCryptoComboBox);
            this.cryptoChooseGroupBox.Location = new System.Drawing.Point(12, 23);
            this.cryptoChooseGroupBox.Name = "cryptoChooseGroupBox";
            this.cryptoChooseGroupBox.Size = new System.Drawing.Size(294, 98);
            this.cryptoChooseGroupBox.TabIndex = 6;
            this.cryptoChooseGroupBox.TabStop = false;
            this.cryptoChooseGroupBox.Text = "Crypto pair";
            // 
            // settingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 195);
            this.Controls.Add(this.cryptoChooseGroupBox);
            this.Controls.Add(this.closeBut);
            this.Controls.Add(this.saveBut);
            this.Name = "settingsWindow";
            this.Text = "settingsWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settings_FormClosing);
            this.Load += new System.EventHandler(this.settingsWindow_Load);
            this.cryptoChooseGroupBox.ResumeLayout(false);
            this.cryptoChooseGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox mainCryptoComboBox;
        private System.Windows.Forms.ComboBox comparedToCryptoComboBox;
        private System.Windows.Forms.Button saveBut;
        private System.Windows.Forms.Button closeBut;
        private System.Windows.Forms.Label mainCriptoLabel;
        private System.Windows.Forms.Label comparedCryptoLabel;
        private System.Windows.Forms.GroupBox cryptoChooseGroupBox;
    }
}