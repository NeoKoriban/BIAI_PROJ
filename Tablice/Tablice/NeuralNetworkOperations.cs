using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Neuro;
using AForge.Neuro.Learning;

using System.Drawing;

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
        
        public float [] transformationToArray (Bitmap bmp)
        {
            Color pixelColor;

            int sizeArray = bmp.Width * bmp.Height;
            float [] array = new float[sizeArray];
            int k = 0;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    pixelColor = bmp.GetPixel(j, i);

                    if(pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                    {
                        array[k] = -0.5f;
                    }
                    else
                    {
                        array[k] = 0.5f;
                    }
                    k++;
                }
            }
                
            return array;
           
        }

        public NeuralNetworkOperations()
        {

        }

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