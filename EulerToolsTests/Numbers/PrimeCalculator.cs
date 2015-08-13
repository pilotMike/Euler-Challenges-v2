using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EulerToolsTests.Numbers
{
    public class PrimeCalculator
    {
        private List<int> _primes = new List<int>() { 2, 3 };

        /// <summary>
        /// Returns whether a number is prime. Set addNewPrimes to false
        /// for parallel use.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="addNewPrimes">whether or not to add new found 
        /// primes to the internal collection. Set to false for Parallel operations.</param>
        /// <returns></returns>
        public bool IsPrime(int i, bool addNewPrimes = false)
        {
            if (i > 1 && i < 4) return true;
            if (i == 1) return false;

            // there are 2 methods for finding primes: 
            // checking agains a pre-existing list and calculating.
            // this loop checks against pre-existing primes. If it is
            // not found, then it is calculated.
            if (_primes.Any(p => i%p == 0))
                return false;

            // calculate whether a number is prime by dividing
            // it by numbers from 2 up to its square root. 
            // e.g. for 100, divide up to 10.
            //if (!CalculatePrime(i)) return false;
            int limit = (int)Math.Sqrt(i) + 1;
            for (int j = 2; j < limit; j++)
                if (i % j == 0)
                    return false;

            if (addNewPrimes)
                _primes.Add(i);
            return true;
        }

        private static List<int> _primesList = new List<int>(5) {2,3}; 
        public static bool IsPrimeNew(int i)
        {
            if (i == 1) return false;
            // 4.105 sec with for loop
            // 4.833 sec with foreach
            // 10.8  sec with .any
            for (int p = 0; p < _primesList.Count; p++)
            {
                if (i% _primesList[p] == 0)
                    return false;
            }
            // pick up brute force where last prime leaves off
            int start = _primesList[_primesList.Count - 1];
            int limit = (int) Math.Sqrt(i) + 1;
            for (int j = start; j < limit; j++)
                if (i%j == 0)
                    return false;
            _primesList.Add(i);
            return true;
        }

        public bool IsPrimeBrute(int i)
        {
            if (i == 1) return false;
            int limit = (int)Math.Sqrt(i) + 1;
            for (int j = 2; j < limit; j++)
                if (i % j == 0)
                    return false;
            return true;
        }

        public static bool IsPrimeBruteStatic(int i)
        {
            if (i == 1) return false;
            int limit = (int)Math.Sqrt(i) + 1;
            for (int j = 2; j < limit; j++)
                if (i % j == 0)
                    return false;
            return true;
        }

        private BlockingCollection<int> _primeBlockingCollection = new BlockingCollection<int>() {2,3}; 
        public bool IsPrimeParallel(int i)
        {
            if (i == 1) return false;
            //if (i == 2 || i == 3) return true;

            int limit = (int)Math.Sqrt(i) + 1;
            bool isPrime = false;
            Parallel.For(5, limit, (j, loopState) =>
            {
                if (i%j == 0)
                {
                    loopState.Stop();
                    isPrime = true;
                }
            });
            return isPrime;
        }

        public bool IsPrimeParallel_StorePrimes(int i)
        {
            if (i == 1) return false;
            if (i == 2 || i == 3) return true;

            if (_primeBlockingCollection.Any(p => i%p == 0)) return true;
            
            int limit = (int)Math.Sqrt(i) + 1;
            bool isPrime = false;
            Parallel.For(5, limit, (j, loopState) =>
            {
                if (i % j == 0)
                {
                    loopState.Stop();
                    isPrime = true;
                }
            });
            if (isPrime) _primeBlockingCollection.Add(i);
            return isPrime;
        }

        /// <summary>
        /// Returns all of the prime numbers from
        /// 0 up to and including the limit.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<int> GetPrimesUpTo(int limit)
        {
            var primes = new List<int> { 2, 3 };
            for (int i = 5; i <= limit; i++)
                if (IsPrime(i, true))
                    primes.Add(i);
            return primes;
        }

        /// <summary>
        /// Get a list of prime numbers excluding the limit in parallel
        /// using a blocking collection.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<int> GetPrimesUpToParallel(int limit)
        {
            var blockingCollection = new BlockingCollection<int>() { 2, 3 };
            Parallel.For(5, limit, (i) =>
            {
                if (blockingCollection.All(p => i % p != 0) &&
                    CalculatePrime(i))
                    blockingCollection.Add(i);
            });
            return blockingCollection;
        }

        private static bool CalculatePrime(int i)
        {
            int limit = (int) Math.Sqrt(i) + 1;
            for (int j = 2; j < limit; j++)
                if (i%j == 0)
                    return false;
            return true;
        }
    }
}
