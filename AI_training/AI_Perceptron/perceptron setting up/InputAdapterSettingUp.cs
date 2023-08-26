using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron.perceptron_setting_up
{
    public class InputAdapterSettingUp
    {
        private TextBox inputTextBox;
        private TextBox outputTextBox;
        private Button connectButton;
        private RichTextBox connectedAdapterDetails;
        public InputAdapterSettingUp(TextBox inputTextBox, TextBox outputTextBox, Button connectButton, RichTextBox connectedAdapterDetails)
        {
            this.inputTextBox = inputTextBox;
            this.outputTextBox = outputTextBox;
            this.connectButton = connectButton;
            this.connectedAdapterDetails = connectedAdapterDetails;
            inputTextBox.TextChanged += inputValueChanged;
            inputTextBox.Validated += inputValueValidated;
            outputTextBox.TextChanged += outputValueChanged;
            outputTextBox.Validated += outputValueValidated;

            connectButton.Enabled = false;
            connectButton.Click += connectButtonClicked;

            outputTextBox.Text = OutputCount.ToString();
        }

        private int InputCount;
        private void inputValueChanged(object sender, EventArgs args)
        {
            int newValue;
            if(int.TryParse(inputTextBox.Text, out newValue))
            {
                if (InputCount == newValue) return;
                InputCount = newValue;
                updateConnectButState();
            }
        }

        private void inputValueValidated(object sender, EventArgs args)
        {
            inputTextBox.Text = InputCount.ToString();
        }


        private int OutputCount = 1;
        private void outputValueChanged(object sender, EventArgs args)
        {
            int newValue;
            if (int.TryParse(outputTextBox.Text, out newValue))
            {
                if (OutputCount == newValue) return;
                OutputCount = newValue;
                updateConnectButState();
            }
        }

        private void outputValueValidated(object sender, EventArgs args)
        {
            outputTextBox.Text = OutputCount.ToString();
        }


        private void updateConnectButState()
        {
            if (InputCount == 0 || OutputCount == 0)
            {
                connectButton.Enabled = false;
                return;
            }
            if(perceptron == null)
            {
                connectButton.Enabled = false;
                return;
            }
            if (perceptron.DataAdapter != null && perceptron.DataAdapter.inputValuesCount == InputCount &&
                perceptron.DataAdapter.outputValuesCount == OutputCount)
            {
                connectButton.Enabled = false;
                return;
            }

            connectButton.Enabled = true;
        }

        private void connectButtonClicked(object sender, EventArgs args)
        {
            connectButton.Enabled = false;
            DataAdapter adapter = new DataAdapterSomeToOne(InputCount, 1);
            perceptron.setDataAdapter(adapter);
            showDetails(adapter);
        }


        private void showDetails(DataAdapter adapter)
        {
            if(adapter == null)
            {
                connectedAdapterDetails.Text = "no adapter connected";
                return;
            }
            connectedAdapterDetails.Text = "Adapter connected: i-" + adapter.inputValuesCount + " o-" + adapter.outputValuesCount;
        }

        private Perceptron perceptron;
        public void ConnectPerceptron(Perceptron perceptron)
        {
            this.perceptron = perceptron;
            if (perceptron != null)
            {
                showDetails(perceptron.DataAdapter);
            }

            updateConnectButState();
        }
    }
}
