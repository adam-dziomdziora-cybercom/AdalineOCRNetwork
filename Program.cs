using System;
using AdalineOCRNetwork.Models;

namespace AdalineOCRNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Neuron n = new Neuron("Letters\\A.txt");
        }
    }
}
