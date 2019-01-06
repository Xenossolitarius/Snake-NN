using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEvo
{
   public class NeuralNet
    {
        int iNodes; // ulaz
        int hNodes; // nevidlji sloj
        int oNodes; // izlaz

       public Matrix whi; // matrica sa utezima između ulaza i nevidljivog sloja
       public Matrix whh; // prva matrica sa utezima između nevidljivog slojeva
       public Matrix woh; // matrica sa utezima između drugog sloja i izlaza

        public NeuralNet(int inputs, int hiddenNo, int outputNo)
        {
            iNodes = inputs;
            oNodes = outputNo;
            hNodes = hiddenNo;

            //kreiranja utega i dodavanje biasa

            whi = new Matrix(hNodes, iNodes + 1);

            whh = new Matrix(hNodes, hNodes + 1);

            woh = new Matrix(oNodes, hNodes + 1);

            //postavljanje nasumičnih vrijednosti

            whi.Randomize();
            whh.Randomize();
            woh.Randomize();


        }
        public void Mutate(float mr)
        {
            //mutira svaki uteg
            whi.Mutate(mr);
            whh.Mutate(mr);
            woh.Mutate(mr);
        }
        //izračun izlaza kroz neuralnu mrežu
        public float[] Output(float[] inputsArr)
        {
            Matrix inputs = woh.SingleColumnMatrixFromArray(inputsArr); // woh je nebitan
            //dodaj bias
            Matrix inputsBias = inputs.AddBias();
            //primjena utega
            Matrix hiddenInputs = whi.Dot(inputsBias);
            //sigmoid
            Matrix hiddenOutputs = hiddenInputs.Activate();
            //dodaj bias
            Matrix hiddenOutputsBias = hiddenOutputs.AddBias();
            //primjena utega
            Matrix hiddenInputs2 = whh.Dot(hiddenOutputsBias);
            //sigmoid
            Matrix hiddenOutputs2 = hiddenInputs2.Activate();
            //dodaj bias
            Matrix hiddenOutputsBias2 = hiddenOutputs2.AddBias();
            //primjena utega
            Matrix outputInputs = woh.Dot(hiddenOutputsBias2);
            //sigmoid
            Matrix outputs = outputInputs.Activate();
            //vračanje polja sa rezultatima
            return outputs.ToArray();

        }

        public NeuralNet Crossover (NeuralNet partner)
        {
            NeuralNet child = new NeuralNet(iNodes, hNodes, oNodes);
            //svi utezi 
            child.whi = whi.Crossover(partner.whi);
            child.whh = whh.Crossover(partner.whh);
            child.woh = woh.Crossover(partner.woh);

            return child;
        }
        public NeuralNet Clone()
        {
            NeuralNet clone = new NeuralNet(iNodes, hNodes, oNodes);

            clone.whi = whi.Clone();
            clone.whh = whh.Clone();
            clone.woh = woh.Clone();

            return clone;

        }

    }
}
