using System;
using System.Collections.Generic;
using System.Linq;

namespace Rainfall.App
{
    public class RainfallCalculator : IRainfallCalculator
    {
        private double[] extractedRainfalls(string town, string strng)
        {
            List<double> rainfall = new List<double>();

            string[] townDataArray = strng.Split("\n");

            foreach (var townData in townDataArray)
            {
                string[] monthWithRainfall = townData.Split(":")[1].Split(",");

                if (townData.Split(":")[0].Equals(town))
                {
                    foreach (var month in monthWithRainfall)
                    {
                        string rainfallString = month.Split(" ")[1];

                        rainfall.Add(double.Parse(rainfallString, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
            }

            return rainfall.ToArray();
        }

        public double Mean(string town, string strng)
        {
            double[] rainfall = extractedRainfalls(town, strng);

            if (rainfall.Length > 0)
            {
                double sum = rainfall.Sum();

                return sum / (rainfall.Length);
            }
            return -1;
        }

        public double Variance(string town, string strng)
        {
            double[] rainfall = extractedRainfalls(town, strng);

            if (rainfall.Length > 0)
            {
                double mean = rainfall.Sum() / (rainfall.Length);

                double sumOfSquareOfMeanMinusRainfall = 0;

                foreach (var rainfallValue in rainfall)
                {
                    sumOfSquareOfMeanMinusRainfall += Math.Pow((mean - rainfallValue),2);
                }

                return sumOfSquareOfMeanMinusRainfall / (rainfall.Length);

            }
            return -1.0;
        }
    }
}
