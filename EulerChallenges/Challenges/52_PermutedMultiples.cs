using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;
using EulerTools.Enumerators;
using EulerTools.Numbers;

namespace EulerChallenges.Challenges
{
    public class _52_PermutedMultiples : IChallenge<int>
    {
        public int Run()
        {
            var result = from n in new InfiniteNumberEnumerator()
                         let mults = Enumerable.Range(2, 5).Select(e => n * e)
                         where mults.All(m => DigitHelper.ArePermutations(m, n))
                         select n;
            return result.First();
        }
    }
}
