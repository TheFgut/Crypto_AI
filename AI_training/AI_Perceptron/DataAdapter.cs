using System;
using System.Collections.Generic;
using System.Text;
using CryptoAnalizerAI.Main;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{
    public abstract class DataAdapter
    {
        public int inputValuesCount { get; protected set; }

        public int outputValuesCount { get; protected set; }
        public abstract float[] Convert(float[] values);

        public abstract float[] Revert(float[] values);
    }

    public class DataAdapterSomeToOne : DataAdapter
    {
        
        public DataAdapterSomeToOne(int inputCount, int outputCount = 1)
        {
            inputValuesCount = inputCount;
            outputValuesCount = outputCount;
        }
        public override float[] Convert(float[] values)
        {
            float[] output = new float[1];

            foreach(float value in values)
            {
                output[0] += value;
            }

            return output;
        }

        public override float[] Revert(float[] values)
        {
            if (values.Length > 1) throw new ArgumentException(); 
            float[] output = new float[inputValuesCount];

            //for (int i = 0; i < inputValuesCount; i++)
            //{
            //    output[i] = Mathf.Lerp(0,values[0],(float)i/ (inputValuesCount - 1)); 
            //}
            output[output.Length - 1] = values[0];
            return output;
        }
    }
}
