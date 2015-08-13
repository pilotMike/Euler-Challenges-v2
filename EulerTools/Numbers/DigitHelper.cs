using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Numbers
{
    public class DigitHelper
    {
        /// <summary>
        /// Returns the number in a digit at a particular index position,
        /// starting with 0 and from the right.
        /// </summary>
        /// <param name="number">One's place is zero</param>
        /// <param name="position"></param>
        /// <example>
        /// <code>
        /// int number = 1234;
        /// int position = 0;
        /// int result = GetDigit(number, digit);
        /// result = 4
        /// </code>
        /// </example>
        public int GetDigit(long number, int position)
        {
            // example: number = 1234, position = 2
            // parsenumber /= (int)Math.Pow(10,2)
            // parsenumber = 12
            // result = parseNumber%10
            // result = 2

            var parseNumber = number;
            // reduce the number so that the starting digit is in the first position
            parseNumber /= (int)Math.Pow(10,position); 
            int result = (int)parseNumber%10;
            return result;
        }

        /// <summary>
        /// Returns a collection of each digit separately.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<int> SplitDigits(int number)
        {
            if (number < 10) return new[] {number};
            int length = DigitCount(number);
            int[] digits = new int[length];
            int parseNu = number;
            for (int i = 0; i < length; i++)
            {
                digits[length - i - 1] = parseNu%10;
                parseNu /= 10;
            }
            return digits;
        }

        /// <summary>
        /// Returns a subdigit of the number passed. E.g.
        /// 123456, subdigit starting at 1 and taking 2 
        /// results in 23.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="startIndex">from the left</param>
        /// <param name="takeCount"></param>
        public int SubDigit(long number, int startIndex, int takeCount)
        {
            int digitPlaces = DigitCount(number) - 1;
            int output = GetDigit(number, digitPlaces - startIndex);
            for (int i = 1; i < takeCount; i++)
            {
                checked
                {
                    output *= 10;
                    output += GetDigit(number, digitPlaces - startIndex - i);
                }
                
            }
            return output;
        }

        /// <summary>
        /// Receives an IList of integers and puts them into a number, e.g. {1,2,3}
        /// becomes 123 as an int.
        /// </summary>
        public long ConvertToNumber(IList<int> ints)
        {
            long output = ints[0];
            for (int i = 1; i < ints.Count; i++)
            {
                checked
                {
                    output *= 10;
                    output += ints[i];
                }
            }
            return output;
        }

        /// <summary>
        /// Creates an integer by appending
        /// b to a, such that a = 1, b = 2
        /// results in 12.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Concat(int a, int b)
        {
            int bCount = DigitCount(b);
            int result = a*(int) Math.Pow(10, bCount) + b;
            return result;
        }

        // so far, not needed. 1/9/2015.
        ///// <summary>
        ///// Creates a long by appending
        ///// b to a, such that a = 1, b = 2
        ///// results in 12.
        ///// </summary>
        ///// <param name="a"></param>
        ///// <param name="b"></param>
        ///// <returns></returns>
        //public long Concat(long a, int b)
        //{
        //    int bCount = DigitCount(b);
        //    long result = a * (long) Math.Pow(10, bCount) + b;
        //    return result;
        //}

        /// <summary>
        /// Returns the number of digits in a number. 
        /// e.g. 1,000 = 4
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int DigitCount(long number)
        {
            if (number == 0) return 1;
            //if (number < 10) return 1; // the method below doesn't work for single digit numbers.
            //if (number == 10) return 2;
            return (int) Math.Floor(Math.Log10(number) + 1);
        }

        /// <summary>
        /// Returns all rotations of the digit, including itself.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<int> RotateDigits(int number)
        {
            var numbers = new List<int> {number};
            int digitCount = DigitCount(number);

            int current = number;
            for (int i = 0; i < digitCount; i++)
            {
                current = RotateNumber(current);
                numbers.Add(current);
            }
            return numbers;
        }

        /// <summary>
        /// Takes the leftmost digit and moves it to the right most side. 
        /// 197 -> 971
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        //public int RotateNumber(int number)
        //{
        //    string num = number.ToString();
        //    string output = num.Substring(1) + num[0];
        //    return int.Parse(output);
        //}

        // This method is >2x faster than the string manipulation method.
        /// <summary>
        /// Takes the leftmost digit and moves it to the right most side. 
        /// 197 -> 971
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int RotateNumber(int number)
        {
            if (number < 10) return number;
            int dCount = DigitCount(number);
            int leftMost = GetDigit(number, dCount - 1);
            int remaining = RemoveLeftMostDigit(number);
            remaining = remaining * 10 + leftMost;
            return remaining;
        }

        /// <summary>
        /// Takes the leftmost character and moves it to the back of the string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string RotateNumber(string text)
        {
            return text.Substring(1) + text[0];
        }

        /// <summary>
        /// Removes the left-most digit of a positive number, such that
        /// 1234 becomes 234.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int RemoveLeftMostDigit(int num)
        {
            if (num < 10)
                return num;
            int digitCount = DigitCount(num);
            return (int)(num % (Math.Pow(10, digitCount - 1)));
        }
    }
}
