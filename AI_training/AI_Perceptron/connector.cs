using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{

    delegate void output<T>(T[] outData);

    delegate T activation<T>(T input);

    public delegate void perceptronOutput(float[] answers);

    public delegate void backPropagete(float[] errors);
}
