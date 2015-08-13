using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Extensions
{
    public static class MyExtensions
    {
        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                var root = (BigInteger.One << (bitLength / 2));

                while (!IsSqrt(n, root))
                {
                    root += n / root;
                    root = root >> 1; //divide by two
                }

                return root;
            }

            throw new ArithmeticException("NaN");

        }

        //public static Boolean IsSqrt(BigInteger n)
        //{
        //    int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
        //    BigInteger root = BigInteger.One << (bitLength / 2);
        //    return IsSqrt(n, root);
        //}

        private static Boolean IsSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = lowerBound + root + root + 1; // original: (root + 1)*(root + 1);

            return (n >= lowerBound && n < upperBound);
        }
    }
}
