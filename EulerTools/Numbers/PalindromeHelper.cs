using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Numbers
{
    public class PalindromeHelper
    {
        /// <summary>
        /// Returns whether each digit on one side of
        /// a number is equal to the digit on the opposite side
        /// of the number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsPalindrome(int number)
        {
            string p = number.ToString();
            return IsPalindrome(p);
        }

        /// <summary>
        /// Returns whether each character on one side of
        /// the text is equal to the charactor on the opposite
        /// side of the text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsPalindrome(string text)
        {
            //if (text.Length % 2 != 0)
            //    return false;

            int half = text.Length / 2;
            for (int i = 0; i < half; i++)
                if (!DigitsAreEqual(i, text))
                    return false;
            return true;
        }

        /// <summary>
        /// The character at index i from the left and right
        /// parts of the string are equal.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool DigitsAreEqual(int i, string text)
        {
            return text[i] == text[text.Length - 1 - i];
        }
    }
}
