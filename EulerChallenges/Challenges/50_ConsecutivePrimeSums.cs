using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;
using EulerTools.Enumerators;
using System.Reactive.Linq;
using MoreLinq;

namespace EulerChallenges.Challenges
{
    public class _50_ConsecutivePrimeSums : IChallenge<int>
    {
        private readonly int _p;

        public _50_ConsecutivePrimeSums()
        {
            _p = 1000000;
        }
        /// <param name="p">find primes under this number</param>
        public _50_ConsecutivePrimeSums(int p)
        {
            this._p = p;
        }

        public int Run()
        {
            var primes = new PrimeEnumerator().TakeWhile(p => p < _p).ToList();
            var query = primes.AsParallel().Select(
                prime =>
                    new {Prime = prime, Count = GetLengthsThatAddToP(prime, primes.Where(p => p < prime/2).ToList())})
                .Where(t => t.Count != 0)
                .OrderByDescending(t => t.Count);

            var result = query.First().Prime;
            return result;
        }

        private int GetLengthsThatAddToP(int prime, List<int> primes)
        {
            var r = SumWhileLength(primes, prime);
            return r;
        }

        /// <param name="cache">dictionary of the prime, Tuple<count, list of primes></param>
        private int GetLengthsCached(ConcurrentDictionary<int, Tuple<int, List<int>>> cache, int targetPrime)
        {
            var half = targetPrime/2;
            var startFrom = cache
                .Where(pair => pair.Key <= half)
                .DefaultIfEmpty(new KeyValuePair<int, Tuple<int, List<int>>>(0, Tuple.Create(0, new List<int>())))
                .MaxBy(pair => pair.Key);
            var primes = new PrimeEnumerator(startFrom.Value.Item1).TakeWhile(p => p <= half);
            var newPrimes = SumWhile(startFrom.Key, targetPrime, startFrom.Value.Item2, primes);

            var newList = startFrom.Value.Item2.Concat(newPrimes.Item2).ToList();

            if (newPrimes.Item1 == 0) return 0;
            cache[targetPrime] = Tuple.Create(targetPrime, newList);
            return newList.Count;
        }

        /// <returns>tuple<count, added primes to make target></returns>
        private Tuple<int, List<int>> SumWhile(int seed, int targetPrime, List<int> currentPrimes, IEnumerable<int> newPrimes )
        {
            int count = 0;
            int acc = seed;
            int indexToRemove = 0;
            List<int> containedPrimes = new List<int>();

            foreach (var prime in newPrimes)
            {
                if (acc < targetPrime)
                {
                    acc += prime;
                    count++;
                    containedPrimes.Add(prime);
                }
                if (acc == targetPrime) return Tuple.Create(count, containedPrimes);
                // if we've gone over the target prime, start decrementing from the smallest primes we've added
                // to see if we'll hit it again. This makes the <1000 test pass.
                if (acc > targetPrime)
                {
                    acc -= currentPrimes[indexToRemove];
                    indexToRemove++;
                    count--;
                    containedPrimes.Remove(currentPrimes[indexToRemove]);
                }
            }
            return Tuple.Create(0, containedPrimes);
        }

        private Tuple<int, List<int>> SumWhileLengthWithList(List<int> primes, int limit)
        {
            int count = 0;
            int acc = 0;
            int indexToRemove = 0;
            List<int> containedPrimes = new List<int>(primes.Count);
            foreach (var prime in primes)
            {
                if (acc < limit)
                {
                    acc += prime;
                    count++;
                    containedPrimes.Add(prime);
                }

                if (acc == limit) return Tuple.Create(count, containedPrimes);
                // if we've gone over the target prime, start decrementing from the smallest primes we've added
                // to see if we'll hit it again. This makes the <1000 test pass.
                if (acc > limit)
                {
                    acc -= primes[indexToRemove];
                    indexToRemove++;
                    count--;
                    containedPrimes.Remove(primes[indexToRemove]);
                }
            }
            return Tuple.Create(count, containedPrimes);
        }

        private int SumWhileLength(List<int> primes, int limit)
        {
            int count = 0;
            int acc = 0;
            int indexToRemove = 0;
            foreach (var prime in primes)
            {
                if (acc < limit)
                {
                    acc += prime;
                    count++;
                }

                if (acc == limit) return count;
                // if we've gone over the target prime, start decrementing from the smallest primes we've added
                // to see if we'll hit it again. This makes the <1000 test pass.
                if (acc > limit)
                {
                    acc -= primes[indexToRemove];
                    indexToRemove++;
                    count--;
                }
            }
            return count;
        }
    }

    public static class Extensions
    {
        public static int SumWhile(this IEnumerable<int> source, Predicate<int> pred)
        {
            int acc = 0;
            foreach (var i in source)
            {
                if (pred(acc)) acc += i;
                else return acc;
            }
            return acc;
        }
    }
}
