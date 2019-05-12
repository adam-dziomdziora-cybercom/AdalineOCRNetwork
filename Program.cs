using System;
using System.IO;
using System.Linq;
using AdalineOCRNetwork.Helpers;
using AdalineOCRNetwork.Models;

namespace AdalineOCRNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                var network = new Network("Letters");
                var samplesPath = Directory.EnumerateFiles("Samples", "*.txt").ToArray();

                foreach (var samplePath in samplesPath)
                {
                    Console.WriteLine("==========================================");
                    Console.WriteLine("Processing " + samplePath);
                    Console.WriteLine("==========================================");

                    var sampleArray = LetterHelper.ReadLetterFromFile(samplePath);
                    network.Process(sampleArray);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
