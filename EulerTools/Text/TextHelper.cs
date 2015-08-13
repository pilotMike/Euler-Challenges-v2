using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Text
{
    public class TextHelper
    {
        /// <summary>
        /// Get the total value of the string. Pass in the upper case.
        /// Such that SKY is 19 + 11 + 25 = 55.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int GetNumberValue(string text)
        {
            return text.Sum(c => c - 64);
        }
    }
}
