using EulerTools.Enumerators;
using EulerTools.Numbers;
using EulerTools.Primes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;

namespace EulerChallenges.Challenges
{
    public class _47_DistinctPrimesFactors : IChallenge<int>
    {
        private readonly int _consec;
        private readonly int _count;

        public _47_DistinctPrimesFactors()
        {
            _count = 4;
            _consec = _count;
        }

        public _47_DistinctPrimesFactors(int numToFind)
        {
            _count = numToFind;
            _consec = numToFind;
        }

        public int Run()
        {
            var e = new InfiniteNumberEnumerator();
            var fHelper = new FactorsHelper();

            var flag = false;
            var found = 0;
            var result = 0;

            foreach (var n in e)
            {
                flag = fHelper.Factors(n).Count(PrimeCalculator.IsPrime) >= _count;
                if (flag) found++;
                else found = 0;
                if (found == _consec)
                {
                    result = n - _consec + 1;
                    break;
                }
            }

            return result;
        }
    }
}
