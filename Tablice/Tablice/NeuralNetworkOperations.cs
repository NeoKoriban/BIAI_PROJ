using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Neuro;
using AForge.Neuro.Learning;
namespace Tablice
{
    class NeuralNetworkOperations
    {
        /**
        * Dobra wypadałoby jeszcze podać wartości które będą uczyć tą naszą sieć i tu jest pytanie
        * czy podajemy wartości do uczenia jako obrazy, czy po prostu od razu wartości w tablicy.
        * Znaków jest 36 (26 liter + 10 cyfr). Rozmiaru litery tzn ilości pixeli nie podawałem na sztywno
        * potem można to zmienić.
        *
        * Starałem się jakoś zastosować ten kod ze sampla http://www.codeproject.com/Articles/11285/Neural-Network-OCR
        *
        * Wieczorem jeszcze coś pokombinuję.
        *
        * */
        int characterCount = 36;
        BackPropagationLearning teacher;
        ActivationNetwork neuralNet;
        public NeuralNetworkOperations(int characterSize)
        {
            neuralNet = new ActivationNetwork(new BipolarSigmoidFunction(2.0f), characterSize, characterCount);
            neuralNet.Randomize();
            teacher = new AForge.Neuro.Learning.BackPropagationLearning(neuralNet);
        }
        public void teachNeuralNetwork(float[][] inputValue, float[][] outputValue)
        {
            // teacher.RunEpoch(inputValue, outputValue);
        }
    }
}