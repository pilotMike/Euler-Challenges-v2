using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Extensions;

namespace EulerTools.Formulas
{
    public static class TriangularFormulas
    {
        public static long TriangularNumber(long n)
        {
            long output;
            checked
            {
                output = n*(n + 1)/2;
            }
            return output;
        }

        //public static BigInteger TriangularNumberBig(long n)
        //{
        //    BigInteger a = n;
        //    return a*(a + 1)/2;
        //}

        public static bool IsTriangular(long x)
        {
            return ((Math.Sqrt(8*x + 1) - 1)/2)%1 == 0;
        }

        //private static bool IsTriangularBig(BigInteger x)
        //{
        //    return ((MyExtensions.Sqrt(8*x + 1) - 1) >> 1)%1 == 0;
        //}
    }
}
