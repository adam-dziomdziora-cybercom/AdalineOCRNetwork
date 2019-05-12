using System.IO;

namespace AdalineOCRNetwork.Models {
    public class Neuron {
        public double[] Weights { get; private set; }
        public string Letter { get; private set; }

        public Neuron () {

        }

        public Neuron (string filePath) {
            Letter = Path.GetFileNameWithoutExtension (filePath);
        }
    }
}