using System.Collections.Generic;
using System.Linq;

namespace Rainfall.App
{
    public class RainfallCalculator : IRainfallCalculator
    {
        private double[] extractedRainfalls(string townData)
        {
            List<double> rainfall = new List<double>();

            string[] monthWithRainfall = townData.Split(":")[1].Split(",");

            foreach (var month in monthWithRainfall)
            {
                string rainfallString = month.Split(" ")[1];

                rainfall.Add(double.Parse(rainfallString, System.Globalization.CultureInfo.InvariantCulture));
            }

            return rainfall.ToArray();
        }

        public double Mean(string town, string strng)
        {
            string[] townDataArray = strng.Split("\n");

            foreach (var townData in townDataArray)
            {
                if (townData.Split(":")[0].Equals(town))
                {
                    double[] rainfall = extractedRainfalls(townData);

                    double sum = rainfall.Sum();

                    return sum / (rainfall.Length);
                }
            }
            return -1;
        }

        public double Variance(string town, string strng)
        {
            string[] townDataArray = strng.Split("\n");

            foreach (var townData in townDataArray)
            {
                if (townData.Split(":")[0].Equals(town))
                {
                    double[] rainfall = extractedRainfalls(townData);

                    double mean = rainfall.Sum() / (rainfall.Length);

                    double sumOfSquareOfMeanMinusRainfall = 0;

                    foreach (var rainfallValue in rainfall)
                    {
                        sumOfSquareOfMeanMinusRainfall += (mean - rainfallValue) * (mean - rainfallValue);
                    }

                    return sumOfSquareOfMeanMinusRainfall / (rainfall.Length);
                }
            }
            return -1.0;
        }
    }
}
