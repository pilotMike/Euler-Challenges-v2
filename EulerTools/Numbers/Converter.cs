using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Numbers
{
    public class Converter
    {
        /// <summary>
        /// Returns a string representation of a base 10 number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string ToBinaryString(int number)
        {
            return Convert.ToString(number, 2);
        }
    }
}
