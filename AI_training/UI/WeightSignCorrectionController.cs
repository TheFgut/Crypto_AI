using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CryptoAnalizerAI.AI_training
{
    public class WeightSignCorrectionController
    {
        private WeightsSignCorrection corrector;
        private TextBox iterationNum;
        public WeightSignCorrectionController(WeightsSignCorrection corrector, TextBox iterationNum)
        {
            this.iterationNum = iterationNum;
            this.corrector = corrector;

            iterationNum.TextChanged += iterNumChanged;
            iterationNum.Validating += Fin;

            showIterationNUmOnDisp();
        }

        private void iterNumChanged(object sender, EventArgs args)
        {
            int newValue;
            if (iterationNum.Text == "none")
            {
                corrector.setCorrectIterationNum(-1);
            }
            if (int.TryParse(iterationNum.Text, out newValue) && newValue != corrector.correctIterationNum)
            {
                corrector.setCorrectIterationNum(newValue);
            }
        }

        private void Fin(object sender, EventArgs args)
        {
            showIterationNUmOnDisp();
        }

        private void showIterationNUmOnDisp()
        {
            int iteNum = corrector.correctIterationNum;
            if (iteNum < 0)
            {
                iterationNum.Text = "none";
            }
            else
            {
                iterationNum.Text = iteNum.ToString();
            }
        }
    }
}
