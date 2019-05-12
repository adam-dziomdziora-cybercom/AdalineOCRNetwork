using System;
using System.IO;
using AdalineOCRNetwork.Helpers;

namespace AdalineOCRNetwork.Models {
    public class Neuron {
        public double[] Weights { get; private set; }
        public string Letter { get; private set; }

        public Neuron () {

        }

        public Neuron (string filePath) {
            Letter = Path.GetFileNameWithoutExtension (filePath);
            Console.WriteLine(Letter);
            Weights = LetterHelper.ReadLetterFromFile(filePath);
            VectorHelper.NormalizeVector(Weights);
        }

     
    }
}