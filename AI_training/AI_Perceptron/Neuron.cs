using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.AI_training.AI_Perceptron
{
    public class Neuron
    {
        protected float num;
        public link[] links { get; protected set; }

        public virtual void Init(Neuron[] inputNeurons, bool bias, Random randomModule)
        {
            int normalNCount = inputNeurons.Length - (!bias ? 0 : 1);

            links = new link[inputNeurons.Length];
            for (int i = 0; i < normalNCount; i++)
            {
                links[i] = new link(inputNeurons[i]);
                links[i].addToWeigth((float)randomModule.NextDouble());
            }
            if (bias)
            {
                links[normalNCount] = new link(inputNeurons[normalNCount]);
                links[normalNCount].addToWeigth((float)randomModule.NextDouble());
            }
        }


        public void setWeigths(float[] weigths)
        {
            for (int i = 0; i < weigths.Length; i++)
            {
                links[i].setWeigth(weigths[i]);
            }
        }


        public float getNum()
        {
            return num;
        }

        internal void setNum(float num)
        {
            this.num = num;
        }

        public float error { get; protected set; }

        public void increaseError(float value)
        {
            error += value;
        }
        public void clearError()
        {
            error = 0;
        }

        //abstracts
        public virtual void backPropagate(float error, float learningSpeed)
        {
            for (int i = 0; i < links.Length; i++)
            {
                links[i].neuron.increaseError(links[i].weigth * error);
                links[i].addToWeigth(-links[i].neuron.getNum() * error * learningSpeed);
            }

        }


        public virtual float Calculate(activationFunction activationFunc)
        {

            float sum = GetInputSum(links);
            num = activationFunc.get(sum);
            return num;
        }

        protected float GetInputSum(link[] links)
        {
            float[] input = getInputs(links);
            float sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * links[i].weigth;
            }
            return sum;
        }

        private float[] getInputs(link[] links)
        {
            float[] inputs = new float[links.Length];
            for (int i = 0; i < links.Length; i++)
            {
                inputs[i] = links[i].output;
            }
            return inputs;
        }

        public class link
        {
            public float weigth { get; private set; }
            public Neuron neuron { get; private set; }

            public virtual float output { get { return neuron.getNum(); } }
            public link(Neuron neuron)
            {
                this.neuron = neuron;
                weigth = 0;
            }

            public void addToWeigth(float value)
            {
                weigth += value;
            }

            internal void setWeigth(float weigth)
            {
                this.weigth = weigth;
            }
        }

        
    }


    public class RNeuron : Neuron
    {
        private link[] memoryLinks;
        public override void Init(Neuron[] inputNeurons, bool bias, Random randomModule)
        {
            int normalNCount = inputNeurons.Length - (!bias ? 0 : 1);

            links = new link[inputNeurons.Length];
            for (int i = 0; i < normalNCount; i++)
            {
                links[i] = new link(inputNeurons[i]);
                links[i].addToWeigth((float)randomModule.NextDouble());
            }
            if (bias)
            {
                links[normalNCount] = new link(inputNeurons[normalNCount]);
                links[normalNCount].addToWeigth((float)randomModule.NextDouble());
            }

            memoryLinks = new link[inputNeurons.Length];
            for (int i = 0; i < normalNCount; i++)
            {
                memoryLinks[i] = new MemoryLink((RNeuron)inputNeurons[i]);
                memoryLinks[i].addToWeigth((float)randomModule.NextDouble());
            }
            if (bias)
            {
                memoryLinks[normalNCount] = new link(inputNeurons[normalNCount]);
                memoryLinks[normalNCount].addToWeigth((float)randomModule.NextDouble());
            }
        }

        private float memory { get
            {
                float m = 0;
                float coef = memoryDrag;
                for (int i = memoryElements.Count - 1; i >= 0;i--)
                {
                    m += memoryElements[i] * coef;
                    coef += memoryDrag;
                }
                return m;
            }
            set
            {
                if (memoryElements.Count >= memoryDuration)
                {
                    memoryElements.RemoveAt(0);
                }
                memoryElements.Add(value);
            }
        }
        private List<float> memoryElements = new List<float>();
        private const int memoryDuration = 10;
        private const float memoryDrag = 0.1f;

        public virtual float memoryOutput { get { return memory; } }
        public override float Calculate(activationFunction activationFunc)
        {
            float inputsSum = GetInputSum(links);
            float memorySum = GetInputSum(memoryLinks);

            memory = activationFunc.get(inputsSum + memorySum);
            num =  memory;
            return memory;
        }

        protected class MemoryLink : link
        {
            private RNeuron rN;
            public MemoryLink(RNeuron neuron) : base(neuron)
            {
                rN = neuron;
            }


            public override float output { get { return rN.memoryOutput; } }
        }

    }

    public class Bias : Neuron
    {
        public override void Init(Neuron[] inputNeurons, bool bias, Random randomModule)
        {
            
        }

        public override float Calculate(activationFunction activationFunc)
        {
            num = 1;
            return num;
        }

        public override void backPropagate(float error, float learningSpeed)
        {
            return;

        }
    }
}
