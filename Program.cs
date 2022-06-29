using AdalineOCRNetwork.Helpers;
using AdalineOCRNetwork.Models;

Console.WriteLine("Hello, World!");


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