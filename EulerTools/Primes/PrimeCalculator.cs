using System;
using System.Collections.Generic;
using System.Linq;
using EulerTools.Enumerators;

namespace EulerTools.Primes
{
    public class PrimeCalculator
    {
        public static bool IsPrime(int i)
        {
            if (i == 1) return false;
            int limit = (int)Math.Sqrt(i) + 1;
            for (int j = 2; j < limit; j++)
                if (i % j == 0)
                    return false;
            return true;
        }

        private static List<int> _primes = new List<int>() {2,3};
        private static PrimeEnumerator _pEnumerator = new PrimeEnumerator();
        private IEnumerator<int> _pEnum = new PrimeEnumerator().GetEnumerator();

        public bool IsPrimeCached(int i)
        {
            if (i == 1) return false;

            int limit = (int)Math.Sqrt(i) + 1;

            for (int j = 0; j < _primes.Count && j < limit; j++)
                if (i % _primes[j] == 0)
                    return false;

            

            _pEnum.MoveNext();
            var nextPrime = _pEnum.Current;
            _primes.Add(nextPrime);

            while (i > nextPrime && nextPrime < limit)
            {
                if (i%nextPrime == 0)
                    return false;
                _pEnum.MoveNext();
                nextPrime = _pEnum.Current;
                _primes.Add(nextPrime);
            }
            
            
            ////int limit = (int)Math.Sqrt(i) + 1;
            //for (int j = _primes[_primes.Count - 1]; j < limit; j++)
            //    if (i % j == 0)
            //        return false;

            //_primes.Add(i);
            return true;
        }
        
        /// <summary>
        /// Returns all of the prime numbers from
        /// 0 up to and including the limit.
        /// Note that there is also the prime enumerator, which may be
        /// faster by delayed execution.
        /// </summary>
        public List<int> GetPrimesUpTo(int limit)
        {
            var primes = new List<int> { 2, 3 };
            for (int i = 5; i <= limit; i++)
                if (IsPrime(i))
                    primes.Add(i);
            return primes;
        }
    }
}
