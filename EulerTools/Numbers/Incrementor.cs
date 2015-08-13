using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Numbers
{
    public class Incrementor
    {
        /// <summary>
        /// Increments a number up to the limit, then returns to 0. 
        /// If you want to increment up to 10, set 9 as the limit.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int Increment(int original, int limit)
        {
            if (original > limit) throw new ArgumentOutOfRangeException("original", "The original value is greater than the limit.");
            if (original == limit) return 0;
            return ++original;
        }
    }
}
