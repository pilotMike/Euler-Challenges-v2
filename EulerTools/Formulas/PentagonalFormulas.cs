using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Extensions;

namespace EulerTools.Numbers
{
    public static class PentagonalFormulas
    {
        public static int PentagonalFormula(int n)
        {
            return n*(3*n - 1)/2;
        }

        /// <summary>
        /// Formula to intvert a pentagonal number is
        /// sqrt(24x + 1) + 1
        /// divided by 6.
        /// 
        /// We check to see if the number is indeed divisible by six by using modulus 1 == 0.
        /// </summary>
        /// <see cref="http://www.mathblog.dk/project-euler-44-smallest-pair-pentagonal-numbers/"/>
        /// <remarks>
        /// original code: 
        /// double penTest = (Math.Sqrt(1 + 24 * number) + 1.0) / 6.0;
        /// return penTest == ((int)penTest);
        /// </remarks>
        public static bool IsPentagonal(long n)
        {
            return ((Math.Sqrt(1 + 24*n) + 1)/6)%1 == 0;
        }

        //public static bool IsPentagonalBig(BigInteger n)
        //{
        //    return ((MyExtensions.Sqrt(1 + 24*n) + 1)/6)%1 == 0;
        //}

        public static double UndoPentagonal(long n)
        {
            return ((Math.Sqrt(1 + 24*n) + 1)/6);
        }
    }
}
