using UnityEngine;

namespace Tobi {

    public static class MathsAdditions {

        // From https://answers.unity.com/questions/421968/normal-distribution-random.html
        public static float RandomGaussianMinMax(float minValue, float maxValue) {
            float u, v, S;
        
            do {
                u = 2.0f * Random.value - 1.0f;
                v = 2.0f * Random.value - 1.0f;
                S = u * u + v * v;
            } while (S >= 1.0f);
        
            // Standard Normal Distribution
            float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
        
            // Normal Distribution centered between the min and max value
            // and clamped following the "three-sigma rule"
            float mean = (minValue + maxValue) / 2.0f;
            float sigma = (maxValue - mean) / 3.0f;
            return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
        }

        public static float RandomGaussianMeanDev(float mean, float stdDev) {
            float u, v, S;
        
            do {
                u = 2.0f * Random.value - 1.0f;
                v = 2.0f * Random.value - 1.0f;
                S = u * u + v * v;
            } while (S >= 1.0f);
        
            // Standard Normal Distribution
            float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);
        
            return Mathf.Clamp(std * stdDev + mean, mean - 3 * stdDev, mean + 3 * stdDev);
        }
    }
}