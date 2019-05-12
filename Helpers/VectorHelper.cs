using System;
using System.Linq;

namespace AdalineOCRNetwork.Helpers {
    public static class VectorHelper {
        public static void NormalizeVector (double[] weights) {
            var vectorlength = Math.Sqrt (weights.Sum (x => x * x));

            if (vectorlength == 0) return;

            while (!IsNormalized (vectorlength)) {
                for (int i = 0; i < weights.Length; i++) {
                    weights[i] /= vectorlength;
                }
                vectorlength = Math.Sqrt (weights.Sum (x => x * x));
            }
        }
        public static bool IsNormalized (double vectorLength) {
            var t1 = Math.Round (vectorLength - 1, 2);
            return t1 < 0.1;
        }
    }
}