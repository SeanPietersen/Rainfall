namespace Rainfall.App
{
    public interface IRainfallCalculator
    {
        double Mean(string town, string strng);

        double Variance(string town, string strng);
    }
}
