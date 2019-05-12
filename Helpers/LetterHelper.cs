using System;
using System.IO;

namespace AdalineOCRNetwork.Helpers {
    public static class LetterHelper {
        public static double[] ReadLetterFromFile (string filePath) {
            var letter = File.ReadAllText (filePath)
                .Replace ("\r\n", string.Empty)
                .Replace ('-', '0')
                .Replace ('#', '1');                
            Console.WriteLine (letter);

            return null;
        }
    }
}