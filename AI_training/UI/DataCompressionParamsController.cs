using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CryptoAnalizerAI.AI_training.CustomDatasets;

namespace CryptoAnalizerAI.AI_training
{
    class DataCompressionParamsController
    {
        private TextBox valueDisp;
        private Button applyBut;
        private DatasetManager dataManager;
        public DataCompressionParamsController(TextBox valueDisp, Button applyBut, DatasetManager dataManager, manual_AI_Trainer trainer)
        {
            this.valueDisp = valueDisp;
            this.applyBut = applyBut;
            this.dataManager = dataManager;

            valueDisp.Text = dataManager.compression.ToString();


            valueDisp.TextChanged += ValueChanged;
            valueDisp.Validated += ValueValidated;

            applyBut.Click += ApplyClicked;

            ///to do for different threads defence
            //trainer.onTrainingStart += Disable;
            //trainer.onTrainingEnd += Enable;
        }

        private void ValueChanged(object sender, EventArgs args)
        {
            int newValue;
            if(int.TryParse(valueDisp.Text, out newValue) && enabled)
            {
                if (newValue == dataManager.compression)
                {
                    applyBut.Enabled = false;
                }
                else
                {
                    applyBut.Enabled = true;
                }
            }
            else if(applyBut.Enabled)
            {
                applyBut.Enabled = false;
            }
        }

        private void ValueValidated(object sender, EventArgs args)
        {
            int newValue;
            if (!int.TryParse(valueDisp.Text, out newValue))
            {
                valueDisp.Text = dataManager.compression.ToString();
                applyBut.Enabled = false;
            }
        }

        private void ApplyClicked(object sender, EventArgs args)
        {
            dataManager.setCompression(int.Parse(valueDisp.Text));
            applyBut.Enabled = false;
        }

        private bool enabled = true;
        private void Enable()
        {
            enabled = true;
            valueDisp.ReadOnly = false;
            ValueChanged(null, null);
        }

        private void Disable()
        {
            enabled = false;
            valueDisp.ReadOnly = true;
            applyBut.Enabled = false;
        }
    }
}
