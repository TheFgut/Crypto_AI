using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CryptoAnalizerAI.AI_geneticTrainingSystem.UI
{
    class ChangeModeCheckBox
    {
        private CheckBox checkBox;
        private GeneticTrainer trainer;
        public ChangeModeCheckBox(CheckBox checkBox, GeneticTrainer trainer)
        {
            this.checkBox = checkBox;
            this.trainer = trainer;
            checkBox.CheckedChanged += checkChanged;
        }

        private void checkChanged(object sender, EventArgs args)
        {
            trainer.ChangeMode(checkBox.Checked);
        }
    }
}
