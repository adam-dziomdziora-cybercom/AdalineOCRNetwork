using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdalineOCRNetwork.Models {
    public class Network {
        private int letterSize;

        public List<Neuron> Neurons { get; private set; } = new List<Neuron> ();

        public Network () {

        }

        public Network (string lettersDirectory) {
            var letterFilePaths = Directory.EnumerateFiles (lettersDirectory, "*.txt").ToArray ();
            if (AreAllNeuronsSameSize ()) {
                letterSize = Neurons.FirstOrDefault ().Weights.Length;
            } else {
                var ex = string.Format ("Nie wszystkie litery mają taki sam rozmiar");
                throw new ArgumentException (ex);
            }
        }

        private bool AreAllNeuronsSameSize () {
            var neuronsDistincsSizes = Neurons.Select (x => x.Weights.Length).Distinct ().Count ();
            return neuronsDistincsSizes == 1;
        }

    }
}