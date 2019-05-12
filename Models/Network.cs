using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdalineOCRNetwork.Helpers;

namespace AdalineOCRNetwork.Models {
    public class Network {
        private int letterSize;

        public List<Neuron> Neurons { get; private set; } = new List<Neuron> ();

        public Network () {

        }

        public Network (string lettersDirectory) {
            var letterFilePaths = Directory.EnumerateFiles (lettersDirectory, "*.txt").ToArray ();

            foreach (var filePath in letterFilePaths) {
                try {
                    var neuron = new Neuron (filePath);
                    Neurons.Add (neuron);
                } catch (Exception ex) {
                    Console.WriteLine (ex);
                }
            }

            if (AreAllNeuronsSameSize ()) {
                letterSize = Neurons.FirstOrDefault ().Weights.Length;
            } else {
                var ex = string.Format ("Nie wszystkie litery mają taki sam rozmiar");
                throw new ArgumentException (ex);
            }
        }

        public void Process (double[] inputVector) {
            if (letterSize != inputVector.Length) {
                throw new ArgumentException ("Wprowadzony znak ma niepoprawny rozmiar matrycy");
            }

            var outputValues = new double[Neurons.Count];

            for (int i = 0; i < Neurons.Count; i++) {
                var neuron = Neurons[i];
                for (int j = 0; j < Neurons[i].Weights.Length; j++) {
                    outputValues[i] += neuron.Weights[j] * inputVector[j];
                }
            }

            for (int i = 0; i < outputValues.Length; i++) {
                Console.WriteLine ("{0}, zgodność w {1:P}", Neurons[i].Letter, outputValues[i]);
            }

            VectorHelper.NormalizeVector (inputVector);
        }

        private bool AreAllNeuronsSameSize () {
            var neuronsDistincsSizes = Neurons.Select (x => x.Weights.Length).Distinct ().Count ();
            return neuronsDistincsSizes == 1;
        }

    }
}