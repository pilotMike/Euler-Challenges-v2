using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using Combinatorics.Collections;

namespace EulerTools.Numbers
{
    public class Pandigital
    {
private const int DigitLength = 9;

        public bool IsPandigital(int multiplicand, int multiplier, int product)
        {
            var concat = DigitHelper.Concat(DigitHelper.Concat(multiplicand, multiplier), product);
            return IsPandigital(concat);
        }

        /// <summary>
        /// Returns whether the number
        /// contains 1-9 exactly once and is 9 digits long.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsPandigital(int number)
        {
            // create 10 booleans to represent 0-9.
            // for each digit, set the index of that digit
            // to true. If any are false, then it is not pandigital.
            // 0 is set to true because it is not included.

            // first, check to see if we have 9 digits.
            if (DigitHelper.DigitCount(number) != DigitLength) return false;

            int temp = number;
            bool[] nums = new bool[10];
            nums[0] = true;

            while (temp > 0)
            {
                int n = temp%10; // get the next digit
                nums[n] = true;
                temp /= 10; // so we can grab the next digit next time
            }

            return nums.All(n => n);
        }

        /// <summary>
        /// Returns whether a number is pandigital to its own digit count,
        /// such that 2143 is pandigital to 4 digits.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsPandigitalToOwnDigitCount(int number)
        {
            int digitCount = DigitHelper.DigitCount(number);
            bool[] nums = new bool[digitCount + 1];
            nums[0] = true;
            int temp = number;

            
            while (temp > 0)
            {
                int n = temp%10;
                if (n > digitCount) return false; // it can't be pandigital is you have a 6 in a 5 digit number.
                nums[n] = true;
                temp /= 10;
            }

            return nums.All(n => n);
        }

        /// <summary>
        /// Returns all 10 digit pandigital numbers. Filters numbers that start with 0.
        /// </summary>
        public IEnumerable<long> GetPandigitalNumbers()
        {
            var numbers = Enumerable.Range(0, 10).ToList();

            var perms = new Permutations<int>(numbers, GenerateOption.WithoutRepetition).AsParallel()
                .Where(list => list[0] != 0)
                .Select(DigitHelper.ConvertToNumber);
            return perms;
        }

    }

    public class OnlinePandigital
    {
        // source: http://www.mathblog.dk/project-euler-32-pandigital-products/

        public bool IsPandigital(int a, int b)
        {
            long concatted = concat(concat(a*b, b), a);
            return IsPandigital(concatted);
        }

        // use bitshifting to check if pandigital
        public bool IsPandigital(long n)
        {
            // source notes
            //It takes a while (at least for me) to digest this pieces of code.
            //On line 8 I chop off the last digit of the number we want to check,
            //and make a bit shift to get the right bit changed to one. The reason 
            //I or the storage integer and bitshifted one is to be able to check if 
            //the digit already has been found. In line 9-11 I check if the number 
            //has changed – if not we have two of the same digits or a zero in the 
            //input number, in either case the number isn’t pandigital.
            int digits = 0;
            int count = 0;
            int tmp;

            while (n > 0)
            {
                tmp = digits;
                // Michael explanation. << moves the bit in front of it
                // to the left by the number of places on the right, 
                // so 1 << 1 becomes 2, 0..01 becomes 0..10 in binary.
                // what he does is take the remainder of the number in question
                // divided by 10, subtracts 1 and shifts 1 over by that many digits.
                // E.G. if n = 1234, n%10-1 = 4-1 = 3.
                // he shift 1 over 3 places, such that 0..01 becomes 0..1000, or 8.

                // Next, he does a bitwise or operation between the previous number and
                // this one, such that, starting with 0 for digits, digits becomes
                // first:  0..0000
                // second: 0..1000 (second is 8)
                // result in this case should be 0..1000
                
                // he then checks to see if the last number and this number are the same
                //
                // ...I still don't understand how it works.

   /*line 8*/   digits = digits | 1 << (int)((n % 10) - 1);
                if (tmp == digits) // check if the number has changed from the previous
                {
                    return false;
                }

                count++;
                n /= 10;
            }
            return digits == (1 << count) - 1;
        }

        // shifts the furst integer a number of places
        // in order to add the second integer.
        public long concat(long a, long b)
        {
            long c = b;
            while (c > 0)
            {
                a *= 10;
                c /= 10;
            }
            return a + b;
        }
    }
}
