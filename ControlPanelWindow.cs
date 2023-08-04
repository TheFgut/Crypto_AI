using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using CryptoAnalizerAI.AI_training.dataset_loading;
using CryptoAnalizerAI.AI_training;

using CryptoAnalizerAI.settings;

namespace CryptoAnalizerAI
{
    public partial class ControlPanelWindow : Form
    {
        public static BinanceWebParser webParser { get; private set; }
        private Settings basicSettings;
        private const string basicSetSaveFileDestination = "settings\\";
        private LoaderAndSaver<Settings> settingsLoaderAndSaver;
        public ControlPanelWindow()
        {
            //
            settingsLoaderAndSaver = new LoaderAndSaver<Settings>(basicSetSaveFileDestination, "basicSettings.txt");
            basicSettings = settingsLoaderAndSaver.loadObject();
            if (basicSettings == null)
            {
                basicSettings = new Settings();
            }
            //подключение драйвера и открытие сайта валюты
            //webParser = new BinanceWebParser(basicSettings.choosedPair);
            InitializeComponent();

        }

        //chronometer control

        private Chronometer chronometerWindow;
        private void ChronometerSwitchBut_Click(object sender, EventArgs e)
        {
            if(chronometerWindow == null)
            {
                chronometerWindow = new Chronometer(webParser);
                ChronometerSwitchBut.Text = "OFF";
                openChronometrSettingsBut.Enabled = true;
                ChronometerSwitchBut.BackColor = Color.Yellow;
            }
            else
            {
                ChronometerSwitchBut.Text = "ON";
                chronometerWindow.Close();
                openChronometrSettingsBut.Enabled = false;
                ChronometerSwitchBut.BackColor = Color.White;

                chronometerWindow = null;
            }
        }


        private void openChronometrSettingsBut_Click(object sender, EventArgs e)
        {
            if (chronometerWindow != null)
            {
                chronometerWindow.Show();
            }

        }

        //updates

        private void FixedUpdate_Tick(object sender, EventArgs e)
        {
            if (chronometerWindow != null)
            {
                textDisplay.Text = chronometerWindow.timer.ToString();
            }

        }





        //Form loaded/closed

        private void ControlPanel_Load(object sender, EventArgs e)
        {

        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(webParser != null)
            {
                webParser.Close();
            }
        }


        //Settings

        private settingsWindow basicSettingsWindow;
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (basicSettingsWindow == null)
            {
                basicSettingsWindow = new settingsWindow(basicSettings, settingsLoaderAndSaver);
                basicSettingsWindow.FormClosed += settingsClosed;
                basicSettingsWindow.Show();
            }


        }

        private void settingsClosed(object sender, EventArgs e)
        {
            basicSettingsWindow.FormClosed -= settingsClosed;
            basicSettingsWindow = null;


        }

        private void restartBut_Click(object sender, EventArgs e)
        {
            Process oldProcess = Process.GetCurrentProcess();
            oldProcess.WaitForExit(1000);

            Application.Exit();
            Process.Start(Application.ExecutablePath);
        }

        //AI training
        TrainingWindow trainingWindow;
        private void AI_TrainingBut_Click(object sender, EventArgs e)
        {
            if(trainingWindow == null)
            {
                trainingWindow = new TrainingWindow();
                trainingWindow.Show();
                trainingWindow.FormClosed += TrainingWindowClosed;
            }
        }

        private void TrainingWindowClosed(object sender, EventArgs e)
        {
            trainingWindow.FormClosed -= TrainingWindowClosed;
            trainingWindow = null;
        }

        private void WebModuleSwitchButton_Click(object sender, EventArgs e)
        {

        }
    }


}
