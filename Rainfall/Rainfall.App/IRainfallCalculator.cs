using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.App
{
    public interface IRainfallCalculator
    {
        double Mean(string town, string strng);

        double Variance(string town, string strng);
    }
}
