using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Fibonacci
{
    public class FibonacciCalculator
    {
        /// <summary>
        /// Find the fibonacci number that has a digit count of digitCount.
        /// E.g. find the first fibonacci number to contain 1,000 digits.
        /// </summary>
        /// <param name="digitCount"></param>
        /// <returns></returns>
        public BigInteger FindFibonacciToDigitCount(int digitCount)
        {
            BigInteger result = 0;
            BigInteger first = 0;
            BigInteger second = 1;

            var limit = GetBigIntegerOfDigits(digitCount);

            while (result< limit)
                result = ComputeFibonacci(ref first, ref second);
            return result;
        }

        /// <summary>
        /// Find the term of the first fibonacci sequence with
        /// x digits.
        /// </summary>
        /// <param name="digitCount"></param>
        /// <returns></returns>
        public int FibonnaciTermToDigitCount(int digitCount)
        {
            // find the term using the formula
            // (n)*Phi=(n+1)
            // where Phi is the Golden Ratio: (1 + sqrt(5))/2
            //
            // and ceil((L-1 + log10(5)/2) / log10(phi))
            //... whatever. it works.
            var phi = (1 + Math.Sqrt(5))/2;
            int fibonacciTerm = (int)Math.Ceiling((digitCount - 1 + Math.Log10(5)/2)/Math.Log10(phi));
            return fibonacciTerm;
        }

        public BigInteger ComputeFibonacci(ref BigInteger first, ref BigInteger second)
        {
            var result = first + second;
            first = second;
            second = result;
            return result;
        }

        /// <summary>
        /// creates a big integer of the smallest number of x digits.
        /// E.g. 4 digits is 1,000.
        /// </summary>
        /// <param name="digitCount"></param>
        /// <returns></returns>
        public BigInteger GetBigIntegerOfDigits(int digitCount)
        {
            return BigInteger.Pow(10, digitCount - 1);
        }
    }
}
