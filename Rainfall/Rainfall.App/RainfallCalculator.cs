using System;

namespace Rainfall.App
{
    public class RainfallCalculator : IRainfallCalculator
    {
        public double Mean(string town, string strng)
        {
            string[] townDataArray = strng.Split("\n");
            foreach (var townData in townDataArray)
            {
                if(townData.Contains(town))
                {
                    string[] monthWithRainfall = townData.Split(":")[1].Split(",");
                    double sum = 0;

                    foreach (var month in monthWithRainfall)
                    {
                        string rainfall = month.Split(" ")[1];
                        sum += double.Parse(rainfall, System.Globalization.CultureInfo.InvariantCulture);
                    }

                    return sum / (monthWithRainfall.Length);                  
                }
            }
            return -1;     
        }

        public double Variance(string town, string strng)
        {
            throw new NotImplementedException();
        }
    }
}
