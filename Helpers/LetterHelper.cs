using System;
using System.IO;
using System.Linq;

namespace AdalineOCRNetwork.Helpers {
    public static class LetterHelper {
        public static double[] ReadLetterFromFile (string filePath) {
            var letter = File.ReadAllText (filePath)
                .Replace ("\r\n", string.Empty)
                .Replace ('-', '0')
                .Replace ('#', '1');
            if (letter.Any (c => c != '0' && c != '1')) {
                var ex = string.Format ("Plik {0} jest nieprawidłowy (zawiera znaki poza '-' i '#'", filePath);
                throw new ArgumentException (ex);
            }

            var arrayOfDigits = letter.Select (digit => (double) (digit - '0')).ToArray ();
           
            return arrayOfDigits;
        }
    }
}