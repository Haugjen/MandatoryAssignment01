using System;
using System.Collections.Generic;
using System.Text;

namespace MA01ClassLibrary
{
    public static class MyConvert
    {
        public const double RATIO = 28.34952;

        public static double ToGrams(double ounces)
        {
            return ounces * RATIO;
        }

        public static double ToOunces(double grams)
        {
            return grams / RATIO;
        }
    }
}
