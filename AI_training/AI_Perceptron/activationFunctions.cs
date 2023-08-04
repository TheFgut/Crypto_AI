using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{
    public abstract class activationFunction
    {
        public abstract float get(float value);
        public abstract float derivative(float value);
    }

    public class hyperbolicTan : activationFunction
    {
        public override float get(float value)
        {
            if (Math.Abs(value) > 10)
            {
                return 1 * Math.Sign(value);
            }
            double eX = Math.Pow(Math.E, value);
            double eMinusX = Math.Pow(Math.E, -value);
            float ret = (float)((eX - eMinusX) / (eX + eMinusX));
            return ret;
        }

        public override float derivative(float value)
        {
            return (float)(1 / (Math.Pow((Math.Pow(Math.E, value)
                + Math.Pow(Math.E, -value)) / 2, 2)));
        }
    }
}
