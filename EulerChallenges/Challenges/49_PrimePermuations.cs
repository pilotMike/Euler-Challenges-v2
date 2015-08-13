using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;
using EulerTools.Enumerators;
using EulerTools.Numbers;
using EulerTools.Primes;
using Facet.Combinatorics;

namespace EulerChallenges.Challenges
{
    public class _49_PrimePermutations : IChallenge<string>
    {
        private int _count;

        public _49_PrimePermutations(int count)
        {
            _count = count;
        }

        public string Run()
        {
            var pe = new PrimeEnumerator();
            var dh = new DigitHelper();

            string result = "";
            var pc = new PrimeCalculator();

            var query = from p in pe.SkipWhile(p => p<1000).TakeWhile(p => p < 10000)
                let digits = dh.SplitDigits(p).ToList()
                let permutations = new Permutations<int>(digits)
                let backToDigits = 
                    from perm in permutations
                    let digit = (int) dh.ConvertToNumber(perm)
                    where digit != p && PrimeCalculator.IsPrime(digit) //pc.IsPrimeCached(digit) //
                    select digit
                select new {p, Permutations = backToDigits};

            var permutationsGreaterThanP = from pair in query
                let perms = from perm in pair.Permutations where perm > pair.p select perm
                where perms.Any()
                select new {pair.p, perms};

            var outputs = from pair in permutationsGreaterThanP
                from perm in pair.perms
                let k = perm + perm - pair.p
                where pair.perms.Contains(k)
                select String.Join("", pair.p, perm, k);

            return outputs.ElementAt(_count);
        }

    }
}
