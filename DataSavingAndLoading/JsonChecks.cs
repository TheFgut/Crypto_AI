using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.DataSavingAndLoading
{
    public static class JsonChecks
    {
        public static float clearInfinities(float number)
        {
            if (float.IsPositiveInfinity(number))
            {
                return number - 1;
            }
            if (float.IsNegativeInfinity(number))
            {
                return number + 1;
            }
            if (float.IsNaN(number))
            {
                return 0;
            }
            return number;
        }
    }
}
