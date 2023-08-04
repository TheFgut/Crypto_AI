using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CryptoAnalizerAI.settings
{
    public partial class settingsWindow : Form
    {
        private Settings settings;

        private LoaderAndSaver<Settings> settingsLoaderAndSaver;
        public settingsWindow(Settings current, LoaderAndSaver<Settings> settingsLoaderAndSaver)
        {
            this.settingsLoaderAndSaver = settingsLoaderAndSaver;
            settings = current;


            InitializeComponent();
            mainCryptoComboBox.DataSource = settings.awailablePairs.getAvailableMainCryptos();
            Crypto main = settings.choosedPair.first;
            mainCryptoComboBox.SelectedItem = main;
            comparedToCryptoComboBox.DataSource = settings.awailablePairs.getAvailableComparedCryptos(main);
            comparedToCryptoComboBox.SelectedItem = settings.choosedPair.second;
            comparedToCryptoComboBox.Enabled = true;
        }

        private void settingsWindow_Load(object sender, EventArgs e)
        {

        }



        //main crypto combo box controls
        private void mainCryptoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto mainCrypto = (Crypto)mainCryptoComboBox.SelectedItem;
            Crypto[] awailableComparedCryptos = settings.awailablePairs.getAvailableComparedCryptos(mainCrypto);
            comparedToCryptoComboBox.DataSource = awailableComparedCryptos;
            comparedToCryptoComboBox.Enabled = awailableComparedCryptos.Length > 1;

            settings.setCurrentPair(new CryptoPair(mainCrypto, awailableComparedCryptos[0]));

            needToRestart = true;
            saveButBecomeAwailable();
        }




        //compared crypto combo box controls

        private void comparedToCryptoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crypto mainCrypto = (Crypto)mainCryptoComboBox.SelectedItem;
            Crypto secondCrypto = (Crypto)comparedToCryptoComboBox.SelectedItem;
            settings.setCurrentPair(new CryptoPair(mainCrypto, secondCrypto));

            needToRestart = true;
            saveButBecomeAwailable();
        }

        //save but
        private bool saveAwailable = false;
        private bool needToRestart = false;
        public void saveButBecomeAwailable()
        {
            if (needToRestart)
            {
                saveBut.Text = "Save and restart";
            }
            saveAwailable = true;
            saveBut.Enabled = true;
            saveBut.BackColor = Color.Green;
        }

        public void disableSaveBut()
        {
            saveBut.Text = "Save";
            saveAwailable = false;
            saveBut.Enabled = false;
            saveBut.BackColor = SystemColors.Control;
        }

        private void save_Click(object sender, EventArgs e)
        {
            Save();
            disableSaveBut();
        }

        private void Save()
        {
            saveAwailable = false;
            settingsLoaderAndSaver.Save(settings);
            if (needToRestart)
            {
                //System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }

        }

        //close but
        private void closeBut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //closing

        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveAwailable &&
                MessageBox.Show("Do you want to exit without saving?", "Infomate", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {

            }
        }
    }

    public delegate Settings settingsUpdate();
}
