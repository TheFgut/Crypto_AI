using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.Chonometer;
using System.Threading;



namespace CryptoAnalizerAI
{
    public partial class ChronometerWindow : Form
    {
        private const string settingsLocalPath = "settings\\";

        private ChronometerSettings settings;
        private LoaderAndSaver<ChronometerSettings> chronometerSettingsLoader;
        private CourseDataRecorder recorder;
        private BinanceWebParser webParser;
        public ChronometerWindow(BinanceWebParser webParser)
        {
            this.webParser = webParser;
            //to do загрузка настроек

            chronometerSettingsLoader = new LoaderAndSaver<ChronometerSettings>(settingsLocalPath, "chronometerSettings.txt");
            settings = chronometerSettingsLoader.loadObject();
            if (settings == null)
            {
                settings = new ChronometerSettings();
            }

            recorder = new CourseDataRecorder(settings);


            InitializeComponent();

            FIxedUpdateBackgroundWorker.RunWorkerAsync();
        }

        private float previousMillisec;
        public float CheckTimePassed()//улучшение точности таймера
        {
            int now = DateTime.Now.Millisecond;
            float value = 0;
            if (previousMillisec > now)
            {
                value = ((1000 - previousMillisec) + now);
            }
            else
            {
                value = now - previousMillisec;
            }
            previousMillisec = DateTime.Now.Millisecond;
            return value / 1000;
        }

        public void saveRocordings(object sender, EventArgs e)
        {
            recorder.saveData();
        }


        public float timer { get; private set; }

        //to do remove FixedUpdate_Tick
        private void FixedUpdate_Tick(object sender, EventArgs e)
        {
            //timer += CheckTimePassed();

            //float currentCourse = webParser.curentPrice();
            //float[] buyOrders;
            //float[] sellOrders;
            //webParser.curentBinanceBuyAndSellOrders(out sellOrders, out buyOrders, settings.buyOrdersRecordDepth);
            //recorder.record(currentCourse, buyOrders, sellOrders);
        }

        
        private void Chronometer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //предотвращение закрытия формы пользователем
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                UpdateWhileVisible.Stop();
                Hide();
            }
            recorder.saveData(true);
            chronometerSettingsLoader.Save(settings);
        }




 
        private void Chronometer_Shown(object sender, EventArgs e)
        {

        }
        
        private void UpdateWhileVisible_Tick(object sender, EventArgs e)
        {
            timerText.Text = ((int)timer).ToString();
        }

        private void Chronometer_Load(object sender, EventArgs e)
        {

        }

        private void FIxedUpdateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                timer += CheckTimePassed();

                //float currentCourse = webParser.curentPrice();
                //float[] buyOrders;
                //float[] sellOrders;
                //webParser.curentBinanceBuyAndSellOrders(out sellOrders, out buyOrders, settings.buyOrdersRecordDepth);
                //recorder.record(currentCourse, buyOrders, sellOrders);
                Thread.Sleep(300);
            } while (true);

        }
        //форма прячится/ показывается
        private bool visible = false;
        private void ChronometerWindow_VisibleChanged(object sender, EventArgs e)
        {
            visible = !visible;
            if (visible)
            {
                UpdateWhileVisible.Start();
            }
        }
    }
}
