using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Numbers
{
    public class FactorialHelper
    {
        private static DigitHelper _digitHelper;
        private Dictionary<int, int> _factorials; 

        private static DigitHelper DigitHelper
        {
            get { return _digitHelper ?? (_digitHelper = new DigitHelper()); }
        }

        private Dictionary<int, int> Factorials
        {
            get { return _factorials ?? (_factorials = InitializeFactorials()); }
        }

        private Dictionary<int, int> InitializeFactorials()
        {
            var factorials = new Dictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                factorials[i] = SolveForFactorial(i);
            }
            return factorials;
        }

        private int SolveForFactorial(int number)
        {
            int sum = 1;
            for (int i = 2; i < number + 1; i++)
                sum *= i;
            return sum;
        }

        /// <summary>
        /// Returns the factorial of a number, or the 
        /// multipliaction of all numbers from itself
        /// down to one. 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int GetFactorial(int number)
        {
            if (number < 10)
                return Factorials[number];

            return SolveForFactorial(number);
        }

        /// <summary>
        /// Determines equality between a number and the sum
        /// of the factorials of each of its digits.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool NumberEqualsSumOfDigitFactorials(int number)
        {
            var split = DigitHelper.SplitDigits(number);
            int sum = split.Sum(num => GetFactorial(num));
            return sum == number;
        }
    }
}
