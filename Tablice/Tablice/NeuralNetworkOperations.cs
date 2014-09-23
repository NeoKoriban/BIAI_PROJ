using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge.Neuro;
using AForge.Neuro.Learning;

using System.Drawing;
using System.IO;

namespace Tablice
{
    class NeuralNetworkOperations
    {
        /**
         * Funkcja zmieniająca bitmapę na tablicę wartości typu double.
         * Argumenty:
         *      Bitmap bmp - przekazanie ścieżki do bitmapy.
         * Zwraca:
         *      double [] letterArray - tablica z wartościami typu double.
         * */
        public double [] transformBitmapToArray(Bitmap bmp)
        {
            Color pixelColor;
            int sizeArray = bmp.Width * bmp.Height;
            double[] letterArray = new double[sizeArray];

            int k = 0;

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    pixelColor = bmp.GetPixel(j, i);

                    if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255)
                        letterArray[k] = -0.5;
                    else
                        letterArray[k] = 0.5;
                    
                    k++;
                }
            }
            return letterArray;
        }

        /**
         * Funkcja przygotowująca listę z listą tablic double z zamienionymi literami.
         * Argumenty:
         *      string letterLink - ścieżka do źródła, gdzie znajdują się litery.
         * Zwraca:
         *      List <double[]> prepareLetterList - lista z tablicami double []
         *      z zamienionymi literami.
         * */
        public List<double[]> prepareLetterList(string letterLink)
        {
            List<double[]> list = new List<double[]>();

            string [] files = Directory.GetFiles(letterLink, "*.bmp");

            for (int i = 0; i < files.Length; i++)
            {
                Bitmap bmpLoad = new Bitmap(files[i]);
                double[] tmpArray = new double[bmpLoad.Width * bmpLoad.Height];
                tmpArray = transformBitmapToArray(bmpLoad);
                list.Add(tmpArray);
            }

            return list;
        }
        public List<double[]> prepareLetterListOutput()
        {
            List<double[]> list = new List<double[]>();

            for (int i = 0; i < 36; i++)
            {
                double[] tmpArray = new double[36];

                for (int j = 0; j < 36; j++)
                {
                    if (j == i)
                        tmpArray[j] = 0.5;
                    else
                        tmpArray[j] = -0.5;
                }

                list.Add(tmpArray);
            }

            return list;
        }
        List<double[]> treningLetterListInput;
        List<double[]> treningLetterListOutput;
        List<double[]> blobDataList;
        List<double[]> blobDataOutput;
        /**
         * Funkcja przygotowująca dane do nauczania sieci.
         * */
        public void prepareDataForTeacher()
        {
            treningLetterListInput = prepareLetterList("Letters");
            treningLetterListOutput = prepareLetterListOutput();
        }

        public void prepareBlobData()
        {
            blobDataList = prepareLetterList("BlobLetters");
        }

        public String runRecognition()
        {
            blobDataList.ForEach(delegate(double[] item)
            {
                item = neuralNet.Compute(item);
            });

            String number = "";

            blobDataList.ForEach(delegate(double[] item)
            {
                number += treningLetterListOutput.IndexOf(item).ToString();
            });

            return number;
        }
       


        int characterCount = 36;
        BackPropagationLearning teacher;
        ActivationNetwork neuralNet;


        public NeuralNetworkOperations()
        {

        }
        

        public NeuralNetworkOperations(int characterSize)
        {
            neuralNet = new ActivationNetwork(new BipolarSigmoidFunction(2.0f), characterSize, characterCount);
            neuralNet.Randomize();
            teacher = new AForge.Neuro.Learning.BackPropagationLearning(neuralNet);
            teacher.LearningRate = 0.5f;
            teacher.Momentum = 0.1f;

            prepareDataForTeacher();

            //var letters = treningLetterListInput.Zip(treningLetterListOutput, (i,o) => new { treningLetterListInput = i, treningLetterListOutput = o });

            double err = 1.0f;

            while(err > 0.1)
            {
                err = teacher.RunEpoch(treningLetterListInput.ToArray(), treningLetterListOutput.ToArray());
            }

            
        }
    }
}