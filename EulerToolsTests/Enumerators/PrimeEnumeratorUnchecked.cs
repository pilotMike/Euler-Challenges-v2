using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Primes;

namespace EulerToolsTests.Enumerators
{
    public class PrimeEnumeratorUnchecked : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            int x = 1;
            while (true)
            {
                x++;
                if (PrimeCalculator.IsPrime(x))
                    yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
