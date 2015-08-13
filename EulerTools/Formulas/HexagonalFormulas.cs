using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Extensions;

namespace EulerTools.Formulas
{
    public static class HexagonalFormulas
    {
        public static long HexagonalFormula(long n)
        {
            return n*(2*n - 1);
        }

        public static bool IsHexagonal(long x)
        {
            return ((Math.Sqrt(8*x + 1) + 1)/4)%1 == 0;
        }

        //public static bool IsHexagonalBig(BigInteger x)
        //{
        //    return ((MyExtensions.Sqrt(8*x + 1) + 1) >> 2)%1 == 0;
        //}
    }
}
