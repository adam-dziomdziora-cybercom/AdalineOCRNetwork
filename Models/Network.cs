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

        }

    }
}