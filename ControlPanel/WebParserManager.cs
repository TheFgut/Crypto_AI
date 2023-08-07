using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using CryptoAnalizerAI;
using CryptoAnalizerAI.settings;


namespace CryptoAnalizerAI.ControlPanel
{
    public class WebParserManager
    {
        private ButtonEnableSwitch[] dependentButtons;
        private Button switchBut;

        public event closingEvent onClose;

        private Settings basicSettings;

        public WebParserManager(Button switchBut, ButtonEnableSwitch[] dependentButtons, Settings basicSettings)
        {
            this.switchBut = switchBut;
            this.dependentButtons = dependentButtons;
            this.basicSettings = basicSettings;
            switchBut.Click += Switch;
            TurnOffParser();
        }

        public bool webParserWorking { get; private set; } = false;

        private void Switch(object sender, EventArgs e)
        {
            if (webParserWorking)
            {
                TurnOffParser();
            }
            else
            {
                TurnOnParser();
            }
        }
        public static BinanceWebParser webParser { get; private set; }
        public void TurnOnParser()
        {
            EnableDependantControls();
            try
            {
                webParser = new BinanceWebParser(basicSettings.choosedPair);
                webParser.onFaultOccured += FaultTurnOff;
            }
            catch
            {
                MessageBox.Show("Browser launch error. Web module won't turn ON", "Informate", MessageBoxButtons.OK);
                return;
            }


            webParserWorking = true;
            switchBut.Text = "OFF";
            switchBut.BackColor = Color.Red;
        }

        public void TurnOffParser()
        {
            onClose?.Invoke();
            DisableDependantControls();
            if(webParser != null)
            {
                webParser.Close();
                webParser.onFaultOccured -= FaultTurnOff;
            }

            webParserWorking = false;
            switchBut.Text = "ON";
            switchBut.BackColor = Color.White;
        }

        private void FaultTurnOff()
        {
            TurnOffParser();
        }

        private void EnableDependantControls()
        {
            foreach (ButtonEnableSwitch but in dependentButtons)
            {
                but.Enable();
            }
        }

        private void DisableDependantControls()
        {
            foreach (ButtonEnableSwitch but in dependentButtons)
            {
                but.Disable();
            }
        }

        public delegate void closingEvent();
    }

    public class ButtonEnableSwitch
    {
        public Button button { get; private set; }
        public ButtonEnableSwitch(Button button)
        {
            this.button = button;
        }

        public void Enable()
        {
            button.Enabled = true;
        }

        public void Disable()
        {
            button.Enabled = false;
        }


    }
}
